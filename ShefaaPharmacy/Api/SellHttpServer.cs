using DataLayer;
using DataLayer.Helper;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Helper;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using DataLayer.Enums;
using DataLayer.Services;
using System.Net;
using Newtonsoft.Json.Linq;
using DataLayer.ViewModels;

// offered to the public domain for any use with no restriction
// and also with no warranty of any kind, please enjoy. - David Jeske. 

// simple HTTP explanation
// http://www.jmarshall.com/easy/http/

namespace ShefaaPharmacy.Api
{
    public class HttpProcessor1
    {
        public TcpClient socket;
        public HttpServer1 srv;
        private Stream inputStream;
        public StreamWriter outputStream;
        public Hashtable httpHeaders = new Hashtable();

        public string barcode;
        public string database;
        public int operation;
        public string invoice;
        public string IsMinus;
        public int userid;
        public string http_method;
        public string http_url;
        public string http_protocol_versionstring;

        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        public HttpProcessor1(TcpClient s, HttpServer1 srv)
        {
            socket = s;
            this.srv = srv;
        }
        private string StreamReadLine(Stream inputStream)
        {
            int next_char;
            string data = "";
            while (true)
            {
                next_char = inputStream.ReadByte();
                if (next_char == '\n') { break; }
                if (next_char == '\r') { continue; }
                if (next_char == -1) { Thread.Sleep(1); continue; };
                data += Convert.ToChar(next_char);
            }
            return data;
        }
        public void Process()
        {
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try
            {
                ParseRequest();
                ReadHeaders();
                if (http_method.Equals("GET"))
                {
                    HandleGETRequest();
                }
                else if (http_method.Equals("POST"))
                {
                    HandlePOSTRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                WriteFailure();
            }
            outputStream.Flush();
            inputStream = null; outputStream = null;
            socket.Close();
        }

        public void ParseRequest()
        {
            String request = StreamReadLine(inputStream);
            string[] tokens = request.Split(' ');
            if (tokens.Length != 3)
            {
                throw new Exception("invalid http request line");
            }
            http_method = tokens[0].ToUpper();
            http_url = tokens[1];

            string temp = http_url.Split('?')[1];
            temp = temp.Replace("%20", " ");
            string[] temp1 = new string[1]; string tt;
            if (temp.Contains("&%"))
            {
                temp1 = temp.Split('&');
                temp1[1] += "&"; temp1[1] += temp1[2];
                temp1[2] = temp1[3];
                temp1[3] = temp1[4];
                temp1[4] = temp1[5];
                temp1[5] = null;
            }
            else
            {
                temp1 = temp.Split('&');
            }

            database = temp1[0].Split('=')[1];
            operation = Convert.ToInt32(temp1[2].Split('=')[1]);
            if (operation != 1)
                userid = Convert.ToInt32(temp1[3].Split('=')[1]);

            if (operation == 1)
                barcode = temp1[1].Split('=')[1];
            else
            {
                invoice = Uri.UnescapeDataString(temp1[1].Split('=')[1]);
                IsMinus = temp1[4].Split('=')[1];
            }
            http_protocol_versionstring = tokens[2];
            Console.WriteLine("starting: " + request);
        }

        public void ReadHeaders()
        {
            Console.WriteLine("readHeaders()");
            String line;
            while ((line = StreamReadLine(inputStream)) != null)
            {
                if (line.Equals(""))
                {
                    Console.WriteLine("got headers");
                    return;
                }
                int separator = line.IndexOf(':');
                if (separator == -1)
                {
                    throw new Exception("invalid http header line: " + line);
                }
                String name = line.Substring(0, separator);
                int pos = separator + 1;
                while ((pos < line.Length) && (line[pos] == ' '))
                {
                    pos++; // strip any spaces
                }
                string value = line.Substring(pos, line.Length - pos);
                Console.WriteLine("header: {0}:{1}", name, value);
                httpHeaders[name] = value;
            }
        }
        public void HandleGETRequest()
        {
            srv.handleGETRequest(this, IsMinus);
        }

        private const int BUF_SIZE = 4096;
        public void HandlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            Console.WriteLine("get post data start");
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("Content-Length"))
            {
                int content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
                if (content_len > MAX_POST_SIZE)
                {
                    throw new Exception(
                        String.Format("POST Content-Length({0}) too big for this simple server",
                          content_len));
                }
                byte[] buf = new byte[BUF_SIZE];
                int to_read = content_len;
                while (to_read > 0)
                {
                    Console.WriteLine("starting Read, to_read={0}", to_read);

                    int numread = this.inputStream.Read(buf, 0, Math.Min(BUF_SIZE, to_read));
                    Console.WriteLine("read finished, numread={0}", numread);
                    if (numread == 0)
                    {
                        if (to_read == 0)
                        {
                            break;
                        }
                        else
                        {
                            throw new Exception("client disconnected during post");
                        }
                    }
                    to_read -= numread;
                    ms.Write(buf, 0, numread);
                }
                ms.Seek(0, SeekOrigin.Begin);
            }
            Console.WriteLine("get post data end");
            srv.handlePOSTRequest(this, new StreamReader(ms));
        }

