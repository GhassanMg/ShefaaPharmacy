using DataLayer;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class FirstTimeSupplierEditForm : GeneralUI.GeneralEditForm
    {
        public List<SupplierDepthViewModel> _SupplierDepthViewModel = new List<SupplierDepthViewModel>();
        SupplierDepthViewModel newsup = new SupplierDepthViewModel();
        EntryDetail mydetail = new EntryDetail();
        public FirstTimeSupplierEditForm()
        {
            InitializeComponent();
        }
        public FirstTimeSupplierEditForm(EntryDetail row)
        {
            mydetail = row;
            newsup = new SupplierDepthViewModel
            {
                AccountId = row.AccountId,
                AccountIdDescr = row.AccountIdDescr,
                Credit = row.Credit
            };
            _SupplierDepthViewModel.Add(newsup);
            InitializeComponent();
            ChangeStyleOfGrid(dgvSupllierEdit);
            LoadGrid();
            dgvSupllierEdit.Columns[0].ReadOnly = true;
        }
        private void LoadGrid()
        {
            if (_SupplierDepthViewModel == null)
            {
                _SupplierDepthViewModel = new List<SupplierDepthViewModel>();
            }
            SupplierEditBindingSource.DataSource = _SupplierDepthViewModel;
            dgvSupllierEdit.DataSource = SupplierEditBindingSource;
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
                context.EntryMasters.FirstOrDefault(x => x.Id == mydetail.EntryMasterId).TotalCredit = Convert.ToDouble(dgvSupllierEdit.CurrentRow.Cells[1].Value);
                context.EntryMasters.FirstOrDefault(x => x.Id == mydetail.EntryMasterId).TotalDebit = Convert.ToDouble(dgvSupllierEdit.CurrentRow.Cells[1].Value);
                context.EntryDetails.Where(x => x.EntryMasterId == mydetail.EntryMasterId).FirstOrDefault(x => x.Credit != 0).Credit = Convert.ToDouble(dgvSupllierEdit.CurrentRow.Cells[1].Value);
                context.EntryDetails.Where(x => x.EntryMasterId == mydetail.EntryMasterId).FirstOrDefault(x => x.Debit != 0).Debit = Convert.ToDouble(dgvSupllierEdit.CurrentRow.Cells[1].Value);

                context.SaveChanges();
                _MessageBoxDialog.Show("تم تعديل الدين بنجاح", MessageBoxState.Done);
                this.Dispose();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }
        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void dgvSupllierEdit_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgvSupllierEdit.CurrentCell.ColumnIndex;
            string headerText = dgvSupllierEdit.Columns[column].Name;

            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("Credit"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }
    }
}
