using DataLayer;
using DataLayer.Enums;
using DataLayer.Tables;
using FastMember;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Invoice
{
    public partial class InvoicePrintForm_3_ : Form
    {
        public InvoicePrintForm_3_()
        {
            InitializeComponent();
        }

        PrintDocument pdoc = null;
        DataTable wStock;
        Image Image, Logo;
        Point point;

        private void button1_Click(object sender, EventArgs e)
        {
            getDaily(DateTime.Now);
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();

            IEnumerable<BillDetail> data = context.BillDetails.Where(x => x.BillMasterId == 23).ToList();
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(data))
            {
                table.Load(reader);
            }
            wStock = table;
            // QR Image Create
            Image = qrcode.Draw(context.TaxAccount.FirstOrDefault().taxNumber, 10);
            
            
            // Print Settings
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("calibri", 15);
            PaperSize psize = new PaperSize("Custom", 0, 30000);
            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            pdoc.DefaultPageSettings.PaperSize.Height = 30000;
            pdoc.DefaultPageSettings.PaperSize.Width = 120;
            pdoc.PrinterSettings.PrinterName = ps.PrinterName;
            pdoc.DefaultPageSettings.Margins = new Margins(0, 0, 0, 0);
            pdoc.PrintPage += new PrintPageEventHandler(dailyDep);
            pdoc.Print();
            pdoc.PrintPage -= new PrintPageEventHandler(dailyDep);
        }

        void dailyDep(object sender, PrintPageEventArgs e)
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();

                // General Settings
                Graphics graphics = e.Graphics;
                Font font = new Font("Calibri", 11);
                float fontHeight = font.GetHeight();
                string underLine = "-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------";
                int startX = 10;
                int startY = 10;
                int Offset = 10;
                Offset += 0;
                Offset += 15;

                // Qr Code
                Logo = Properties.Resources.logo;
                Point p = new Point(startX, startY + 10);
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(Logo, p);
                Offset += 20;

                // Header
                graphics.DrawString("ShefaaPharmacy / Baramkeh", new Font("Calibri", 13, FontStyle.Bold), new SolidBrush(Color.Black), startX + 280, startY + Offset);
                Offset += 40;
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                Offset += 15;

                graphics.DrawString("Tax Number : " + context.TaxAccount.FirstOrDefault().taxNumber +
                    "                          Phone : " + "2211393" +
                    "                          Commercial Register : " + "121st5"
                    , new Font("Calibri", 11), new SolidBrush(Color.Black), startX + 15, startY + Offset);
                Offset += 15;
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                string xParent = "*";
                Offset += 20;

                // BillMaster Info
                string parent = wStock.Rows[0]["BillMasterId"].ToString();

                Offset += 20;
                graphics.DrawString("Bill Number " + parent.ToUpper(), new Font("Calibri", 11, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 15;
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                Offset += 12;
                graphics.DrawString("InvoiceKind                               Currency           PaymentType           TotalPrice           Date", new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 12;
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                Offset += 20;
                xParent = parent;
                
                string InvoiceKind = (0 + 1) + " - " + Enum.GetName(typeof(InvoiceKind),wStock.Rows[0]["InvoiceKind"]);
                string CreationDate = wStock.Rows[0]["CreationDate"].ToString();
                string PaymentMethod = wStock.Rows[0]["Id"].ToString();
                string Currency = "SP";
                string TotalBill = wStock.Rows[0]["TotalPrice"].ToString();
                graphics.DrawString(InvoiceKind, new Font("Calibri", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                graphics.DrawString(Currency, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 195, startY + Offset);
                graphics.DrawString(PaymentMethod, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 305, startY + Offset);
                graphics.DrawString(TotalBill, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 405, startY + Offset);
                graphics.DrawString(CreationDate, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 500, startY + Offset);
                Offset += 20;
                string nextParent1;
                nextParent1 = wStock.Rows[0 + 1]["quantity"].ToString();

                // BillDetails Info
                Offset += 20;
                graphics.DrawString("Bill Details ", new Font("Calibri", 11, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 15;
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                Offset += 12;
                graphics.DrawString("Item                                             Unit           quantity           Price           Total", new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 12;
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                Offset += 20;
                xParent = parent;

                for (int i = 0; i < wStock.Rows.Count; i++)
                {
                    string item = (i + 1) + " - " + wStock.Rows[i]["ArticaleIdDescr"].ToString();
                    string quantity = wStock.Rows[i]["quantity"].ToString();
                    string UnitName = wStock.Rows[i]["UnitTypeIdDescr"].ToString();
                    string Price = wStock.Rows[i]["Price"].ToString();
                    string Total = wStock.Rows[i]["TotalPrice"].ToString();
                    graphics.DrawString(item, new Font("Calibri", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                    graphics.DrawString(UnitName, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 190, startY + Offset);
                    graphics.DrawString(quantity, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 270, startY + Offset);
                    graphics.DrawString(Price, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 342, startY + Offset);
                    graphics.DrawString(Total, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 407, startY + Offset);
                    Offset += 20;
                    string nextParent;
                    if (i < wStock.Rows.Count - 1)
                        nextParent = wStock.Rows[i + 1]["quantity"].ToString();
                    else
                        nextParent = "*";
                }

                // Total Info
                var billmaster = context.BillMasters.Where(x => x.Id == Convert.ToInt32(wStock.Rows[0]["BillMasterId"])).ToList().FirstOrDefault();
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                Offset += 20;
                graphics.DrawString("Sub Total :  " + billmaster.TotalPrice.ToString(), new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 22;
                
                // Qr Code
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                point = new Point(800, startY + Offset);
                graphics.DrawImage(Image, 680, startY + Offset, 80, 80);

                double ConsumerSpendingTax = ((billmaster.TotalPrice * 6) / 100); // 0.6
                double ReconstructionTax = ((billmaster.TotalPrice * 6) / 1000); // 0.06
                double localAdministrationTax = ((billmaster.TotalPrice * 3) / 1000); // 0.03
                graphics.DrawString("Consumer Spending Tax : " + ConsumerSpendingTax.ToString(), new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 22;
                graphics.DrawString("Reconstruction Tax : " + ReconstructionTax.ToString(), new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 22;
                graphics.DrawString("local Administration Tax : " + localAdministrationTax.ToString(), new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 22;
                graphics.DrawString("Discount :" + billmaster.discount.ToString(), new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 22;
                graphics.DrawString("Final Total :" + (billmaster.TotalPrice + ConsumerSpendingTax + ReconstructionTax + localAdministrationTax).ToString(), new Font("Calibri", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 50;

                // Footer
                graphics.DrawString("Thanks For Your Visit", new Font("Calibri", 11, FontStyle.Bold), new SolidBrush(Color.Black), startX + 335, startY + Offset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public DataTable getDaily(DateTime date)
        {
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                SqlConnection connection = new SqlConnection(@"Data Source=POST-5;Initial Catalog=TM_Second;Integrated Security=true;");
                connection.Open();
                using (SqlDataAdapter ds1 = new SqlDataAdapter("select A.Quantity,A.TotalPrice from BillDetail A ", connection))
                {
                    DataSet ds = new DataSet();
                    ds1.Fill(ds);
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    connection.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Could not get   Inventory  by WareHouse" + ex);
            }


        }
        //private static string GetDisplayName(this Enum enumValue)
        //{
        //    string displayName;
        //    displayName = enumValue.GetType()
        //        .GetMember(enumValue.ToString())
        //        .FirstOrDefault()
        //        .GetCustomAttribute<DisplayAttribute>()?
        //        .GetName();
        //    if (String.IsNullOrEmpty(displayName))
        //    {
        //        displayName = enumValue.ToString();
        //    }
        //    return displayName;
        //}

    }
}
