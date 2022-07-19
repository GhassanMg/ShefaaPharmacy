using DataLayer;
using DataLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
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

namespace ShefaaPharmacy.Desktop
{
    public partial class WarningDesktop : UserControl
    {
        public WarningDesktop()
        {
            InitializeComponent();
        }
        public void ArticleWarning()
        {
            DataTable result = DataBaseService.ExecStoredProcedure(ShefaaPharmacyDbContext.GetCurrentContext().Database.GetDbConnection(),
                                                "GetArticleInStore",
                                                null);
            List<ArticleExpiryDay> resultReport = DataBaseService.ConvertDataTable<ArticleExpiryDay>(result);
            if (resultReport != null)
            {
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = resultReport;
                dataGridView1.DataSource = bindingSource;
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

                dataGridView1.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
                dataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Refresh();
            }
        }
    }
}
