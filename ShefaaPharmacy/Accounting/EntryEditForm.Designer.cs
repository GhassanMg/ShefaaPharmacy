namespace ShefaaPharmacy.Accounting
{
    partial class EntryEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntryEditForm));
            this.pTopMaster = new System.Windows.Forms.Panel();
            this.lbDeleteEntry = new System.Windows.Forms.LinkLabel();
            this.lbEditEntry = new System.Windows.Forms.LinkLabel();
            this.tbId = new System.Windows.Forms.TextBox();
            this.lbDate = new System.Windows.Forms.Label();
            this.lbMasterId = new System.Windows.Forms.Label();
            this.dtCreationDate = new MetroFramework.Controls.MetroDateTime();
            this.pBottomLastOperation = new System.Windows.Forms.Panel();
            this.pPrevLast = new System.Windows.Forms.Panel();
            this.pbPrevLast = new System.Windows.Forms.PictureBox();
            this.lbPrevLast = new System.Windows.Forms.Label();
            this.pPrevPrevLast = new System.Windows.Forms.Panel();
            this.pbPrevPrevLast = new System.Windows.Forms.PictureBox();
            this.lbPrevPrevLast = new System.Windows.Forms.Label();
            this.pLastOp = new System.Windows.Forms.Panel();
            this.pbLastOp = new System.Windows.Forms.PictureBox();
            this.lbLastOp = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pBottomMaster = new System.Windows.Forms.Panel();
            this.pbCancel = new System.Windows.Forms.PictureBox();
            this.pbOk = new System.Windows.Forms.PictureBox();
            this.tbBalance = new System.Windows.Forms.TextBox();
            this.tbTotCredit = new System.Windows.Forms.TextBox();
            this.tbTotDebit = new System.Windows.Forms.TextBox();
            this.lbRemainingAmount = new System.Windows.Forms.Label();
            this.lbTotalPrice = new System.Windows.Forms.Label();
            this.lbPayment = new System.Windows.Forms.Label();
            this.pFillDetail = new System.Windows.Forms.Panel();
            this.dgDetail = new System.Windows.Forms.DataGridView();
            this.DetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.EditBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).BeginInit();
            this.pHelperButton.SuspendLayout();
            this.pTopMaster.SuspendLayout();
            this.pBottomLastOperation.SuspendLayout();
            this.pPrevLast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevLast)).BeginInit();
            this.pPrevPrevLast.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevPrevLast)).BeginInit();
            this.pLastOp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastOp)).BeginInit();
            this.pBottomMaster.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).BeginInit();
            this.pFillDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pHelperButton
            // 
            this.pHelperButton.Location = new System.Drawing.Point(835, 5);
            this.pHelperButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            // 
            // pTopMaster
            // 
            this.pTopMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pTopMaster.Controls.Add(this.lbDeleteEntry);
            this.pTopMaster.Controls.Add(this.lbEditEntry);
            this.pTopMaster.Controls.Add(this.tbId);
            this.pTopMaster.Controls.Add(this.lbDate);
            this.pTopMaster.Controls.Add(this.lbMasterId);
            this.pTopMaster.Controls.Add(this.dtCreationDate);
            this.pTopMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTopMaster.Location = new System.Drawing.Point(24, 63);
            this.pTopMaster.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pTopMaster.Name = "pTopMaster";
            this.pTopMaster.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pTopMaster.Size = new System.Drawing.Size(1016, 44);
            this.pTopMaster.TabIndex = 1;
            // 
            // lbDeleteEntry
            // 
            this.lbDeleteEntry.AutoSize = true;
            this.lbDeleteEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbDeleteEntry.Location = new System.Drawing.Point(46, 10);
            this.lbDeleteEntry.Name = "lbDeleteEntry";
            this.lbDeleteEntry.Size = new System.Drawing.Size(72, 18);
            this.lbDeleteEntry.TabIndex = 237;
            this.lbDeleteEntry.TabStop = true;
            this.lbDeleteEntry.Text = "حذف سند قيد";
            this.lbDeleteEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbDeleteEntry_LinkClicked);
            // 
            // lbEditEntry
            // 
            this.lbEditEntry.AutoSize = true;
            this.lbEditEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbEditEntry.Location = new System.Drawing.Point(159, 10);
            this.lbEditEntry.Name = "lbEditEntry";
            this.lbEditEntry.Size = new System.Drawing.Size(74, 18);
            this.lbEditEntry.TabIndex = 236;
            this.lbEditEntry.TabStop = true;
            this.lbEditEntry.Text = "تعديل سند قيد";
            this.lbEditEntry.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LbEditEntry_LinkClicked);
            // 
            // tbId
            // 
            this.tbId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbId.Location = new System.Drawing.Point(793, 10);
            this.tbId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(131, 24);
            this.tbId.TabIndex = 235;
            // 
            // lbDate
            // 
            this.lbDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDate.AutoSize = true;
            this.lbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbDate.Location = new System.Drawing.Point(703, 12);
            this.lbDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbDate.Name = "lbDate";
            this.lbDate.Size = new System.Drawing.Size(42, 18);
            this.lbDate.TabIndex = 27;
            this.lbDate.Text = "التاريخ";
            // 
            // lbMasterId
            // 
            this.lbMasterId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbMasterId.AutoSize = true;
            this.lbMasterId.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbMasterId.Location = new System.Drawing.Point(930, 12);
            this.lbMasterId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMasterId.Name = "lbMasterId";
            this.lbMasterId.Size = new System.Drawing.Size(48, 18);
            this.lbMasterId.TabIndex = 26;
            this.lbMasterId.Text = "رقم القيد";
            // 
            // dtCreationDate
            // 
            this.dtCreationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtCreationDate.Location = new System.Drawing.Point(438, 10);
            this.dtCreationDate.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dtCreationDate.MinimumSize = new System.Drawing.Size(0, 29);
            this.dtCreationDate.Name = "dtCreationDate";
            this.dtCreationDate.Size = new System.Drawing.Size(232, 30);
            this.dtCreationDate.TabIndex = 25;
            // 
            // pBottomLastOperation
            // 
            this.pBottomLastOperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBottomLastOperation.Controls.Add(this.pPrevLast);
            this.pBottomLastOperation.Controls.Add(this.pPrevPrevLast);
            this.pBottomLastOperation.Controls.Add(this.pLastOp);
            this.pBottomLastOperation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottomLastOperation.Location = new System.Drawing.Point(24, 440);
            this.pBottomLastOperation.Margin = new System.Windows.Forms.Padding(4, 7, 4, 3);
            this.pBottomLastOperation.Name = "pBottomLastOperation";
            this.pBottomLastOperation.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pBottomLastOperation.Size = new System.Drawing.Size(1016, 62);
            this.pBottomLastOperation.TabIndex = 10;
            // 
            // pPrevLast
            // 
            this.pPrevLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPrevLast.Controls.Add(this.pbPrevLast);
            this.pPrevLast.Controls.Add(this.lbPrevLast);
            this.pPrevLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pPrevLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pPrevLast.Location = new System.Drawing.Point(313, 3);
            this.pPrevLast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pPrevLast.Name = "pPrevLast";
            this.pPrevLast.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pPrevLast.Size = new System.Drawing.Size(389, 54);
            this.pPrevLast.TabIndex = 3;
            this.pPrevLast.Click += new System.EventHandler(this.pPrevLast_Click);
            // 
            // pbPrevLast
            // 
            this.pbPrevLast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbPrevLast.Image = ((System.Drawing.Image)(resources.GetObject("pbPrevLast.Image")));
            this.pbPrevLast.Location = new System.Drawing.Point(279, 12);
            this.pbPrevLast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbPrevLast.Name = "pbPrevLast";
            this.pbPrevLast.Size = new System.Drawing.Size(42, 33);
            this.pbPrevLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrevLast.TabIndex = 4;
            this.pbPrevLast.TabStop = false;
            this.pbPrevLast.Click += new System.EventHandler(this.pPrevLast_Click);
            // 
            // lbPrevLast
            // 
            this.lbPrevLast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPrevLast.AutoSize = true;
            this.lbPrevLast.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbPrevLast.Location = new System.Drawing.Point(183, 16);
            this.lbPrevLast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPrevLast.Name = "lbPrevLast";
            this.lbPrevLast.Size = new System.Drawing.Size(73, 21);
            this.lbPrevLast.TabIndex = 2;
            this.lbPrevLast.Text = "عملية رقم";
            this.lbPrevLast.Click += new System.EventHandler(this.pPrevLast_Click);
            // 
            // pPrevPrevLast
            // 
            this.pPrevPrevLast.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pPrevPrevLast.Controls.Add(this.pbPrevPrevLast);
            this.pPrevPrevLast.Controls.Add(this.lbPrevPrevLast);
            this.pPrevPrevLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pPrevPrevLast.Dock = System.Windows.Forms.DockStyle.Left;
            this.pPrevPrevLast.Location = new System.Drawing.Point(3, 3);
            this.pPrevPrevLast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pPrevPrevLast.Name = "pPrevPrevLast";
            this.pPrevPrevLast.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pPrevPrevLast.Size = new System.Drawing.Size(310, 54);
            this.pPrevPrevLast.TabIndex = 2;
            this.pPrevPrevLast.Click += new System.EventHandler(this.pPrevPrevLast_Click);
            // 
            // pbPrevPrevLast
            // 
            this.pbPrevPrevLast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPrevPrevLast.Image = ((System.Drawing.Image)(resources.GetObject("pbPrevPrevLast.Image")));
            this.pbPrevPrevLast.Location = new System.Drawing.Point(248, 12);
            this.pbPrevPrevLast.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbPrevPrevLast.Name = "pbPrevPrevLast";
            this.pbPrevPrevLast.Size = new System.Drawing.Size(42, 33);
            this.pbPrevPrevLast.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPrevPrevLast.TabIndex = 7;
            this.pbPrevPrevLast.TabStop = false;
            this.pbPrevPrevLast.Click += new System.EventHandler(this.pPrevPrevLast_Click);
            // 
            // lbPrevPrevLast
            // 
            this.lbPrevPrevLast.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbPrevPrevLast.AutoSize = true;
            this.lbPrevPrevLast.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lbPrevPrevLast.Location = new System.Drawing.Point(126, 16);
            this.lbPrevPrevLast.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPrevPrevLast.Name = "lbPrevPrevLast";
            this.lbPrevPrevLast.Size = new System.Drawing.Size(73, 21);
            this.lbPrevPrevLast.TabIndex = 6;
            this.lbPrevPrevLast.Text = "عملية رقم";
            this.lbPrevPrevLast.Click += new System.EventHandler(this.pPrevPrevLast_Click);
            // 
            // pLastOp
            // 
            this.pLastOp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pLastOp.Controls.Add(this.pbLastOp);
            this.pLastOp.Controls.Add(this.lbLastOp);
            this.pLastOp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pLastOp.Dock = System.Windows.Forms.DockStyle.Right;
            this.pLastOp.Location = new System.Drawing.Point(702, 3);
            this.pLastOp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pLastOp.Name = "pLastOp";
            this.pLastOp.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pLastOp.Size = new System.Drawing.Size(309, 54);
            this.pLastOp.TabIndex = 1;
            this.pLastOp.Click += new System.EventHandler(this.pLastOp_Click);
            // 
            // pbLastOp
            // 
            this.pbLastOp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbLastOp.Image = ((System.Drawing.Image)(resources.GetObject("pbLastOp.Image")));
            this.pbLastOp.Location = new System.Drawing.Point(242, 12);
            this.pbLastOp.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbLastOp.Name = "pbLastOp";
            this.pbLastOp.Size = new System.Drawing.Size(42, 33);
            this.pbLastOp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLastOp.TabIndex = 3;
            this.pbLastOp.TabStop = false;
            this.pbLastOp.Click += new System.EventHandler(this.pLastOp_Click);
            // 
            // lbLastOp
            // 
            this.lbLastOp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbLastOp.AutoSize = true;
            this.lbLastOp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLastOp.Location = new System.Drawing.Point(94, 16);
            this.lbLastOp.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbLastOp.Name = "lbLastOp";
            this.lbLastOp.Size = new System.Drawing.Size(97, 21);
            this.lbLastOp.TabIndex = 1;
            this.lbLastOp.Text = "آخر عملية رقم";
            this.lbLastOp.Click += new System.EventHandler(this.pLastOp_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(24, 432);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1016, 8);
            this.splitter1.TabIndex = 14;
            this.splitter1.TabStop = false;
            // 
            // pBottomMaster
            // 
            this.pBottomMaster.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBottomMaster.Controls.Add(this.pbCancel);
            this.pBottomMaster.Controls.Add(this.pbOk);
            this.pBottomMaster.Controls.Add(this.tbBalance);
            this.pBottomMaster.Controls.Add(this.tbTotCredit);
            this.pBottomMaster.Controls.Add(this.tbTotDebit);
            this.pBottomMaster.Controls.Add(this.lbRemainingAmount);
            this.pBottomMaster.Controls.Add(this.lbTotalPrice);
            this.pBottomMaster.Controls.Add(this.lbPayment);
            this.pBottomMaster.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pBottomMaster.Location = new System.Drawing.Point(24, 346);
            this.pBottomMaster.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pBottomMaster.Name = "pBottomMaster";
            this.pBottomMaster.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pBottomMaster.Size = new System.Drawing.Size(1016, 86);
            this.pBottomMaster.TabIndex = 16;
            // 
            // pbCancel
            // 
            this.pbCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbCancel.Image = global::ShefaaPharmacy.Properties.Resources.Group_2299__1_;
            this.pbCancel.Location = new System.Drawing.Point(328, 49);
            this.pbCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbCancel.Name = "pbCancel";
            this.pbCancel.Size = new System.Drawing.Size(164, 30);
            this.pbCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbCancel.TabIndex = 241;
            this.pbCancel.TabStop = false;
            this.pbCancel.Click += new System.EventHandler(this.pbCancel_Click);
            // 
            // pbOk
            // 
            this.pbOk.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbOk.Image = global::ShefaaPharmacy.Properties.Resources.Group_2315;
            this.pbOk.Location = new System.Drawing.Point(544, 49);
            this.pbOk.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pbOk.Name = "pbOk";
            this.pbOk.Size = new System.Drawing.Size(158, 30);
            this.pbOk.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbOk.TabIndex = 240;
            this.pbOk.TabStop = false;
            this.pbOk.Click += new System.EventHandler(this.PbOk_Click);
            // 
            // tbBalance
            // 
            this.tbBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbBalance.Location = new System.Drawing.Point(227, 13);
            this.tbBalance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbBalance.Name = "tbBalance";
            this.tbBalance.Size = new System.Drawing.Size(131, 24);
            this.tbBalance.TabIndex = 238;
            // 
            // tbTotCredit
            // 
            this.tbTotCredit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotCredit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbTotCredit.Location = new System.Drawing.Point(456, 13);
            this.tbTotCredit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbTotCredit.Name = "tbTotCredit";
            this.tbTotCredit.Size = new System.Drawing.Size(131, 24);
            this.tbTotCredit.TabIndex = 237;
            // 
            // tbTotDebit
            // 
            this.tbTotDebit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTotDebit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.tbTotDebit.Location = new System.Drawing.Point(712, 13);
            this.tbTotDebit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tbTotDebit.Name = "tbTotDebit";
            this.tbTotDebit.Size = new System.Drawing.Size(131, 24);
            this.tbTotDebit.TabIndex = 236;
            // 
            // lbRemainingAmount
            // 
            this.lbRemainingAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbRemainingAmount.AutoSize = true;
            this.lbRemainingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbRemainingAmount.Location = new System.Drawing.Point(593, 15);
            this.lbRemainingAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRemainingAmount.Name = "lbRemainingAmount";
            this.lbRemainingAmount.Size = new System.Drawing.Size(74, 18);
            this.lbRemainingAmount.TabIndex = 18;
            this.lbRemainingAmount.Text = "إجمالي الدائن";
            // 
            // lbTotalPrice
            // 
            this.lbTotalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTotalPrice.AutoSize = true;
            this.lbTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbTotalPrice.Location = new System.Drawing.Point(364, 15);
            this.lbTotalPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTotalPrice.Name = "lbTotalPrice";
            this.lbTotalPrice.Size = new System.Drawing.Size(35, 18);
            this.lbTotalPrice.TabIndex = 17;
            this.lbTotalPrice.Text = "الفرق";
            // 
            // lbPayment
            // 
            this.lbPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbPayment.AutoSize = true;
            this.lbPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lbPayment.Location = new System.Drawing.Point(850, 15);
            this.lbPayment.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPayment.Name = "lbPayment";
            this.lbPayment.Size = new System.Drawing.Size(76, 18);
            this.lbPayment.TabIndex = 16;
            this.lbPayment.Text = "إجمالي المدين";
            // 
            // pFillDetail
            // 
            this.pFillDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pFillDetail.Controls.Add(this.dgDetail);
            this.pFillDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pFillDetail.Location = new System.Drawing.Point(24, 107);
            this.pFillDetail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pFillDetail.Name = "pFillDetail";
            this.pFillDetail.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.pFillDetail.Size = new System.Drawing.Size(1016, 239);
            this.pFillDetail.TabIndex = 17;
            // 
            // dgDetail
            // 
            this.dgDetail.AutoGenerateColumns = false;
            this.dgDetail.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgDetail.BackgroundColor = System.Drawing.Color.White;
            this.dgDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDetail.DataSource = this.DetailBindingSource;
            this.dgDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgDetail.Location = new System.Drawing.Point(3, 3);
            this.dgDetail.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgDetail.MultiSelect = false;
            this.dgDetail.Name = "dgDetail";
            this.dgDetail.Size = new System.Drawing.Size(1008, 231);
            this.dgDetail.TabIndex = 0;
            this.dgDetail.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgDetail_CellValidating);
            this.dgDetail.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgDetail_DataError);
            this.dgDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgDetail_EditingControlShowing);
            this.dgDetail.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgDetail_RowEnter);
            this.dgDetail.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgDetail_RowValidating);
            this.dgDetail.BindingContextChanged += new System.EventHandler(this.dgDetail_BindingContextChanged);
            // 
            // DetailBindingSource
            // 
            this.DetailBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.DetailBindingSource_AddingNew);
            // 
            // EditBindingSource
            // 
            this.EditBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.EditBindingSource_AddingNew);
            this.EditBindingSource.DataSourceChanged += new System.EventHandler(this.EditBindingSource_DataSourceChanged);
            // 
            // EntryEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1051, 514);
            this.Controls.Add(this.pFillDetail);
            this.Controls.Add(this.pBottomMaster);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pBottomLastOperation);
            this.Controls.Add(this.pTopMaster);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EntryEditForm";
            this.Padding = new System.Windows.Forms.Padding(24, 63, 11, 12);
            this.Text = "سند قيد";
            this.Load += new System.EventHandler(this.EntryEditForm_Load);
            this.Controls.SetChildIndex(this.pTopMaster, 0);
            this.Controls.SetChildIndex(this.pBottomLastOperation, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.pBottomMaster, 0);
            this.Controls.SetChildIndex(this.pFillDetail, 0);
            this.Controls.SetChildIndex(this.pHelperButton, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnMaximaizing)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnMinimizing)).EndInit();
            this.pHelperButton.ResumeLayout(false);
            this.pTopMaster.ResumeLayout(false);
            this.pTopMaster.PerformLayout();
            this.pBottomLastOperation.ResumeLayout(false);
            this.pPrevLast.ResumeLayout(false);
            this.pPrevLast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevLast)).EndInit();
            this.pPrevPrevLast.ResumeLayout(false);
            this.pPrevPrevLast.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrevPrevLast)).EndInit();
            this.pLastOp.ResumeLayout(false);
            this.pLastOp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLastOp)).EndInit();
            this.pBottomMaster.ResumeLayout(false);
            this.pBottomMaster.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOk)).EndInit();
            this.pFillDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EditBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTopMaster;
        private System.Windows.Forms.Panel pBottomLastOperation;
        private System.Windows.Forms.Panel pPrevLast;
        private System.Windows.Forms.PictureBox pbPrevLast;
        private System.Windows.Forms.Label lbPrevLast;
        private System.Windows.Forms.Panel pPrevPrevLast;
        private System.Windows.Forms.PictureBox pbPrevPrevLast;
        private System.Windows.Forms.Label lbPrevPrevLast;
        private System.Windows.Forms.Panel pLastOp;
        private System.Windows.Forms.PictureBox pbLastOp;
        private System.Windows.Forms.Label lbLastOp;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel pBottomMaster;
        private System.Windows.Forms.Label lbRemainingAmount;
        private System.Windows.Forms.Label lbTotalPrice;
        private System.Windows.Forms.Label lbPayment;
        private System.Windows.Forms.Panel pFillDetail;
        private System.Windows.Forms.DataGridView dgDetail;
        private System.Windows.Forms.BindingSource EditBindingSource;
        private System.Windows.Forms.BindingSource DetailBindingSource;
        private System.Windows.Forms.Label lbDate;
        private System.Windows.Forms.Label lbMasterId;
        private MetroFramework.Controls.MetroDateTime dtCreationDate;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TextBox tbBalance;
        private System.Windows.Forms.TextBox tbTotCredit;
        private System.Windows.Forms.TextBox tbTotDebit;
        private System.Windows.Forms.PictureBox pbCancel;
        private System.Windows.Forms.PictureBox pbOk;
        private System.Windows.Forms.LinkLabel lbDeleteEntry;
        private System.Windows.Forms.LinkLabel lbEditEntry;
    }
}
