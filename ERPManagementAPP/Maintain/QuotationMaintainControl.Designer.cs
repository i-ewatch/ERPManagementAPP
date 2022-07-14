
namespace ERPManagementAPP.Maintain
{
    partial class QuotationMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuotationMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.QuotationgroupControl = new DevExpress.XtraEditors.GroupControl();
            this.QuotationgridControl = new DevExpress.XtraGrid.GridControl();
            this.QuotationgridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colQuotationNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuotationDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerDirectoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvalidFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Company_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.cet_InvaildFlag = new DevExpress.XtraEditors.CheckEdit();
            this.btn_Quotation_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Quotation_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Quotation_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Quotation_Search = new DevExpress.XtraEditors.SimpleButton();
            this.det_QuotationDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotationgroupControl)).BeginInit();
            this.QuotationgroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.QuotationgridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuotationgridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).BeginInit();
            this.Company_BarpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cet_InvaildFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_QuotationDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_QuotationDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.QuotationgroupControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 846);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // QuotationgroupControl
            // 
            this.QuotationgroupControl.Controls.Add(this.QuotationgridControl);
            this.QuotationgroupControl.Controls.Add(this.Company_BarpanelControl);
            this.QuotationgroupControl.Location = new System.Drawing.Point(12, 12);
            this.QuotationgroupControl.Name = "QuotationgroupControl";
            this.QuotationgroupControl.Size = new System.Drawing.Size(1254, 822);
            this.QuotationgroupControl.TabIndex = 4;
            this.QuotationgroupControl.Text = "報價單";
            // 
            // QuotationgridControl
            // 
            this.QuotationgridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QuotationgridControl.Location = new System.Drawing.Point(2, 66);
            this.QuotationgridControl.MainView = this.QuotationgridView;
            this.QuotationgridControl.Name = "QuotationgridControl";
            this.QuotationgridControl.Size = new System.Drawing.Size(1250, 754);
            this.QuotationgridControl.TabIndex = 5;
            this.QuotationgridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.QuotationgridView});
            // 
            // QuotationgridView
            // 
            this.QuotationgridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colQuotationNumber,
            this.colQuotationDate,
            this.colCustomerNumber,
            this.colCustomerDirectoryNumber,
            this.colProjectNumber,
            this.colTotal,
            this.colTotalTax,
            this.colTotalQty,
            this.colRemark,
            this.colFileName,
            this.colInvalidFlag});
            this.QuotationgridView.GridControl = this.QuotationgridControl;
            this.QuotationgridView.Name = "QuotationgridView";
            this.QuotationgridView.OptionsView.ShowGroupPanel = false;
            // 
            // colQuotationNumber
            // 
            this.colQuotationNumber.Caption = "報價單號";
            this.colQuotationNumber.FieldName = "QuotationNumber";
            this.colQuotationNumber.Name = "colQuotationNumber";
            this.colQuotationNumber.OptionsColumn.AllowEdit = false;
            this.colQuotationNumber.Visible = true;
            this.colQuotationNumber.VisibleIndex = 0;
            // 
            // colQuotationDate
            // 
            this.colQuotationDate.Caption = "報價月份";
            this.colQuotationDate.FieldName = "QuotationDate";
            this.colQuotationDate.Name = "colQuotationDate";
            this.colQuotationDate.OptionsColumn.AllowEdit = false;
            this.colQuotationDate.Visible = true;
            this.colQuotationDate.VisibleIndex = 1;
            // 
            // colCustomerNumber
            // 
            this.colCustomerNumber.Caption = "客戶編號";
            this.colCustomerNumber.FieldName = "QuotationCustomerNumber";
            this.colCustomerNumber.Name = "colCustomerNumber";
            this.colCustomerNumber.OptionsColumn.AllowEdit = false;
            this.colCustomerNumber.Visible = true;
            this.colCustomerNumber.VisibleIndex = 2;
            // 
            // colCustomerDirectoryNumber
            // 
            this.colCustomerDirectoryNumber.Caption = "客戶員工編號";
            this.colCustomerDirectoryNumber.FieldName = "QuotationCustomerDirectoryNumber";
            this.colCustomerDirectoryNumber.Name = "colCustomerDirectoryNumber";
            this.colCustomerDirectoryNumber.OptionsColumn.AllowEdit = false;
            // 
            // colProjectNumber
            // 
            this.colProjectNumber.Caption = "專案代碼";
            this.colProjectNumber.FieldName = "ProjectNumber";
            this.colProjectNumber.Name = "colProjectNumber";
            this.colProjectNumber.OptionsColumn.AllowEdit = false;
            this.colProjectNumber.Visible = true;
            this.colProjectNumber.VisibleIndex = 3;
            // 
            // colTotal
            // 
            this.colTotal.Caption = "合計";
            this.colTotal.FieldName = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.OptionsColumn.AllowEdit = false;
            this.colTotal.Visible = true;
            this.colTotal.VisibleIndex = 4;
            // 
            // colTotalTax
            // 
            this.colTotalTax.Caption = "稅後合計";
            this.colTotalTax.FieldName = "TotalTax";
            this.colTotalTax.Name = "colTotalTax";
            this.colTotalTax.OptionsColumn.AllowEdit = false;
            this.colTotalTax.Visible = true;
            this.colTotalTax.VisibleIndex = 6;
            // 
            // colTotalQty
            // 
            this.colTotalQty.Caption = "數量合計";
            this.colTotalQty.FieldName = "TotalQty";
            this.colTotalQty.Name = "colTotalQty";
            this.colTotalQty.OptionsColumn.AllowEdit = false;
            this.colTotalQty.Visible = true;
            this.colTotalQty.VisibleIndex = 5;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "備註";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 7;
            // 
            // colFileName
            // 
            this.colFileName.Caption = "附件檔名";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 8;
            // 
            // colInvalidFlag
            // 
            this.colInvalidFlag.Caption = "作廢旗標";
            this.colInvalidFlag.FieldName = "InvalidFlag";
            this.colInvalidFlag.Name = "colInvalidFlag";
            this.colInvalidFlag.OptionsColumn.AllowEdit = false;
            // 
            // Company_BarpanelControl
            // 
            this.Company_BarpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Company_BarpanelControl.Controls.Add(this.cet_InvaildFlag);
            this.Company_BarpanelControl.Controls.Add(this.btn_Quotation_Delete);
            this.Company_BarpanelControl.Controls.Add(this.btn_Quotation_Edit);
            this.Company_BarpanelControl.Controls.Add(this.btn_Quotation_Add);
            this.Company_BarpanelControl.Controls.Add(this.btn_Quotation_Search);
            this.Company_BarpanelControl.Controls.Add(this.det_QuotationDate);
            this.Company_BarpanelControl.Controls.Add(this.labelControl1);
            this.Company_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Company_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.Company_BarpanelControl.Name = "Company_BarpanelControl";
            this.Company_BarpanelControl.Size = new System.Drawing.Size(1250, 43);
            this.Company_BarpanelControl.TabIndex = 4;
            // 
            // cet_InvaildFlag
            // 
            this.cet_InvaildFlag.Dock = System.Windows.Forms.DockStyle.Left;
            this.cet_InvaildFlag.Location = new System.Drawing.Point(553, 0);
            this.cet_InvaildFlag.Name = "cet_InvaildFlag";
            this.cet_InvaildFlag.Properties.AllowFocused = false;
            this.cet_InvaildFlag.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cet_InvaildFlag.Properties.Appearance.Options.UseFont = true;
            this.cet_InvaildFlag.Properties.Caption = "作廢旗標";
            this.cet_InvaildFlag.Size = new System.Drawing.Size(95, 43);
            this.cet_InvaildFlag.TabIndex = 30;
            // 
            // btn_Quotation_Delete
            // 
            this.btn_Quotation_Delete.AllowFocus = false;
            this.btn_Quotation_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Quotation_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Quotation_Delete.ImageOptions.Image")));
            this.btn_Quotation_Delete.Location = new System.Drawing.Point(468, 0);
            this.btn_Quotation_Delete.Name = "btn_Quotation_Delete";
            this.btn_Quotation_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Quotation_Delete.TabIndex = 29;
            this.btn_Quotation_Delete.Text = "Delete";
            // 
            // btn_Quotation_Edit
            // 
            this.btn_Quotation_Edit.AllowFocus = false;
            this.btn_Quotation_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Quotation_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Quotation_Edit.ImageOptions.Image")));
            this.btn_Quotation_Edit.Location = new System.Drawing.Point(383, 0);
            this.btn_Quotation_Edit.Name = "btn_Quotation_Edit";
            this.btn_Quotation_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Quotation_Edit.TabIndex = 28;
            this.btn_Quotation_Edit.Text = "Edit";
            // 
            // btn_Quotation_Add
            // 
            this.btn_Quotation_Add.AllowFocus = false;
            this.btn_Quotation_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Quotation_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Quotation_Add.ImageOptions.Image")));
            this.btn_Quotation_Add.Location = new System.Drawing.Point(298, 0);
            this.btn_Quotation_Add.Name = "btn_Quotation_Add";
            this.btn_Quotation_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Quotation_Add.TabIndex = 27;
            this.btn_Quotation_Add.Text = "Add";
            // 
            // btn_Quotation_Search
            // 
            this.btn_Quotation_Search.AllowFocus = false;
            this.btn_Quotation_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Quotation_Search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Quotation_Search.ImageOptions.Image")));
            this.btn_Quotation_Search.Location = new System.Drawing.Point(213, 0);
            this.btn_Quotation_Search.Name = "btn_Quotation_Search";
            this.btn_Quotation_Search.Size = new System.Drawing.Size(85, 43);
            this.btn_Quotation_Search.TabIndex = 26;
            this.btn_Quotation_Search.Text = "Search";
            // 
            // det_QuotationDate
            // 
            this.det_QuotationDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.det_QuotationDate.EditValue = null;
            this.det_QuotationDate.Location = new System.Drawing.Point(45, 0);
            this.det_QuotationDate.Name = "det_QuotationDate";
            this.det_QuotationDate.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.det_QuotationDate.Properties.Appearance.Options.UseFont = true;
            this.det_QuotationDate.Properties.Appearance.Options.UseTextOptions = true;
            this.det_QuotationDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.det_QuotationDate.Properties.AutoHeight = false;
            this.det_QuotationDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_QuotationDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_QuotationDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = true;
            this.det_QuotationDate.Properties.Mask.EditMask = "yyyy";
            this.det_QuotationDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.det_QuotationDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.det_QuotationDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.det_QuotationDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.det_QuotationDate.Size = new System.Drawing.Size(168, 43);
            this.det_QuotationDate.TabIndex = 25;
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
            this.layoutControlItem1.Control = this.QuotationgroupControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1258, 826);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // QuotationMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "QuotationMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuotationgroupControl)).EndInit();
            this.QuotationgroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.QuotationgridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuotationgridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).EndInit();
            this.Company_BarpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cet_InvaildFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_QuotationDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_QuotationDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl QuotationgroupControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl Company_BarpanelControl;
        private DevExpress.XtraEditors.CheckEdit cet_InvaildFlag;
        private DevExpress.XtraEditors.SimpleButton btn_Quotation_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Quotation_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Quotation_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Quotation_Search;
        private DevExpress.XtraEditors.DateEdit det_QuotationDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.GridControl QuotationgridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView QuotationgridView;
        private DevExpress.XtraGrid.Columns.GridColumn colQuotationNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colQuotationDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerDirectoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colInvalidFlag;
    }
}
