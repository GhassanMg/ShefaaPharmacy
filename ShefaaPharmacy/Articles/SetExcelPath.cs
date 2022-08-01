using ShefaaPharmacy.Articles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.IO;
using ShefaaPharmacy;
using DataLayer;
using Spire.Xls;
using DataLayer.Tables;
using ExcelDataReader;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System.Reflection;

namespace ShefaaPharmacy
{
    public partial class SetExcelPath : MetroFramework.Forms.MetroForm
    {
        DataTableCollection tables;
        public SetExcelPath()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (datagrid.Rows.Count != 0)
            {
                try
                {
                    Insert(datagrid.DataSource as List<Medicine>);
                    _MessageBoxDialog.Show("تم الاستيراد بنجاح", MessageBoxState.Done);
                    button1.Visible = false;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public void Insert(List<Medicine> list)
        {
            using (var copy = new SqlBulkCopy(ShefaaPharmacyDbContext.ConStr))
            {
                DataTable dt = new DataTable();
                copy.DestinationTableName = "dbo.medicines";
                // Add mappings so that the column order doesn't matter
                copy.ColumnMappings.Add(nameof(Medicine.id), "id");
                copy.ColumnMappings.Add(nameof(Medicine.Name), "name");
                copy.ColumnMappings.Add(nameof(Medicine.Company), "company");
                copy.ColumnMappings.Add(nameof(Medicine.scientific_name), "scientific_name");
                copy.ColumnMappings.Add(nameof(Medicine.caliber), "caliber");
                copy.ColumnMappings.Add(nameof(Medicine.format_id_descr), "format_id_descr");
                copy.ColumnMappings.Add(nameof(Medicine.size), "size");
                copy.ColumnMappings.Add(nameof(Medicine.BuyPrice), "BuyPrice");
                copy.ColumnMappings.Add(nameof(Medicine.SellPrice), "SellPrice");
                copy.ColumnMappings.Add(nameof(Medicine.barcode), "barcode");

                dt = ToDataTable(list);
                copy.WriteToServer(dt);
            }
        }
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Files(.xlsx)|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string tmp = ofd.FileName;
                    tmp = tmp.Substring(tmp.LastIndexOf('\\') + 1);
                    tbPath.Text = tmp;
                    using (var stream = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                                {
                                    UseHeaderRow = true
                                }
                            });
                            tables = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tables)
                                cboSheet.Items.Add(table.TableName);
                        }
                    }
                }
            }
            button2.Enabled = false;
            cboSheet.Visible = true;
            label2.Visible = true;
            cboSheet.SelectedIndex = 0;
        }
        private void cboSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tables[cboSheet.SelectedItem.ToString()];
            if (dt != null)
            {
                List<Medicine> list = new List<Medicine>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Medicine obj = new Medicine();
                    obj.id = dt.Rows[i]["الرقم"].ToString();
                    obj.Name = dt.Rows[i]["اسم المستحضر"].ToString();
                    obj.Company = dt.Rows[i]["معمل"].ToString();
                    obj.scientific_name = dt.Rows[i]["تركيب"].ToString();
                    obj.caliber = dt.Rows[i]["عيار"].ToString();
                    obj.format_id_descr = dt.Rows[i]["شكل صيدلاني"].ToString();
                    obj.size = dt.Rows[i]["شكل العبوة"].ToString();
                    obj.BuyPrice = dt.Rows[i]["نت"].ToString();
                    obj.SellPrice = dt.Rows[i]["عموم"].ToString();
                    obj.barcode = dt.Rows[i]["BarCode"].ToString();
                    list.Add(obj);
                }
                datagrid.DataSource = list;
                button1.Visible = true;
                button2.Enabled = true;
            }
        }
        private void SetExcelPath_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            cboSheet.Visible = false;
            label2.Visible = false;
        }
    }
}
