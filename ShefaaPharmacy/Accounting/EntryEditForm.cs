using DataLayer.Enums;
using DataLayer;
using DataLayer.Enums;
using DataLayer.Services;
using DataLayer.Tables;
using Microsoft.EntityFrameworkCore;
using ShefaaPharmacy.GeneralUI;
using ShefaaPharmacy.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ShefaaPharmacy.Definition;

namespace ShefaaPharmacy.Accounting
{
    public partial class EntryEditForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        EntryMaster entryMaster;
        KindOperation kindOperation;
        EntryMaster lastOp, prevLastOp, prevPrevLastOp;
        public bool RowValidating { get; set; }
        public bool NewRecord { get; set; }
        public bool Pick { set; get; }
        public EntryEditForm()
        {
            InitializeComponent();
        }
        private void ChangeImageButton()
        {
            if (FormOperation == FormOperation.New || FormOperation == FormOperation.NewFromPicker)
            {
                //pbOk.Image = Properties.Resources.SaveButton;
                //pbCancel.Image = Properties.Resources.EditButton;
                //pbRefresh.Image = Properties.Resources.DeleteButton;
                Text = "إضافة سند قيد جديد";
                pBottomLastOperation.Visible = true;
                lbEditEntry.Visible = true;
                lbDeleteEntry.Visible = true;
            }
            else if (FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
            {
                //pbOk.Image = Properties.Resources.EditButton;
                //pbCancel.Image = Properties.Resources.Group_2299__1_;
                //pbRefresh.Image = Properties.Resources.DeleteButton;
                Text = "تعديل سند قيد";
                lbEditEntry.Visible = false;
                lbDeleteEntry.Visible = false;
                pBottomLastOperation.Visible = false;
            }
            else if (FormOperation == FormOperation.Delete)
            {
                Text = "حذف سند قيد";
                lbEditEntry.Visible = false;
                lbDeleteEntry.Visible = false;
                //pbCancel.Image = Properties.Resources.Group_2299__1_;
                //pbRefresh.Image = Properties.Resources.DeleteButton;
            }
            dgDetail.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dgDetail.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dgDetail.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dgDetail.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgDetail.EnableHeadersVisualStyles = false;
        }
        public static EntryMaster CreateEntry(EntryMaster entryMaster, FormOperation formOperation = FormOperation.New)
        {
            EntryEditForm fmEdit = new EntryEditForm(entryMaster, KindOperation.Entry, formOperation);
            try
            {
                fmEdit.FormOperation = formOperation;
                fmEdit.ShowDialog();
                return entryMaster;
            }
            finally
            {
                fmEdit.Dispose();
            }
        }
        public EntryEditForm(EntryMaster entity, KindOperation kindOperation, FormOperation formOperation = FormOperation.New)
        {
            InitializeComponent();
            RowValidating = true;
            entryMaster = entity;
            this.kindOperation = kindOperation;
            FormOperation = formOperation;
            EditBindingSource.DataSource = entryMaster;
            ((EntryMaster)EditBindingSource.DataSource).onUpdateForm += InitEntity_onUpdateForm;
            if (entryMaster.EntryDetails == null)
            {
                entryMaster.EntryDetails = ShefaaPharmacyDbContext.GetCurrentContext().EntryDetails.Where(x => x.EntryMasterId == entryMaster.Id).ToList();
            }
            DetailBindingSource.DataSource = entryMaster.EntryDetails;
            dgDetail.AutoGenerateColumns = true;
            LastThreeOperation();
            ChangeImageButton();
        }
        private void CheckKey(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void LastThreeOperation()
        {
            if (!(FormOperation == FormOperation.New || FormOperation == FormOperation.NewFromPicker))
            {
                pLastOp.Visible = false;
                pPrevLast.Visible = false;
                pPrevPrevLast.Visible = false;
            }
            else
            {
                pLastOp.Visible = false;
                pPrevLast.Visible = false;
                pPrevPrevLast.Visible = false;
                var xx = ShefaaPharmacyDbContext.GetCurrentContext().EntryMasters.Where(x => x.KindOperation == kindOperation).OrderByDescending(x => x.CreationDate).Take(3).Include("EntryDetails").ToList();
                if (xx.Count > 0)
                {
                    for (int i = 0; i < xx.Count; i++)
                    {
                        if (i == 0)
                        {
                            pLastOp.Visible = true;
                            lbLastOp.Text = "أخر عملية رقم" + "\t" + xx[i].Id;
                            lastOp = xx[i];
                        }
                        else if (i == 1)
                        {
                            pPrevLast.Visible = true;
                            lbPrevLast.Text = "عملية رقم" + "\t" + xx[i].Id;
                            prevLastOp = xx[i];
                        }
                        else if (i == 2)
                        {
                            pPrevPrevLast.Visible = true;
                            lbPrevPrevLast.Text = "عملية رقم" + "\t" + xx[i].Id;
                            prevPrevLastOp = xx[i];
                        }
                    }
                }
            }
        }
        public void BindingToControl()
        {
            tbId.DataBindings.Add("text", EditBindingSource, "Id");
            dtCreationDate.DataBindings.Add("text", EditBindingSource, "CreationDate");
            tbBalance.DataBindings.Add("text", EditBindingSource, "Balance");
            tbTotCredit.DataBindings.Add("text", EditBindingSource, "TotalCredit");
            tbTotDebit.DataBindings.Add("text", EditBindingSource, "TotalDebit");
        }
        private void EditBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            BindingToControl();
        }
        private void dgDetail_BindingContextChanged(object sender, EventArgs e)
        {
            dgDetail.Columns["Id"].Visible = false;
            dgDetail.Columns["KindOperation"].Visible = false;
            dgDetail.Refresh();
        }
        private void InitEntity_onUpdateForm()
        {
            EditBindingSource.ResetCurrentItem();
        }
        private void pLastOp_Click(object sender, EventArgs e)
        {
            EntryEditForm entryEditForm = new EntryEditForm(lastOp, lastOp.KindOperation, FormOperation.Edit);
            entryEditForm.ShowDialog();
        }
        private void pPrevLast_Click(object sender, EventArgs e)
        {
            EntryEditForm entryEditForm = new EntryEditForm(prevLastOp, prevLastOp.KindOperation, FormOperation.Edit);
            entryEditForm.ShowDialog();
        }

        private void pPrevPrevLast_Click(object sender, EventArgs e)
        {
            EntryEditForm entryEditForm = new EntryEditForm(prevPrevLastOp, prevPrevLastOp.KindOperation, FormOperation.Edit);
            entryEditForm.ShowDialog();
        }

        private void DetailBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            e.NewObject = new EntryDetail(entryMaster);
        }

