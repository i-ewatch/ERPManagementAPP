
namespace ERPManagementAPP.Maintain
{
    partial class PickingMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickingMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.PruchasegroupControl = new DevExpress.XtraEditors.GroupControl();
            this.PickinggridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPickingFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickingNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickingCustomerNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProjectNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickingTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPickingInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Company_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btn_Picking_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Picking_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Picking_Add = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Picking_Search = new DevExpress.XtraEditors.SimpleButton();
            this.det_PickingDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PruchasegroupControl)).BeginInit();
            this.PruchasegroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PickinggridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).BeginInit();
            this.Company_BarpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.det_PickingDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_PickingDate.Properties)).BeginInit();
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
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // PruchasegroupControl
            // 
            this.PruchasegroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.PruchasegroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.PruchasegroupControl.Controls.Add(this.PickinggridControl);
            this.PruchasegroupControl.Controls.Add(this.Company_BarpanelControl);
            this.PruchasegroupControl.Location = new System.Drawing.Point(12, 12);
            this.PruchasegroupControl.Name = "PruchasegroupControl";
            this.PruchasegroupControl.Size = new System.Drawing.Size(1254, 822);
            this.PruchasegroupControl.TabIndex = 4;
            this.PruchasegroupControl.Text = "領料/領料退回";
            // 
            // PickinggridControl
            // 
            this.PickinggridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PickinggridControl.Location = new System.Drawing.Point(2, 66);
            this.PickinggridControl.MainView = this.gridView1;
            this.PickinggridControl.Name = "PickinggridControl";
            this.PickinggridControl.Size = new System.Drawing.Size(1250, 754);
            this.PickinggridControl.TabIndex = 4;
            this.PickinggridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPickingFlag,
            this.colPickingNumber,
            this.colPickingCustomerNumber,
            this.colProjectNumber,
            this.colPickingTax,
            this.colPickingInvoiceNo,
            this.colTotal,
            this.colTotalTax,
            this.colPosting,
            this.colRemark,
            this.colFileName});
            this.gridView1.GridControl = this.PickinggridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPickingFlag
            // 
            this.colPickingFlag.Caption = "領料銷貨旗標";
            this.colPickingFlag.FieldName = "PickingFlag";
            this.colPickingFlag.Name = "colPickingFlag";
            this.colPickingFlag.OptionsColumn.AllowEdit = false;
            this.colPickingFlag.Visible = true;
            this.colPickingFlag.VisibleIndex = 0;
            // 
            // colPickingNumber
            // 
            this.colPickingNumber.Caption = "領料日期";
            this.colPickingNumber.FieldName = "PickingNumber";
            this.colPickingNumber.Name = "colPickingNumber";
            this.colPickingNumber.OptionsColumn.AllowEdit = false;
            this.colPickingNumber.Visible = true;
            this.colPickingNumber.VisibleIndex = 1;
            // 
            // colPickingCustomerNumber
            // 
            this.colPickingCustomerNumber.Caption = "客戶編號";
            this.colPickingCustomerNumber.FieldName = "PickingCustomerNumber";
            this.colPickingCustomerNumber.Name = "colPickingCustomerNumber";
            this.colPickingCustomerNumber.OptionsColumn.AllowEdit = false;
            this.colPickingCustomerNumber.Visible = true;
            this.colPickingCustomerNumber.VisibleIndex = 2;
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
            // colPickingTax
            // 
            this.colPickingTax.Caption = "稅別";
            this.colPickingTax.FieldName = "PickingTax";
            this.colPickingTax.Name = "colPickingTax";
            this.colPickingTax.OptionsColumn.AllowEdit = false;
            this.colPickingTax.Visible = true;
            this.colPickingTax.VisibleIndex = 4;
            // 
            // colPickingInvoiceNo
            // 
            this.colPickingInvoiceNo.Caption = "發票號碼";
            this.colPickingInvoiceNo.FieldName = "PickingInvoiceNo";
            this.colPickingInvoiceNo.Name = "colPickingInvoiceNo";
            this.colPickingInvoiceNo.OptionsColumn.AllowEdit = false;
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
            // Company_BarpanelControl
            // 
            this.Company_BarpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Company_BarpanelControl.Controls.Add(this.btn_Picking_Delete);
            this.Company_BarpanelControl.Controls.Add(this.btn_Picking_Edit);
            this.Company_BarpanelControl.Controls.Add(this.btn_Picking_Add);
            this.Company_BarpanelControl.Controls.Add(this.btn_Picking_Search);
            this.Company_BarpanelControl.Controls.Add(this.det_PickingDate);
            this.Company_BarpanelControl.Controls.Add(this.labelControl1);
            this.Company_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Company_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.Company_BarpanelControl.Name = "Company_BarpanelControl";
            this.Company_BarpanelControl.Size = new System.Drawing.Size(1250, 43);
            this.Company_BarpanelControl.TabIndex = 3;
            // 
            // btn_Picking_Delete
            // 
            this.btn_Picking_Delete.AllowFocus = false;
            this.btn_Picking_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Picking_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Picking_Delete.ImageOptions.Image")));
            this.btn_Picking_Delete.Location = new System.Drawing.Point(468, 0);
            this.btn_Picking_Delete.Name = "btn_Picking_Delete";
            this.btn_Picking_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Picking_Delete.TabIndex = 29;
            this.btn_Picking_Delete.Text = "Delete";
            // 
            // btn_Picking_Edit
            // 
            this.btn_Picking_Edit.AllowFocus = false;
            this.btn_Picking_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Picking_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Picking_Edit.ImageOptions.Image")));
            this.btn_Picking_Edit.Location = new System.Drawing.Point(383, 0);
            this.btn_Picking_Edit.Name = "btn_Picking_Edit";
            this.btn_Picking_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Picking_Edit.TabIndex = 28;
            this.btn_Picking_Edit.Text = "Edit";
            // 
            // btn_Picking_Add
            // 
            this.btn_Picking_Add.AllowFocus = false;
            this.btn_Picking_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Picking_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Picking_Add.ImageOptions.Image")));
            this.btn_Picking_Add.Location = new System.Drawing.Point(298, 0);
            this.btn_Picking_Add.Name = "btn_Picking_Add";
            this.btn_Picking_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Picking_Add.TabIndex = 27;
            this.btn_Picking_Add.Text = "Add";
            // 
            // btn_Picking_Search
            // 
            this.btn_Picking_Search.AllowFocus = false;
            this.btn_Picking_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Picking_Search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Picking_Search.ImageOptions.Image")));
            this.btn_Picking_Search.Location = new System.Drawing.Point(213, 0);
            this.btn_Picking_Search.Name = "btn_Picking_Search";
            this.btn_Picking_Search.Size = new System.Drawing.Size(85, 43);
            this.btn_Picking_Search.TabIndex = 26;
            this.btn_Picking_Search.Text = "Search";
            // 
            // det_PickingDate
            // 
            this.det_PickingDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.det_PickingDate.EditValue = null;
            this.det_PickingDate.Location = new System.Drawing.Point(45, 0);
            this.det_PickingDate.Name = "det_PickingDate";
            this.det_PickingDate.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.det_PickingDate.Properties.Appearance.Options.UseFont = true;
            this.det_PickingDate.Properties.Appearance.Options.UseTextOptions = true;
            this.det_PickingDate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.det_PickingDate.Properties.AutoHeight = false;
            this.det_PickingDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_PickingDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.det_PickingDate.Properties.Mask.EditMask = "yyyy/MM";
            this.det_PickingDate.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.det_PickingDate.Properties.ShowMonthNavigationButtons = DevExpress.Utils.DefaultBoolean.True;
            this.det_PickingDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.det_PickingDate.Properties.VistaCalendarInitialViewStyle = DevExpress.XtraEditors.VistaCalendarInitialViewStyle.YearView;
            this.det_PickingDate.Properties.VistaCalendarViewStyle = DevExpress.XtraEditors.VistaCalendarViewStyle.YearView;
            this.det_PickingDate.Size = new System.Drawing.Size(168, 43);
            this.det_PickingDate.TabIndex = 25;
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
            // PickingMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "PickingMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PruchasegroupControl)).EndInit();
            this.PruchasegroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PickinggridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).EndInit();
            this.Company_BarpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.det_PickingDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.det_PickingDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl PruchasegroupControl;
        private DevExpress.XtraGrid.GridControl PickinggridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPickingFlag;
        private DevExpress.XtraGrid.Columns.GridColumn colPickingNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPickingCustomerNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPickingTax;
        private DevExpress.XtraGrid.Columns.GridColumn colPickingInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalTax;
        private DevExpress.XtraGrid.Columns.GridColumn colPosting;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraEditors.PanelControl Company_BarpanelControl;
        private DevExpress.XtraEditors.SimpleButton btn_Picking_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Picking_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Picking_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Picking_Search;
        private DevExpress.XtraEditors.DateEdit det_PickingDate;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}
