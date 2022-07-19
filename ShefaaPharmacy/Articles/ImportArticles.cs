using DataLayer;
using DataLayer.Helper;
using DataLayer.Services;
using DataLayer.Tables;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShefaaPharmacy.Articles
{
    public partial class ImportArticles : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        List<Article> SelectedArticles;
        List<ExcelArticleViewModel> excelArticleViewModels;
        string sFileName;
        DataTable fileExecl;
        bool save = false;
        public ImportArticles()
        {
            InitializeComponent();
        }

        private void pbAccountPick_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Excel File to Edit";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel File|*.xlsx;*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog1.FileName;
            }
            textBox1.Text = sFileName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(sFileName);
                Worksheet sheet = workbook.Worksheets[0];
                fileExecl = sheet.ExportDataTable();
                bsFileExcel.DataSource = fileExecl;
                dtFileExcel.AutoGenerateColumns = true;
                dtFileExcel.DataSource = bsFileExcel;
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "Checked";
                checkColumn.HeaderText = "إختيار";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.DisplayIndex = 0;
                dtFileExcel.Columns.Add(checkColumn);
                dtFileExcel.Refresh();
                SelectedArticles = new List<Article>();
                excelArticleViewModels = new List<ExcelArticleViewModel>();
                bsPick.DataSource = excelArticleViewModels;
                dgPick.AutoGenerateColumns = true;
                dgPick.DataSource = bsPick;
                dgPick.Refresh();
                button1.Enabled = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtFileExcel.DataSource;
                bs.Filter = dtFileExcel.Columns["Name"].HeaderText.ToString() + " LIKE '%" + tbSearch.Text + "%'";
                dtFileExcel.DataSource = bs;
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void dtFileExcel_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtFileExcel.DataSource != null)
            {
                if (e.ColumnIndex == dtFileExcel.Columns["Checked"].Index && e.RowIndex != -1)
                {
                    dtFileExcel.EndEdit();
                }
            }
        }

        private void dtFileExcel_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtFileExcel.Columns["Checked"].Index)
                {
                    var data = excelArticleViewModels.FirstOrDefault(x => x.Name == dtFileExcel["Name", e.RowIndex].Value.ToString());
                    if (dtFileExcel.CurrentCell.Value == null)
                    {
                        return;
                    }
                    bool isChecked = (bool)dtFileExcel.CurrentCell.Value;
                    if (isChecked)
                    {
                        if (data == null)
                        {
                            excelArticleViewModels.Add(new ExcelArticleViewModel()
                            {
                                Name = dtFileExcel["Name", e.RowIndex].Value.ToString(),
                                BuyPrice = Convert.ToDouble(dtFileExcel["BuyPrice", e.RowIndex].Value),
                                Caliber = dtFileExcel["Caliber", e.RowIndex].Value.ToString(),
                                CompanyName = dtFileExcel["CompanyName", e.RowIndex].Value.ToString(),
                                FormatName = dtFileExcel["FormatName", e.RowIndex].Value.ToString(),
                                LastUpdate = Convert.ToDateTime(dtFileExcel["LastUpdate", e.RowIndex].Value),
                                Selected = true,
                                SellPrice = Convert.ToDouble(dtFileExcel["SellPrice", e.RowIndex].Value),
                                Size = dtFileExcel["Size", e.RowIndex].Value.ToString(),
                                Barcode = dtFileExcel["Barcode", e.RowIndex].Value.ToString(),
                                ActiveIngredients = dtFileExcel["ActiveIngredients", e.RowIndex].Value.ToString()
                            }
                            );
                            dgPick.AutoGenerateColumns = true;
                            dgPick.DataSource = excelArticleViewModels.ToList();
                            dtFileExcel.Rows.RemoveAt(e.RowIndex);
                            dtFileExcel.Refresh();

                        }
                        else
                        {
                            dtFileExcel.CurrentCell.Value = true;
                            dtFileExcel.Refresh();
                        }
                    }
                    else
                    {
                        if (data != null)
                        {
                            excelArticleViewModels.Remove(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtFileExcel.DataSource;
                bs.Filter = dtFileExcel.Columns["CompanyName"].HeaderText.ToString() + " LIKE '%" + textBox2.Text + "%'";
                dtFileExcel.DataSource = bs;
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                save = true;
                lbSaveInDataBase.Visible = true;
                SelectedArticles = new List<Article>();
                foreach (var item in excelArticleViewModels)
                {
                    var rowFound = ShefaaPharmacyDbContext.GetCurrentContext().Articles.Where(x => x.Name == item.Name
                                     && x.Caliber == item.Caliber && x.FormatId == DescriptionFK.FormatExistsAndCreate(item.FormatName.ToString()).Id
                                     && x.Size == item.Size).FirstOrDefault();
                    if (rowFound != null)
                    {
                        string msg = String.Format("الصنف{0} موجود بقاعدة البيانات هل تريد تحديث السعر فقط", rowFound.Name);
                        if (_MessageBoxDialog.Show(msg, MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                        {
                            //var PriceT = new PriceTag()
                            //{
                            //    ArticaleId = rowFound.Id,
                            //    ExpiryDate = DateTime.Now.AddMonths(3),
                            //    UnitTypeId = 3,
                            //    BuyPrimary = Convert.ToDouble(item.BuyPrice),
                            //    SellPrimary = Convert.ToDouble(item.SellPrice),
                            //    Unit2TypeId = 1,
                            //    Unit3TypeId = 1,
                            //    QuentityOfPrimary = 0,
                            //    QuentityOfSecondary = 0,
                            //    BuySecondary = 0,
                            //    SellSecondary = 0,
                            //    BuyTertiary = 0,
                            //    SellTertiary = 0
                            //};
                            //var ontext = ShefaaPharmacyDbContext.GetCurrentContext();
                            ////ontext.PriceTags.Add(PriceT);
                            //ontext.SaveChanges();
                        }
                        continue;
                    }
                    SelectedArticles.Add(new Article()
                    {
                        Name = item.Name?.ToString() ?? "",
                        EnglishName = item.Name?.ToString() ?? "",
                        FormatId = DescriptionFK.FormatExistsAndCreate(item.FormatName?.ToString()).Id,
                        Size = item.Size?.ToString() ?? "",
                        Caliber = item.Caliber?.ToString() ?? "",
                        ArticleCategoryId = ConstantDataBase.APC_Drugs,
                        ItsGeneral = false,
                        CompanyId = DescriptionFK.GetCompanyAndCreate(item.CompanyName?.ToString()).Id,
                        Barcode = item.Barcode ?? "",
                        ActiveIngredients = item.ActiveIngredients?.ToString() ?? "",
                        //PriceTags = new List<PriceTag>()
                        //            {
                        //                new PriceTag()
                        //                {
                        //                    ExpiryDate = DateTime.Now.AddMonths(3),
                        //                    UnitTypeId = 3,
                        //                    BuyPrimary = Convert.ToDouble(item.BuyPrice),
                        //                    SellPrimary = Convert.ToDouble(item.SellPrice),
                        //                    Unit2TypeId = 1,
                        //                    Unit3TypeId = 1,
                        //                    QuentityOfPrimary = 0,
                        //                    QuentityOfSecondary = 0,
                        //                    BuySecondary = 0,
                        //                    SellSecondary = 0,BuyTertiary = 0 ,SellTertiary = 0
                        //                }
                        //            }
                    });
                }
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                context.Articles.UpdateRange(SelectedArticles);
                context.SaveChanges();
                _MessageBoxDialog.Show("تم حفظ البيانات", MessageBoxState.Done);
                dgPick.DataSource = new List<ExcelArticleViewModel>();
                dgPick.Refresh();
                lbSaveInDataBase.Visible = false;
            }
            catch (Exception Ex)
            {
                _MessageBoxDialog.Show(Ex.Message.ToString(), MessageBoxState.Error);
                lbSaveInDataBase.Visible = false;
            }
        }
        private void llImportFilterd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var bin = (dtFileExcel.DataSource) as BindingSource;
            if (bin.Count > 0)
            {
                foreach (DataRowView item in bin.List)
                {
                    try
                    {
                        var data = excelArticleViewModels.FirstOrDefault(x => x.Name == item["Name"].ToString());
                        if (data == null)
                        {
                            var res = new ExcelArticleViewModel()
                            {
                                Name = item["Name"].ToString(),
                                
                                Caliber = item["Caliber"].ToString(),
                                CompanyName = item["CompanyName"].ToString(),
                                FormatName = item["FormatName"].ToString(),
                                Selected = true,
                                Size = item["Size"].ToString(),
                                Barcode = item["Barcode"].ToString(),
                                ActiveIngredients = item["ActiveIngredients"].ToString()
                            };
                            try
                            {
                                res.BuyPrice = Convert.ToDouble(item["BuyPrice"].ToString());
                            }
                            catch (Exception)
                            {
                                res.BuyPrice = 0.0;
                            }
                            try
                            {
                                res.SellPrice = Convert.ToDouble(item["SellPrice"].ToString());
                            }
                            catch (Exception)
                            {
                                res.SellPrice = 0.0;
                            }
                            try
                            {
                                res.LastUpdate = Convert.ToDateTime(item["LastUpdate"].ToString());
                            }
                            catch (Exception)
                            {
                                res.LastUpdate = new DateTime(2000, 1, 1);
                            }
                            excelArticleViewModels.Add(res);
                        }
                    }

                    catch (Exception ex)
                    {
                        _MessageBoxDialog.Show(ex.Message.ToString(), MessageBoxState.Error);
                    }
                }
                dgPick.AutoGenerateColumns = true;
                dgPick.DataSource = excelArticleViewModels.ToList();
            }
        }
        
        private void dgPick_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgPick.DataSource != null)
            {
                if (e.ColumnIndex == dgPick.Columns["Selected"].Index && e.RowIndex != -1)
                {
                    dgPick.EndEdit();
                }
            }
        }

        private void dgPick_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgPick.Columns["Selected"].Index)
                {
                    //var data = excelArticleViewModels.FirstOrDefault(x => x.Name == dgPick["Name", e.RowIndex].Value.ToString());
                    //if (dtFileExcel.CurrentCell.Value == null)
                    //{
                    //    return;
                    //}
                    bool isChecked = (bool)dgPick.CurrentCell.Value;
                    if (!isChecked)
                    {
                        var index = e.RowIndex;
                        DataRow dataRow = (bsFileExcel.DataSource as DataTable).NewRow();
                        dataRow.SetField("LastUpdate", Convert.ToDateTime(dgPick["LastUpdate", e.RowIndex].Value).ToString());
                        dataRow.SetField("Name", dgPick["Name", e.RowIndex].Value.ToString());
                        dataRow.SetField("FormatName", dgPick["FormatName", e.RowIndex].Value.ToString());
                        dataRow.SetField("Size", dgPick["Size", e.RowIndex].Value.ToString());
                        dataRow.SetField("Caliber", dgPick["Caliber", e.RowIndex].Value.ToString());
                        dataRow.SetField("BuyPrice", Convert.ToDouble(dgPick["BuyPrice", e.RowIndex].Value).ToString());
                        dataRow.SetField("SellPrice", Convert.ToDouble(dgPick["SellPrice", e.RowIndex].Value).ToString());
                        dataRow.SetField("CompanyName", dgPick["CompanyName", e.RowIndex].Value.ToString());
                        dataRow.SetField("Barcode", dgPick["Barcode", e.RowIndex].Value.ToString());
                        dataRow.SetField("ActiveIngredients", dgPick["ActiveIngredients", e.RowIndex].Value.ToString());
                        (bsFileExcel.DataSource as DataTable).Rows.InsertAt(dataRow, 0);
                        //dgPick.Rows.RemoveAt(index);
                        (bsPick.DataSource as List<ExcelArticleViewModel>).RemoveAt(index);
                        dgPick.DataSource = bsPick;
                        dgPick.AutoGenerateColumns = true;
                        dgPick.Refresh();
                        dtFileExcel.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void dgPick_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgPick.CurrentRow.DataBoundItem == null || save)
                return;
            try
            {

                var cell = dgPick[e.ColumnIndex, e.RowIndex];
                string cellName = cell.OwningColumn.Name;
                if ((cellName == "Barcode") && (e.FormattedValue.ToString().Trim() != ""))
                {
                    var context = ShefaaPharmacyDbContext.GetCurrentContext();
                    var bar = context.Articles.Where(x => x.Barcode == e.FormattedValue.ToString().Trim()).FirstOrDefault();
                    if (bar != null)
                    {
                        _MessageBoxDialog.Show("لا يمكن تكرار الباركود لصنفين", MessageBoxState.Error);
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
