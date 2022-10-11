using ShefaaPharmacy.Helper;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShefaaPharmacy.GeneralUI
{
    public partial class GeneralEditForm : ShefaaPharmacy.GeneralUI.AbstractForm
    {
        protected object CurrentEntity;
        protected bool close = false;
        protected string[] HiddenColumn;
        public GeneralEditForm()
        {
            InitializeComponent();
        }
        virtual protected void DesignDataGridView(DataGridView dataGridView)
        {
            dataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("AD-STOOR", 12);
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(66, 172, 186);

            dataGridView.DefaultCellStyle.Font = new Font("AD-STOOR", 10);
            dataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        virtual protected void ShowColumn(DataGridViewColumnCollection dataGridViewColumnCollection)
        {
            foreach (DataGridViewColumn item in dataGridViewColumnCollection)
            {
                if (HiddenColumn == null || !HiddenColumn.Contains(item.Name))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }
        virtual protected void ShowColumn(DataGridViewColumnCollection dataGridViewColumnCollection,string[] hiddenColumn)
        {
            foreach (DataGridViewColumn item in dataGridViewColumnCollection)
            {
                if (hiddenColumn == null || !hiddenColumn.Contains(item.Name))
                {
                    item.Visible = true;
                }
                else
                {
                    item.Visible = false;
                }
            }
        }
        virtual protected void ShowSpecificColumn(DataGridViewColumnCollection dataGridViewColumnCollection)
        {
            foreach (DataGridViewColumn item in dataGridViewColumnCollection)
            {
                if (HiddenColumn == null || !HiddenColumn.Contains(item.Name))
                {
                    item.Visible = false;
                }
                else
                {
                    item.Visible = true;
                }
            }
        }
        protected virtual void BindingEntityToControls()
        {

        }

        private void EditBindingSource_DataSourceChanged(object sender, EventArgs e)
        {
            BindingEntityToControls();
        }

        private void GeneralEditForm_Load(object sender, EventArgs e)
        {
            //btnCancel.Size = new Size(136, 49);
            //btnOk.Size = new Size(136, 49);
            int leftFirstButton = ((pBottom.Size.Width - (btnCancel.Size.Width + btnOk.Size.Width)) / 2);
            btnCancel.Location = new Point(leftFirstButton - 3, 0);
            btnOk.Location = new Point(leftFirstButton + btnCancel.Size.Width + 3, 0);
        }

        virtual protected void btOk_Click(object sender, EventArgs e)
        {
            if (_MessageBoxDialog.Show("هل انت متاكد ؟ ", MessageBoxState.Answering) == MessageBoxAnswer.No)
                throw new Exception();
        }

        virtual protected void btCancel_Click(object sender, EventArgs e)
        {
            if (_MessageBoxDialog.Show("هل تريد فعلا إلغاء كل ما أجري من تعديلات ؟",MessageBoxState.Answering) == MessageBoxAnswer.Yes)
                Close();
        }
    }
}