        public void WriteSuccess(string content_type = "text/html")
        {
            outputStream.WriteLine("HTTP/1.0 200 OK");
            outputStream.WriteLine("Content-Type: " + content_type);
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }

        public void WriteFailure()
        {
            outputStream.WriteLine("HTTP/1.0 404 File not found");
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }
    }
    public abstract class HttpServer1
    {
        protected int port;
        TcpListener listener;
        bool is_active = true;

        public HttpServer1(int port)
        {
            this.port = port;
        }

        public void listen()
        {
            try
            {
                listener = new TcpListener(port);
                listener.Start();
                while (is_active)
                {
                    TcpClient s = listener.AcceptTcpClient();
                    HttpProcessor1 processor = new HttpProcessor1(s, this);
                    Thread thread = new Thread(new ThreadStart(processor.Process));
                    thread.Start();
                    Thread.Sleep(1);
                }
            }
            catch
            {

            }
        }

        public abstract void handleGETRequest(HttpProcessor1 p, string IsMinus);

        public abstract void handlePOSTRequest(HttpProcessor1 p, StreamReader inputData);
    }

    public class SellHttpServer : HttpServer1
    {
        BillMaster billMaster = new BillMaster();
        string billNumber;
        InvoiceKind invoiceKind = InvoiceKind.Sell;
        FormOperation FormOperation = FormOperation.New;
        public SellHttpServer(int port) : base(port)
        {
        }
        public void CheckNumbers(ShefaaPharmacyDbContext context)
        {
            billMaster.CalcTotalMobile();
            billMaster.TotalPrice = Convert.ToInt32(DescriptionFK.RoundInMath(billMaster.TotalPrice, context.DataBaseConfigurations.FirstOrDefault().CountNumberAfterComma));
            billMaster.Payment = Convert.ToInt32(DescriptionFK.RoundInMath(billMaster.Payment, context.DataBaseConfigurations.FirstOrDefault().CountNumberAfterComma));
        }
        private bool SaveNewBill(ShefaaPharmacyDbContext context, User usr, string IsMinus)
        {
            if (ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.Any())
                billNumber = (ShefaaPharmacyDbContext.GetCurrentContext().BillMasters.ToList().LastOrDefault().Id + 1).ToString();
            else
                billNumber = "1";
            double billValue = billMaster.TotalPrice;
            BillService billService = new BillService(billMaster);
            bool result = false;
            switch (invoiceKind)
            {
                case InvoiceKind.Sell:
                    if (IsMinus == "true") result = billService.SellInMinusBill();
                    else result = billService.SellBillMobile(context, usr);
                    break;
                default:
                    break;
            }
            if (!result)
            {
                return false;
            }

            Guid GCode = Guid.NewGuid();
            string GUIDCode = GCode.ToString();
            var CurrentTaxAccount = ShefaaPharmacyDbContext.GetCurrentContext().TaxAccount.ToList().FirstOrDefault();
            var thread = new Thread(() =>
            {
                if (AddInvoiveToTaxSystem(billNumber, billValue, GUIDCode))
                {
                    SaveNewTaxReportForInvoice(billNumber, billValue, GUIDCode, CurrentTaxAccount.taxNumber, CurrentTaxAccount.facilityName, true);
                }
                else
                {
                    SaveNewTaxReportForInvoice(billNumber, billValue, GUIDCode, CurrentTaxAccount.taxNumber, CurrentTaxAccount.facilityName, false);
                }
            });
            thread.Start();
            return result;
        }
        private bool AddInvoiveToTaxSystem(string billNumber, double billValue, string GUIDCode)
        {
            try
            {
                string url = String.Format("http://213.178.227.75/Taxapi/api/Bill/AddFullBill");
                WebRequest requestPost = WebRequest.Create(url);
                requestPost.Method = "POST";
                requestPost.ContentType = "application/json";
                requestPost.Headers.Add("Authorization", "Bearer " + ShefaaPharmacyDbContext.GetCurrentContext().TaxAccount.FirstOrDefault().Token);
                TaxReportViewModel newObj = new TaxReportViewModel
                {
                    billValue = billValue,
                    billNumber = billNumber,
                    code = GUIDCode,
                    currency = "SP",
                    exProgram = "ShefaaPharmacy",
                    date = DateTime.Now.Date,
                };

                var postData = JsonConvert.SerializeObject(newObj);
                using (var streamWriter = new StreamWriter(requestPost.GetRequestStream()))
                {
                    streamWriter.Write(postData);
                    streamWriter.Flush();
                    streamWriter.Close();
                }

                var httpResponse = (HttpWebResponse)requestPost.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    int code = (int)httpResponse.StatusCode;
                    var res = streamReader.ReadToEnd();
                    JObject resultJson = (JObject)JsonConvert.DeserializeObject(res);
                    IList<string> keys = resultJson.Properties().Select(p => p.Name).ToList();
                    if (resultJson["data"] != null)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
        private void SaveNewTaxReportForInvoice(string billNumber, double billValue, string randomNumber, string TaxNumber, string FacilityName, bool Istransfered)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            DetailedTaxCode NewTaxInvoice = new DetailedTaxCode
            {
                BillValue = billValue,
                BillNumber = billNumber,
                Currency = "SP",
                FacilityName = FacilityName,
                PosNumber = 10,
                taxNumber = TaxNumber,
                RandomCode = randomNumber,
                DateTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm tt"),
                IsTransfeered = Istransfered,
                InvoiceKind = InvoiceKind.Sell
            };
            context.DetailedTaxCode.Add(NewTaxInvoice);
            context.SaveChanges();
        }
        public override void handleGETRequest(HttpProcessor1 p, string IsMinus)
        {
            try
            {
                billMaster = new BillMaster();
                string temp = ShefaaPharmacyDbContext.ConStr;
                ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection("TM_" + p.database);
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                billMaster.context = context;
                if (p.operation == 1) // 1 mean it's the first request to get articale info from database
                {
                    var articleBarcode = context.Articles.Where(x => x.Barcode == p.barcode).FirstOrDefault();
                    if (articleBarcode != null)
                    {
                        //this is neccessary for sending json data in c#
                        JsonSerializerSettings settings = new JsonSerializerSettings
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                            Formatting = Formatting.Indented
                        };
                        articleBarcode.PriceTagMasters = context.PriceTagMasters
                                .Where(x => x.ArticleId == articleBarcode.Id)
                                .Include(x => x.PriceTagDetails)
                                .OrderBy(x => x.ExpiryDate)
                                .ToList();
                        articleBarcode.ArticleUnits = context.ArticleUnits.Where(x => x.ArticleId == articleBarcode.Id).ToList();
                        var sample = new InvoiceModelToMobile()
                        {
                            articale = articleBarcode,
                            AccountsArray = context.Accounts.Where(x => x.CategoryId == ConstantDataBase.AC_Customer).ToList()
                        };
                        string response = JsonConvert.SerializeObject(sample, settings);
                        p.WriteSuccess();
                        p.outputStream.WriteLine(response);
                        ShefaaPharmacyDbContext.ConStr = temp;
                    }
                    else
                    {
                        p.WriteFailure();
                        p.outputStream.WriteLine("fail");
                    }
                }
                else // it's mean that the request is to make sell invoice
                {
                    string resp = p.invoice;
                    List<Dictionary<String, String>> list = new List<Dictionary<string, string>>();
                    billMaster.InvoiceKind = invoiceKind;
                    list = JsonConvert.DeserializeObject<List<Dictionary<String, String>>>(resp);
                    List<BillDetail> mybilld = new List<BillDetail>();
                    billMaster.IsReturned = false;
                    billMaster.YearId = YearService.GetAvailableYearMobile(context);
                    billMaster.AccountId = 11;
                    int userId = 0;

                    foreach (var item in list)
                    {
                        BillDetail detail = new BillDetail(billMaster);
                        detail.context = context;
                        detail.Barcode = item["barcode"];
                        billMaster.PaymentMethod = item["method"] == "Cash" ? PaymentMethod.Cash : PaymentMethod.Debit;
                        billMaster.StoreId = Convert.ToInt32(item["storeId"]);
                        billMaster.BranchId = Convert.ToInt32(item["branchId"]);
                        billMaster.discount = Convert.ToDouble(item["totalDiscount"]);
                        detail.InvoiceKind = InvoiceKind.Sell;
                        detail.ArticaleId = Convert.ToInt32(item["artId"]);
                        detail.UnitTypeId = Convert.ToInt32(item["unitId"]);
                        detail.Quantity = Convert.ToInt32(item["quantity"]);
                        detail.Price = Convert.ToDouble(item["price"]);
                        detail.Discount = Convert.ToDouble(item["discount"]);
                        detail.PriceTagId = Convert.ToInt32(item["priceTagId"]);
                        detail.UnitTypeIdBasic = Convert.ToInt32(item["basicUnitId"]);
                        detail.QuantityGift = Convert.ToInt32(item["gift"]);
                        billMaster.payment = Convert.ToInt32(item["paid"]);
                        detail.TotalPrice = Convert.ToDouble(item["totalPrice"]);
                        userId = Convert.ToInt32(item["userId"]);
                        billMaster.TotalItem = Convert.ToInt32(item["quantityForAll"]);
                        billMaster.CreationBy = userId;
                        billMaster.RemainingAmount = Convert.ToDouble(item["remainPrice"]);
                        if (billMaster.paymentMethod == PaymentMethod.Debit)
                        {
                            billMaster.AccountId = Convert.ToInt32(item["accountId"]);
                            if (billMaster.AccountId == 0) billMaster.AccountId = 11;
                        }
                        mybilld.Add(detail);
                    }
                    billMaster.BillDetails = mybilld;
                    CheckNumbers(context);
                    User tmp = context.Users.Where(x => x.Id == userId).FirstOrDefault();
                    tmp.UserPermissions = context.UserPermissions.Where(x => (x.UserId == tmp.Id)).FirstOrDefault();
                    if (tmp.Position == Position.admin)
                        billMaster.CreationByDescr = "admin";
                    else
                        billMaster.CreationByDescr = "manager";
                    bool res;
                    if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                    {
                        res = SaveNewBill(context, tmp, IsMinus);
                        if (res)
                        {
                            p.WriteSuccess();
                        }
                        else
                        {
                            p.WriteFailure();
                        }
                    }
                }
                ShefaaPharmacyDbContext.ConStr = temp;
            }
            catch (Exception)
            {
                p.WriteFailure();
            }
        }
        public override void handlePOSTRequest(HttpProcessor1 p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();

            p.WriteSuccess();
            p.outputStream.WriteLine("<html><body><h1>test server</h1>");
            p.outputStream.WriteLine("<a href=/test>return</a><p>");
            p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);
            ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection("TM_" + p.database);
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            BillDetail ID = new BillDetail();
            if (ID.AddArticleByMobile(context, p.barcode) != null)
            {
                Article barcode = ID.AddArticleByMobile(context, p.barcode);
                string response = JsonConvert.SerializeObject(barcode);
                p.WriteSuccess();
                p.outputStream.WriteLine(response);
            }
            else
            {
                p.WriteSuccess();
                p.outputStream.WriteLine("fail");
            }
        }
    }
}