        private void dgDetail_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dgDetail.CurrentCell.ColumnIndex;
            string headerText = dgDetail.Columns[column].Name;
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            if (headerText.Equals("AccountIdDescr"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    List<string> data = ShefaaPharmacyDbContext.GetCurrentContext().Accounts.Where(x => !x.General).ToList().Select(x => x.Name).ToList();
                    AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
                    data.ForEach(x => autoCompleteStringCollection.Add(x));
                    tb.AutoCompleteMode = AutoCompleteMode.Suggest;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    tb.AutoCompleteCustomSource = autoCompleteStringCollection;
                }
            }
            e.Control.KeyPress -= new KeyPressEventHandler(CheckKey);
            if (headerText.Equals("Credit") || headerText.Equals("Debit"))
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(CheckKey);
                }
            }
        }

        private bool AccountId_Validating()
        {
            Account result;

            SetColumnIndex method = new SetColumnIndex(Mymethod);
            dgDetail.BeginInvoke(method, dgDetail.Columns["AccountIdDescr"].Index);

            result = AccountPickForm.PickAccount("", null, FormOperation.Pick);
            if (result == null)
            {
                _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
                dgDetail.CurrentCell.Value = "";
                return false;
            }
            else
            {
                (DetailBindingSource.Current as EntryDetail).AccountId = result.Id;
                (DetailBindingSource.Current as EntryDetail).AccountIdDescr = result.Name;
                dgDetail.CurrentCell.Value = result.Name;
                return true;
            }
        }

        private void dgDetail_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //int column = dgDetail.CurrentCell.ColumnIndex;
            //string headerText = dgDetail.Columns[column].Name;
            //if (headerText.Equals("Credit") || headerText.Equals("Debit"))
            //{
            //    if (dgDetail.CurrentCell.Value == null)
            //    {
            //        _MessageBoxDialog.Show("قيمة خاطئة", MessageBoxState.Error);
            //        return;
            //    }
            //}

            if (dgDetail.Columns[e.ColumnIndex].Name == "Credit" || dgDetail.Columns[e.ColumnIndex].Name == "Debit")
            {
                if (String.IsNullOrEmpty(e.FormattedValue.ToString()))
                {
                    dgDetail.CurrentCell.Value = "0";
                    //dgDetail.Rows[e.RowIndex].ErrorText ="Company Name must not be empty";
                    e.Cancel = true;
                }
            }
        }

        private void dgDetail_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDetail.CurrentRow == null || RowValidating == false)
            {
                return;
            }
            if (dgDetail.CurrentCell.ColumnIndex != dgDetail.Columns["Debit"].Index)
            {
                SetColumnIndex method = new SetColumnIndex(Mymethod);
                dgDetail.BeginInvoke(method, dgDetail.Columns["Debit"].Index);
            }
        }
        private void Mymethod(int columnIndex)
        {
            dgDetail.CurrentCell = dgDetail.CurrentRow.Cells[columnIndex];
            dgDetail.BeginEdit(true);
        }
        delegate void SetColumnIndex(int i);

        private void dgDetail_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {

            if (dgDetail.CurrentRow.DataBoundItem == null)
                return;
            try
            {
                //AccountId Check
                string account = dgDetail.Rows[e.RowIndex].Cells["AccountIdDescr"].Value.ToString().Trim();
                if (account == "" || DescriptionFK.AccountExists(true, account, 0) == null)
                {
                    if (_MessageBoxDialog.Show("حساب خاطئ هل تريد استخدام الاستعراض", MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                    {
                        if (!AccountId_Validating())
                        {
                            e.Cancel = true;
                            RowValidating = false;
                            return;
                        }
                    }
                    else
                    {
                        dgDetail.CurrentCell = dgDetail["AccountIdDescr", e.RowIndex];
                        dgDetail.BeginEdit(true);
                        return;
                    }
                }
                //Debit And Credit Check 
                if (Convert.ToDouble(dgDetail.Rows[e.RowIndex].Cells["Debit"].Value) == 0 && Convert.ToDouble(dgDetail.Rows[e.RowIndex].Cells["Credit"].Value) == 0)
                {
                    _MessageBoxDialog.Show("لا يجب ان يكون المدين والدائن صفر", MessageBoxState.Error);
                    e.Cancel = true;
                    RowValidating = false;
                    dgDetail.CurrentCell = dgDetail["Debit", e.RowIndex];
                    dgDetail.BeginEdit(true);
                    return;
                }
                RowValidating = true;
                (EditBindingSource.DataSource as EntryMaster).CalcTotal();
                //EditBindingSource.ResetBindings(true);
            }
            catch (Exception ex)
            {
                _MessageBoxDialog.Show(ex.Message, MessageBoxState.Error);
            }
        }

        private void EditBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            entryMaster = new EntryMaster();
            entryMaster.onUpdateForm += InitEntity_onUpdateForm;
            entryMaster.EntryDetails = new List<EntryDetail>();
            e.NewObject = entryMaster;
            dgDetail.DataBindings.Clear();
            DetailBindingSource.Clear();
            DetailBindingSource.DataSource = entryMaster.EntryDetails;
            dgDetail.DataSource = DetailBindingSource;
            LastThreeOperation();
        }
        public void SetFocus()
        {
            SetColumnIndexFocus method = new SetColumnIndexFocus(MymethodFocus);
            dgDetail.BeginInvoke(method, dgDetail.Columns["Debit"].Index);
        }
        private void MymethodFocus(int columnIndex)
        {
            if (dgDetail.CurrentRow == null)
            {
                DetailBindingSource.AddNew();
            }
            dgDetail.CurrentCell = dgDetail.CurrentRow.Cells[columnIndex];
            dgDetail.BeginEdit(true);
        }
        delegate void SetColumnIndexFocus(int i);
        private void pbCancel_Click(object sender, EventArgs e)
        {
            CheckLastRow();
            string message = "هل تريد إغلاق الواجهة";
            MessageBoxAnswer dialogResult = _MessageBoxDialog.Show(message, MessageBoxState.Answering);
            if (dialogResult == MessageBoxAnswer.Yes)
            {
                Close();
            }
            else
            {
                EditBindingSource.AddNew();
                LastThreeOperation();
                SetFocus();
            }
        }


        private void PbOk_Click(object sender, EventArgs e)
        {
            if (!RDSFECXA__WEWDSA.Ree())
            {
                _MessageBoxDialog.Show("النسخة غير مسجلة يجب التسجيل للإكمال", MessageBoxState.Warning);
                return;
            }
            if (FormOperation == FormOperation.New || FormOperation == FormOperation.NewFromPicker)
            {
                NewEntry();
            }
            else if (FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
            {
                EditEntry();
            }
            else if (FormOperation == FormOperation.Delete)
            {
                DeleteEntry();
            }
        }

        private void EntryEditForm_Load(object sender, EventArgs e)
        {

        }

        private void CheckLastRow()
        {
            if (dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Debit"].Value == null ||
                dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Credit"].Value == null ||
                dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["AccountIdDescr"].Value == null)
            {
                return;
            }
            if (Convert.ToDouble(dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Debit"].Value) == 0 &&
                Convert.ToDouble(dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["Credit"].Value) == 0 &&
                dgDetail.Rows[dgDetail.Rows.Count - 1].Cells["AccountIdDescr"].Value.ToString() == "")
            {
                entryMaster.EntryDetails.RemoveAt(dgDetail.Rows.Count - 1);
            }
        }
        private void DeleteEntry()
        {
            if (DetailBindingSource.Count < 1)
            {
                _MessageBoxDialog.Show("لا يوجد أسطر لإتمام العملية", MessageBoxState.Error);
                return;
            }
            string message = "متأكد من حذف سند القيد";
            MessageBoxAnswer dialogResult = _MessageBoxDialog.Show(message, MessageBoxState.Answering);
            if (dialogResult == MessageBoxAnswer.Yes)
            {
                EntryService entryService = new EntryService(entryMaster);
                bool res = entryService.DeleteEntry();
                if (res)
                {
                    _MessageBoxDialog.Show("تم حذف القيد", MessageBoxState.Done);
                    Close();
                }
            }
        }
        private void EditEntry()
        {
            if (entryMaster.TotalCredit != entryMaster.TotalDebit)
            {
                _MessageBoxDialog.Show("المدين لا يساوي الدائن لا يمكن المتابعة", MessageBoxState.Error);
                return;
            }
            if (entryMaster.EntryDetails.Count == 0)
            {
                _MessageBoxDialog.Show("لا يوجد أسطر للتخزين", MessageBoxState.Error);
                return;
            }
            CheckLastRow();
            EntryService entryService = new EntryService(entryMaster);
            bool result = entryService.EditEntry();
            if (result)
            {
                _MessageBoxDialog.Show("تم التعديل بنجاح", MessageBoxState.Done);
            }
            else
            {
                _MessageBoxDialog.Show("حدث خطأ اثناء التعديل", MessageBoxState.Done);
            }
            if (FormOperation == FormOperation.EditFromPicker)
            {
                Close();
            }
        }

        private void LbDeleteEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InputForm.OpenInputNumber(ShefaaForms.DeleteEntry, "ادخل رقم سند القيد");
        }

        private void LbEditEntry_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            InputForm.OpenInputNumber(ShefaaForms.EditEntry, "ادخل رقم سند القيد");
        }

        private void dgDetail_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            dgDetail.Rows[e.RowIndex].ErrorText = "لايمكن أن يبقى هذا الحقل فارغا";
            e.Cancel = true;
        }

        private void NewEntry()
        {
            if (entryMaster.TotalCredit != entryMaster.TotalDebit)
            {
                _MessageBoxDialog.Show("المدين لا يساوي الدائن لا يمكن المتابعة", MessageBoxState.Error);
                return;
            }
            if (entryMaster.EntryDetails.Count == 0)
            {
                _MessageBoxDialog.Show("لا يوجد أسطر للتخزين", MessageBoxState.Error);
                return;
            }
            CheckLastRow();
            var context = ShefaaPharmacyDbContext.GetCurrentContext();
            var newMaster = context.EntryMasters.Add(EditBindingSource.Current as EntryMaster);
            context.SaveChanges();
            _MessageBoxDialog.Show("تم إضافة سند قيد برقم " + newMaster.Entity.Id, MessageBoxState.Done);
            if (FormOperation == FormOperation.NewFromPicker)
                Close();
            else
                EditBindingSource.AddNew();
        }
        /// <summary>
        ///  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pOk_Click(object sender, EventArgs e)
        {

            //if (FormOperation == FormOperation.New || FormOperation == FormOperation.NewFromPicker)
            //{
            //    CheckLastRow();
            //    if (entryMaster.TotalCredit != entryMaster.TotalDebit)
            //    {
            //        _MessageBoxDialog.Show("المدين لا يساوي الدائن لا يمكن المتابعة", MessageBoxState.Error);
            //        return;
            //    }
            //    if (entryMaster.EntryDetails.Count == 0)
            //    {
            //        _MessageBoxDialog.Show("لا يوجد أسطر للتخزين", MessageBoxState.Error);
            //        return;
            //    }
            //    ShefaaPharmacyDbContext context = ShefaaPharmacyDbContext.GetCurrentContext();
            //    if (NewRecord)
            //    {
            //        var newMaster = context.EntryMasters.Add(EditBindingSource.Current as EntryMaster);
            //        context.SaveChanges();
            //        _MessageBoxDialog.Show("تم إضافة سند قيد برقم " + newMaster.Entity.Id, MessageBoxState.Done);
            //        if (Pick)
            //            Close();
            //        else
            //            EditBindingSource.AddNew();
            //    }
            //    else
            //    {

            //    }
            //}
            //else if (FormOperation == FormOperation.Edit || FormOperation == FormOperation.EditFromPicker)
            //{

            //}
        }
    }
}
