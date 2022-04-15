
namespace ERPManagementAPP.Maintain
{
    partial class PurchaseMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.PruchasegroupControl = new DevExpress.XtraEditors.GroupControl();
            this.PurchasegridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPurchaseFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseCompanyNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Company_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btn_Purchase_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Purchase_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Purchase_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Purchase_Search = new DevExpress.XtraEditors.SimpleButton();
            this.det_PurchaseDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PruchasegroupControl)).BeginInit();
            this.PruchasegroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasegridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).BeginInit();
            this.Company_BarpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.det_PurchaseDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_PurchaseDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.PruchasegroupControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 846);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // PruchasegroupControl
            // 
            this.PruchasegroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.PruchasegroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.PruchasegroupControl.Controls.Add(this.PurchasegridControl);
            this.PruchasegroupControl.Controls.Add(this.Company_BarpanelControl);
            this.PruchasegroupControl.Location = new System.Drawing.Point(12, 12);
            this.PruchasegroupControl.Name = "PruchasegroupControl";
            this.PruchasegroupControl.Size = new System.Drawing.Size(1254, 822);
            this.PruchasegroupControl.TabIndex = 4;
            this.PruchasegroupControl.Text = "進貨/進貨退出";
            // 
            // PurchasegridControl
            // 
            this.PurchasegridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PurchasegridControl.Location = new System.Drawing.Point(2, 66);
            this.PurchasegridControl.MainView = this.gridView1;
            this.PurchasegridControl.Name = "PurchasegridControl";
            this.PurchasegridControl.Size = new System.Drawing.Size(1250, 754);
            this.PurchasegridControl.TabIndex = 4;
            this.PurchasegridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPurchaseFlag,
            this.colPurchaseNumber,
            this.colPurchaseCompanyNumber,
            this.colProjectNumber,
            this.colPurchaseTax,
            this.colPurchaseInvoiceNo,
            this.colTotal,
            this.colTotalTax,
            this.colPosting,
            this.colRemark,
            this.colFileName});
            this.gridView1.GridControl = this.PurchasegridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPurchaseFlag
            // 
            this.colPurchaseFlag.Caption = "進貨旗標";
            this.colPurchaseFlag.FieldName = "PurchaseFlag";
            this.colPurchaseFlag.Name = "colPurchaseFlag";
            this.colPurchaseFlag.OptionsColumn.AllowEdit = false;
            this.colPurchaseFlag.Visible = true;
            this.colPurchaseFlag.VisibleIndex = 0;
            // 
            // colPurchaseNumber
            // 
            this.colPurchaseNumber.Caption = "進貨日期";
            this.colPurchaseNumber.FieldName = "PurchaseNumber";
            this.colPurchaseNumber.Name = "colPurchaseNumber";
            this.colPurchaseNumber.OptionsColumn.AllowEdit = false;
            this.colPurchaseNumber.Visible = true;
            this.colPurchaseNumber.VisibleIndex = 1;
            // 
            // colPurchaseCompanyNumber
            // 
            this.colPurchaseCompanyNumber.Caption = "廠商編號";
            this.colPurchaseCompanyNumber.FieldName = "PurchaseCompanyNumber";
            this.colPurchaseCompanyNumber.Name = "colPurchaseCompanyNumber";
            this.colPurchaseCompanyNumber.OptionsColumn.AllowEdit = false;
            this.colPurchaseCompanyNumber.Visible = true;
            this.colPurchaseCompanyNumber.VisibleIndex = 2;
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
            // colPurchaseTax
            // 
            this.colPurchaseTax.Caption = "稅別";
            this.colPurchaseTax.FieldName = "PurchaseTax";
            this.colPurchaseTax.Name = "colPurchaseTax";
            this.colPurchaseTax.OptionsColumn.AllowEdit = false;
            this.colPurchaseTax.Visible = true;
            this.colPurchaseTax.VisibleIndex = 4;
            // 
            // colPurchaseInvoiceNo
            // 
            this.colPurchaseInvoiceNo.Caption = "發票號碼";
            this.colPurchaseInvoiceNo.FieldName = "PurchaseInvoiceNo";
            this.colPurchaseInvoiceNo.Name = "colPurchaseInvoiceNo";
            this.colPurchaseInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colPurchaseInvoiceNo.Visible = true;
            this.colPurchaseInvoiceNo.VisibleIndex = 5;
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
            this.Company_BarpanelControl.Controls.Add(this.btn_Purchase_Delete);
            this.Company_BarpanelControl.Controls.Add(this.btn_Purchase_Edit);
            this.Company_BarpanelControl.Controls.Add(this.btn_Purchase_Add);
            this.Company_BarpanelControl.Controls.Add(this.btn_Purchase_Search);
            this.Company_BarpanelControl.Controls.Add(this.det_PurchaseDate);
            this.Company_BarpanelControl.Controls.Add(this.labelControl1);
            this.Company_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Company_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.Company_BarpanelControl.Name = "Company_BarpanelControl";
            this.Company_BarpanelControl.Size = new System.Drawing.Size(1250, 43);
            this.Company_BarpanelControl.TabIndex = 3;
            // 
            // btn_Purchase_Delete
            // 
            this.btn_Purchase_Delete.AllowFocus = false;
            this.btn_Purchase_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Purchase_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Purchase_Delete.ImageOptions.Image")));
            this.btn_Purchase_Delete.Location = new System.Drawing.Point(468, 0);
            this.btn_Purchase_Delete.Name = "btn_Purchase_Delete";
            this.btn_Purchase_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Purchase_Delete.TabIndex = 29;
            this.btn_Purchase_Delete.Text = "Delete";
            // 
            // btn_Purchase_Edit
            // 
            this.btn_Purchase_Edit.AllowFocus = false;
            this.btn_Purchase_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Purchase_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Purchase_Edit.ImageOptions.Image")));
            this.btn_Purchase_Edit.Location = new System.Drawing.Point(383, 0);
            this.btn_Purchase_Edit.Name = "btn_Purchase_Edit";
            this.btn_Purchase_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Purchase_Edit.TabIndex = 28;
            this.btn_Purchase_Edit.Text = "Edit";
            // 
            // btn_Purchase_Add
            // 
            this.btn_Purchase_Add.AllowFocus = false;
            this.btn_Purchase_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Purchase_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Purchase_Add.ImageOptions.Image")));
            this.btn_Purchase_Add.Location = new System.Drawing.Point(298, 0);
            this.btn_Purchase_Add.Name = "btn_Purchase_Add";
            this.btn_Purchase_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Purchase_Add.TabIndex = 27;
            this.btn_Purchase_Add.Text = "Add";
            // 
            // btn_Purchase_Search
            // 
            this.btn_Purchase_Search.AllowFocus = false;
            this.btn_Purchase_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Purchase_Search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Purchase_Search.ImageOptions.Image")));
            this.btn_Purchase_Search.Location = new System.Drawing.Point(213, 0);
            this.btn_Purchase_Search.Name = "btn_Purchase_Search";
            this.btn_Purchase_Search.Size = new System.Drawing.Size(85, 43);
            this.btn_Purchase_Search.TabIndex = 26;
            this.btn_Purchase_Search.Text = "Search";
            // 
            // det_PurchaseDate
            // 
            this.det_PurchaseDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.det_PurchaseDate.EditValue = null;
            this.det_PurchaseDate.Location = new System.Drawing.Point(45, 0);
            this.det_PurchaseDate.Name = "det_PurchaseDate";
            this.det_PurchaseDate.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.det_PurchaseDate.Properties.Appearance.Options.UseFont = true;
            this.det_PurchaseDate.Properties.Appearance.Options.UseTextOptions = true;
            this.det_PurchaseDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.det_PurchaseDate.Properties.AutoHeight = false;
            this.det_PurchaseDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_PurchaseDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_PurchaseDate.Properties.Mask.EditMask = "yyyy/MM";
            this.det_PurchaseDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.det_PurchaseDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.True;
            this.det_PurchaseDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.det_PurchaseDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.det_PurchaseDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.det_PurchaseDate.Size = new System.Drawing.Size(168, 43);
            this.det_PurchaseDate.TabIndex = 25;
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
            this.layoutControlItem1.Control = this.PruchasegroupControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1258, 826);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // PurchaseMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "PurchaseMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PruchasegroupControl)).EndInit();
            this.PruchasegroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PurchasegridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).EndInit();
            this.Company_BarpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.det_PurchaseDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_PurchaseDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl PruchasegroupControl;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl Company_BarpanelControl;
        private DevExpress.XtraGrid.GridControl PurchasegridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Purchase_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Purchase_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Purchase_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Purchase_Search;
        private DevExpress.XtraEditors.DateEdit det_PurchaseDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseFlag;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseCompanyNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseTax;
        private DevExpress.XtraGrid.Columns.GridColumn colPurchaseInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colPosting;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNumber;
    }
}
