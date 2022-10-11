using DataLayer;
using DataLayer.Enums;
using DataLayer.StoredProcedures;
using DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Accounting
{
    public partial class FirstTimeReport : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        public List<GetAccountDebitCredit> _TotalPriceForAll { get; set; }
        public FirstTimeReport()
        {
            InitializeComponent();

        }
        EntryMaster entry;
        string type = "";
        public FirstTimeReport(EntryMaster entry)
        {
            this.entry = entry;
            InitializeComponent();

        }
        public FirstTimeReport(EntryMaster entry, string type)
        {
            this.entry = entry;
            this.type = type;
            InitializeComponent();
            LoadTotalForAll();
            ChangeStyle(dgvTotal);

        }
        void ChangeStyle(DataGridView dataGridView)
        {
            dataGridView.Refresh();
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dataGridView.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.Refresh();

        }
        private void LoadTotalForAll()
        {
            _TotalPriceForAll = new List<GetAccountDebitCredit>();

            TotalbindingSource.DataSource = _TotalPriceForAll;
            dgvTotal.DataSource = TotalbindingSource;

        }
        public static EntryMaster PickEntry(EntryMaster entry, FormOperation formOperation = FormOperation.Show)
        {
            FirstTimeReport fmPick = new FirstTimeReport(entry);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض سندات القيد";
                fmPick.ShowDialog();
                return entry;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static EntryMaster PickEntry(int textFilter, EntryMaster entry, FormOperation formOperation = FormOperation.Show)
        {
            EntryMaster tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.Id == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            FirstTimeReport fmPick = new FirstTimeReport(entry);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر سند القيد";
                fmPick.ForeColor = Color.Green;
                fmPick.ShowDialog();
                return entry;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            try
            {
                HiddenColumn = new string[] { "Id" };

            }
            catch (Exception)
            {
                ;
            }

            PickGridView.Refresh();
        }

        protected override void Rebinding()
        {
            if (entry == null || entry.Id == 0)
                if (type == "FirstTime")
                    //PickGridView.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().EntryDetails.Where(x => x.AccountId == 19).ToList();
                    PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().EntryDetails.Where(s => s.KindOperation == KindOperation.GoodFirstTime && s.AccountId != 18  /*&& x.AccountId != 12*/).ToList();//.Where(s => s.Debit != 0)
                else
                    PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.KindOperation == KindOperation.GoodFirstTime).ToList();

            HiddenColumn = new string[] { "Balance" };

            base.Rebinding();
            PickGridView.Columns[0].DisplayIndex = 7;
            PickGridView.Columns[0].HeaderText = "البيان";
            PickGridView.Columns["Id"].Visible = false;
            PickGridView.Columns["CreationByDescr"].Visible = false;
            PickGridView.Columns["Description"].Visible = false;
            PickGridView.Columns["CreationDate"].Visible = false;
            SumTotal();
        }
        private int SumDeptCredit(string col)
        {
            int total = 0;
            foreach (DataGridViewRow x in PickGridView.Rows)
            {
                if (col == "Depit")
                    total += Convert.ToInt32(x.Cells[1].Value);
                else
                    total += Convert.ToInt32(x.Cells[2].Value);
            }
            return total;
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = entry;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            //base.DeleteCurrentItem(shefaaPharmacyDbContext);
            //if (Auth.IsManager())
            //{
            //    if (_MessageBoxDialog.Show("هل أنت متأكد من حذف هذا السند", "انتبه", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    {
            //        shefaaPharmacyDbContext.EntryDetails.RemoveRange(shefaaPharmacyDbContext.EntryDetails.Where(x => x.EntryMasterId == entry));
            //    }
            //}

        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            EntryEditForm.CreateEntry(new EntryMaster(), FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var mymaster = context.EntryMasters.FirstOrDefault(x => x.Id == (PickBindingSource.Current as EntryDetail).EntryMasterId);
            EntryEditForm entryEditForm = new EntryEditForm(mymaster, mymaster.KindOperation, FormOperation.EditFromPicker);
            entryEditForm.ShowDialog();
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            SetCurrentEntity();
            if (FormOperation != FormOperation.Pick)
            {
                if (PickBindingSource.Current == null)
                    return;
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                var mymaster = context.EntryMasters.FirstOrDefault(x => x.Id == (PickBindingSource.Current as EntryDetail).EntryMasterId);
                EntryEditForm entryEditForm = new EntryEditForm(mymaster, mymaster.KindOperation, FormOperation.EditFromPicker);
                entryEditForm.ShowDialog();
                Rebinding();
            }
            else
            {
                Close();
            }
        }
        private void SumTotal()
        {
            GetAccountDebitCredit FullTotal = new GetAccountDebitCredit();
            FullTotal.AccountId = 18;
            foreach (DataGridViewRow myrow in PickGridView.Rows)
            {
                if (myrow.Cells["AccountIdDescr"].Value.ToString() != " ")
                {
                    FullTotal.Debit += Convert.ToDouble(myrow.Cells["Debit"].Value);
                    FullTotal.Credit += Convert.ToDouble(myrow.Cells["Credit"].Value);
                }

            }
            TotalbindingSource.DataSource = FullTotal;
            dgvTotal.Columns[3].HeaderText = "قيمة رأس المال";
        }
        private void FirstTimeReport_Load(object sender, EventArgs e)
        {

            //PickGridView.Refresh();

            //PickGridView.Columns[0].DisplayIndex = 7;
            //PickGridView.Columns[0].HeaderText = "البيان";
            //PickGridView.Columns["Id"].Visible = false;
            //PickGridView.Columns["CreationByDescr"].Visible = false;
            //PickGridView.Columns["Description"].Visible = false;
            //PickGridView.Columns["CreationDate"].Visible = false;
            //SumTotal();

            //PickGridView.Columns[9].DisplayIndex = 0;
            //PickGridView.Columns[0].HeaderText = "التاريخ";

            //PickGridView.Columns["AccountIdCreditDescr"].HeaderText = "الحساب";
            //PickGridView.Columns["TotalCredit"].HeaderText = "الدائن";
            //PickGridView.Columns["TotalDebit"].HeaderText = "المدين";

            //PickGridView.Columns["AccountIdDebitDescr"].Visible = false;
            //PickGridView.Columns["CreationDate"].DefaultCellStyle.Format = "d";//Short Date

        }

        private void dgvTotal_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
