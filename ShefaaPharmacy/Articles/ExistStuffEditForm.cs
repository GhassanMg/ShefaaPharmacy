using DataLayer;
using DataLayer.Tables;
using DataLayer.ViewModels;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class ExistStuffEditForm : GeneralUI.GeneralEditForm
    {
        EntryDetail Mydetail = new EntryDetail();
        ExistStuffViewModel mystuff = new ExistStuffViewModel();
        public List<ExistStuffViewModel> _ExistStuffViewModel { get; set; }
        public string Description { get; set; }
        public double Count { get; set; }
        public double Price { get; set; }

        public ExistStuffEditForm()
        {
            InitializeComponent();
        }
        public ExistStuffEditForm(ExistStuffViewModel myrow,EntryDetail detail)
        {
            InitializeComponent();
            LoadGrid();
            ChangeStyleOfGrid(dgvEditStuff);
            dgvEditStuff.Columns[0].ReadOnly = true;
            EditBindingSource.DataSource = myrow;
            //dgvArticles.Rows.Add(k);
            dgvEditStuff.Refresh();
            Description = myrow.Description;
            Count = myrow.Count;
            Price = myrow.Price;
            mystuff = myrow;
            Mydetail = detail;
        }
        private void LoadGrid()
        {
            if (_ExistStuffViewModel == null)
            {
                _ExistStuffViewModel = new List<ExistStuffViewModel>();
            }

            EditBindingSource.DataSource = _ExistStuffViewModel;
            dgvEditStuff.DataSource = EditBindingSource;
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

        private void dgvEditStuff_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgvEditStuff.CurrentCell.ColumnIndex;
            string headerText = dgvEditStuff.Columns[column].Name;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("Price") || headerText.Equals("Count"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
                UpdateStuff(EditBindingSource.DataSource as ExistStuffViewModel);
                UpdateEntry();
                _MessageBoxDialog.Show("تم تعديل الموجودات بنجاح", MessageBoxState.Done);
                this.Dispose();
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show("حصل خطأ أثناء التخزين" + "...." + ex.Message, MessageBoxState.Error);
            }

        }
        private void UpdateStuff(ExistStuffViewModel mylist)
        {
            SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("update ExistStuff set Count = '" + mylist.Count + "' , Price='" + mylist.Price + "',Description='" + mylist.Description + "' WHERE name ='" + mylist.Name + "'and Count='" + Count + "'and Price='" + Price + "'", con);
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void UpdateEntry()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            context.EntryMasters.FirstOrDefault(x => x.Id == Mydetail.EntryMasterId).TotalCredit = Convert.ToDouble(dgvEditStuff.CurrentRow.Cells[2].Value);
            context.EntryMasters.FirstOrDefault(x => x.Id == Mydetail.EntryMasterId).TotalDebit = Convert.ToDouble(dgvEditStuff.CurrentRow.Cells[2].Value);
            context.EntryDetails.Where(x => x.Id == Mydetail.Id).FirstOrDefault(x => x.Debit != 0).Debit = Convert.ToDouble(dgvEditStuff.CurrentRow.Cells[2].Value);
            context.EntryDetails.Where(x => x.Id == Mydetail.Id-1).FirstOrDefault(x => x.Credit != 0).Credit = Convert.ToDouble(dgvEditStuff.CurrentRow.Cells[2].Value);
            context.SaveChanges();
        }
    }
}
