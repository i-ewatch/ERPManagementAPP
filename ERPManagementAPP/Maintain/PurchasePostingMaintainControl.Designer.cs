
namespace ERPManagementAPP.Maintain
{
    partial class PurchasePostingMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchasePostingMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.PurchasegridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPurchaseFlag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseCompanyNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPurchaseInvoiceNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalTax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosting = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Purchase_Search = new DevExpress.XtraEditors.SimpleButton();
            this.cet_Other = new DevExpress.XtraEditors.CheckEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PurchasegridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cet_Other.Properties)).BeginInit();
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
            this.groupControl1.Controls.Add(this.PurchasegridControl);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1254, 822);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "進貨/進貨退出";
            // 
            // PurchasegridControl
            // 
            this.PurchasegridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PurchasegridControl.Location = new System.Drawing.Point(2, 66);
            this.PurchasegridControl.MainView = this.gridView1;
            this.PurchasegridControl.Name = "PurchasegridControl";
            this.PurchasegridControl.Size = new System.Drawing.Size(1250, 754);
            this.PurchasegridControl.TabIndex = 5;
            this.PurchasegridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPurchaseFlag,
            this.colPurchaseNumber,
            this.colPurchaseCompanyNumber,
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
            this.colPurchaseCompanyNumber.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colPurchaseCompanyNumber.Visible = true;
            this.colPurchaseCompanyNumber.VisibleIndex = 2;
            // 
            // colPurchaseTax
            // 
            this.colPurchaseTax.Caption = "稅別";
            this.colPurchaseTax.FieldName = "PurchaseTax";
            this.colPurchaseTax.Name = "colPurchaseTax";
            this.colPurchaseTax.OptionsColumn.AllowEdit = false;
            // 
            // colPurchaseInvoiceNo
            // 
            this.colPurchaseInvoiceNo.Caption = "發票號碼";
            this.colPurchaseInvoiceNo.FieldName = "PurchaseInvoiceNo";
            this.colPurchaseInvoiceNo.Name = "colPurchaseInvoiceNo";
            this.colPurchaseInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colPurchaseInvoiceNo.Visible = true;
            this.colPurchaseInvoiceNo.VisibleIndex = 3;
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
            this.colTotal.VisibleIndex = 4;
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
            this.colTotalTax.VisibleIndex = 5;
            // 
            // colPosting
            // 
            this.colPosting.Caption = "過帳";
            this.colPosting.FieldName = "Posting";
            this.colPosting.Name = "colPosting";
            this.colPosting.Visible = true;
            this.colPosting.VisibleIndex = 6;
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
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_Purchase_Search);
            this.panelControl1.Controls.Add(this.cet_Other);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1250, 43);
            this.panelControl1.TabIndex = 0;
            // 
            // btn_Purchase_Search
            // 
            this.btn_Purchase_Search.AllowFocus = false;
            this.btn_Purchase_Search.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Purchase_Search.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Purchase_Search.ImageOptions.Image")));
            this.btn_Purchase_Search.Location = new System.Drawing.Point(142, 0);
            this.btn_Purchase_Search.Name = "btn_Purchase_Search";
            this.btn_Purchase_Search.Size = new System.Drawing.Size(85, 43);
            this.btn_Purchase_Search.TabIndex = 29;
            this.btn_Purchase_Search.Text = "Search";
            // 
            // cet_Other
            // 
            this.cet_Other.Dock = System.Windows.Forms.DockStyle.Left;
            this.cet_Other.Location = new System.Drawing.Point(0, 0);
            this.cet_Other.Name = "cet_Other";
            this.cet_Other.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cet_Other.Properties.Appearance.Options.UseFont = true;
            this.cet_Other.Properties.Appearance.Options.UseTextOptions = true;
            this.cet_Other.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cet_Other.Properties.Caption = "其他付款方式";
            this.cet_Other.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.cet_Other.Size = new System.Drawing.Size(142, 43);
            this.cet_Other.TabIndex = 28;
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
            // PurchasePostingMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "PurchasePostingMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PurchasegridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cet_Other.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Purchase_Search;
        private DevExpress.XtraEditors.CheckEdit cet_Other;
        private DevExpress.XtraGrid.GridControl PurchasegridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
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
    }
}
