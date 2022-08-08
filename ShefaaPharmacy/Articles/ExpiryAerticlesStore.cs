using DataLayer;
using DataLayer.Services;
using DataLayer.StoredProcedures;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class ExpiryAerticlesStore : AbstractForm
    {
        public List<ExpiryArticlesViewModel> _ExpiryArticlesViewModels { get; set; }
        List<PriceTagMaster> mylist = new List<PriceTagMaster>();
        public ExpiryAerticlesStore()
        {
            InitializeComponent();
        }
        private void LoadGrid()
        {
            if (_ExpiryArticlesViewModels == null)
            {
                _ExpiryArticlesViewModels = new List<ExpiryArticlesViewModel>();
            }
            bindingSourceMaster.DataSource = _ExpiryArticlesViewModels;
            dgMaster.DataSource = bindingSourceMaster;
            LoadAllExpiryArticles();
        }
        private void ExpiryAerticlesStore_Load(object sender, EventArgs e)
        {
            LoadGrid();
            ChangeStyleOfGrid(dgMaster);
            if (dgMaster.Rows.Count == 0)
            {
                lblCenter.Visible = true;
            }
            else
            {
                lblCenter.Visible = false;
            }
        }
        private void LoadAllExpiryArticles()
        {
            GetExpiredArticle();
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
        void EditGridStyle()
        {
            dgMaster.Columns.OfType<DataGridViewColumn>().ToList().ForEach(col => col.Visible = false);
            dgMaster.Columns["Id"].Visible = true;
            dgMaster.Columns["ArticleIdDescr"].Visible = true;
            dgMaster.Columns["UnitIdDescr"].Visible = true;
            dgMaster.Columns["CountAllItem"].Visible = true;
            dgMaster.Columns["ExpiryDate"].Visible = true;

            dgMaster.Columns["ArticleIdDescr"].HeaderText = "اسم المنتج";
            dgMaster.Columns["UnitIdDescr"].HeaderText = "الواحدة";
            dgMaster.Columns["CountAllItem"].HeaderText = "الكمية المتبقية";
            dgMaster.Columns["ExpiryDate"].HeaderText = "تاريخ انتهاء الصلاحية";
            dgMaster.Columns.Add("LeftDays", "الأيام المتبقية");

            dgMaster.Columns["UnitIdDescr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["CountAllItem"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgMaster.Columns["LeftDays"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

        }

        private void GetExpiredArticle()
        {
            try
            {
                SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);
                con.Open();
                SqlCommand cmd = new SqlCommand("select ArticleIdDescr as الصنف,UnitIdDescr as الواحدة,TransQuantity as [الكمية المحولة في المخزن] ,ExpiryDate as [تاريخ انتهاء الصلاحية] from ExpiryTransfeerDetail order by ArticleIdDescr asc", con);
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();
                da.Fill(ds, "FirstTimeArticles");
                bindingSourceMaster.DataSource = ds.Tables["FirstTimeArticles"];
                dgMaster.Refresh();
            }
            catch
            {
                dgMaster.Rows.Clear(); dgMaster.Columns.Clear();
                _MessageBoxDialog.Show("لا يوجد مواد محولة في المخزن", MessageBoxState.Warning);
                this.Close();
            }
        }
        private void CheckLeftDays()
        {
            int Ldays = 0;
            foreach (DataGridViewRow MyRow in dgMaster.Rows)
            {
                Ldays = (int)(Convert.ToDateTime(MyRow.Cells["ExpiryDate"].Value) - DateTime.Now).TotalDays;
                if (Ldays <= 0)
                {
                    dgMaster.Rows[MyRow.Index].Cells["LeftDays"].Value = 0;
                    dgMaster.Rows[MyRow.Index].Cells["LeftDays"].Style.BackColor = Color.Red;
                }
                else
                {
                    dgMaster.Rows[MyRow.Index].Cells["LeftDays"].Value = Ldays;
                    dgMaster.Rows[MyRow.Index].Cells["LeftDays"].Style.BackColor = Color.Orange;
                }
            }
            dgMaster.Refresh();
        }
    }
}
