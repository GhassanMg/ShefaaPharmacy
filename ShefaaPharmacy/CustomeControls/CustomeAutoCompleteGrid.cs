using DataLayer;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.CustomeControls
{
    public partial class CustomeAutoCompleteGrid : Form
    {
        public CustomeAutoCompleteGrid()
        {
            InitializeComponent();
        }
        public void RefreshData(string data)
        {
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            var splitData = data.Split(' ');
            var queryable = context.Articles.ToList();
            foreach (var f in splitData)
            {
                queryable = queryable.Where(u => u.Name.Contains(f)).ToList();
            }
            bsQueryArticle.DataSource = queryable.Select(x=>x.Name);
            dgvQueryArticle.DataSource = bsQueryArticle;
            dgvQueryArticle.AutoGenerateColumns = true;
        }
        
        private void dgvQueryArticle_BindingContextChanged(object sender, EventArgs e)
        {
            dgvQueryArticle.Refresh();
        }
        public void ShowGrid(int x, int y)
        {
            this.Location = new Point(x, y);
            this.Visible = true;
        }
        public void HideGrid()
        {
            this.Visible = false;
        }

        private void dgvQueryArticle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvQueryArticle.AutoGenerateColumns = true;
        }
    }
}
