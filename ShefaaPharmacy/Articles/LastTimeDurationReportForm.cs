using DataLayer;
using DataLayer.Services;
using DataLayer.Tables;
using DataLayer.ViewModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class LastTimeDurationReportForm : GeneralUI.AbstractForm
    {
        public List<LastTimeArticles> _AllLastTimeArticales { get; set; }
        public List<FullPriceViewModel> _FullTotalPrice { get; set; }

        public LastTimeDurationReportForm()
        {
            InitializeComponent();

            LoadGrid();
            dgMaster.AutoGenerateColumns = true;
            dgDetail.AutoGenerateColumns = true;
            var count = ShefaaPharmacyDbContext.GetCurrentContext().Articles.ToList().Count();
            if (count > 0)
            {
                ArticleService.BindLastTimeArticlesToToDB();
                LoadMaster();
                LoadDetail();
            }
            WindowState = FormWindowState.Maximized;
        }
        private void LoadGrid()
        {
            if (_AllLastTimeArticales == null)
            {
                _AllLastTimeArticales = new List<LastTimeArticles>();
            }
            if (_FullTotalPrice == null)
            {
                _FullTotalPrice = new List<FullPriceViewModel>();
            }

            bindingSourceMaster.DataSource = _AllLastTimeArticales;
            dgMaster.DataSource = bindingSourceMaster;

            bindingSourceDetail.DataSource = _FullTotalPrice;
            dgDetail.DataSource = bindingSourceDetail;
        }

        private void LoadMaster()
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<LastTimeArticles> LastTimeArts = context.LastTimeArticles.ToList();
            bindingSourceMaster.DataSource = LastTimeArts;
            dgMaster.Refresh();
        }

        private void LoadDetail()
        {
            FullPriceViewModel FullPrice = new FullPriceViewModel();

            foreach (LastTimeArticles myrow in bindingSourceMaster)
            {
                FullPrice.FullPrice += myrow.TotalPrice;
            }
            bindingSourceDetail.DataSource = FullPrice;
            dgDetail.Refresh();
        }
        private void dgMaster_BindingContextChanged(object sender, EventArgs e)
        {
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.Refresh();
        }
        private void dgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.Refresh();
        }

        private void dgMaster_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgMaster.Columns["ID"].Visible = false;
            dgMaster.Columns["CreationByDescr"].Visible = false;
        }
    }
}
