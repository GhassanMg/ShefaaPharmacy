using DataLayer;
using DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataLayer.Enums;
using DataLayer.Services;
using ShefaaPharmacy.Helper;
using ShefaaPharmacy.GeneralUI;
using DataLayer.Helper;

namespace ShefaaPharmacy.Articles
{
    public partial class ArticleUnitsEditForm : ShefaaPharmacy.GeneralUI.GeneralEditForm
    {
        List<ArticleUnits> allArticleUnits;
        ArticleUnits newArticleUnit;
        bool Editted = false;
        public ArticleUnitsEditForm()
        {
            InitializeComponent();
            FormOperation = FormOperation.New;
            
        }
        public ArticleUnitsEditForm(ArticleUnits articleUnit)
        {
            InitializeComponent();
            if (articleUnit.Id == 0)
            {
                FormOperation = FormOperation.New;
                newArticleUnit = NewArticleUnit(articleUnit);
            }
            else
            {
                FormOperation = FormOperation.Edit;
                newArticleUnit = articleUnit;
            }
            startUp();
            tbArticleName.Text = DescriptionFK.GetArticaleName(newArticleUnit.ArticleId);
           
            List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == articleUnit.ArticleId).ToList();
            EditBindingSource.DataSource = newArticleUnit;
            bsMaster.DataSource = articleUnits;
            BindingControls();
            if(FormOperation==FormOperation.New) metroLabel11.Text = "اختر الواحدة الرئيسية";
            btnAdd.Enabled = true;
        }
        int addcount = 0;
        protected override void btOk_Click(object sender, EventArgs e)
        {
            if (dgMaster.Rows.Count == 0)
            {
                _MessageBoxDialog.Show("لم يتم اضافة اية واحدات!! ", MessageBoxState.Error);
            }
            else if(_MessageBoxDialog.Show("هل انتهيت من الإضافة ؟ ", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
            {
                Close();
            }
            else
                return;
        }

        protected override void btCancel_Click(object sender, EventArgs e)
        {
            if (tbArticleName.Text == "")
            {
                base.btCancel_Click(sender, e);
                return;
            }
            else if (dgMaster.Rows.Count == 0)
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                ArticleUnits articleUnits = new ArticleUnits
                {
                    UnitTypeId = context.UnitTypes.FirstOrDefault(x => x.Name.Contains("علبة")).Id,
                    ArticleId = newArticleUnit.ArticleId,
                    QuantityForPrimary = 0,
                    IsPrimary = true,
                    CreationDate = DateTime.Now,
                    CreationBy = UserLoggedIn.User.Id,
                };
                context.ArticleUnits.Add(articleUnits);
                context.SaveChanges();
            }
                base.btCancel_Click(sender, e);
        }
        private void validate()
        {
            if (tbArticleName.Text.ToString().Trim() != "")
            {
                Article result = DescriptionFK.ArticaleExists(true, tbArticleName.Text.ToString(), 0);
                if (result != null)
                {
                    newArticleUnit = new ArticleUnits() { ArticleId = result.Id };
                    tbArticleName.Text = result.Name;
                    List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == result.Id).ToList();
                    bsMaster.DataSource = articleUnits;
                    EditBindingSource.DataSource = newArticleUnit;
                }
            }
        }
        public void BindingControls()
        {
            try
            {
                cbPrimary.DataBindings.Add("checked", EditBindingSource, "IsPrimary", false, DataSourceUpdateMode.OnPropertyChanged);
                HelperUI.ConfigrationComboBox<UnitType>(cbUnitTypeId, ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.Where(x => x.Id != 1).ToList(), null, "Name", "Id", FormOperation);
                tbQuantityFromBaseUnit.DataBindings.Add("text", EditBindingSource, "QuantityForPrimary", false, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }
        public ArticleUnits NewArticleUnit(ArticleUnits article)
        {
            return new ArticleUnits()
            {
                IsPrimary = false,
                ArticleId = article.ArticleId,
            };
        }

        private void TbArticleName_Validating(object sender, CancelEventArgs e)
        {
            validate();
        }
        
        private void LbArticleName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            Article choosed = ArticlePicker.PickArticale("", 0, FormOperation.Pick);
            if (choosed != null)
            {
                newArticleUnit = new ArticleUnits() { ArticleId = choosed.Id };
                tbArticleName.Text = choosed.Name;
                List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == choosed.Id).ToList();
                bsMaster.DataSource = articleUnits;
                if (articleUnits.Count != 0 && articleUnits.FirstOrDefault().IsPrimary) 
                {
                    Editted = true;
                }
                EditBindingSource.Clear();
                EditBindingSource.DataSource = newArticleUnit;
                BindingControls();
                btnAdd.Enabled = true;
                lbArticleName.Enabled = false;
                lbArticleName.ForeColor = Color.Gray;
                if (context.PriceTagMasters.Where(x => x.ArticleId == choosed.Id && x.CountAllItem != 0).Count() > 0) 
                {
                    _MessageBoxDialog.Show("لا يمكن تعديل الواحدات...يوجد عمليات قائمة على هذه المادة", MessageBoxState.Warning);
                    cbUnitTypeId.Enabled = btnAdd.Enabled = tbQuantityFromBaseUnit.Enabled = false;
                    
                }
                else
                {
                    cbUnitTypeId.Enabled = btnAdd.Enabled = tbQuantityFromBaseUnit.Enabled = true;
                }
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
            dgMaster.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgMaster.Refresh();
        }

        private void ArticleUnitsEditForm_Load(object sender, EventArgs e)
        {
            startUp();
        }
        private void startUp()
        {
            base.HiddenColumn = new string[] { "ArticleId", "Article", "UnitTypeId", "Id", "CreationByDescr", "CreationDate" };
            dgMaster.AutoGenerateColumns = true;
            dgMaster.ReadOnly = true;
            dgMaster.AllowUserToAddRows = false;
            dgMaster.AllowUserToDeleteRows = false;
        }
        private void BsMaster_DataSourceChanged(object sender, EventArgs e)
        {
            ShowColumn(dgMaster.Columns);
            dgMaster.Refresh();
        }

        private void CbUnitTypeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgMaster.Rows.Count == 0)
            {
                cbPrimary.Checked = true;
            }
            int selectedValue = 0;
            try
            {
                selectedValue = (int)cbUnitTypeId.SelectedValue;
            }
            catch (Exception)
            {
                return;
            }
            var articlesunits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == newArticleUnit.ArticleId && x.UnitTypeId == selectedValue).ToList();
            
            if (articlesunits.Count > 0)
            {
                _MessageBoxDialog.Show("لا يمكن تكرار واحدتين لنفس الصنف ", MessageBoxState.Error);
                
            }
            if (dgMaster.Rows.Count > 0)
            {
                var baseunitId = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == newArticleUnit.ArticleId && x.IsPrimary == true).ToList().FirstOrDefault().UnitTypeId;
                if (selectedValue < baseunitId)
                {
                    _MessageBoxDialog.Show("لا يمكن اختيار واحدة اكبر من الواحدة الرئيسية ", MessageBoxState.Error);
                    return;
                }
            }
            
        }

        private void CbPrimary_CheckedChanged(object sender, EventArgs e)
        {
            if (cbPrimary.Checked)
            {
                if (ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == newArticleUnit.ArticleId).Any(x => x.IsPrimary))
                {
                    _MessageBoxDialog.Show("لا يمكن وضع واحدتين رئيسيتين", MessageBoxState.Error);
                    cbPrimary.CheckState = CheckState.Unchecked;
                }
                else
                {
                    lbQuantityFromBaseUnit.Visible = false;
                    tbQuantityFromBaseUnit.Visible = false;
                }
            }
            else
            {
                lbQuantityFromBaseUnit.Visible = true;
                tbQuantityFromBaseUnit.Visible = true;
            }
        }

        private void dgMaster_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //contextMenuStrip1.Show(MousePosition);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

            ShefaaPharmacyDbContext context = new ShefaaPharmacyDbContext();
            //string selectedValue = dgMaster.CurrentCell.Value.ToString();
            //var articlesunits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == newArticleUnit.ArticleId && x.UnitTypeIdDescr == selectedValue).ToList();

            //EditBindingSource

            ((ArticleUnits)EditBindingSource.Current).UnitTypeId = (int)cbUnitTypeId.SelectedValue;
            ((ArticleUnits)EditBindingSource.Current).ArticleId = newArticleUnit.ArticleId;
            //if (articlesunits[0].IsPrimary)
            //{
                _MessageBoxDialog.Show("لايمكن حذف الواحدة الرئيسية للمادة", MessageBoxState.Error);
                
            //}
            //else
            //{
                context.ArticleUnits.Remove(((ArticleUnits)EditBindingSource.Current));
                context.SaveChanges();
                InventoryService.ConvertAllPriceTagToSmallest(((ArticleUnits)EditBindingSource.Current).ArticleId);
                _MessageBoxDialog.Show("تم حذف الواحدة", MessageBoxState.Done);
                dgMaster.Rows.Remove(dgMaster.CurrentRow);
            //}

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //base.btOk_Click(sender, e);
                if (_MessageBoxDialog.Show("هل انت متاكد ؟ ", MessageBoxState.Answering) == MessageBoxAnswer.No)
                {
                    return;
                }
                if (!RDSFECXA__WEWDSA.Ree())
                {
                    _MessageBoxDialog.Show("النسخة غير مسجلة يجب التسجيل للإكمال", MessageBoxState.Alert);
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
            try
            {
                ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();

                if (FormOperation == FormOperation.NewFromPicker || FormOperation == FormOperation.New)
                {
                    int selectedValue = (int)cbUnitTypeId.SelectedValue;
                    var articlesunits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == newArticleUnit.ArticleId && x.UnitTypeId == selectedValue).ToList();
                    if (articlesunits.Count > 0)
                    {
                        _MessageBoxDialog.Show("لا يمكن تكرار واحدتين لنفس الصنف ", MessageBoxState.Error);
                        return;
                    }
                    if (cbPrimary.Checked)
                    {
                        if (ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == newArticleUnit.ArticleId).Any(x => x.IsPrimary))
                        {
                            _MessageBoxDialog.Show("لا يمكن وضع واحدتين رئيسيتين", MessageBoxState.Error);
                            return;
                        }

                    }
                    if (dgMaster.Rows.Count > 0)
                    {
                        var baseunitId = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == newArticleUnit.ArticleId && x.IsPrimary == true).ToList().FirstOrDefault().UnitTypeId;
                        if (selectedValue < baseunitId)
                        {
                            _MessageBoxDialog.Show("لا يمكن اختيار واحدة اكبر من الواحدة الرئيسية ", MessageBoxState.Error);
                            return;
                        }
                    }
                    ((ArticleUnits)EditBindingSource.Current).IsPrimary = cbPrimary.Checked;
                    if (cbPrimary.Checked)
                    {
                        ((ArticleUnits)EditBindingSource.Current).QuantityForPrimary = 0;
                    }
                    else
                    {
                        if (Convert.ToInt32(tbQuantityFromBaseUnit.Text) <= 0)
                        {
                            _MessageBoxDialog.Show("يجب إدخال كميتها من الواحدة الرئيسية", MessageBoxState.Error);
                            return;
                        }
                        ((ArticleUnits)EditBindingSource.Current).QuantityForPrimary = Convert.ToInt32(tbQuantityFromBaseUnit.Text);
                    }
                    ((ArticleUnits)EditBindingSource.Current).UnitTypeId = (int)cbUnitTypeId.SelectedValue;
                    ((ArticleUnits)EditBindingSource.Current).ArticleId = newArticleUnit.ArticleId;
                    context.ArticleUnits.Add(((ArticleUnits)EditBindingSource.Current));
                    context.SaveChanges();
                    if(Editted)
                    {
                        ArticleService.MakeNewPriceTagForNewUnit(((ArticleUnits)EditBindingSource.Current).ArticleId, ((ArticleUnits)EditBindingSource.Current).UnitTypeId);
                    }
                    if (!Editted)
                    {
                        InventoryService.ConvertAllPriceTagToSmallest(((ArticleUnits)EditBindingSource.Current).ArticleId);
                    }
                    

                    _MessageBoxDialog.Show("تمت إضافة واحدة جديدة", MessageBoxState.Done);
                    if (FormOperation == FormOperation.NewFromPicker)
                    {
                        Close();
                    }
                    if (cbPrimary.Checked)
                    {
                        cbPrimary.Checked = false;
                        metroLabel11.Text = "اختر الواحدة الفرعية";
                        lbQuantityFromBaseUnit.Visible = tbQuantityFromBaseUnit.Visible = true;
                        lbBaseUnit1.Visible = lbBaseUnit2.Visible = true;
                        lbBaseUnit2.Text = cbUnitTypeId.Text;
                    }
                }
                EditBindingSource.AddNew();
                List<ArticleUnits> articleUnits = ShefaaPharmacyDbContext.GetCurrentContext().ArticleUnits.Where(x => x.ArticleId == newArticleUnit.ArticleId).ToList();
                bsMaster.DataSource = articleUnits;
                dgMaster.DataSource = bsMaster;
                dgMaster.Refresh();
                addcount++;
            }
            catch (Exception ex)
            {

            }
        }

        private void dgMaster_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Right)
            //{
            //    int rowIndex = e.RowIndex;

            //    dgMaster.Rows[rowIndex].Selected = true;
            //}
        }
    }
}
