using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Invoice
{
    public partial class InvoicePrintForm : Form
    {
        protected GridStyle[] StyledColumn;
        protected string[] HiddenColumn;
        public InvoicePrintForm()
        {
            InitializeComponent();
            LoadMaster();
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custom", 500, 1500);
            printDocument1.DefaultPageSettings.PaperSize.RawKind = 50;
            printDocument1.PrinterSettings.DefaultPageSettings.PaperSize.RawKind = 50;
            printDocument1.DefaultPageSettings.Landscape = true;

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

                    if(item.HeaderText == "السعر")
                    dgMaster.Columns[item.DisplayIndex].HeaderText = "الإفرادي" ;
                    if(item.HeaderText == "اجمالي السعر")
                    dgMaster.Columns[item.DisplayIndex].HeaderText = "الإجمالي" ;
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
        private void Rebinding()
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
            dgMaster.Refresh();
        }
        private void AdjustmentGridColumns()
        {
            dgMaster.AutoGenerateColumns = true;
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Rebinding();
        }

        private void InvoicePrintForm_Load(object sender, EventArgs e)
        {
            AdjustmentGridColumns();
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

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
