using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Invoice
{
    public partial class InvoicePrintForm_2_ : Form
    {
        protected GridStyle[] StyledColumn;
        protected string[] HiddenColumn;
        public InvoicePrintForm_2_()
        {
            InitializeComponent();
            LoadMaster();
            //LoadInvoiceInfo();
            PaperSize pagesize = new PaperSize();
            pagesize.PaperName = "Custom";
            //pagesize.Width = 200;
            pagesize.Height = 400;
            printDocument1.DefaultPageSettings.PaperSize = pagesize;
            //printDocument1.DefaultPageSettings.PaperSize.RawKind = 50;
            //printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = 50;
            printDocument1.DefaultPageSettings.Landscape = true;

            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CenterPictureBox(QrCodePicture, QrCodePicture.Image);
        }
        //private void LoadInvoiceInfo()
        //{
        //    var context = ShefaaPharmacyDbContext.GetCurrentContext();
        //    List<BillMaster> lastBill = context.BillMasters.ToList();
        //    bindingInfo.DataSource = lastBill.FirstOrDefault();
        //    dgInvoiceInfo.DataSource = bindingInfo;
        //    dgInvoiceInfo.Refresh();
        //}
        private void LoadMaster()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<BillDetail> lastBill = context.BillDetails.ToList();
            bindingMaster.DataSource = lastBill;
            dgMaster.DataSource = bindingMaster;
            dgMaster.Refresh();
        }
        private void ShowColumn(DataGridViewColumnCollection dataGridViewColumnCollection)
        {
            foreach (DataGridViewColumn item in dataGridViewColumnCollection)
            {
                if (HiddenColumn == null || !HiddenColumn.Contains(item.Name))
                {
                    item.Visible = true;
                    if (item.DataGridView.Name == "dgMaster")
                    {
                        if (item.HeaderText == "السعر")
                            dgMaster.Columns[item.DisplayIndex].HeaderText = "الإفرادي";
                        if (item.HeaderText == "اجمالي السعر")
                            dgMaster.Columns[item.DisplayIndex].HeaderText = "الإجمالي";
                        if (item.HeaderText == "نوع الكمية")
                            dgMaster.Columns[item.DisplayIndex].HeaderText = "الواحدة";
                    }
                }
                else
                {
                    item.Visible = false;
                }
            }
        }
        private void ColumnWidth(DataGridViewColumnCollection dataGridViewColumnCollection)
        {
            foreach (DataGridViewColumn item in dataGridViewColumnCollection)
            {
                if (StyledColumn != null && StyledColumn.Any(x => x.ColName == item.Name))
                {
                    item.Width = StyledColumn.FirstOrDefault(x => x.ColName == item.Name).Width;
                }
            }
        }
        private void RebindingMaster()
        {
            HiddenColumn = new string[] { "Id", "BarcodeDescr", "InvoiceKind", "QuantityGift", "CountLeft", "Discount", "CreationByDescr", "CreationDate" };
            if (dgMaster.Columns != null)
            {
                ShowColumn(dgMaster.Columns);
            }
            if (StyledColumn != null)
            {
                ColumnWidth(dgMaster.Columns);
            }
            dgMaster.Columns["quantity"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["UnitTypeIdDescr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgMaster.Refresh();
        }
        //private void RebindingInfo()
        //{
        //    HiddenColumn = new string[] { "Id", "CountLeft", "Discount", "TotalItem", "TotalPrice", "Payment", "RemainingAmount", "CreationByDescr", "CreatedBy", "CreationDate" };
        //    if (dgInvoiceInfo.Columns != null)
        //    {
        //        ShowColumn(dgInvoiceInfo.Columns);
        //    }
        //    if (StyledColumn != null)
        //    {
        //        ColumnWidth(dgInvoiceInfo.Columns);
        //    }
        //    dgInvoiceInfo.Columns["InvoiceKind"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        //    dgInvoiceInfo.Columns["PaymentMethod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        //    dgInvoiceInfo.Refresh();
        //}
        private void AdjustmentGridColumns()
        {
            dgMaster.AutoGenerateColumns = true;
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            RebindingMaster();
        }

        private void InvoicePrintForm_2__Load(object sender, EventArgs e)
        {
            AdjustmentGridColumns();
        }

        private void CenterPictureBox(PictureBox picBox, Image picImage)
        {
            picBox.Image = picImage;
            picBox.Location = new Point((this.Width / 3),
                                        (this.Height / 40)) ;
            picBox.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            //printDocument1.Print();
            ////PrintScreen();
            //printPreviewDialog1.ShowDialog();

            PrintScreen();
            printPreviewDialog1.ShowDialog();
        }
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        public static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        private Bitmap memoryImage;

        private void PrintScreen()
        {
            Graphics mygraphics = CreateGraphics();
            Size s = Size;
            memoryImage = new Bitmap(s.Width, s.Height, mygraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            IntPtr dc1 = mygraphics.GetHdc();
            IntPtr dc2 = memoryGraphics.GetHdc();
            BitBlt(dc2, 0, 0, ClientRectangle.Width, ClientRectangle.Height, dc1, 0, 0, 13369376);
            mygraphics.ReleaseHdc(dc1);
            memoryGraphics.ReleaseHdc(dc2);
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            //DateTime date = DateTime.Now.AddDays(9);
            e.Graphics.DrawImage(memoryImage, 0, 0);

            //Graphics graphics = e.Graphics;
            //Font font = new Font("Arial", 10);
            //var brush = new SolidBrush(Color.Black);
            //float fontHeight = font.GetHeight();
            //int startX = 5;
            //int startY = 35;
            //int Offset = 40;
            //graphics.DrawString("             DIGITAL STORE               ", font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //graphics.DrawString("           ITEMS TO DELIVER             ", font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //string linea3 = string.Format("{0} Ticket#: {1}", DateTime.Now.ToString(), date);
            //graphics.DrawString(linea3, font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //string linea4 = string.Format("NB#: {0}", "ghassan");
            //graphics.DrawString(linea4, font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //graphics.DrawString("Item ID      Weigth     Price     Type", font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //graphics.DrawString("----------------------------------------", font, brush, startX, startY + Offset);
            //Offset = Offset + 20;

            //var cant = (22 - 12) / 6;

            //var pos = 12;
            //for (var i = 0; i < cant; i++)
            //{
            //    var linea7 = string.Format("{0} {1} {2} {3}", "Mohammad", "ghassan", "Al-Moghrabe", "S.V.B");
            //    graphics.DrawString(linea7, font, brush, startX, startY + Offset);
            //    Offset = Offset + 20;
            //    graphics.DrawString("Mohammad", font, brush, startX, startY + Offset);
            //    Offset = Offset + 20;
            //    graphics.DrawString("Al-Moghrabe", font, brush, startX, startY + Offset);
            //    Offset = Offset + 20;
            //    if (i != cant - 1)
            //        Offset = Offset + 20;
            //}

            //Offset = Offset + 20;
            //string linea5 = string.Format("{0}: {1}", "Stock".PadRight(15), "data4");
            //graphics.DrawString(linea5, font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //string linea6 = string.Format("{0}: {1}", "Total peso".PadRight(15), "data5");
            //graphics.DrawString(linea6, font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //string linea71 = string.Format("{0}: {1}", "Total TAR1".PadRight(15), "data6");
            //graphics.DrawString(linea71, font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //string linea8 = string.Format("{0}: {1}", "Total TAR2".PadRight(15), "data7");
            //graphics.DrawString(linea8, font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //string linea9 = string.Format("{0}: {1} = {2}", "Total Vol".PadRight(15), "data8", "data9");
            //graphics.DrawString(linea9, font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //string linea10 = string.Format("Items retirados: {0}", "data10");
            //graphics.DrawString(linea10, font, brush, startX, startY + Offset);
            //Offset = Offset + 20;
            //string linea11 = string.Format("Usuario: {0}", "data11");
            //graphics.DrawString(linea11, font, brush, startX, startY + Offset);
            //Offset = Offset + 60;
            //graphics.DrawString("----------------------------------------", font, brush, startX, startY + Offset);
            //Offset = Offset + 40;
            //string linea12 = string.Format("{0}", "data3");
            //graphics.DrawString(linea12, font, brush, startX, startY + Offset);
            //Offset = Offset + 40;
            //graphics.DrawString("            SIGNATUE           ", font, brush, startX, startY + Offset);
            //Offset = Offset + 40;
            //graphics.DrawString("*******THANKS FOR WORK WITH US********", font, brush, startX, startY + Offset);
            //Offset = Offset + 10;
            //if ("R" == "R")
            //    graphics.DrawString("**********************************", font, brush, startX, startY + Offset);
            //graphics.DrawString("a", font, brush, startX, startY + Offset);
            //e.HasMorePages = false;
        }

        private void dgMaster_BindingContextChanged(object sender, EventArgs e)
        {
            dgMaster.AutoGenerateColumns = true;
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 11);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgMaster_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 60;
            foreach (DataGridViewRow dr in dgMaster.Rows)
            {
                height += dr.Height;
            }
            dgMaster.Height = height;
        }

        private void pTop_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void dgInvoiceInfo_BindingContextChanged(object sender, EventArgs e)
        //{
        //    dgInvoiceInfo.AutoGenerateColumns = true;
        //    dgInvoiceInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    dgInvoiceInfo.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 11);
        //    dgInvoiceInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

        //    dgInvoiceInfo.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
        //    dgInvoiceInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        //    RebindingInfo();
        //}

        //private void dgInvoiceInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        //{
        //    var height = 40;
        //    foreach (DataGridViewRow dr in dgInvoiceInfo.Rows)
        //    {
        //        height += dr.Height;
        //    }

        //    dgInvoiceInfo.Height = height;
        //}
    }
}
