using DataLayer;
using DataLayer.Helper;
using DataLayer.Tables;
using DataLayer.ViewModels;
using DataLayer.Services;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Helper;
using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ShefaaPharmacy.GeneralUI;
using System.Collections.Generic;
using Newtonsoft.Json;
using DataLayer.Enums;
using System.Web;
using System.Text;
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
        public string barcode;
        public string database;
        public int operation;
        public string invoice;
        public int userid;
        public string http_method;
        public string http_url;
        public string http_protocol_versionstring;
        public Hashtable httpHeaders = new Hashtable();

        private static int MAX_POST_SIZE = 10 * 1024 * 1024; // 10MB

        public HttpProcessor1(TcpClient s, HttpServer1 srv)
        {
            socket = s;
            this.srv = srv;
        }

        private string streamReadLine(Stream inputStream)
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
        public void process()
        {
            // we can't use a StreamReader for input, because it buffers up extra data on us inside it's
            // "processed" view of the world, and we want the data raw after the headers
            inputStream = new BufferedStream(socket.GetStream());

            // we probably shouldn't be using a streamwriter for all output from handlers either
            outputStream = new StreamWriter(new BufferedStream(socket.GetStream()));
            try
            {
                parseRequest();
                readHeaders();
                if (http_method.Equals("GET"))
                {
                    handleGETRequest();
                }
                else if (http_method.Equals("POST"))
                {
                    handlePOSTRequest();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.ToString());
                writeFailure();
            }
            outputStream.Flush();
            // bs.Flush(); // flush any remaining output
            inputStream = null; outputStream = null; // bs = null;            
            socket.Close();
        }

        public void parseRequest()
        {
            String request = streamReadLine(inputStream);

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
                temp1[4] = null;
            }
            else
            {
                temp1 = temp.Split('&');
            }

            database = temp1[0].Split('=')[1];
            operation = Convert.ToInt32(temp1[2].Split('=')[1]);
            if (operation != 1)
                userid = Convert.ToInt32(temp1[3].Split('=')[1]);
            //Console.WriteLine(database);
            if (operation == 1)
                barcode = temp1[1].Split('=')[1];
            else
                invoice = Uri.UnescapeDataString(temp1[1].Split('=')[1]);

            //param = http_url.Split('=')[1].ToString();
            http_protocol_versionstring = tokens[2];

            Console.WriteLine("starting: " + request);
        }

        public void readHeaders()
        {
            Console.WriteLine("readHeaders()");
            String line;
            while ((line = streamReadLine(inputStream)) != null)
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

        public void handleGETRequest()
        {
            srv.handleGETRequest(this);
        }

        private const int BUF_SIZE = 4096;
        public void handlePOSTRequest()
        {
            // this post data processing just reads everything into a memory stream.
            // this is fine for smallish things, but for large stuff we should really
            // hand an input stream to the request processor. However, the input stream 
            // we hand him needs to let him see the "end of the stream" at this content 
            // length, because otherwise he won't know when he's seen it all! 

            Console.WriteLine("get post data start");
            int content_len = 0;
            MemoryStream ms = new MemoryStream();
            if (this.httpHeaders.ContainsKey("Content-Length"))
            {
                content_len = Convert.ToInt32(this.httpHeaders["Content-Length"]);
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

        public void writeSuccess(string content_type = "text/html")
        {
            outputStream.WriteLine("HTTP/1.0 200 OK");
            outputStream.WriteLine("Content-Type: " + content_type);
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }

        public void writeFailure()
        {
            outputStream.WriteLine("HTTP/1.0 404 File not found");
            outputStream.WriteLine("Connection: close");
            outputStream.WriteLine("");
        }
    }
    //[JsonObject(IsReference = true)]
    public abstract class HttpServer1
    {
        BillMaster billmaster;
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
                    Thread thread = new Thread(new ThreadStart(processor.process));
                    thread.Start();
                    Thread.Sleep(1);
                }
            }
            catch
            {

            }

        }

        public abstract void handleGETRequest(HttpProcessor1 p);

        public abstract void handlePOSTRequest(HttpProcessor1 p, StreamReader inputData);
    }

    public class BuyHttpServer : HttpServer1
    {
        BillMaster billMaster = new BillMaster();
        InvoiceKind invoiceKind = InvoiceKind.Sell;
        FormOperation FormOperation = FormOperation.New;
        public BuyHttpServer(int port)
            : base(port)
        {
        }
        public void CheckNumbers(ShefaaPharmacyDbContext context)
        {
            billMaster.CalcTotalMobile();
            billMaster.TotalPrice = Convert.ToInt32(DescriptionFK.RoundInMath(billMaster.TotalPrice, context.DataBaseConfigurations.FirstOrDefault().CountNumberAfterComma));
            billMaster.Payment = Convert.ToInt32(DescriptionFK.RoundInMath(billMaster.Payment, context.DataBaseConfigurations.FirstOrDefault().CountNumberAfterComma));
        }


        private bool SaveNewBill(ShefaaPharmacyDbContext context, User usr)
        {
            BillService billService = new BillService(billMaster);
            bool result = false;
            switch (invoiceKind)
            {
                case InvoiceKind.Sell:
                    result = billService.SellBillMobile(context, usr);
                    //LastThreeOperation();
                    break;
                case InvoiceKind.Buy:
                    result = billService.BuyBill();
                    //LastThreeOperation();
                    break;
                case InvoiceKind.ReturnSell:
                    result = billService.ReturnBill(InvoiceKind.ReturnSell);
                    //LastThreeOperation();
                    break;
                case InvoiceKind.ExpiryArticles:
                    result = billService.DestructionBill();
                    break;
                default:
                    break;
            }
            if (!result)
            {
                // _MessageBoxDialog.Show("حصل خطأ أثناء تخزين الفاتورة", MessageBoxState.Error);
                return false;
            }
            return result;
        }
        public override void handleGETRequest(HttpProcessor1 p)
        {
            try
            {
                billMaster = new BillMaster();
                string temp = ShefaaPharmacyDbContext.ConStr;
                ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection("TM_" + p.database);
                //var query = "SET IDENTITY_INSERT dbo.BillMaster ON; INSERT INTO dbo.BillMaster (IdentityColumn) VALUES (@identityColumnValue); SET IDENTITY_INSERT dbo.BillMaster ON;";
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
                billMaster.context = context;
                //System.Diagnostics.Debugger.Break
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
                        };//context.PriceTagMasters.Where(x => x.ArticleId == articleBarcode.Id && x.CountAllItem==0 && x.CountSoldItem==0).ToList();
                        articleBarcode.PriceTagMasters = context.PriceTagMasters
                                .Where(x => x.ArticleId == articleBarcode.Id && ((x.CountAllItem + x.CountGiftItem) - x.CountSoldItem) != 0)
                                .Include(x => x.PriceTagDetails)
                                .OrderBy(x => x.ExpiryDate)
                                .ToList(); /*DescriptionFK.GetOldestExpiryDate(articleBarcode.Id);*/
                        //var countleft = Int32.Parse(articleBarcode.CountLeft);
                        //articleBarcode.CountLeft = countleft.ToString();
                        articleBarcode.ArticleUnits = context.ArticleUnits.Where(x => x.ArticleId == articleBarcode.Id).ToList();
                        var sample = new InvoiceModelToMobile()
                        {
                            articale = articleBarcode,
                            AccountsArray = context.Accounts.Where(x => x.CategoryId == ConstantDataBase.AC_Customer).ToList()
                        };
                        string response = JsonConvert.SerializeObject(sample, settings);
                        p.writeSuccess();
                        p.outputStream.WriteLine(response);
                        ShefaaPharmacyDbContext.ConStr = temp;
                    }
                    else
                    {
                        p.writeFailure();
                        p.outputStream.WriteLine("fail");
                    }
                }
                else
                {
                    string resp = p.invoice;
                    List<Dictionary<String, String>> list = new List<Dictionary<string, string>>();
                    billMaster.InvoiceKind = invoiceKind;
                    list = JsonConvert.DeserializeObject<List<Dictionary<String, String>>>(resp);
                    List<BillDetail> mybilld = new List<BillDetail>();
                    billMaster.IsReturned = false;
                    billMaster.YearId = YearService.GetAvailableYearMobile(context);
                    billMaster.AccountId = 11;
                    //billMaster.CreatedBy
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
                        //detail.TotalPrice = item["totalPrice"];
                        //detail.UnitTypeIdDescr
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
                        res = SaveNewBill(context, tmp);
                        if (res)
                        {
                            p.writeSuccess();
                            // _MessageBoxDialog.Show("تم حفظ الفاتورة", MessageBoxState.Done);
                        }
                        else
                        {
                            p.writeFailure();
                        }
                    }
                }
                ShefaaPharmacyDbContext.ConStr = temp;

            }
            catch (Exception e)
            {
                p.writeFailure();
            }
        }

        public override void handlePOSTRequest(HttpProcessor1 p, StreamReader inputData)
        {
            Console.WriteLine("POST request: {0}", p.http_url);
            string data = inputData.ReadToEnd();

            p.writeSuccess();
            p.outputStream.WriteLine("<html><body><h1>test server</h1>");
            p.outputStream.WriteLine("<a href=/test>return</a><p>");
            p.outputStream.WriteLine("postbody: <pre>{0}</pre>", data);

            string temp = ShefaaPharmacyDbContext.ConStr;
            ShefaaPharmacyDbContext.ConStr = ConnectionManager.GetConnection("TM_" + p.database);
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            BillDetail ID = new BillDetail();
            if (ID.AddArticleByMobile(context, p.barcode) != null)
            {
                Article barcode = ID.AddArticleByMobile(context, p.barcode);
                // User user = login.LoginForMobile(context, p.userName, p.Password);
                string response = JsonConvert.SerializeObject(barcode);
                p.writeSuccess();
                p.outputStream.WriteLine(response);
                //response = response + "\n{\n\"db\"" + " : " + "\"" + DBs.Rows[i][0].ToString().Substring(3) + "\"\n" + "}" + (i == DBs.Rows.Count - 1 ? "" : ",");
            }
            else
            {
                p.writeSuccess();
                p.outputStream.WriteLine("fail");
            }
        }
    }


}




