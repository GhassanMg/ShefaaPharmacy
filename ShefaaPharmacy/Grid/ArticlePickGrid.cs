using DataLayer;
using DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Grid
{
    public partial class ArticlePickGrid : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        DataLayer.Tables.Article article;
        public ArticlePickGrid()
        {
            InitializeComponent();
        }
        public ArticlePickGrid(Point point)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            Location = point;
            TopLevel = false;
            FormBorderStyle = FormBorderStyle.None;
            ShadowType = MetroFramework.Forms.MetroFormShadowType.None;
            pHelperButton.Visible = false;
            DisplayHeader = false;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            var result = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.Name.Contains("")).ToList();
            ArticleService.ListItemLeftInStore(result);
            bs.DataSource = result;
            dgArticle.DataSource = bs;
            ShowHideColumn();
        }
        private void ShowHideColumn()
        {
            for (int i = 0; i < dgArticle.Columns.Count; i++)
            {
                dgArticle.Columns[dgArticle.Columns[i].Name].Visible = false;
            }
            dgArticle.Columns["Name"].Visible = true;
            dgArticle.Columns["CountLeft"].Visible = true;
        }
        private void SetCurrentEntity()
        {
            article = (dgArticle.CurrentRow.DataBoundItem as DataLayer.Tables.Article);
        }
        public static DataLayer.Tables.Article Pick(string name, Point point)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<DataLayer.Tables.Article> arts = context.Articles.Where(x => x.Name.Contains(name)).ToList();
            ArticleService.ListItemLeftInStore(arts);
            ArticlePickGrid articlePickGrid = new ArticlePickGrid();
            articlePickGrid.bsArtcles.DataSource = arts;
            articlePickGrid.dgArticle.DataSource = articlePickGrid.bsArtcles;
            articlePickGrid.dgArticle.AllowUserToAddRows = false;
            articlePickGrid.dgArticle.AllowUserToDeleteRows = false;
            articlePickGrid.dgArticle.ReadOnly = true;
            articlePickGrid.ShowHideColumn();
            //articlePickGrid.tbSearch.Text = name;
            articlePickGrid.StartPosition = FormStartPosition.Manual;
            articlePickGrid.Location = point;
            articlePickGrid.ShowDialog();
            return articlePickGrid.article;
        }
        public void Filter(string word)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            List<DataLayer.Tables.Article> arts = context.Articles.Where(x => x.Name.Contains(word)).ToList();

            bsArtcles.DataSource = arts;
            dgArticle.DataSource = bsArtcles;
            ShowHideColumn();

        }
        private void dgAccount_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            SetCurrentEntity();
            Close();
        }

        private void dgAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = dgArticle.CurrentRow.Index;
                if (i < 0)
                {
                    return;
                }
                SetCurrentEntity();
                Close();
            }
        }
    }
}
