using DataLayer.Services;
using DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.GeneralUI;
using DataLayer;
using DataLayer.Helper;
using System.Threading;
using System.IO;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using Spire.Xls;

namespace ShefaaPharmacy.Articles
{
    public partial class ArticleImportForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        //Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
        //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
        //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
        List<Article> Articales;
        string sFileName;
        DataTable file;
        BindingSource bs;
        //int iRow, iCol = 2;

        private void pbAccountPick_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Excel File to Edit";
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Excel File|*.xlsx;*.xls";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog1.FileName;
            }
            textBox1.Text = sFileName;

        }
        private void newmethod(string sFile)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(sFile);
            Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            // dt.Column = colCount;  
            dtGrid.ColumnCount = colCount;
            dtGrid.RowCount = rowCount;

            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {


                    //write the value to the Grid  


                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                    {
                        dtGrid.Rows[i - 1].Cells[j - 1].Value = xlRange.Cells[i, j].Value2.ToString();
                    }
                    // Console.Write(xlRange.Cells[i, j].Value2.ToString() + "\t");  

                    //add useful things here!     
                }
            }

            //cleanup  
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:  
            //  never use two dots, all COM objects must be referenced and released individually  
            //  ex: [somthing].[something].[something] is bad  

            //release com objects to fully kill excel process from running in the background  
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release  
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release  
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
        private void readExcel(string sFile)
        {
            //try
            //{
            //    start();
            //    xlApp = new Microsoft.Office.Interop.Excel.Application();
            //    xlWorkBook = xlApp.Workbooks.Open(sFile);           // WORKBOOK TO OPEN THE EXCEL FILE.
            //    xlWorkSheet = xlWorkBook.Worksheets["Table 1"];      // NAME OF THE SHEET.
            //    Articales = new List<DataLayer.Tables.Article>();
            //    int iCol;
            //    int colCount = 0;
            //    for (iCol = 1; iCol <= xlWorkSheet.Columns.Count; iCol++)
            //    {
            //        if (xlWorkSheet.Cells[1, iCol].value == null)
            //        {
            //            break;      // BREAK LOOP.
            //        }
            //        else
            //        {
            //            //DataGridViewColumn col = new DataGridViewTextBoxColumn();
            //            //col.HeaderText = xlWorkSheet.Cells[1, iCol].value;
            //            //int colIndex = dgArticleItem.Columns.Add(col);     // ADD A NEW COLUMN.
            //            colCount++;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    xlWorkBook.Close();
            //    xlApp.Quit();
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            //    return;
            //}
            // ADD ROWS TO THE GRID.
            //try
            //{
            //    lbAll.Text = xlWorkSheet.Rows.Count + "";
            //    var context = ShefaaPharmacyDbContext.GetCurrentContext();
            //    for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)  // START FROM THE SECOND ROW.
            //    {
            //        if (xlWorkSheet.Cells[iRow, 1].value == null)
            //        {
            //            break;
            //        }
            //        try
            //        {
            //            Article article = new Article();
            //            article.Name = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 2].value);
            //            article.EnglishName = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 2].value);
            //            article.FormatId = DescriptionFK.FormatExistsAndCreate(xlWorkSheet.Cells[iRow, 3].value).Id;
            //            article.Size = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 4].value);
            //            article.Caliber = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 5].value);
            //            article.ArticleCategoryId = ConstantDataBase.APC_Drugs;
            //            article.ItsGeneral = false;
            //            article.CompanyId = DescriptionFK.GetCompanyAndCreate(xlWorkSheet.Cells[iRow, 8].value).Id;
            //            article = context.Articles.Add(article).Entity;
            //            context.SaveChanges();

            //            PriceTag priceTag = new PriceTag();
            //            priceTag.ArticaleId = article.Id;
            //            priceTag.BuyPrimary = ObjectExtensions.NullSafeTodouble(xlWorkSheet.Cells[iRow, 6].value());
            //            priceTag.SellPrimary = ObjectExtensions.NullSafeTodouble(xlWorkSheet.Cells[iRow, 7].value());
            //            priceTag.CreationDate = Convert.ToDateTime(xlWorkSheet.Cells[iRow, 1].value());
            //            priceTag.UnitTypeId = 1;
            //            priceTag.Unit2TypeId = 1;
            //            priceTag.Unit3TypeId = 1;
            //            context.PriceTags.Add(priceTag);
            //            context.SaveChanges();

            //            //article.ArticaleSubCategoryId = DescriptionFK.GetArticaleSubCategoryId(xlWorkSheet.Cells[iRow, 2].value);
            //            //article.Dosage = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 4].value());
            //            //article.ScientificName = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 5].value());
            //            //article.SideEffects = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 6].value());
            //            //article.LimitUp = Convert.ToInt32(xlWorkSheet.Cells[iRow, 7].value());
            //            //article.LimitDown = Convert.ToInt32(xlWorkSheet.Cells[iRow, 8].value());
            //            //article.Interactions = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 9].value());
            //            //article.Precautions = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 10].value());
            //            //article.ActiveIngredients = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 11].value());
            //            //article.Description = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 12].value());
            //            //article.Note = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 13].value());
            //            //article = context.Articles.Add(article).Entity;
            //            //context.SaveChanges();
            //            //PriceTag priceTag = new PriceTag();
            //            //priceTag.ArticaleId = article.Id;
            //            //priceTag.Barcode = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 14].value());
            //            //priceTag.ExpiryDate = Convert.ToDateTime(xlWorkSheet.Cells[iRow, 15].value());
            //            //priceTag.UnitTypeId = DescriptionFK.GetUnitId(xlWorkSheet.Cells[iRow, 16].value());
            //            //priceTag.BuyPrimary = Convert.ToDouble(xlWorkSheet.Cells[iRow, 17].value());
            //            //priceTag.SellPrimary = Convert.ToDouble(xlWorkSheet.Cells[iRow, 18].value());
            //            //priceTag.Unit2TypeId = DescriptionFK.GetUnitId(xlWorkSheet.Cells[iRow, 19].value());
            //            //priceTag.Unit3TypeId = 1;
            //            //priceTag.QuentityOfPrimary = Convert.ToInt32(xlWorkSheet.Cells[iRow, 20].value());
            //            //priceTag.BuySecondary = Convert.ToDouble(xlWorkSheet.Cells[iRow, 21].value());
            //            //priceTag.SellSecondary = Convert.ToDouble(xlWorkSheet.Cells[iRow, 22].value());
            //            //priceTag.CompanyId = DescriptionFK.GetCompanyId(xlWorkSheet.Cells[iRow, 3].value);
            //            //context.PriceTags.Add(priceTag);
            //            //context.SaveChanges();
            //            lbDone.Text = Convert.ToInt32(lbDone.Text) + 1 + "";
            //        }
            //        catch (Exception ex)
            //        {
            //            lbError.Text = Convert.ToInt32(lbError.Text) + 1 + "";
            //            continue;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            //}
            //finally
            //{
            //    xlWorkBook.Close();
            //    xlApp.Quit();
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkBook);
            //    System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkSheet);
            //    End();
            //}

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //readExcel(sFileName);
            //newmethod(sFileName);
            //try
            //{
            //    OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
            //    openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
            //    openFileDialog1.FilterIndex = 3;

            //    openFileDialog1.Multiselect = false;        //not allow multiline selection at the file selection level
            //    openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog
            //    openFileDialog1.InitialDirectory = @"Desktop"; //define the initial directory

            //    if (openFileDialog1.ShowDialog() == DialogResult.OK)        //executing when file open
            //    {
            //        string pathName = openFileDialog1.FileName;
            //        var fileName = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            //        DataTable tbContainer = new DataTable();
            //        string strConn = string.Empty;
            //        string sheetName = "Table 1";

            //        FileInfo file = new FileInfo(pathName);
            //        if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
            //        string extension = file.Extension;
            //        switch (extension)
            //        {
            //            case ".xls":
            //                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            //                break;
            //            case ".xlsx":
            //                strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
            //                break;
            //            default:
            //                strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
            //                break;
            //        }
            //        OleDbConnection cnnxls = new OleDbConnection(strConn);
            //        OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}$]", sheetName), cnnxls);
            //        oda.Fill(tbContainer);

            //        dtGrid.DataSource = tbContainer;
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error!");
            //}
            try
            {
                Workbook workbook = new Workbook();
                workbook.LoadFromFile(sFileName);
                Worksheet sheet = workbook.Worksheets[0];
                file = sheet.ExportDataTable();
                //List<ExcelArticleViewModel> fileContent = DataBaseService.ConvertDataTable<ExcelArticleViewModel>(file);
                bs = new BindingSource();
                bs.DataSource = file;
                dtGrid.AutoGenerateColumns = true;
                dtGrid.DataSource = bs;
                DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
                checkColumn.Name = "Checked";
                checkColumn.HeaderText = "إختيار";
                checkColumn.Width = 50;
                checkColumn.ReadOnly = false;
                checkColumn.DisplayIndex = 0;
                dtGrid.Columns.Add(checkColumn);
                dtGrid.Refresh();
                Articales = new List<Article>();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        void start()
        {
            //button1.Enabled = false;
            //pbAccountPick.Enabled = false;
            //textBox1.Enabled = false;
            //label3.Visible = true;
            //lbStop.Visible = false;
        }
        void End()
        {
            //button1.Enabled = true;
            //pbAccountPick.Enabled = true;
            //textBox1.Enabled = true;
            //label3.Visible = false;
            //lbStop.Visible = false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (Articales == null || Articales.Count == 0)
            {
                _MessageBoxDialog.Show("البيانات غير مكتملة", MessageBoxState.Error);
                return;
            }
            else
            {
                try
                {
                    ShefaaPharmacyDbContext.GetCurrentContext().Articles.AddRange(Articales);
                    ShefaaPharmacyDbContext.GetCurrentContext().SaveChanges();
                    _MessageBoxDialog.Show("تم إضافة الأصناف إلى قاعدة البيانات", MessageBoxState.Done);
                }
                catch (Exception)
                {
                    _MessageBoxDialog.Show("حصل خطأ أثناء التخزين", MessageBoxState.Error);
                }

            }
        }

        private void ArticleImportForm_Load(object sender, EventArgs e)
        {
            btnMaximaizing.Enabled = false;
        }
        private void dtGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //var y = (dtGrid.DataSource as List<ExcelArticleViewModel>).Where(x => x.Selected == true);
            //List<Article> art = new List<Article>();
            //foreach (DataGridViewRow item in dtGrid.Rows)
            //{
               
            //    bool isSelected = Convert.ToBoolean(item.Cells["Checked"].Value);
            //    if (isSelected)
            //    {
            //        //Article article = new Article();
            //        //article.Name = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 2].value);
            //        //article.EnglishName = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 2].value);
            //        //article.FormatId = DescriptionFK.FormatExistsAndCreate(xlWorkSheet.Cells[iRow, 3].value).Id;
            //        //article.Size = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 4].value);
            //        //article.Caliber = ObjectExtensions.NullSafeToString(xlWorkSheet.Cells[iRow, 5].value);
            //        //article.ArticleCategoryId = ConstantDataBase.APC_Drugs;
            //        //article.ItsGeneral = false;
            //        //article.CompanyId = DescriptionFK.GetCompanyAndCreate(xlWorkSheet.Cells[iRow, 8].value).Id;
            //    }

            //}
            try
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                context.Articles.AddRange(Articales);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                ;
            }
        }

        public ArticleImportForm()
        {
            InitializeComponent();
        }

        private void dtGrid_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (dtGrid.CurrentRow.DataBoundItem == null)
            //    return;
            //var cell = dtGrid[e.ColumnIndex, e.RowIndex];
            //string cellName = cell.OwningColumn.Name;
            //var currentRow = dtGrid.Rows[e.RowIndex];
            //if (cellName == "Checked")
            //{
            //    var d = ((DataGridViewCheckBoxCell)dtGrid["Checked", e.RowIndex]).Value;
            //    if (d!=null)
            //    {
            //        if (Articales.FirstOrDefault(x => x.Name == dtGrid["Name", e.RowIndex].Value.ToString()) == null)
            //        {
            //            Articales.Add(new Article()
            //            {
            //                Name = dtGrid["Name", e.RowIndex].Value.ToString(),
            //                EnglishName = dtGrid["Name", e.RowIndex].Value.ToString(),
            //                FormatId = DescriptionFK.FormatExistsAndCreate(dtGrid["FormatName", e.RowIndex].Value.ToString()).Id,
            //                Size = dtGrid["Size", e.RowIndex].Value.ToString(),
            //                Caliber = dtGrid["Caliber", e.RowIndex].Value.ToString(),
            //                ArticleCategoryId = ConstantDataBase.APC_Drugs,
            //                ItsGeneral = false,
            //                CompanyId = DescriptionFK.GetCompanyAndCreate(dtGrid["CompanyName", e.RowIndex].Value.ToString()).Id,
            //                PriceTags = new List<PriceTag>()
            //                {
            //                    new PriceTag()
            //                    {
            //                        ExpiryDate = DateTime.Now.AddMonths(3),
            //                        UnitTypeId = 3,
            //                        BuyPrimary = Convert.ToDouble(dtGrid["BuyPrice", e.RowIndex].Value),
            //                        SellPrimary = Convert.ToDouble(dtGrid["SellPrice", e.RowIndex].Value),
            //                        Unit2TypeId = 1,
            //                        Unit3TypeId = 1,
            //                        QuentityOfPrimary = 0,
            //                        QuentityOfSecondary = 0,
            //                        BuySecondary = 0,
            //                        SellSecondary = 0,BuyTertiary = 0 ,SellTertiary = 0
            //                    }
            //                }
            //            });
            //        }
            //    }
            //}
        }

        private void dtGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dtGrid.DataSource != null)
            {
                if (e.ColumnIndex == dtGrid.Columns["Checked"].Index && e.RowIndex != -1)
                {
                    dtGrid.EndEdit();
                }
            }
        }

        private void dtGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dtGrid.Columns["Checked"].Index)
                {
                    var data = Articales.FirstOrDefault(x => x.Name == dtGrid["Name", e.RowIndex].Value.ToString());
                    if (dtGrid.CurrentCell.Value == null)
                    {
                        return;
                    }
                    bool isChecked = (bool)dtGrid.CurrentCell.Value;
                    if (isChecked)
                    {
                        if (data == null)
                        {
                            Articales.Add(new Article()
                            {
                                Name = dtGrid["Name", e.RowIndex].Value.ToString(),
                                EnglishName = dtGrid["Name", e.RowIndex].Value.ToString(),
                                FormatId = DescriptionFK.FormatExistsAndCreate(dtGrid["FormatName", e.RowIndex].Value.ToString()).Id,
                                Size = dtGrid["Size", e.RowIndex].Value.ToString(),
                                Caliber = dtGrid["Caliber", e.RowIndex].Value.ToString(),
                                ArticleCategoryId = ConstantDataBase.APC_Drugs,
                                ItsGeneral = false,
                                CompanyId = DescriptionFK.GetCompanyAndCreate(dtGrid["CompanyName", e.RowIndex].Value.ToString()).Id,
                                //PriceTags = new List<PriceTag>()
                                //    {
                                //        new PriceTag()
                                //        {
                                //            ExpiryDate = DateTime.Now.AddMonths(3),
                                //            UnitTypeId = 3,
                                //            BuyPrimary = Convert.ToDouble(dtGrid["BuyPrice", e.RowIndex].Value),
                                //            SellPrimary = Convert.ToDouble(dtGrid["SellPrice", e.RowIndex].Value),
                                //            Unit2TypeId = 1,
                                //            Unit3TypeId = 1,
                                //            QuentityOfPrimary = 0,
                                //            QuentityOfSecondary = 0,
                                //            BuySecondary = 0,
                                //            SellSecondary = 0,BuyTertiary = 0 ,SellTertiary = 0
                                //        }
                                //    }
                            });
                        }
                        else
                        {
                            dtGrid.CurrentCell.Value = true;
                            dtGrid.Refresh();
                        }
                    }
                    else
                    {
                        if (data != null)
                        {
                            Articales.Remove(data);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtGrid.DataSource;
                bs.Filter = dtGrid.Columns["Name"].HeaderText.ToString() + " LIKE '%" + tbSearch.Text + "%'";
                dtGrid.DataSource = bs;
            }
            catch (Exception ex)
            {
                ;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbPath_Click(object sender, EventArgs e)
        {

        }
    }
}
