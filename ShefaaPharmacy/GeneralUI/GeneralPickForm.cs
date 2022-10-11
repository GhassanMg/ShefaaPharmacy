using DataLayer.Enums;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.Helper;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class GeneralPickForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        protected object CurrentEntity;
        protected int ColumnIndex = -1;
        protected GridStyle[] StyledColumn;

        #region Paginate
        protected int CountRecord;
        protected int PageSize = 10;
        protected int FromRow = 0;
        protected int ToRow = 10;
        protected int CurrentPage = 0;
        protected int CountPage = 10;
        #endregion
        public GeneralPickForm()
        {
            InitializeComponent();
            PickGridView.AutoGenerateColumns = true;
            //PickGridView.DefaultCellStyle.Font = new Font("Segoe UI", 12);
            //PickGridView.Font = new Font("Segoe UI", 12);
        }
        virtual protected void AdjustmentGridColumns()
        {
            PickGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            PickGridView.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            PickGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            PickGridView.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            PickGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Rebinding();
        }
        virtual protected void Rebinding()
        {
            if (PickGridView.Columns != null)
            {
                ShowColumn(PickGridView.Columns);
            }
            if (StyledColumn != null)
            {
                ColumnWidth(PickGridView.Columns);
            }
            PickGridView.Refresh();
        }
        virtual protected void ColumnWidth(DataGridViewColumnCollection dataGridViewColumnCollection)
        {
            foreach (DataGridViewColumn item in dataGridViewColumnCollection)
            {
                if (StyledColumn != null && StyledColumn.Any(x => x.ColName == item.Name))
                {
                    item.Width = StyledColumn.FirstOrDefault(x => x.ColName == item.Name).Width;
                }
            }
        }
        //virtual protected void ShowColumn(DataGridViewColumnCollection dataGridViewColumnCollection)
        //{
        //    foreach (DataGridViewColumn item in dataGridViewColumnCollection)
        //    {
        //        if (HiddenColumn == null || !HiddenColumn.Contains(item.Name))
        //        {
        //            item.Visible = true;
        //        }
        //        else
        //        {
        //            item.Visible = false;
        //        }
        //    }
        //}
        protected virtual void SetCurrentEntity()
        {
        }
        protected virtual void DeleteCurrentItem(ShefaaPharmacyDbContext shefaaPharmacyDbContext)
        {
        }

        private void PickGridView_BindingContextChanged(object sender, EventArgs e)
        {
            AdjustmentGridColumns();
        }

        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            SetCurrentEntity();
        }

        protected virtual void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            PickBindingNavigator.DeleteItem = null;
            if (CurrentEntity != null)
            {
                ShefaaPharmacyDbContext shefaaPharmacyDbContext = ShefaaPharmacyDbContext.GetCurrentContext();
                DeleteCurrentItem(shefaaPharmacyDbContext);
                try
                {
                    shefaaPharmacyDbContext.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    _MessageBoxDialog.Show("لا يمكن حذف السجل لوجود سجلات مرتبطة به", MessageBoxState.Error);
                }
                catch (Exception x)
                {
                    _MessageBoxDialog.Show(x.Message + " حدث خطأ أثناء الحذف", MessageBoxState.Error);
                }
                Rebinding();
            }
        }
        protected virtual void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            SetCurrentEntity();
        }

        protected virtual void PickGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (FormOperation == FormOperation.Pick)
                {
                    SetCurrentEntity();
                    Close();
                }
            }
        }

        protected virtual void PickGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }
            SetCurrentEntity();
            if (FormOperation == FormOperation.Pick)
            {
                Close();
            }
        }

        protected virtual void PickGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void PickGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
        }
        protected virtual void PickGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        protected virtual void PickBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {

        }

        protected virtual void PickGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        protected virtual void PickGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

        }

        protected virtual void PickGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = PickGridView.CurrentRow.Index;
                if (i < 0)
                {
                    return;
                }
                SetCurrentEntity();
                if (FormOperation == FormOperation.Pick)
                {
                    Close();
                }
            }
        }
        protected virtual void tsFilterdText_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = PickBindingSource;
            bs.Filter = "Name like '%" + tsFilterdText.Text + "%'";
            PickGridView.DataSource = bs;
            PickGridView.Refresh();
        }

        protected virtual void tsbtnEdit_Click(object sender, EventArgs e)
        {

        }

        protected virtual void tsRefresh_Click(object sender, EventArgs e)
        {
            Rebinding();
        }
        protected virtual void tsReset_Click(object sender, EventArgs e)
        {

        }

        private void PickGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex % 2 != 0)
            {
                PickGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(245, 247, 248);
            }
            else
            {
                PickGridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void PickGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                GridMenuHeader.Show(PickGridView, PickGridView.PointToClient(Cursor.Position));
                ColumnIndex = e.ColumnIndex;
            }
        }

        private void miHideColumn_Click(object sender, EventArgs e)
        {
            if (ColumnIndex != -1)
            {
                PickGridView.Columns[ColumnIndex].Visible = false;
                PickGridView.Refresh();
            }
        }

        protected virtual void tsddlSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected virtual void tsddlSearch2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected virtual void tsnextPage_Click(object sender, EventArgs e)
        {

        }

        private void GeneralPickForm_Load(object sender, EventArgs e)
        {

        }

        private void PickGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
