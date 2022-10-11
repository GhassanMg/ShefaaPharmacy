using DataLayer.Enums;
using DataLayer;
using DataLayer.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.Definition
{
    public partial class UnitPickForm : ShefaaPharmacy.GeneralUI.GeneralPickForm
    {
        UnitType unitType;
        int articleId = 0;
        public UnitPickForm()
        {
            InitializeComponent();
        }
        public UnitPickForm(UnitType unitType)
        {
            this.unitType = unitType;
            InitializeComponent();
        }
        public static UnitType PickAccount(UnitType unitType, FormOperation formOperation = FormOperation.Show)
        {
            UnitPickForm fmPick = new UnitPickForm(unitType);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إستعراض الكميات";
                fmPick.ShowDialog();
                return (UnitType)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        public static UnitType PickUnitType(string textFilter, UnitType unitType, FormOperation formOperation = FormOperation.Show, int articleId = 0)
        {
            UnitType tmpAcc = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.Where(x => x.Name == textFilter).FirstOrDefault();
            if (tmpAcc != null)
            {
                return tmpAcc;
            }
            UnitPickForm fmPick = new UnitPickForm(unitType);
            try
            {
                fmPick.FormOperation = formOperation;
                fmPick.Text = "إختر كمية";
                fmPick.ForeColor = Color.Green;
                fmPick.articleId = articleId;
                fmPick.ShowDialog();
                return (UnitType)fmPick.CurrentEntity;
            }
            finally
            {
                fmPick.Dispose();
            }
        }
        protected override void AdjustmentGridColumns()
        {
            base.AdjustmentGridColumns();
            PickGridView.Refresh();
        }
        protected override void Rebinding()
        {
            if (this.articleId != 0)
            {
                var context = ShefaaPharmacyDbContext.GetCurrentContext();
                List<UnitType> unitTypesForArticle = new List<UnitType>();
                var c= context.ArticleUnits.Where(x => x.ArticleId == articleId).ToList();
                foreach (var item in c)
                {
                    unitTypesForArticle.Add(context.UnitTypes.FirstOrDefault(x => x.Id == item.UnitTypeId));
                }
                //PriceTag priceTag = UnitTypeService.GetLastPriceTagForArticle(articleId);
                //if (priceTag.UnitTypeId != 1)
                //{
                //    unitTypesForArticle.Add(context.UnitTypes.FirstOrDefault(x => x.Id == priceTag.UnitTypeId));
                //}
                //else if (priceTag.Unit2TypeId != 1)
                //{
                //    unitTypesForArticle.Add(context.UnitTypes.FirstOrDefault(x => x.Id == priceTag.Unit2TypeId));
                //}
                //else if (priceTag.Unit3TypeId != 1)
                //{
                //    unitTypesForArticle.Add(context.UnitTypes.FirstOrDefault(x => x.Id == priceTag.Unit3TypeId));
                //}
                PickBindingSource.DataSource = unitTypesForArticle;
            }
            else
            {
                if (unitType == null || unitType.Id == 0)
                    PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.Where(x => x.Id != 1).ToList();
                else
                    PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.Where(x => x.Id == unitType.Id).ToList();
            }
            base.Rebinding();
        }
        protected override void SetCurrentEntity()
        {
            base.SetCurrentEntity();
            CurrentEntity = (UnitType)PickBindingSource.Current;
        }
        protected override void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
            base.DeleteCurrentItem(shefaaPharmacyDbContext);
            shefaaPharmacyDbContext.UnitTypes.Remove(CurrentEntity as UnitType);
        }

        protected override void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            base.bindingNavigatorAddNewItem_Click(sender, e);
            UnitEditForm.CreateUnitType(CurrentEntity as UnitType, FormOperation.NewFromPicker);
            Rebinding();
        }
        protected override void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            base.PickGridView_CellDoubleClick(sender, e);
            if (FormOperation != FormOperation.Pick)
            {
                UnitEditForm edForm = new UnitEditForm(CurrentEntity as UnitType, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsbtnEdit_Click(object sender, EventArgs e)
        {
            if (PickBindingSource.Current == null)
                return;
            if (FormOperation != FormOperation.Pick)
            {
                SetCurrentEntity();
                UnitEditForm edForm = new UnitEditForm(CurrentEntity as UnitType, FormOperation.EditFromPicker);
                edForm.ShowDialog();
                edForm.Dispose();
                PickBindingSource.ResetBindings(false);
            }
        }
        protected override void tsFilterdText_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tsFilterdText.Text))
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.ToList();
            }
            else
            {
                PickBindingSource.DataSource = ShefaaPharmacyDbContext.GetCurrentContext().UnitTypes.Where(x => x.Name.Contains(tsFilterdText.Text)).ToList();
            }

            base.Rebinding();
        }
        private void UnitPickForm_Load(object sender, EventArgs e)
        {
            if (FormOperation == FormOperation.Pick)
            {
                this.Text = "إختر كمية";
            }
            else
            {
                this.Text = "إستعراض الكميات";
            }
        }
    }
}
