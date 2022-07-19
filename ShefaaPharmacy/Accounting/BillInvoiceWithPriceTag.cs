using DataLayer.Enums;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Accounting
{
    public partial class BillInvoiceWithPriceTag : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        List<BillDetail> BillDetails { set; get; }
        BillMaster BillMaster { set; get; }
        InvoiceKind invoiceKind;
        public BillInvoiceWithPriceTag()
        {
            InitializeComponent();
        }
        public BillInvoiceWithPriceTag(List<BillDetail> billDetails, BillMaster billMaster)
        {
            this.BillDetails = billDetails;
            this.BillMaster = billMaster;
            EditBindingSource.DataSource = this.BillDetails;

            //dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            //dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            //dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            //dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
