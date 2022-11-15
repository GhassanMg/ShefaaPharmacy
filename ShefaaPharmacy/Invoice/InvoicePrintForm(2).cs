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
            LoadInvoiceInfo();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 500, 1500);
            printDocument1.DefaultPageSettings.PaperSize.RawKind = 50;
            printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = 50;
            printDocument1.DefaultPageSettings.Landscape = true;

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            CenterPictureBox(QrCodePicture, QrCodePicture.Image);
        }
        private void LoadInvoiceInfo()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<BillMaster> lastBill = context.BillMasters.ToList();
            bindingInfo.DataSource = lastBill.FirstOrDefault();
            dgInvoiceInfo.DataSource = bindingInfo;
            dgInvoiceInfo.Refresh();
        }
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
        private void RebindingInfo()
        {
            HiddenColumn = new string[] { "Id", "CountLeft", "Discount", "TotalItem", "TotalPrice", "Payment", "RemainingAmount", "CreationByDescr", "CreatedBy", "CreationDate" };
            if (dgInvoiceInfo.Columns != null)
            {
                ShowColumn(dgInvoiceInfo.Columns);
            }
            if (StyledColumn != null)
            {
                ColumnWidth(dgInvoiceInfo.Columns);
            }
            dgInvoiceInfo.Columns["InvoiceKind"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgInvoiceInfo.Columns["PaymentMethod"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgInvoiceInfo.Refresh();
        }
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
            e.Graphics.DrawImage(memoryImage, 0, 0);
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
            var height = 40;
            foreach (DataGridViewRow dr in dgMaster.Rows)
            {
                height += dr.Height;
            }

            dgMaster.Height = height;
        }

        private void dgInvoiceInfo_BindingContextChanged(object sender, EventArgs e)
        {
            dgInvoiceInfo.AutoGenerateColumns = true;
            dgInvoiceInfo.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgInvoiceInfo.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 11);
            dgInvoiceInfo.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgInvoiceInfo.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgInvoiceInfo.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            RebindingInfo();
        }

        private void dgInvoiceInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var height = 40;
            foreach (DataGridViewRow dr in dgInvoiceInfo.Rows)
            {
                height += dr.Height;
            }

            dgInvoiceInfo.Height = height;
        }
    }
}
