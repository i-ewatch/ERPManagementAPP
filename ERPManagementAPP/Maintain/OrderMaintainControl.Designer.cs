
namespace ERPManagementAPP.Maintain
{
    partial class OrderMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.OrdergroupControl = new DevExpress.XtraEditors.GroupControl();
            this.OrdergridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOrderNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderCompanyNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrderDirectoryNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInvalidFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Company_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.cet_InvaildFlag = new DevExpress.XtraEditors.CheckEdit();
            this.btn_Order_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Order_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Order_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Order_Search = new DevExpress.XtraEditors.SimpleButton();
            this.det_OrderDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdergroupControl)).BeginInit();
            this.OrdergroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OrdergridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).BeginInit();
            this.Company_BarpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cet_InvaildFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_OrderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_OrderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.OrdergroupControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 846);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // OrdergroupControl
            // 
            this.OrdergroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.OrdergroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.OrdergroupControl.Controls.Add(this.OrdergridControl);
            this.OrdergroupControl.Controls.Add(this.Company_BarpanelControl);
            this.OrdergroupControl.Location = new System.Drawing.Point(12, 12);
            this.OrdergroupControl.Name = "OrdergroupControl";
            this.OrdergroupControl.Size = new System.Drawing.Size(1254, 822);
            this.OrdergroupControl.TabIndex = 4;
            this.OrdergroupControl.Text = "訂購單";
            // 
            // OrdergridControl
            // 
            this.OrdergridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrdergridControl.Location = new System.Drawing.Point(2, 66);
            this.OrdergridControl.MainView = this.gridView1;
            this.OrdergridControl.Name = "OrdergridControl";
            this.OrdergridControl.Size = new System.Drawing.Size(1250, 754);
            this.OrdergridControl.TabIndex = 4;
            this.OrdergridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOrderNumber,
            this.colOrderDate,
            this.colOrderCompanyNumber,
            this.colOrderDirectoryNumber,
            this.colProjectNumber,
            this.colTotal,
            this.colTotalTax,
            this.colTotalQty,
            this.colRemark,
            this.colFileName,
            this.colInvalidFlag});
            this.gridView1.GridControl = this.OrdergridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colOrderNumber
            // 
            this.colOrderNumber.Caption = "訂購單號";
            this.colOrderNumber.FieldName = "OrderNumber";
            this.colOrderNumber.Name = "colOrderNumber";
            this.colOrderNumber.OptionsColumn.AllowEdit = false;
            this.colOrderNumber.Visible = true;
            this.colOrderNumber.VisibleIndex = 0;
            // 
            // colOrderDate
            // 
            this.colOrderDate.Caption = "訂單月份";
            this.colOrderDate.FieldName = "OrderDate";
            this.colOrderDate.Name = "colOrderDate";
            this.colOrderDate.OptionsColumn.AllowEdit = false;
            this.colOrderDate.Visible = true;
            this.colOrderDate.VisibleIndex = 1;
            // 
            // colOrderCompanyNumber
            // 
            this.colOrderCompanyNumber.Caption = "廠商編號";
            this.colOrderCompanyNumber.FieldName = "OrderCompanyNumber";
            this.colOrderCompanyNumber.Name = "colOrderCompanyNumber";
            this.colOrderCompanyNumber.OptionsColumn.AllowEdit = false;
            this.colOrderCompanyNumber.Visible = true;
            this.colOrderCompanyNumber.VisibleIndex = 2;
            // 
            // colOrderDirectoryNumber
            // 
            this.colOrderDirectoryNumber.Caption = "廠商員工編號";
            this.colOrderDirectoryNumber.FieldName = "OrderDirectoryNumber";
            this.colOrderDirectoryNumber.Name = "colOrderDirectoryNumber";
            this.colOrderDirectoryNumber.OptionsColumn.AllowEdit = false;
            this.colOrderDirectoryNumber.Visible = true;
            this.colOrderDirectoryNumber.VisibleIndex = 3;
            // 
            // colProjectNumber
            // 
            this.colProjectNumber.Caption = "專案代碼";
            this.colProjectNumber.FieldName = "ProjectNumber";
            this.colProjectNumber.Name = "colProjectNumber";
            this.colProjectNumber.OptionsColumn.AllowEdit = false;
            this.colProjectNumber.Visible = true;
            this.colProjectNumber.VisibleIndex = 4;
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
            // colTotalQty
            // 
            this.colTotalQty.Caption = "數量合計";
            this.colTotalQty.FieldName = "TotalQty";
            this.colTotalQty.Name = "colTotalQty";
            this.colTotalQty.OptionsColumn.AllowEdit = false;
            this.colTotalQty.Visible = true;
            this.colTotalQty.VisibleIndex = 7;
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
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 9;
            // 
            // colInvalidFlag
            // 
            this.colInvalidFlag.Caption = "作廢旗標";
            this.colInvalidFlag.FieldName = "InvalidFlag";
            this.colInvalidFlag.Name = "colInvalidFlag";
            // 
            // Company_BarpanelControl
            // 
            this.Company_BarpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Company_BarpanelControl.Controls.Add(this.cet_InvaildFlag);
            this.Company_BarpanelControl.Controls.Add(this.btn_Order_Delete);
            this.Company_BarpanelControl.Controls.Add(this.btn_Order_Edit);
            this.Company_BarpanelControl.Controls.Add(this.btn_Order_Add);
            this.Company_BarpanelControl.Controls.Add(this.btn_Order_Search);
            this.Company_BarpanelControl.Controls.Add(this.det_OrderDate);
            this.Company_BarpanelControl.Controls.Add(this.labelControl1);
            this.Company_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Company_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.Company_BarpanelControl.Name = "Company_BarpanelControl";
            this.Company_BarpanelControl.Size = new System.Drawing.Size(1250, 43);
            this.Company_BarpanelControl.TabIndex = 3;
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
            // btn_Order_Delete
            // 
            this.btn_Order_Delete.AllowFocus = false;
            this.btn_Order_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Order_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Order_Delete.ImageOptions.Image")));
            this.btn_Order_Delete.Location = new System.Drawing.Point(468, 0);
            this.btn_Order_Delete.Name = "btn_Order_Delete";
            this.btn_Order_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Order_Delete.TabIndex = 29;
            this.btn_Order_Delete.Text = "Delete";
            // 
            // btn_Order_Edit
            // 
            this.btn_Order_Edit.AllowFocus = false;
            this.btn_Order_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Order_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Order_Edit.ImageOptions.Image")));
            this.btn_Order_Edit.Location = new System.Drawing.Point(383, 0);
            this.btn_Order_Edit.Name = "btn_Order_Edit";
            this.btn_Order_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Order_Edit.TabIndex = 28;
            this.btn_Order_Edit.Text = "Edit";
            // 
            // btn_Order_Add
            // 
            this.btn_Order_Add.AllowFocus = false;
            this.btn_Order_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Order_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Order_Add.ImageOptions.Image")));
            this.btn_Order_Add.Location = new System.Drawing.Point(298, 0);
            this.btn_Order_Add.Name = "btn_Order_Add";
            this.btn_Order_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Order_Add.TabIndex = 27;
            this.btn_Order_Add.Text = "Add";
            // 
            // btn_Order_Search
            // 
            this.btn_Order_Search.AllowFocus = false;
            this.btn_Order_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Order_Search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Order_Search.ImageOptions.Image")));
            this.btn_Order_Search.Location = new System.Drawing.Point(213, 0);
            this.btn_Order_Search.Name = "btn_Order_Search";
            this.btn_Order_Search.Size = new System.Drawing.Size(85, 43);
            this.btn_Order_Search.TabIndex = 26;
            this.btn_Order_Search.Text = "Search";
            // 
            // det_OrderDate
            // 
            this.det_OrderDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.det_OrderDate.EditValue = null;
            this.det_OrderDate.Location = new System.Drawing.Point(45, 0);
            this.det_OrderDate.Name = "det_OrderDate";
            this.det_OrderDate.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.det_OrderDate.Properties.Appearance.Options.UseFont = true;
            this.det_OrderDate.Properties.Appearance.Options.UseTextOptions = true;
            this.det_OrderDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.det_OrderDate.Properties.AutoHeight = false;
            this.det_OrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_OrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_OrderDate.Properties.CalendarTimeProperties.Mask.UseMaskAsDisplayFormat = true;
            this.det_OrderDate.Properties.Mask.EditMask = "yyyy";
            this.det_OrderDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.det_OrderDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.det_OrderDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearsGroupView;
            this.det_OrderDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearsGroupView;
            this.det_OrderDate.Size = new System.Drawing.Size(168, 43);
            this.det_OrderDate.TabIndex = 25;
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
            this.layoutControlItem1.Control = this.OrdergroupControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1258, 826);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // OrderMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "OrderMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrdergroupControl)).EndInit();
            this.OrdergroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OrdergridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).EndInit();
            this.Company_BarpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cet_InvaildFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_OrderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_OrderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl OrdergroupControl;
        private DevExpress.XtraGrid.GridControl OrdergridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderCompanyNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalQty;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraEditors.PanelControl Company_BarpanelControl;
        private DevExpress.XtraEditors.SimpleButton btn_Order_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Order_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Order_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Order_Search;
        private DevExpress.XtraEditors.DateEdit det_OrderDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDirectoryNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOrderDate;
        private DevExpress.XtraGrid.Columns.GridColumn colInvalidFlag;
        private DevExpress.XtraEditors.CheckEdit cet_InvaildFlag;
    }
}
