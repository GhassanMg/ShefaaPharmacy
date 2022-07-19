using DataLayer;
using DataLayer.Enums;
using DataLayer.Services;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class FirstTimeCustomerEditForm : GeneralUI.GeneralEditForm
    {
        public List<CustomerDepthViewModel> _CustomerDepthViewModel = new List<CustomerDepthViewModel>();
        CustomerDepthViewModel newsup = new CustomerDepthViewModel();
        EntryDetail mydetail = new EntryDetail();
        public int AccountProfitId { get; set; }
        List<int> mydepitIds = new List<int>();
        public FirstTimeCustomerEditForm()
        {
            InitializeComponent();
        }
        public FirstTimeCustomerEditForm(EntryDetail row)
        {
            mydetail = row;
            newsup = new CustomerDepthViewModel
            {
                AccountId = row.AccountId,
                AccountIdDescr = row.AccountIdDescr,
                Debit = row.Debit
            };
            _CustomerDepthViewModel.Add(newsup);
            InitializeComponent();
            LoadGrid();
            ChangeStyleOfGrid(dgvCustomerEdit);
            dgvCustomerEdit.Columns[0].ReadOnly = true;
        }
        private void LoadGrid()
        {
            if (_CustomerDepthViewModel == null)
            {
                _CustomerDepthViewModel = new List<CustomerDepthViewModel>();
            }
            CustomerEditBindingSource.DataSource = _CustomerDepthViewModel;
            dgvCustomerEdit.DataSource = CustomerEditBindingSource;
        }
        void ChangeStyleOfGrid(DataGridView dataGridView)
        {
            dataGridView.Refresh();
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dataGridView.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dgvCustomerEdit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgvCustomerEdit.CurrentCell.ColumnIndex;
            string headerText = dgvCustomerEdit.Columns[column].Name;

            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("Debit"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }
        protected override void btOk_Click(object sender, EventArgs e)
        {
            try
            {
                base.btOk_Click(sender, e);
            }
            catch (Exception)
            {
                return;
            }
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                context.EntryMasters.FirstOrDefault(x => x.Id == mydetail.EntryMasterId).TotalCredit = Convert.ToDouble(dgvCustomerEdit.CurrentRow.Cells[1].Value);
                context.EntryMasters.FirstOrDefault(x => x.Id == mydetail.EntryMasterId).TotalDebit = Convert.ToDouble(dgvCustomerEdit.CurrentRow.Cells[1].Value);
                context.EntryDetails.Where(x => x.EntryMasterId == mydetail.EntryMasterId).FirstOrDefault(x => x.Credit != 0).Credit = Convert.ToDouble(dgvCustomerEdit.CurrentRow.Cells[1].Value);
                context.EntryDetails.Where(x => x.EntryMasterId == mydetail.EntryMasterId).FirstOrDefault(x => x.Debit != 0).Debit = Convert.ToDouble(dgvCustomerEdit.CurrentRow.Cells[1].Value);

                context.SaveChanges();
                _MessageBoxDialog.Show("تم تعديل الدين بنجاح", MessageBoxState.Done);
                this.Dispose();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }
        }
    }
}
