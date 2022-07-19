using DataLayer.Tables;
using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DataLayer;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;

namespace ShefaaPharmacy.Articles
{
    public partial class PriceTagEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        PriceTagMaster _PriceTagMaster;
        Article _Article;
        string[] hiddenDetail = new string[] { "Id", "CreationByDescr", "CreationDate", "PriceTagId", "UnitId" };


        public PriceTagEditForm()
        {
            InitializeComponent();
            HiddenColumn = new string[] { "Id", "CreationByDescr", "CreationDate", "ArticleId", "BranchId", "BranchIdDescr", "UnitId", };
            List<PriceTagMaster> priceTagMasters = new List<PriceTagMaster>();
            List<PriceTagDetail> priceTagDetails = new List<PriceTagDetail>();
            bsMaster.DataSource = priceTagMasters;
            bsDetail.DataSource = priceTagDetails;
            dgDetail.AutoGenerateColumns = true;
            dgMaster.AutoGenerateColumns = true;
            dgDetail.Refresh();
            dgMaster.Refresh();
        }
        public PriceTagEditForm(Article article)
        {

            InitializeComponent();
            //var firstpricetag= ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters
            base.HiddenColumn = new string[] { "Id", "CreationByDescr", "CreationDate", "ArticleId", "BranchId", "BranchIdDescr", "UnitId", };
            dgDetail.AutoGenerateColumns = true;
            dgMaster.AutoGenerateColumns = true;
            _Article = article;
            if (_Article != null)
            {
                tbArticleName.Text = _Article.Name;
                List<PriceTagMaster> priceTagMasters = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == _Article.Id).Include(x => x.PriceTagDetails).ToList();
                bsMaster.DataSource = priceTagMasters;
                dgMaster.Refresh();
                
            }

        }

        private void LbArticleName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Article result = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
            if (result != null)
            {
                tbArticleName.Text = result.Name;
                _Article = result;
                List<PriceTagMaster> priceTagMasters = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == result.Id).Include(x => x.PriceTagDetails).ToList();
                if (priceTagMasters.Count >= 1)
                {
                    bsMaster.DataSource = priceTagMasters;
                    dgMaster.Refresh();
                    dgMaster.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                    dgMaster.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Gold;
                }
                else
                {
                    _MessageBoxDialog.Show("لا يوجد بطاقات سعر يجب تعريف بطاقة", MessageBoxState.Warning);
                    PriceTagMaster priceTagMasterResult = NewPriceTag.CreateNewPrice(_Article.Id);
                    if (priceTagMasterResult != null && priceTagMasterResult.Id != 0)
                    {
                        _MessageBoxDialog.Show("تم تعريف بطاقة سعر جديدة", MessageBoxState.Done);
                        priceTagMasters = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == result.Id).Include(x => x.PriceTagDetails).ToList();
                        bsMaster.DataSource = priceTagMasters;
                        dgMaster.Refresh();
                    }
                }
                
            }
        }

        private void BsMaster_PositionChanged(object sender, EventArgs e)
        {
            if (bsMaster.Current == null)
                return;
            LoadDetail(bsMaster.Current as PriceTagMaster);
        }
        private void LoadDetail(PriceTagMaster priceTagMaster)
        {
            if (priceTagMaster == null || priceTagMaster.Id == 0 || priceTagMaster.PriceTagDetails == null)
            {
                return;
            }
            else if (priceTagMaster.PriceTagDetails.Count > 0)
            {
                dgMaster.Refresh();
                bsDetail.DataSource = priceTagMaster.PriceTagDetails;
                dgDetail.Refresh();
            }
        }

        private void DgMaster_BindingContextChanged(object sender, EventArgs e)
        {
            dgMaster.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgMaster.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgMaster.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgMaster.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgMaster.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgMaster.Columns != null)
            {
                ShowColumn(dgMaster.Columns);
            }
            if (dgMaster.Rows.Count >= 1)
            {
                dgMaster.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                dgMaster.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Gold;
            }
            dgMaster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgMaster.Refresh();
        }

        private void DgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (dgDetail.Columns != null)
            {
                ShowColumn(dgDetail.Columns, hiddenDetail);
            }
            dgDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgDetail.Refresh();
        }

        private void BsMaster_DataSourceChanged(object sender, EventArgs e)
        {
            ShowColumn(dgMaster.Columns);
            dgMaster.Refresh();
        }

        private void BsDetail_DataSourceChanged(object sender, EventArgs e)
        {
            ShowColumn(dgDetail.Columns, hiddenDetail);
            dgMaster.Refresh();
        }

        private void PriceTagEditForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void miAddNewPriceTag_Click(object sender, EventArgs e)
        {
            if (dgMaster.CurrentRow != null && _Article != null && _Article.Id != 0)
            {
                PriceTagMaster priceTagMasterResult = NewPriceTag.CreateNewPrice(_Article.Id);
                if (priceTagMasterResult != null && priceTagMasterResult.Id != 0)
                {
                    _MessageBoxDialog.Show("تم تعريف بطاقة سعر جديدة", MessageBoxState.Done);
                    List<PriceTagMaster> priceTagMasters = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == _Article.Id).Include(x => x.PriceTagDetails).ToList();
                    bsMaster.DataSource = priceTagMasters;
                    dgMaster.Refresh();
                }
            }
        }
        private void RefreshGrid()
        {
            List<PriceTagMaster> priceTagMasters = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == _Article.Id).Include(x => x.PriceTagDetails).ToList();

            LoadDetail(bsMaster.Current as PriceTagMaster);
        }
        private void miEditPriceTagDetail_Click(object sender, EventArgs e)
        {
            if (dgDetail.CurrentRow != null && _Article != null && _Article.Id != 0)
            {
                PriceTagDetailEditForm.EditNewPrice(_Article.Id, dgDetail.CurrentRow.DataBoundItem as PriceTagDetail);
                LoadDetail(bsMaster.Current as PriceTagMaster);
            }
        }
        private void LoadMaster(Article art)
        {
            List<PriceTagMaster> priceTagMasters = ShefaaPharmacyDbContext.GetCurrentContext().PriceTagMasters.Where(x => x.ArticleId == art.Id).Include(x => x.PriceTagDetails).ToList();
            if (priceTagMasters.Count >= 1)
            {
                bsMaster.DataSource = priceTagMasters;
                dgMaster.Refresh();
                dgMaster.Rows[0].DefaultCellStyle.BackColor = Color.Gold;
                dgMaster.Rows[0].DefaultCellStyle.SelectionBackColor = Color.Gold;
            }
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if ( _Article != null && _Article.Id != 0)
                {
                    NewPriceTag frm = new NewPriceTag(_Article.Id,(dgMaster.Rows[0].DataBoundItem as PriceTagMaster).Id,0);
                    frm.ShowDialog();
                    LoadMaster(_Article);
                    LoadDetail(bsMaster.Current as PriceTagMaster);
                }
            }
            catch
            {
                _MessageBoxDialog.Show("يرجى تحديد سطر البطاقة المراد تعديلها", MessageBoxState.Done);
                return;
            }
        }
    }
}
