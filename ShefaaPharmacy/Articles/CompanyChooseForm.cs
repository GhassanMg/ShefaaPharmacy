using DataLayer;
using DataLayer.ViewModels;
using Newtonsoft.Json;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class CompanyChooseForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        public CompanyChooseForm()
        {
            InitializeComponent();

        }
        string GetStatus;
        public bool isloading = false;
        private void CompanyChooseForm_Load(object sender, EventArgs e)
        {
            tbSearch.ForeColor = Color.Gray;

            ChangeStyleOfGrid(datagridcompane);
            ChangeFontForAll();
            button2.Enabled = false;

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
        public void ChangeFontForAll()
        {
            button1.Font = button2.Font = CheckCompanies.Font = lblLoading.Font = label1.Font = radioButton1.Font = radioButton2.Font = new Font("El Messiri SemiBold", 10);
        }
        private void ThreadJob()
        {
            Thread.Sleep(2000);

            this.Invoke((MethodInvoker)delegate
            {
                GetCompanies();
            });
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (GetStatus == "offline" || GetStatus == "online")
            {
                pcloader.Visible = true;
                lblLoading.Visible = true;
                Thread t = new Thread(new ThreadStart(ThreadJob));
                t.IsBackground = true;
                t.Start();
                button2.Enabled = true;
            }
            else
            {
                pcloader.Visible = false;
                lblLoading.Visible = false;
                _MessageBoxDialog.Show("يجب تحديد نوع العملية", MessageBoxState.Error);
                return;
            }
        }
        private void GetCompanies()
        {
            pcloader.Visible = true;
            lblLoading.Visible = true;
            ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            CompanyApiViewModel mycomp = new CompanyApiViewModel();
            List<CompanyApiViewModel> mylist = new List<CompanyApiViewModel>();
            datagridcompane.Columns.Clear();
            datagridcompane.DataSource = null;

            if (GetStatus == "online")
            {
                mylist = GetRESTData("http://lamsetshefaa-desktop.lamsetshefaa.com/api/company/all").data;

                datagridcompane.DataSource = mylist.OrderByDescending(r => r.Name).ToList();
                datagridcompane.Columns[0].ReadOnly = true;
                pcloader.Visible = false;
                lblLoading.Visible = false;
                datagridcompane.Refresh();
                CheckCompanies.Enabled = true;
            }

            else if (GetStatus == "offline")
            {
                SqlConnection con = new SqlConnection(ShefaaPharmacyDbContext.ConStr);//connection name

                SqlCommand cmd = new SqlCommand("select distinct company as الشركة from Medicines order by company Desc ", con);
                con.Open();
                //    ==========
                var Count = context.Medicines.Count();
                
                //    ==========
                cmd.CommandType = CommandType.Text;

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataSet ds = new DataSet();

                da.Fill(ds, "Medicines");

                if (Count == 0)
                {
                    pcloader.Visible = false;
                    lblLoading.Visible = false;
                    if (_MessageBoxDialog.Show("لايوجد مواد جاهزة للاستيراد..يرجى تحديد مسار ملف الاكسيل", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                    {
                        SetExcelPath frm = new SetExcelPath();
                        frm.ShowDialog();
                        GetCompanies();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    datagridcompane.DataSource = ds.Tables["Medicines"];
                    datagridcompane.Columns[0].ReadOnly = true;
                    try
                    {
                        DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn();
                        checkBoxColumn.HeaderText = "استيراد";
                        checkBoxColumn.Width = 30;
                        checkBoxColumn.Name = "Checked";
                        datagridcompane.Columns.Insert(1, checkBoxColumn);
                    }
                    catch
                    {

                    }
                    pcloader.Visible = false;
                    lblLoading.Visible = false;
                    datagridcompane.Refresh();
                    CheckCompanies.Enabled = true;
                }
            }
        }
        private ApiResponseViewModel<CompanyApiViewModel> GetRESTData(string uri)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(uri);
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            var x = JsonConvert.DeserializeObject<ApiResponseViewModel<CompanyApiViewModel>>(s);
            return x;
        }
        private async void Upload(string actionUrl)
        {
            if (datagridcompane.RowCount <= 0)
            {
                return;
            }
            List<string> companys = new List<string>();
            MultipartFormDataContent formContent = new MultipartFormDataContent();
            int i = 0;
            foreach (var item in datagridcompane.DataSource as List<CompanyApiViewModel>)
            {
                if (item.Checked)
                {
                    formContent.Add(new StringContent(item.Name), "company_names[" + i + "]");
                    i++;
                }
            }
            if (i == 0)
            {
                _MessageBoxDialog.Show("لم يتم اختيار شركة", MessageBoxState.Warning);
                pcloader.Visible = false;
                lblLoading.Visible = false;
                return;
            }
            var myHttpClient = new HttpClient();
            var response = await myHttpClient.PostAsync(actionUrl.ToString(), formContent);
            string stringContent = await response.Content.ReadAsStringAsync();
            var x = JsonConvert.DeserializeObject<ApiResponseViewModel<ArticleApiViewModel>>(stringContent);
            lblLoading.Visible = pcloader.Visible = false;
            this.Close();
            NewImportArticlesOnline frm = new NewImportArticlesOnline(x.data);
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pcloader.Visible = true;
            lblLoading.Visible = true;

            if (GetStatus == "online")
            {
                Upload("http://lamsetshefaa-desktop.lamsetshefaa.com/api/articles/by/company-names");
            }
            else
            {
                int CompsCount = 0;
                List<string> Comps = new List<string>();

                foreach (DataGridViewRow item in datagridcompane.Rows)
                {
                    if (Convert.ToBoolean(item.Cells["Checked"].Value))
                    {
                        Comps.Add(item.Cells["الشركة"].Value.ToString());
                        CompsCount++;
                    }
                }
                if (CompsCount == 0)//اي انه لم يتم تحديد شركة
                {
                    _MessageBoxDialog.Show("لم يتم اختيار شركة", MessageBoxState.Warning);
                    pcloader.Visible = false;
                    lblLoading.Visible = false;
                }
                else
                {
                    pcloader.Visible = false;
                    lblLoading.Visible = false;

                    NewImportArticlesOnline frm = new NewImportArticlesOnline(Comps);
                    frm.ShowDialog();
                    this.TopMost = false;
                }
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            GetStatus = "online";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GetStatus = "offline";
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            //if(tbSearch.Text== "أدخل اسم الشركة كاملا")
            //tbSearch.Clear();
            if (GetStatus == "offline")
            {
                try
                {
                    BindingSource bs = new BindingSource();
                    bs.DataSource = datagridcompane.DataSource;
                    bs.Filter = datagridcompane.Columns["الشركة"].HeaderText.ToString().ToUpper() + " LIKE '%" + tbSearch.Text.ToUpper() + "%'";
                    datagridcompane.DataSource = bs;
                    datagridcompane.Refresh();
                }
                catch (Exception ex)
                {
                    ;
                }
            }
            if (GetStatus == "online")
            {
                datagridcompane.ClearSelection();
                foreach (DataGridViewRow row in datagridcompane.Rows)
                {
                    row.Selected = false;
                    if (row.Cells[0].Value.ToString().ToUpper().Contains(tbSearch.Text.ToUpper()))
                    {
                        row.Selected = true;
                        datagridcompane.FirstDisplayedScrollingRowIndex = row.Index;
                    }
                }
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckCompanies.Checked)
            {
                foreach (DataGridViewRow item in datagridcompane.Rows)
                {
                    item.Cells["Checked"].Value = 1;
                }
                datagridcompane.Refresh();
            }
            else
            {
                foreach (DataGridViewRow item in datagridcompane.Rows)
                {
                    item.Cells["Checked"].Value = 0;
                }
            }
        }
    }
}
