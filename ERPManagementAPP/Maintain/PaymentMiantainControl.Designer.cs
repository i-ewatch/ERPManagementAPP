
namespace ERPManagementAPP.Maintain
{
    partial class PaymentMiantainControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentMiantainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentItemNo1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentItemName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btn_PaymentItem_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_PaymentItem_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_PaymentItem_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_PaymentItem_Add = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentItemNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentUse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentMethod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Payment_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Payment_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Payment_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Payment_Add = new DevExpress.XtraEditors.SimpleButton();
            this.det_PaymentDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.det_PaymentDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_PaymentDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl2);
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 843);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.Controls.Add(this.gridControl2);
            this.groupControl2.Controls.Add(this.panelControl2);
            this.groupControl2.Location = new System.Drawing.Point(874, 12);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(392, 819);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "請款品項";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 66);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(388, 751);
            this.gridControl2.TabIndex = 1;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentItemNo1,
            this.colPaymentItemName});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colPaymentItemNo1
            // 
            this.colPaymentItemNo1.Caption = "品項代碼";
            this.colPaymentItemNo1.FieldName = "PaymentItemNo";
            this.colPaymentItemNo1.Name = "colPaymentItemNo1";
            this.colPaymentItemNo1.OptionsColumn.AllowEdit = false;
            this.colPaymentItemNo1.Visible = true;
            this.colPaymentItemNo1.VisibleIndex = 0;
            // 
            // colPaymentItemName
            // 
            this.colPaymentItemName.Caption = "品項名稱";
            this.colPaymentItemName.FieldName = "PaymentItemName";
            this.colPaymentItemName.Name = "colPaymentItemName";
            this.colPaymentItemName.OptionsColumn.AllowEdit = false;
            this.colPaymentItemName.Visible = true;
            this.colPaymentItemName.VisibleIndex = 1;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btn_PaymentItem_Refresh);
            this.panelControl2.Controls.Add(this.btn_PaymentItem_Delete);
            this.panelControl2.Controls.Add(this.btn_PaymentItem_Edit);
            this.panelControl2.Controls.Add(this.btn_PaymentItem_Add);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(2, 23);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(388, 43);
            this.panelControl2.TabIndex = 0;
            // 
            // btn_PaymentItem_Refresh
            // 
            this.btn_PaymentItem_Refresh.AllowFocus = false;
            this.btn_PaymentItem_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_PaymentItem_Refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_PaymentItem_Refresh.ImageOptions.Image")));
            this.btn_PaymentItem_Refresh.Location = new System.Drawing.Point(255, 0);
            this.btn_PaymentItem_Refresh.Name = "btn_PaymentItem_Refresh";
            this.btn_PaymentItem_Refresh.Size = new System.Drawing.Size(85, 43);
            this.btn_PaymentItem_Refresh.TabIndex = 12;
            this.btn_PaymentItem_Refresh.Text = "Refresh";
            // 
            // btn_PaymentItem_Delete
            // 
            this.btn_PaymentItem_Delete.AllowFocus = false;
            this.btn_PaymentItem_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_PaymentItem_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_PaymentItem_Delete.ImageOptions.Image")));
            this.btn_PaymentItem_Delete.Location = new System.Drawing.Point(170, 0);
            this.btn_PaymentItem_Delete.Name = "btn_PaymentItem_Delete";
            this.btn_PaymentItem_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_PaymentItem_Delete.TabIndex = 11;
            this.btn_PaymentItem_Delete.Text = "Delete";
            // 
            // btn_PaymentItem_Edit
            // 
            this.btn_PaymentItem_Edit.AllowFocus = false;
            this.btn_PaymentItem_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_PaymentItem_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_PaymentItem_Edit.ImageOptions.Image")));
            this.btn_PaymentItem_Edit.Location = new System.Drawing.Point(85, 0);
            this.btn_PaymentItem_Edit.Name = "btn_PaymentItem_Edit";
            this.btn_PaymentItem_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_PaymentItem_Edit.TabIndex = 10;
            this.btn_PaymentItem_Edit.Text = "Edit";
            // 
            // btn_PaymentItem_Add
            // 
            this.btn_PaymentItem_Add.AllowFocus = false;
            this.btn_PaymentItem_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_PaymentItem_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_PaymentItem_Add.ImageOptions.Image")));
            this.btn_PaymentItem_Add.Location = new System.Drawing.Point(0, 0);
            this.btn_PaymentItem_Add.Name = "btn_PaymentItem_Add";
            this.btn_PaymentItem_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_PaymentItem_Add.TabIndex = 9;
            this.btn_PaymentItem_Add.Text = "Add";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(853, 819);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "代墊代付資料";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 66);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(849, 751);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentNumber,
            this.colProjectNumber,
            this.colPaymentDate,
            this.colPaymentInvoiceNo,
            this.colPaymentItemNo,
            this.colPaymentUse,
            this.colEmployeeNumber,
            this.colPaymentAmount,
            this.colPaymentMethod,
            this.colRemark,
            this.colTransferDate,
            this.colFileName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPaymentNumber
            // 
            this.colPaymentNumber.Caption = "編號";
            this.colPaymentNumber.FieldName = "PaymentNumber";
            this.colPaymentNumber.Name = "colPaymentNumber";
            this.colPaymentNumber.OptionsColumn.AllowEdit = false;
            this.colPaymentNumber.Visible = true;
            this.colPaymentNumber.VisibleIndex = 0;
            // 
            // colProjectNumber
            // 
            this.colProjectNumber.Caption = "專案代碼";
            this.colProjectNumber.FieldName = "ProjectNumber";
            this.colProjectNumber.Name = "colProjectNumber";
            this.colProjectNumber.OptionsColumn.AllowEdit = false;
            this.colProjectNumber.Visible = true;
            this.colProjectNumber.VisibleIndex = 1;
            // 
            // colPaymentDate
            // 
            this.colPaymentDate.Caption = "日期";
            this.colPaymentDate.FieldName = "PaymentDate";
            this.colPaymentDate.Name = "colPaymentDate";
            this.colPaymentDate.OptionsColumn.AllowEdit = false;
            this.colPaymentDate.Visible = true;
            this.colPaymentDate.VisibleIndex = 2;
            // 
            // colPaymentInvoiceNo
            // 
            this.colPaymentInvoiceNo.Caption = "發票號碼";
            this.colPaymentInvoiceNo.FieldName = "PaymentInvoiceNo";
            this.colPaymentInvoiceNo.Name = "colPaymentInvoiceNo";
            this.colPaymentInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colPaymentInvoiceNo.Visible = true;
            this.colPaymentInvoiceNo.VisibleIndex = 3;
            // 
            // colPaymentItemNo
            // 
            this.colPaymentItemNo.Caption = "品項代碼";
            this.colPaymentItemNo.FieldName = "PaymentItemNo";
            this.colPaymentItemNo.Name = "colPaymentItemNo";
            this.colPaymentItemNo.OptionsColumn.AllowEdit = false;
            this.colPaymentItemNo.Visible = true;
            this.colPaymentItemNo.VisibleIndex = 4;
            // 
            // colPaymentUse
            // 
            this.colPaymentUse.Caption = "用途";
            this.colPaymentUse.FieldName = "PaymentUse";
            this.colPaymentUse.Name = "colPaymentUse";
            this.colPaymentUse.OptionsColumn.AllowEdit = false;
            this.colPaymentUse.Visible = true;
            this.colPaymentUse.VisibleIndex = 5;
            // 
            // colEmployeeNumber
            // 
            this.colEmployeeNumber.Caption = "申請人";
            this.colEmployeeNumber.FieldName = "EmployeeNumber";
            this.colEmployeeNumber.Name = "colEmployeeNumber";
            this.colEmployeeNumber.OptionsColumn.AllowEdit = false;
            this.colEmployeeNumber.OptionsFilter.AllowAutoFilter = false;
            this.colEmployeeNumber.Visible = true;
            this.colEmployeeNumber.VisibleIndex = 6;
            // 
            // colPaymentAmount
            // 
            this.colPaymentAmount.Caption = "金額";
            this.colPaymentAmount.DisplayFormat.FormatString = "C0";
            this.colPaymentAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colPaymentAmount.FieldName = "PaymentAmount";
            this.colPaymentAmount.Name = "colPaymentAmount";
            this.colPaymentAmount.OptionsColumn.AllowEdit = false;
            this.colPaymentAmount.Visible = true;
            this.colPaymentAmount.VisibleIndex = 7;
            // 
            // colPaymentMethod
            // 
            this.colPaymentMethod.Caption = "請款方式";
            this.colPaymentMethod.FieldName = "PaymentMethod";
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.OptionsColumn.AllowEdit = false;
            this.colPaymentMethod.Visible = true;
            this.colPaymentMethod.VisibleIndex = 8;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "備註";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 9;
            // 
            // colTransferDate
            // 
            this.colTransferDate.Caption = "匯款收款日期";
            this.colTransferDate.FieldName = "TransferDate";
            this.colTransferDate.Name = "colTransferDate";
            this.colTransferDate.OptionsColumn.AllowEdit = false;
            this.colTransferDate.Visible = true;
            this.colTransferDate.VisibleIndex = 10;
            // 
            // colFileName
            // 
            this.colFileName.Caption = "附件檔名";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 11;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_Payment_Refresh);
            this.panelControl1.Controls.Add(this.btn_Payment_Delete);
            this.panelControl1.Controls.Add(this.btn_Payment_Edit);
            this.panelControl1.Controls.Add(this.btn_Payment_Add);
            this.panelControl1.Controls.Add(this.det_PaymentDate);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(849, 43);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_Payment_Refresh
            // 
            this.btn_Payment_Refresh.AllowFocus = false;
            this.btn_Payment_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Payment_Refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Payment_Refresh.ImageOptions.Image")));
            this.btn_Payment_Refresh.Location = new System.Drawing.Point(468, 0);
            this.btn_Payment_Refresh.Name = "btn_Payment_Refresh";
            this.btn_Payment_Refresh.Size = new System.Drawing.Size(85, 43);
            this.btn_Payment_Refresh.TabIndex = 31;
            this.btn_Payment_Refresh.Text = "Refresh";
            // 
            // btn_Payment_Delete
            // 
            this.btn_Payment_Delete.AllowFocus = false;
            this.btn_Payment_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Payment_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Payment_Delete.ImageOptions.Image")));
            this.btn_Payment_Delete.Location = new System.Drawing.Point(383, 0);
            this.btn_Payment_Delete.Name = "btn_Payment_Delete";
            this.btn_Payment_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Payment_Delete.TabIndex = 30;
            this.btn_Payment_Delete.Text = "Delete";
            // 
            // btn_Payment_Edit
            // 
            this.btn_Payment_Edit.AllowFocus = false;
            this.btn_Payment_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Payment_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Payment_Edit.ImageOptions.Image")));
            this.btn_Payment_Edit.Location = new System.Drawing.Point(298, 0);
            this.btn_Payment_Edit.Name = "btn_Payment_Edit";
            this.btn_Payment_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Payment_Edit.TabIndex = 29;
            this.btn_Payment_Edit.Text = "Edit";
            // 
            // btn_Payment_Add
            // 
            this.btn_Payment_Add.AllowFocus = false;
            this.btn_Payment_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Payment_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Payment_Add.ImageOptions.Image")));
            this.btn_Payment_Add.Location = new System.Drawing.Point(213, 0);
            this.btn_Payment_Add.Name = "btn_Payment_Add";
            this.btn_Payment_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Payment_Add.TabIndex = 28;
            this.btn_Payment_Add.Text = "Add";
            // 
            // det_PaymentDate
            // 
            this.det_PaymentDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.det_PaymentDate.EditValue = null;
            this.det_PaymentDate.Location = new System.Drawing.Point(45, 0);
            this.det_PaymentDate.Name = "det_PaymentDate";
            this.det_PaymentDate.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.det_PaymentDate.Properties.Appearance.Options.UseFont = true;
            this.det_PaymentDate.Properties.Appearance.Options.UseTextOptions = true;
            this.det_PaymentDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.det_PaymentDate.Properties.AutoHeight = false;
            this.det_PaymentDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_PaymentDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_PaymentDate.Properties.Mask.EditMask = "yyyy/MM";
            this.det_PaymentDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.det_PaymentDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.True;
            this.det_PaymentDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.det_PaymentDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.det_PaymentDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.det_PaymentDate.Size = new System.Drawing.Size(168, 43);
            this.det_PaymentDate.TabIndex = 27;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(45, 43);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "日期";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.splitterItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1278, 843);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(857, 823);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.groupControl2;
            this.layoutControlItem2.Location = new System.Drawing.Point(862, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(396, 823);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(857, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 823);
            // 
            // PaymentMiantainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "PaymentMiantainControl";
            this.Size = new System.Drawing.Size(1278, 843);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.det_PaymentDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_PaymentDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentUse;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentItemNo1;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentItemName;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_PaymentItem_Refresh;
        private DevExpress.XtraEditors.SimpleButton btn_PaymentItem_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_PaymentItem_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_PaymentItem_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Payment_Refresh;
        private DevExpress.XtraEditors.SimpleButton btn_Payment_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Payment_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Payment_Add;
        private DevExpress.XtraEditors.DateEdit det_PaymentDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNumber;
    }
}
