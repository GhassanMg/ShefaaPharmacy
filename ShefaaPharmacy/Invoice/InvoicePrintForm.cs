﻿using DataLayer;
using DataLayer.Enums;
using DataLayer.Tables;
using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Threading;
using System.Globalization;

namespace ShefaaPharmacy.Invoice
{
    public partial class InvoicePrintForm : Form
    {
        PrintDocument pdoc = null;
        DataTable wStock;
        Image Image, Logo;
        BillMaster billmaster;
        List<BillDetail> billdetails;
        Point point;
        public InvoicePrintForm()
        {
            InitializeComponent();
        }
        public InvoicePrintForm(BillMaster Master)
        {
            billmaster = Master;
            billdetails = new List<BillDetail>(Master.BillDetails.Where(s => s.Quantity != 0));
            PrintInvoice();
        }
        private void PrintInvoice()
        {
            Zen.Barcode.CodeQrBarcodeDraw qrcode = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();

            IEnumerable<BillDetail> data = billdetails;
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(data))
            {
                table.Load(reader);
            }
            wStock = table;

            // QR Image Create
            try
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-UK");
            }
            catch
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            }
            var TaxAccount = context.TaxAccount.ToList().FirstOrDefault();
            string RandomNmuber = TaxAccount.taxNumber +
                "_" + TaxAccount.facilityName + "_" + "001" + "#" +
                billmaster.CreationDate + "_" + billmaster.TotalPrice + "_" + "SP" + "ShefaaPharmacy";

            MD5 md5Hasher = MD5.Create();
            byte[] sipher = md5Hasher.ComputeHash(Encoding.Default.GetBytes(RandomNmuber));
            string GUIDCode = new Guid(sipher).ToString();

            string QrString = "#" + RandomNmuber + "#" + GUIDCode + "#";

            Image = qrcode.Draw(QrString, 10);

            // Print Settings
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("calibri", 15);
            PaperSize psize = new PaperSize("Custom", 5000, 30000);
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
                var Info = context.PharmacyInformation.ToList().FirstOrDefault() ?? null;
                if(Info ==null) graphics.DrawString("PharmacyName / Location", new Font("Calibri", 13, FontStyle.Bold), new SolidBrush(Color.Black), startX + 280, startY + Offset);
                else graphics.DrawString(Info.PharmacyName+ " / " + Info.Address , new Font("Calibri", 13, FontStyle.Bold), new SolidBrush(Color.Black), startX + 280, startY + Offset);
                Offset += 40;
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                Offset += 15;

                if (Info == null) graphics.DrawString("Tax Number : " + context.TaxAccount.FirstOrDefault().taxNumber +
                    "                          Phone : ----- " +
                    "                          Commercial Register Number : ----- " 
                    , new Font("Calibri", 11), new SolidBrush(Color.Black), startX + 15, startY + Offset);

                else graphics.DrawString("Tax Number : " + context.TaxAccount.FirstOrDefault().taxNumber +
                    "                          Phone : " + Info.Tel  +
                    "                          Commercial Register Number : " + Info.CommercialRegisterNumber 
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
                string PaymentMethod = Enum.GetName(typeof(PaymentMethod), billmaster.paymentMethod);
                string Currency = "SP";
                string TotalBill = wStock.Rows[0]["TotalPrice"].ToString();
                graphics.DrawString(InvoiceKind, new Font("Calibri", 10), new SolidBrush(Color.Black), startX, startY + Offset);
                graphics.DrawString(Currency, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 195, startY + Offset);
                graphics.DrawString(PaymentMethod, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 305, startY + Offset);
                graphics.DrawString(TotalBill, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 405, startY + Offset);
                graphics.DrawString(CreationDate, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 500, startY + Offset);
                Offset += 20;

                // BillDetails Info
                Offset += 20;
                graphics.DrawString("Bill Details ", new Font("Calibri", 11, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 15;
                graphics.DrawString(underLine, new Font("Calibri", 11), new SolidBrush(Color.Black), 0, startY + Offset);
                Offset += 12;
                graphics.DrawString("Item                                                                                          Unit           quantity           Price           Total", new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
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
                    graphics.DrawString(UnitName, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 347, startY + Offset);
                    graphics.DrawString(quantity, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 430, startY + Offset);
                    graphics.DrawString(Price, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 502, startY + Offset);
                    graphics.DrawString(Total, new Font("Calibri", 10), new SolidBrush(Color.Black), startX + 571, startY + Offset);
                    Offset += 20;
                    string nextParent;
                    if (i < wStock.Rows.Count - 1)
                        nextParent = wStock.Rows[i]["quantity"].ToString();
                    else
                        nextParent = "*";
                }

                // Total Info
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
                graphics.DrawString("Discount : " + billmaster.discount.ToString(), new Font("Calibri", 11), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 22;
                graphics.DrawString("Final Total : " + (billmaster.TotalPrice + ConsumerSpendingTax + ReconstructionTax + localAdministrationTax).ToString(), new Font("Calibri", 12, FontStyle.Bold), new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 50;

                // Footer
                graphics.DrawString("Thanks For Your Visit", new Font("Calibri", 11, FontStyle.Bold), new SolidBrush(Color.Black), startX + 335, startY + Offset);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
