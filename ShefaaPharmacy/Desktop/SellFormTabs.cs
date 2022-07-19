using DataLayer;
using DataLayer.Enums;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Articale;
using ShefaaPharmacy.Articles;
using ShefaaPharmacy.CustomeControls;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Grid;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShefaaPharmacy.Desktop
{
    public partial class SellFormTabs : UserControl
    {
        public static GeneralInvoiceEditForm[] EazyForms;
        public static CustomeAutoCompleteGrid customeAutoCompleteGrid;
        //public ArticlePickGrid ArticlePickGrid;
        public SellFormTabs()
        {
            InitializeComponent( );
        }
        public void LoadTabs()
        {
            //var arts = ShefaaPharmacyDbContext.GetCurrentContext().Articles.ToListAsync();
            //arts.Add(new Article() { Name = "" });
            //arts = arts.OrderBy(x => x.Name).ToList();
            dgvQueryArticle.CellDoubleClick += DgvQueryArticle_CellDoubleClick;
            dgvQueryArticle.KeyDown += DgvQueryArticle_KeyDown;
            customeAutoCompleteGrid = new CustomeAutoCompleteGrid();
            EazyForms = new GeneralInvoiceEditForm[6];
        }

        private void DgvQueryArticle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            Article article = ((Article)dgvQueryArticle.CurrentRow.DataBoundItem);
            if (article.Id != 0)
            {
                if (article.ItsGeneral)
                {
                    Article result = ArticlePicker.PickArticale("", (int)article.ArticleIdGeneral, FormOperation.Pick);
                    if (result != null)
                    {
                        EazyForms[tcSell.SelectedIndex].AddArticle(article);
                        EazyForms[tcSell.SelectedIndex].dgDetail.Refresh();
                    }
                }
                else
                {
                    //article.PriceTags = ShefaaPharmacyDbContext.GetCurrentContext().PriceTags.Where(x => x.ArticaleId == article.Id).ToList();
                    EazyForms[tcSell.SelectedIndex].AddArticle(article);
                    EazyForms[tcSell.SelectedIndex].dgDetail.Refresh();
                }
            }
            HideGrid();
        }

        public void assinged()
        {
            EazyForms[0] = new GeneralInvoiceEditForm(new BillMaster(), InvoiceKind.Sell, FormOperation.New, true);
            tp1.Controls.Add(EazyForms[0]);
            EazyForms[0].Show();
        }

        private void tcSell_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void tcSell_Selected(object sender, TabControlEventArgs e)
        {
            if (EazyForms[e.TabPageIndex] == null)
            {
                EazyForms[e.TabPageIndex] = new GeneralInvoiceEditForm(new BillMaster(), InvoiceKind.Sell, FormOperation.New, true);
            }
            e.TabPage.Controls.Add(EazyForms[e.TabPageIndex]);
            EazyForms[e.TabPageIndex].Show();
        }

        private void pDeleteRow_Click(object sender, EventArgs e)
        {
            EazyForms[tcSell.SelectedIndex].DeleteRow();
        }

        private void pDecreseQuantity_Click(object sender, EventArgs e)
        {
            EazyForms[tcSell.SelectedIndex].DecreseQuantity();
        }

        private void pIncreseQuantity_Click(object sender, EventArgs e)
        {
            EazyForms[tcSell.SelectedIndex].InecreseQuantity();
        }

        private void EditBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
        }
        private void tbSearchArticle_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearchArticle.Text))
            {
                bsQueryArticle.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => !x.ItsGeneral).Take(10).ToList();
                dgvQueryArticle.DataSource = bsQueryArticle;
                dgvQueryArticle.AutoGenerateColumns = true;
            }
            else
            {
                RefreshData(tbSearchArticle.Text);
            }
            ShowGrid(tbSearchArticle.Location.X, tbSearchArticle.Location.Y + tbSearchArticle.Height + 1);
        }
        public void RefreshData(string data)
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            var splitData = data.Split(' ');
            var queryable = context.Articles.ToList();
            foreach (var key in splitData)
            {
                queryable = queryable
                    .Where(u => (!String.IsNullOrEmpty(u.Name) && u.Name.ToLower().Contains(key.ToLower()))
                            ||
                                (!String.IsNullOrEmpty(u.EnglishName) && u.EnglishName.ToLower().Contains(key.ToLower()))
                            ||
                                (!String.IsNullOrEmpty(u.Barcode) && u.Barcode.ToLower().Contains(key.ToLower()))
                ).ToList();
            }
            bsQueryArticle.DataSource = queryable;
            dgvQueryArticle.DataSource = bsQueryArticle;
            dgvQueryArticle.AutoGenerateColumns = true;
        }
        private void dgvQueryArticle_BindingContextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn item in dgvQueryArticle.Columns)
            {
                if (item.Name == "Name" || item.Name == "EnglishName")
                {
                    item.Visible = true;
                }
                else
                    item.Visible = false;
            }
            dgvQueryArticle.Refresh();
        }
        private void DgvQueryArticle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            Article article = ((Article)dgvQueryArticle.Rows[e.RowIndex].DataBoundItem);
            if (article.Id != 0)
            {
                if (article.ItsGeneral)
                {
                    Article result = ArticlePicker.PickArticale("", (int)article.ArticleIdGeneral, FormOperation.Pick);
                    if (result != null)
                    {
                        EazyForms[tcSell.SelectedIndex].AddArticle(article);
                        EazyForms[tcSell.SelectedIndex].dgDetail.Refresh();
                    }
                }
                else
                {
                    //article.PriceTags = ShefaaPharmacyDbContext.GetCurrentContext().PriceTags.Where(x => x.ArticaleId == article.Id).ToList();
                    EazyForms[tcSell.SelectedIndex].AddArticle(article);
                    EazyForms[tcSell.SelectedIndex].dgDetail.Refresh();
                }
            }
            HideGrid();
        }
        public void ShowGrid(int x, int y)
        {
            dgvQueryArticle.Location = new Point(x, y);
            dgvQueryArticle.Visible = true;
            dgvQueryArticle.BackgroundColor = Color.White;

            dgvQueryArticle.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvQueryArticle.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgvQueryArticle.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgvQueryArticle.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgvQueryArticle.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvQueryArticle.BringToFront();
        }
        public void HideGrid()
        {
            dgvQueryArticle.Visible = false;
        }
        private void SellFormTabs_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (((TextBox)sender).Name != "tbSearchArticle" && ((DataGridView)sender).Name != "dgvQueryArticle")
                {
                    HideGrid();
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void tbSearchArticle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                HideGrid();
            }
            else if (e.KeyCode == Keys.Enter && dgvQueryArticle.Visible)
            {
                DgvQueryArticle_KeyDown(sender, e);
            }
        }

        private void tp2_Click(object sender, EventArgs e)
        {

        }
    }
}
