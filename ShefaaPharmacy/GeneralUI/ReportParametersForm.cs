using DataLayer;
using DataLayer.Enums;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using ShefaaPharmacy.Accounting;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.Articles;
using ShefaaPharmacy.Definition;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class ReportParametersForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public bool PressOk { get; set; }
        public UserParameters UserParameters { get; set; }
        public ReportParametersForm()
        {
            InitializeComponent();
        }
        public static UserParameters ReportParameterForProfit(UserParameters userParameters)
        {
            ReportParametersForm fmPick = new ReportParametersForm();
            try
            {

                fmPick.tabControl1.TabPages.Remove(fmPick.tpBill);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpArticle);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpAccounting);
                fmPick.bsAccounting.DataSource = userParameters;
                fmPick.RebindingbsAccounting();
                fmPick.cbBranchId.Enabled = false;
                fmPick.cbUserId.Enabled = false;
                fmPick.dtFromDate.Enabled = false;
                fmPick.dtToDate.Enabled = false;
                //fmPick.bsAccounting.DataSource = userParameters;
                fmPick.PressOk = false;
                fmPick.RebindingGeneral();
                fmPick.ShowDialog();
                if (fmPick.PressOk == false)
                {
                    return null;
                }
                return fmPick.UserParameters;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static UserParameters ReportParameterForAccounting(UserParameters userParameters)
        {
            ReportParametersForm fmPick = new ReportParametersForm();
            try
            {
                fmPick.tabControl1.TabPages.Remove(fmPick.tpBill);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpArticle);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpGeneral);
                fmPick.bsAccounting.DataSource = userParameters;
                fmPick.PressOk = false;
                fmPick.panel3.Visible = true;
                //fmPick.RebindingGeneral();
                fmPick.RebindingbsAccounting();
                fmPick.ShowDialog();
                if (fmPick.PressOk == false)
                {
                    return null;
                }
                return fmPick.UserParameters;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static UserParameters ReportParameterForEntryReport(UserParameters userParameters)
        {
            ReportParametersForm fmPick = new ReportParametersForm();
            try
            {

                fmPick.tabControl1.TabPages.Remove(fmPick.tpBill);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpArticle);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpAccounting);
                fmPick.cbBranchId.Enabled = false;
                fmPick.bsAccounting.DataSource = userParameters;
                fmPick.PressOk = false;
                fmPick.RebindingGeneral();
                fmPick.ShowDialog();
                if (fmPick.PressOk == false)
                {
                    return null;
                }
                return fmPick.UserParameters;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static UserParameters ReportParameterProfitFromDateToDate(UserParameters userParameters)
        {
            ReportParametersForm fmPick = new ReportParametersForm();
            try
            {

                fmPick.tabControl1.TabPages.Remove(fmPick.tpBill);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpArticle);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpAccounting);
                fmPick.bsAccounting.DataSource = userParameters;
                fmPick.RebindingbsAccounting();
                fmPick.cbBranchId.Enabled = false;
                fmPick.cbUserId.Enabled = false;
                //fmPick.bsAccounting.DataSource = userParameters;
                fmPick.PressOk = false;
                fmPick.RebindingGeneral();
                fmPick.ShowDialog();
                if (fmPick.PressOk == false)
                {
                    return null;
                }
                return fmPick.UserParameters;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static UserParameters ReportParameterForArticle(UserParameters userParameters)
        {
            ReportParametersForm fmPick = new ReportParametersForm();
            try
            {
                fmPick.tabControl1.TabPages.Remove(fmPick.tpAccounting);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpBill);
                fmPick.bsAccounting.DataSource = userParameters;
                fmPick.PressOk = false;
                fmPick.RebindingGeneral();
                fmPick.RebindingbsArticle();
                fmPick.ShowDialog();
                if (fmPick.PressOk == false)
                {
                    return null;
                }
                
                return fmPick.UserParameters;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static UserParameters ReportParameterForIvoice(UserParameters userParameters)
        {
            ReportParametersForm fmPick = new ReportParametersForm();
            try
            {
                fmPick.tabControl1.TabPages.Remove(fmPick.tpAccounting);
                fmPick.tabControl1.TabPages.Remove(fmPick.tpArticle);
                fmPick.bsAccounting.DataSource = userParameters;
                fmPick.PressOk = false;
                fmPick.RebindingGeneral();
                fmPick.RebindingbsBill();
                fmPick.ShowDialog();
                if (fmPick.PressOk == false)
                {
                    return null;
                }
                return fmPick.UserParameters;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public void RebindingGeneral()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();

            cbUserId.DataSource = context.Users.ToList();
            cbUserId.DisplayMember = "Name";
            cbUserId.ValueMember = "Id";
            cbUserId.SelectedItem = UserLoggedIn.User;

            cbBranchId.DataSource = context.Branches.ToList();
            cbBranchId.DisplayMember = "Name";
            cbBranchId.ValueMember = "Id";
            cbBranchId.SelectedItem = UserService.GetBranch(UserLoggedIn.User.Id);

            cbYearId.DataSource = context.Years.ToList();
            cbYearId.DisplayMember = "Name";
            cbYearId.ValueMember = "Id";
            cbYearId.SelectedItem = YearService.GetYear().FirstOrDefault();

            //cbYearId.Items.AddRange(YearService.GetYear().ToArray());
        }
        public void RebindingbsAccounting()
        {
            tbAccountId.DataBindings.Add("text", bsAccounting, "Acc_AccountIdDescr", true, DataSourceUpdateMode.OnPropertyChanged);
            List<string> data = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.ToList().Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            data.ForEach(x => autoCompleteStringCollection.Add(x));
            tbAccountId.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbAccountId.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbAccountId.AutoCompleteCustomSource = autoCompleteStringCollection;


            var context = ShefaaPharmacyDbContext.GetCurrentContext();

            cbUserId2.DataSource = context.Users.ToList();
            cbUserId2.DisplayMember = "Name";
            cbUserId2.ValueMember = "Id";
            cbUserId2.SelectedItem = UserLoggedIn.User;

            cbBranchId2.DataSource = context.Branches.ToList();
            cbBranchId2.DisplayMember = "Name";
            cbBranchId2.ValueMember = "Id";
            cbBranchId2.SelectedItem = UserService.GetBranch(UserLoggedIn.User.Id);

            cbYearId2.DataSource = context.Years.ToList();
            cbYearId2.DisplayMember = "Name";
            cbYearId2.ValueMember = "Id";
            cbYearId2.SelectedItem = YearService.GetYear().FirstOrDefault();
        }

        public void RebindingbsArticle()
        {
            tbArticleName.DataBindings.Add("text", bsAccounting, "ArticleIdDescr", true, DataSourceUpdateMode.OnPropertyChanged);
            List<string> data = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            data.ForEach(x => autoCompleteStringCollection.Add(x));
            tbArticleName.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbArticleName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbArticleName.AutoCompleteCustomSource = autoCompleteStringCollection;
        }
        public void RebindingbsBill()
        {
            cbInvoiceKind.DataSource = Enum.GetValues(typeof(InvoiceKind));
            tbInvoiceId.DataBindings.Add("text", bsAccounting, "InvoiceId", true, DataSourceUpdateMode.OnPropertyChanged);
            tbInvoiceAccountId.DataBindings.Add("text", bsAccounting, "Acc_AccountIdDescr", true, DataSourceUpdateMode.OnPropertyChanged);
            List<string> data = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Select(x => x.Name).ToList();
            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            data.ForEach(x => autoCompleteStringCollection.Add(x));
            tbInvoiceAccountId.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbInvoiceAccountId.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tbInvoiceAccountId.AutoCompleteCustomSource = autoCompleteStringCollection;
        }

        private void tbAccountId_Validating(object sender, CancelEventArgs e)
        {
            Account result = AccountPickForm.PickAccount((sender as TextBox).Text.ToString().Trim(), null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
                e.Cancel = true;
            }
            else
            {
                (bsAccounting.Current as UserParameters).Acc_AccountId = result.Id;
                (bsAccounting.Current as UserParameters).Acc_AccountIdDescr = result.Name;
                tbAccountId.Text = result.Name;
                //tbAccountId.DataBindings[0].WriteValue();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            btnOk.Select();
            ReportParametersForm fmPick = new ReportParametersForm();
            if (tbAccountId.Visible == true)
            {
                if (tbAccountId.Text == null || tbAccountId.Text == "")
                {
                    ValidateBox.Visible = true;
                    
                    return;
                }
            }

            this.UserParameters = bsAccounting.DataSource as UserParameters;
            PressOk = true;
            Close();
        }

        private void tbYearId_Validating(object sender, CancelEventArgs e)
        {
            Year result = YearPickForm.PickYear((sender as TextBox).Text.ToString().Trim(), null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
                e.Cancel = true;
            }
            else
            {
                (bsAccounting.Current as UserParameters).YearId = result.Id;
                (bsAccounting.Current as UserParameters).YearIdDescr = result.Name;
                //tbYearId.Text = result.Name;
                //tbYearId.DataBindings[0].WriteValue();
            }
        }

        private void tbBranchId_Validating(object sender, CancelEventArgs e)
        {
            Branch result = BranchPickForm.PickBranch((sender as TextBox).Text.ToString().Trim(), null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
                e.Cancel = true;
            }
            else
            {
                (bsAccounting.Current as UserParameters).BranchId = result.Id;
                (bsAccounting.Current as UserParameters).BranchIdDescr = result.Name;
                // tbBranchId.Text = result.Name;
                //tbBranchId.DataBindings[0].WriteValue();
            }
        }

        private void tbUserId_Validating(object sender, CancelEventArgs e)
        {
            User result = UserPickForm.PickUser((sender as TextBox).Text.ToString().Trim(), null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
                e.Cancel = true;
            }
            else
            {
                (bsAccounting.Current as UserParameters).UserId = result.Id;
                (bsAccounting.Current as UserParameters).UserIdDescr = result.Name;
                //tbUserId.Text = result.Name;
                //tbUserId.DataBindings[0].WriteValue();
            }
        }

        private void cbInvoiceKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            (bsAccounting.Current as UserParameters).InvoiceKind = (InvoiceKind)cbInvoiceKind.SelectedItem;
        }

        private void tpAccounting_Click(object sender, EventArgs e)
        {

        }

        private void cbYearId_SelectedIndexChanged(object sender, EventArgs e)
        {
            (bsAccounting.Current as UserParameters).YearId = ((Year)cbYearId.SelectedItem).Id;
        }

        private void cbBranchId_SelectedIndexChanged(object sender, EventArgs e)
        {
            (bsAccounting.Current as UserParameters).BranchId = ((Branch)cbBranchId.SelectedItem).Id;
        }

        private void cbUserId_SelectedIndexChanged(object sender, EventArgs e)
        {
            (bsAccounting.Current as UserParameters).UserId = ((User)cbUserId.SelectedItem).Id;
        }

        private void cbYearId2_SelectedIndexChanged(object sender, EventArgs e)
        {
            (bsAccounting.Current as UserParameters).YearId = ((Year)cbYearId2.SelectedItem).Id;
        }

        private void cbBranchId2_SelectedIndexChanged(object sender, EventArgs e)
        {
            (bsAccounting.Current as UserParameters).BranchId = ((Branch)cbBranchId2.SelectedItem).Id;
        }

        private void cbUserId2_SelectedIndexChanged(object sender, EventArgs e)
        {
            (bsAccounting.Current as UserParameters).UserId = ((User)cbUserId2.SelectedItem).Id;
        }

        private void pbAccountPick_Click_1(object sender, EventArgs e)
        {
            Account result = AccountPickForm.PickAccount(tbAccountId.Text.ToString().Trim(), null, null, FormOperation.Pick, true);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);

            }
            else
            {
                (bsAccounting.Current as UserParameters).Acc_AccountId = result.Id;
                (bsAccounting.Current as UserParameters).Acc_AccountIdDescr = result.Name;
                tbAccountId.Text = result.Name;
            }
        }

        private void pbInvoiceAccountPick_Click(object sender, EventArgs e)
        {
            Account result = AccountPickForm.PickAccount("", null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
            }
            else
            {
                (bsAccounting.Current as UserParameters).Acc_AccountId = result.Id;
                (bsAccounting.Current as UserParameters).Acc_AccountIdDescr = result.Name;
                tbInvoiceAccountId.Text = result.Name;
            }
        }

        private void cbInvoiceKind_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ((UserParameters)bsAccounting.DataSource).InvoiceKind = (InvoiceKind)cbInvoiceKind.SelectedItem;
        }

        private void ReportParametersForm_Load(object sender, EventArgs e)
        {
            var dateyear = YearService.GetYear().FirstOrDefault();
            dtFromDate.Format = dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dtFromDate.CustomFormat = dateTimePicker2.CustomFormat = "ss:mm:hh MM/dd/yyyy";
            dtFromDate.Value = dateTimePicker2.Value = new DateTime(DateTime.Now.Year, 1, 1, 00, 00, 01);
            dtFromDate.Text = dtFromDate.Value.ToString();
            dtFromDate.Refresh();
            dtToDate.Format = dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dtToDate.CustomFormat = dateTimePicker1.CustomFormat = "ss:mm:hh MM/dd/yyyy";
            dtToDate.Value = dateTimePicker1.Value = new DateTime(DateTime.Now.Year, 12, 31, 23, 59, 59);
            dtToDate.Text = dtToDate.Value.ToString();
            dtToDate.Refresh();
            btnMaximaizing.Enabled = false;
        }
        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {
            ((UserParameters)bsAccounting.DataSource).FromDate = dtFromDate.Value;
        }
        private void dtToDate_ValueChanged(object sender, EventArgs e)
        {
            ((UserParameters)bsAccounting.DataSource).ToDate = dtToDate.Value;
        }

        private void pbArticlePick_Click(object sender, EventArgs e)
        {
            Article result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
            if (result == null)
            {
                tbArticleName.Text = "";
            }
            else
            {
                (bsAccounting.Current as UserParameters).ArticleId = result.Id;
                (bsAccounting.Current as UserParameters).ArticleIdDescr = result.Name;
                tbArticleName.Text = result.Name;
                tbSize.Focus();
            }
        }
        private void ArticleName_Validating()
        {
            Article result = DescriptionFK.ArticaleExists(true, tbArticleName.Text, 0);
            if (result == null)
            {
                _MessageBoxDialog.Show("يرجى إدخال صنف صحيح", MessageBoxState.Error);
                tbArticleName.Text = "";
                tbArticleName.Focus();
            }
            else
            {
                (bsAccounting.Current as UserParameters).ArticleId = result.Id;
                (bsAccounting.Current as UserParameters).ArticleIdDescr = result.Name;
                tbSize.Focus();
            }
        }

        private void lbInvoiceType_Click(object sender, EventArgs e)
        {

        }

        private void tbAccountId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && tbAccountId.Text != "")
            {
                btnOk.Select();
            }
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // if it is a hotkey, return true; otherwise, return false
            if (this.tbArticleName.Focused)
            {
                if (keyData == Keys.Enter)
                {
                    ArticleName_Validating();
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            switch (keyData)
            {
                case Keys.Enter:
                    if (tbAccountId.Text != "")
                    {
                        btnOk.Focus();
                        btnOk.Select();
                        this.UserParameters = bsAccounting.DataSource as UserParameters;
                        PressOk = true;
                        Close();
                    }
                    return true;
                default:
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void TbArticleName_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    tbSize.Focus();
            //}
        }

        private void lbAccountId_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            tbAccountId.Clear();
            Account result = AccountPickForm.PickAccount(tbAccountId.Text.ToString().Trim(), null, null, FormOperation.Pick, true);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
                ValidateBox.Visible = false;
            }
            else
            {
                ValidateBox.Visible = false;
                (bsAccounting.Current as UserParameters).Acc_AccountId = result.Id;
                (bsAccounting.Current as UserParameters).Acc_AccountIdDescr = result.Name;
                tbAccountId.Text = result.Name;

            }
        }

        private void tbAccountId_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            PressOk = false;
            Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            ((UserParameters)bsAccounting.DataSource).FromDate = dateTimePicker2.Value;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ((UserParameters)bsAccounting.DataSource).ToDate = dateTimePicker1.Value;
        }

        private void tbArticleName_Validating(object sender, CancelEventArgs e)
        {
            Article result = DescriptionFK.ArticaleExists(true, tbArticleName.Text, 0);
            if (result == null)
            {
                _MessageBoxDialog.Show("يرجى إدخال صنف صحيح", MessageBoxState.Error);
                tbArticleName.Text = "";
                tbArticleName.Focus();
            }
            else
            {
                (bsAccounting.Current as UserParameters).ArticleId = result.Id;
                (bsAccounting.Current as UserParameters).ArticleIdDescr = result.Name;
                tbSize.Focus();
            }
        }

        private void ReportParametersForm_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
