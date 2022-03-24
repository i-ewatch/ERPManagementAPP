
namespace ERPManagementAPP.Maintain
{
    partial class PartnerMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PartnerMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.SalesgridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSalesFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPostingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTakeACut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCost = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfitSharing = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfitSharingDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSalesEmployeeNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Company_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btn_Export = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Sales_Search = new DevExpress.XtraEditors.SimpleButton();
            this.cbt_ProfitSharing = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cbt_Posting = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cbt_Employee = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.det_SalesDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SalesgridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).BeginInit();
            this.Company_BarpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbt_ProfitSharing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbt_Posting.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbt_Employee.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_SalesDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_SalesDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 846);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.Controls.Add(this.SalesgridControl);
            this.groupControl1.Controls.Add(this.Company_BarpanelControl);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1254, 822);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "合作夥伴分潤";
            // 
            // SalesgridControl
            // 
            this.SalesgridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SalesgridControl.Location = new System.Drawing.Point(2, 66);
            this.SalesgridControl.MainView = this.gridView1;
            this.SalesgridControl.Name = "SalesgridControl";
            this.SalesgridControl.Size = new System.Drawing.Size(1250, 754);
            this.SalesgridControl.TabIndex = 5;
            this.SalesgridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSalesFlag,
            this.colSalesNumber,
            this.colSalesCustomerNumber,
            this.colSalesTax,
            this.colSalesInvoiceNo,
            this.colTotal,
            this.colTotalTax,
            this.colPosting,
            this.colPostingDate,
            this.colRemark,
            this.colFileName,
            this.colTakeACut,
            this.colCost,
            this.colProfitSharing,
            this.colProfitSharingDate,
            this.colSalesEmployeeNumber});
            this.gridView1.GridControl = this.SalesgridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSalesFlag
            // 
            this.colSalesFlag.Caption = "銷貨旗標";
            this.colSalesFlag.FieldName = "SalesFlag";
            this.colSalesFlag.Name = "colSalesFlag";
            this.colSalesFlag.OptionsColumn.AllowEdit = false;
            this.colSalesFlag.Visible = true;
            this.colSalesFlag.VisibleIndex = 0;
            // 
            // colSalesNumber
            // 
            this.colSalesNumber.Caption = "銷貨日期";
            this.colSalesNumber.FieldName = "SalesNumber";
            this.colSalesNumber.Name = "colSalesNumber";
            this.colSalesNumber.OptionsColumn.AllowEdit = false;
            this.colSalesNumber.Visible = true;
            this.colSalesNumber.VisibleIndex = 1;
            // 
            // colSalesCustomerNumber
            // 
            this.colSalesCustomerNumber.Caption = "客戶編號";
            this.colSalesCustomerNumber.FieldName = "SalesCustomerNumber";
            this.colSalesCustomerNumber.Name = "colSalesCustomerNumber";
            this.colSalesCustomerNumber.OptionsColumn.AllowEdit = false;
            this.colSalesCustomerNumber.Visible = true;
            this.colSalesCustomerNumber.VisibleIndex = 2;
            // 
            // colSalesTax
            // 
            this.colSalesTax.Caption = "稅別";
            this.colSalesTax.FieldName = "SalesTax";
            this.colSalesTax.Name = "colSalesTax";
            this.colSalesTax.OptionsColumn.AllowEdit = false;
            this.colSalesTax.Visible = true;
            this.colSalesTax.VisibleIndex = 3;
            // 
            // colSalesInvoiceNo
            // 
            this.colSalesInvoiceNo.Caption = "發票號碼";
            this.colSalesInvoiceNo.FieldName = "SalesInvoiceNo";
            this.colSalesInvoiceNo.Name = "colSalesInvoiceNo";
            this.colSalesInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colSalesInvoiceNo.Visible = true;
            this.colSalesInvoiceNo.VisibleIndex = 4;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "合計";
            this.colTotal.DisplayFormat.FormatString = "C0";
            this.colTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 5;
            // 
            // colTotalTax
            // 
            this.colTotalTax.Caption = "稅後總計";
            this.colTotalTax.DisplayFormat.FormatString = "C0";
            this.colTotalTax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalTax.FieldName = "TotalTax";
            this.colTotalTax.Name = "colTotalTax";
            this.colTotalTax.OptionsColumn.AllowEdit = false;
            this.colTotalTax.Visible = true;
            this.colTotalTax.VisibleIndex = 6;
            // 
            // colPosting
            // 
            this.colPosting.Caption = "過帳";
            this.colPosting.FieldName = "Posting";
            this.colPosting.Name = "colPosting";
            this.colPosting.OptionsColumn.AllowEdit = false;
            this.colPosting.Visible = true;
            this.colPosting.VisibleIndex = 7;
            // 
            // colPostingDate
            // 
            this.colPostingDate.Caption = "過帳日期";
            this.colPostingDate.FieldName = "PostingDate";
            this.colPostingDate.Name = "colPostingDate";
            this.colPostingDate.Visible = true;
            this.colPostingDate.VisibleIndex = 12;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "備註";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 8;
            // 
            // colFileName
            // 
            this.colFileName.Caption = "附件檔名";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            // 
            // colTakeACut
            // 
            this.colTakeACut.Caption = "抽成";
            this.colTakeACut.DisplayFormat.FormatString = "{0}%";
            this.colTakeACut.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colTakeACut.FieldName = "TakeACut";
            this.colTakeACut.Name = "colTakeACut";
            this.colTakeACut.OptionsColumn.AllowEdit = false;
            this.colTakeACut.Visible = true;
            this.colTakeACut.VisibleIndex = 9;
            // 
            // colCost
            // 
            this.colCost.Caption = "成本";
            this.colCost.FieldName = "Cost";
            this.colCost.Name = "colCost";
            this.colCost.OptionsColumn.AllowEdit = false;
            this.colCost.Visible = true;
            this.colCost.VisibleIndex = 10;
            // 
            // colProfitSharing
            // 
            this.colProfitSharing.Caption = "分潤";
            this.colProfitSharing.DisplayFormat.FormatString = "C0";
            this.colProfitSharing.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProfitSharing.FieldName = "ProfitSharing";
            this.colProfitSharing.Name = "colProfitSharing";
            this.colProfitSharing.OptionsColumn.AllowEdit = false;
            this.colProfitSharing.Visible = true;
            this.colProfitSharing.VisibleIndex = 11;
            // 
            // colProfitSharingDate
            // 
            this.colProfitSharingDate.Caption = "分潤日期";
            this.colProfitSharingDate.FieldName = "ProfitSharingDate";
            this.colProfitSharingDate.Name = "colProfitSharingDate";
            this.colProfitSharingDate.Visible = true;
            this.colProfitSharingDate.VisibleIndex = 13;
            // 
            // colSalesEmployeeNumber
            // 
            this.colSalesEmployeeNumber.Caption = "員工號碼";
            this.colSalesEmployeeNumber.FieldName = "SalesEmployeeNumber";
            this.colSalesEmployeeNumber.Name = "colSalesEmployeeNumber";
            this.colSalesEmployeeNumber.OptionsColumn.AllowEdit = false;
            this.colSalesEmployeeNumber.Visible = true;
            this.colSalesEmployeeNumber.VisibleIndex = 14;
            // 
            // Company_BarpanelControl
            // 
            this.Company_BarpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Company_BarpanelControl.Controls.Add(this.btn_Export);
            this.Company_BarpanelControl.Controls.Add(this.btn_Sales_Search);
            this.Company_BarpanelControl.Controls.Add(this.cbt_ProfitSharing);
            this.Company_BarpanelControl.Controls.Add(this.labelControl4);
            this.Company_BarpanelControl.Controls.Add(this.cbt_Posting);
            this.Company_BarpanelControl.Controls.Add(this.labelControl3);
            this.Company_BarpanelControl.Controls.Add(this.cbt_Employee);
            this.Company_BarpanelControl.Controls.Add(this.labelControl2);
            this.Company_BarpanelControl.Controls.Add(this.det_SalesDate);
            this.Company_BarpanelControl.Controls.Add(this.labelControl1);
            this.Company_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Company_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.Company_BarpanelControl.Name = "Company_BarpanelControl";
            this.Company_BarpanelControl.Size = new System.Drawing.Size(1250, 43);
            this.Company_BarpanelControl.TabIndex = 4;
            // 
            // btn_Export
            // 
            this.btn_Export.AllowFocus = false;
            this.btn_Export.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Export.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Export.ImageOptions.Image")));
            this.btn_Export.Location = new System.Drawing.Point(1165, 0);
            this.btn_Export.Name = "btn_Export";
            this.btn_Export.Size = new System.Drawing.Size(85, 43);
            this.btn_Export.TabIndex = 37;
            this.btn_Export.Text = "Export";
            // 
            // btn_Sales_Search
            // 
            this.btn_Sales_Search.AllowFocus = false;
            this.btn_Sales_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Sales_Search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Sales_Search.ImageOptions.Image")));
            this.btn_Sales_Search.Location = new System.Drawing.Point(846, 0);
            this.btn_Sales_Search.Name = "btn_Sales_Search";
            this.btn_Sales_Search.Size = new System.Drawing.Size(85, 43);
            this.btn_Sales_Search.TabIndex = 36;
            this.btn_Sales_Search.Text = "Search";
            // 
            // cbt_ProfitSharing
            // 
            this.cbt_ProfitSharing.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbt_ProfitSharing.EditValue = "全部";
            this.cbt_ProfitSharing.Location = new System.Drawing.Point(736, 0);
            this.cbt_ProfitSharing.Name = "cbt_ProfitSharing";
            this.cbt_ProfitSharing.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_ProfitSharing.Properties.Appearance.Options.UseFont = true;
            this.cbt_ProfitSharing.Properties.Appearance.Options.UseTextOptions = true;
            this.cbt_ProfitSharing.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_ProfitSharing.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_ProfitSharing.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbt_ProfitSharing.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.cbt_ProfitSharing.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_ProfitSharing.Properties.AppearanceFocused.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_ProfitSharing.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbt_ProfitSharing.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.cbt_ProfitSharing.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_ProfitSharing.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_ProfitSharing.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.cbt_ProfitSharing.Properties.AppearanceItemSelected.Options.UseTextOptions = true;
            this.cbt_ProfitSharing.Properties.AppearanceItemSelected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_ProfitSharing.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbt_ProfitSharing.Properties.Items.AddRange(new object[] {
            "全部",
            "未分潤",
            "分潤"});
            this.cbt_ProfitSharing.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbt_ProfitSharing.Size = new System.Drawing.Size(110, 40);
            this.cbt_ProfitSharing.TabIndex = 35;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl4.Location = new System.Drawing.Point(691, 0);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 43);
            this.labelControl4.TabIndex = 34;
            this.labelControl4.Text = "分潤";
            // 
            // cbt_Posting
            // 
            this.cbt_Posting.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbt_Posting.EditValue = "全部";
            this.cbt_Posting.Location = new System.Drawing.Point(581, 0);
            this.cbt_Posting.Name = "cbt_Posting";
            this.cbt_Posting.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_Posting.Properties.Appearance.Options.UseFont = true;
            this.cbt_Posting.Properties.Appearance.Options.UseTextOptions = true;
            this.cbt_Posting.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_Posting.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_Posting.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbt_Posting.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.cbt_Posting.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_Posting.Properties.AppearanceFocused.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_Posting.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbt_Posting.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.cbt_Posting.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_Posting.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_Posting.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.cbt_Posting.Properties.AppearanceItemSelected.Options.UseTextOptions = true;
            this.cbt_Posting.Properties.AppearanceItemSelected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_Posting.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbt_Posting.Properties.Items.AddRange(new object[] {
            "全部",
            "未過帳",
            "過帳"});
            this.cbt_Posting.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbt_Posting.Size = new System.Drawing.Size(110, 40);
            this.cbt_Posting.TabIndex = 32;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl3.Location = new System.Drawing.Point(536, 0);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(45, 43);
            this.labelControl3.TabIndex = 31;
            this.labelControl3.Text = "過帳";
            // 
            // cbt_Employee
            // 
            this.cbt_Employee.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbt_Employee.Location = new System.Drawing.Point(299, 0);
            this.cbt_Employee.Name = "cbt_Employee";
            this.cbt_Employee.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_Employee.Properties.Appearance.Options.UseFont = true;
            this.cbt_Employee.Properties.Appearance.Options.UseTextOptions = true;
            this.cbt_Employee.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_Employee.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_Employee.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbt_Employee.Properties.AppearanceDropDown.Options.UseTextOptions = true;
            this.cbt_Employee.Properties.AppearanceDropDown.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_Employee.Properties.AppearanceFocused.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_Employee.Properties.AppearanceFocused.Options.UseFont = true;
            this.cbt_Employee.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.cbt_Employee.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_Employee.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.cbt_Employee.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.cbt_Employee.Properties.AppearanceItemSelected.Options.UseTextOptions = true;
            this.cbt_Employee.Properties.AppearanceItemSelected.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbt_Employee.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbt_Employee.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbt_Employee.Size = new System.Drawing.Size(237, 40);
            this.cbt_Employee.TabIndex = 29;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl2.Location = new System.Drawing.Point(213, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 43);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "合作夥伴";
            // 
            // det_SalesDate
            // 
            this.det_SalesDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.det_SalesDate.EditValue = null;
            this.det_SalesDate.Location = new System.Drawing.Point(45, 0);
            this.det_SalesDate.Name = "det_SalesDate";
            this.det_SalesDate.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.det_SalesDate.Properties.Appearance.Options.UseFont = true;
            this.det_SalesDate.Properties.Appearance.Options.UseTextOptions = true;
            this.det_SalesDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.det_SalesDate.Properties.AutoHeight = false;
            this.det_SalesDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_SalesDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_SalesDate.Properties.Mask.EditMask = "yyyy/MM";
            this.det_SalesDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.det_SalesDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.True;
            this.det_SalesDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.det_SalesDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.det_SalesDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.det_SalesDate.Size = new System.Drawing.Size(168, 43);
            this.det_SalesDate.TabIndex = 25;
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
            this.labelControl1.TabIndex = 11;
            this.labelControl1.Text = "日期";
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(1278, 846);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.groupControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1258, 826);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // PartnerMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "PartnerMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SalesgridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).EndInit();
            this.Company_BarpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbt_ProfitSharing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbt_Posting.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbt_Employee.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_SalesDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_SalesDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl Company_BarpanelControl;
        private DevExpress.XtraEditors.ComboBoxEdit cbt_Posting;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cbt_Employee;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit det_SalesDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl SalesgridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesFlag;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesTax;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colPosting;
        private DevExpress.XtraGrid.Columns.GridColumn colPostingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colTakeACut;
        private DevExpress.XtraGrid.Columns.GridColumn colCost;
        private DevExpress.XtraGrid.Columns.GridColumn colProfitSharing;
        private DevExpress.XtraGrid.Columns.GridColumn colProfitSharingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colSalesEmployeeNumber;
        private DevExpress.XtraEditors.SimpleButton btn_Sales_Search;
        private DevExpress.XtraEditors.ComboBoxEdit cbt_ProfitSharing;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btn_Export;
    }
}
