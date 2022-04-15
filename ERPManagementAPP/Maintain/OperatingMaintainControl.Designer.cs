
namespace ERPManagementAPP.Maintain
{
    partial class OperatingMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperatingMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.OperatinggroupControl = new DevExpress.XtraEditors.GroupControl();
            this.OperatinggridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colOperatingFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperatingNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperatingCompanyNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperatingTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOperatingInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Company_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btn_Operating_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Operating_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Operating_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Operating_Search = new DevExpress.XtraEditors.SimpleButton();
            this.det_OperatingDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OperatinggroupControl)).BeginInit();
            this.OperatinggroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OperatinggridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).BeginInit();
            this.Company_BarpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.det_OperatingDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_OperatingDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.OperatinggroupControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 846);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // OperatinggroupControl
            // 
            this.OperatinggroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.OperatinggroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.OperatinggroupControl.Controls.Add(this.OperatinggridControl);
            this.OperatinggroupControl.Controls.Add(this.Company_BarpanelControl);
            this.OperatinggroupControl.Location = new System.Drawing.Point(12, 12);
            this.OperatinggroupControl.Name = "OperatinggroupControl";
            this.OperatinggroupControl.Size = new System.Drawing.Size(1254, 822);
            this.OperatinggroupControl.TabIndex = 4;
            this.OperatinggroupControl.Text = "營運/營運退出";
            // 
            // OperatinggridControl
            // 
            this.OperatinggridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperatinggridControl.Location = new System.Drawing.Point(2, 66);
            this.OperatinggridControl.MainView = this.gridView1;
            this.OperatinggridControl.Name = "OperatinggridControl";
            this.OperatinggridControl.Size = new System.Drawing.Size(1250, 754);
            this.OperatinggridControl.TabIndex = 4;
            this.OperatinggridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colOperatingFlag,
            this.colOperatingNumber,
            this.colOperatingCompanyNumber,
            this.colProjectNumber,
            this.colOperatingTax,
            this.colOperatingInvoiceNo,
            this.colTotal,
            this.colTotalTax,
            this.colPosting,
            this.colRemark,
            this.colFileName});
            this.gridView1.GridControl = this.OperatinggridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colOperatingFlag
            // 
            this.colOperatingFlag.Caption = "營運旗標";
            this.colOperatingFlag.FieldName = "OperatingFlag";
            this.colOperatingFlag.Name = "colOperatingFlag";
            this.colOperatingFlag.OptionsColumn.AllowEdit = false;
            this.colOperatingFlag.Visible = true;
            this.colOperatingFlag.VisibleIndex = 0;
            // 
            // colOperatingNumber
            // 
            this.colOperatingNumber.Caption = "營運日期";
            this.colOperatingNumber.FieldName = "OperatingNumber";
            this.colOperatingNumber.Name = "colOperatingNumber";
            this.colOperatingNumber.OptionsColumn.AllowEdit = false;
            this.colOperatingNumber.Visible = true;
            this.colOperatingNumber.VisibleIndex = 1;
            // 
            // colOperatingCompanyNumber
            // 
            this.colOperatingCompanyNumber.Caption = "廠商編號";
            this.colOperatingCompanyNumber.FieldName = "OperatingCompanyNumber";
            this.colOperatingCompanyNumber.Name = "colOperatingCompanyNumber";
            this.colOperatingCompanyNumber.OptionsColumn.AllowEdit = false;
            this.colOperatingCompanyNumber.Visible = true;
            this.colOperatingCompanyNumber.VisibleIndex = 2;
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
            // colOperatingTax
            // 
            this.colOperatingTax.Caption = "稅別";
            this.colOperatingTax.FieldName = "OperatingTax";
            this.colOperatingTax.Name = "colOperatingTax";
            this.colOperatingTax.OptionsColumn.AllowEdit = false;
            this.colOperatingTax.Visible = true;
            this.colOperatingTax.VisibleIndex = 4;
            // 
            // colOperatingInvoiceNo
            // 
            this.colOperatingInvoiceNo.Caption = "發票號碼";
            this.colOperatingInvoiceNo.FieldName = "OperatingInvoiceNo";
            this.colOperatingInvoiceNo.Name = "colOperatingInvoiceNo";
            this.colOperatingInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colOperatingInvoiceNo.Visible = true;
            this.colOperatingInvoiceNo.VisibleIndex = 5;
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
            this.colTotal.VisibleIndex = 6;
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
            this.colTotalTax.VisibleIndex = 7;
            // 
            // colPosting
            // 
            this.colPosting.Caption = "過帳";
            this.colPosting.FieldName = "Posting";
            this.colPosting.Name = "colPosting";
            this.colPosting.OptionsColumn.AllowEdit = false;
            this.colPosting.Visible = true;
            this.colPosting.VisibleIndex = 8;
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
            // colFileName
            // 
            this.colFileName.Caption = "附件檔名";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            this.colFileName.VisibleIndex = 10;
            // 
            // Company_BarpanelControl
            // 
            this.Company_BarpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Company_BarpanelControl.Controls.Add(this.btn_Operating_Delete);
            this.Company_BarpanelControl.Controls.Add(this.btn_Operating_Edit);
            this.Company_BarpanelControl.Controls.Add(this.btn_Operating_Add);
            this.Company_BarpanelControl.Controls.Add(this.btn_Operating_Search);
            this.Company_BarpanelControl.Controls.Add(this.det_OperatingDate);
            this.Company_BarpanelControl.Controls.Add(this.labelControl1);
            this.Company_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Company_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.Company_BarpanelControl.Name = "Company_BarpanelControl";
            this.Company_BarpanelControl.Size = new System.Drawing.Size(1250, 43);
            this.Company_BarpanelControl.TabIndex = 3;
            // 
            // btn_Operating_Delete
            // 
            this.btn_Operating_Delete.AllowFocus = false;
            this.btn_Operating_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Operating_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Operating_Delete.ImageOptions.Image")));
            this.btn_Operating_Delete.Location = new System.Drawing.Point(468, 0);
            this.btn_Operating_Delete.Name = "btn_Operating_Delete";
            this.btn_Operating_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Operating_Delete.TabIndex = 29;
            this.btn_Operating_Delete.Text = "Delete";
            // 
            // btn_Operating_Edit
            // 
            this.btn_Operating_Edit.AllowFocus = false;
            this.btn_Operating_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Operating_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Operating_Edit.ImageOptions.Image")));
            this.btn_Operating_Edit.Location = new System.Drawing.Point(383, 0);
            this.btn_Operating_Edit.Name = "btn_Operating_Edit";
            this.btn_Operating_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Operating_Edit.TabIndex = 28;
            this.btn_Operating_Edit.Text = "Edit";
            // 
            // btn_Operating_Add
            // 
            this.btn_Operating_Add.AllowFocus = false;
            this.btn_Operating_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Operating_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Operating_Add.ImageOptions.Image")));
            this.btn_Operating_Add.Location = new System.Drawing.Point(298, 0);
            this.btn_Operating_Add.Name = "btn_Operating_Add";
            this.btn_Operating_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Operating_Add.TabIndex = 27;
            this.btn_Operating_Add.Text = "Add";
            // 
            // btn_Operating_Search
            // 
            this.btn_Operating_Search.AllowFocus = false;
            this.btn_Operating_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Operating_Search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Operating_Search.ImageOptions.Image")));
            this.btn_Operating_Search.Location = new System.Drawing.Point(213, 0);
            this.btn_Operating_Search.Name = "btn_Operating_Search";
            this.btn_Operating_Search.Size = new System.Drawing.Size(85, 43);
            this.btn_Operating_Search.TabIndex = 26;
            this.btn_Operating_Search.Text = "Search";
            // 
            // det_OperatingDate
            // 
            this.det_OperatingDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.det_OperatingDate.EditValue = null;
            this.det_OperatingDate.Location = new System.Drawing.Point(45, 0);
            this.det_OperatingDate.Name = "det_OperatingDate";
            this.det_OperatingDate.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.det_OperatingDate.Properties.Appearance.Options.UseFont = true;
            this.det_OperatingDate.Properties.Appearance.Options.UseTextOptions = true;
            this.det_OperatingDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.det_OperatingDate.Properties.AutoHeight = false;
            this.det_OperatingDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_OperatingDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_OperatingDate.Properties.Mask.EditMask = "yyyy/MM";
            this.det_OperatingDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.det_OperatingDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.True;
            this.det_OperatingDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.det_OperatingDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.det_OperatingDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.det_OperatingDate.Size = new System.Drawing.Size(168, 43);
            this.det_OperatingDate.TabIndex = 25;
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
            this.layoutControlItem1.Control = this.OperatinggroupControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1258, 826);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // OperatingMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "OperatingMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OperatinggroupControl)).EndInit();
            this.OperatinggroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.OperatinggridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).EndInit();
            this.Company_BarpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.det_OperatingDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_OperatingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl OperatinggroupControl;
        private DevExpress.XtraGrid.GridControl OperatinggridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colOperatingFlag;
        private DevExpress.XtraGrid.Columns.GridColumn colOperatingNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOperatingCompanyNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colOperatingTax;
        private DevExpress.XtraGrid.Columns.GridColumn colOperatingInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colPosting;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraEditors.PanelControl Company_BarpanelControl;
        private DevExpress.XtraEditors.SimpleButton btn_Operating_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Operating_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Operating_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Operating_Search;
        private DevExpress.XtraEditors.DateEdit det_OperatingDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
