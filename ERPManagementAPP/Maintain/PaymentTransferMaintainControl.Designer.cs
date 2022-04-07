
namespace ERPManagementAPP.Maintain
{
    partial class PaymentTransferMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentTransferMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaymentNumber = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btn_TransferDate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1254, 822);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "代墊代付費用";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 66);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1250, 754);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaymentNumber,
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
            // colPaymentDate
            // 
            this.colPaymentDate.Caption = "日期";
            this.colPaymentDate.FieldName = "PaymentDate";
            this.colPaymentDate.Name = "colPaymentDate";
            this.colPaymentDate.OptionsColumn.AllowEdit = false;
            this.colPaymentDate.Visible = true;
            this.colPaymentDate.VisibleIndex = 1;
            // 
            // colPaymentInvoiceNo
            // 
            this.colPaymentInvoiceNo.Caption = "發票號碼";
            this.colPaymentInvoiceNo.FieldName = "PaymentInvoiceNo";
            this.colPaymentInvoiceNo.Name = "colPaymentInvoiceNo";
            this.colPaymentInvoiceNo.OptionsColumn.AllowEdit = false;
            this.colPaymentInvoiceNo.Visible = true;
            this.colPaymentInvoiceNo.VisibleIndex = 2;
            // 
            // colPaymentItemNo
            // 
            this.colPaymentItemNo.Caption = "品項代碼";
            this.colPaymentItemNo.FieldName = "PaymentItemNo";
            this.colPaymentItemNo.Name = "colPaymentItemNo";
            this.colPaymentItemNo.OptionsColumn.AllowEdit = false;
            this.colPaymentItemNo.Visible = true;
            this.colPaymentItemNo.VisibleIndex = 3;
            // 
            // colPaymentUse
            // 
            this.colPaymentUse.Caption = "用途";
            this.colPaymentUse.FieldName = "PaymentUse";
            this.colPaymentUse.Name = "colPaymentUse";
            this.colPaymentUse.OptionsColumn.AllowEdit = false;
            // 
            // colEmployeeNumber
            // 
            this.colEmployeeNumber.Caption = "申請人";
            this.colEmployeeNumber.FieldName = "EmployeeNumber";
            this.colEmployeeNumber.Name = "colEmployeeNumber";
            this.colEmployeeNumber.OptionsColumn.AllowEdit = false;
            this.colEmployeeNumber.OptionsFilter.AllowAutoFilter = false;
            this.colEmployeeNumber.Visible = true;
            this.colEmployeeNumber.VisibleIndex = 4;
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
            this.colPaymentAmount.VisibleIndex = 5;
            // 
            // colPaymentMethod
            // 
            this.colPaymentMethod.Caption = "請款方式";
            this.colPaymentMethod.FieldName = "PaymentMethod";
            this.colPaymentMethod.Name = "colPaymentMethod";
            this.colPaymentMethod.OptionsColumn.AllowEdit = false;
            this.colPaymentMethod.Visible = true;
            this.colPaymentMethod.VisibleIndex = 6;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "備註";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            // 
            // colTransferDate
            // 
            this.colTransferDate.Caption = "匯款收款日期";
            this.colTransferDate.FieldName = "TransferDate";
            this.colTransferDate.Name = "colTransferDate";
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
            this.panelControl1.Controls.Add(this.btn_TransferDate);
            this.panelControl1.Controls.Add(this.btn_Payment_Refresh);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1250, 43);
            this.panelControl1.TabIndex = 1;
            // 
            // btn_Payment_Refresh
            // 
            this.btn_Payment_Refresh.AllowFocus = false;
            this.btn_Payment_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Payment_Refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Payment_Refresh.ImageOptions.Image")));
            this.btn_Payment_Refresh.Location = new System.Drawing.Point(0, 0);
            this.btn_Payment_Refresh.Name = "btn_Payment_Refresh";
            this.btn_Payment_Refresh.Size = new System.Drawing.Size(85, 43);
            this.btn_Payment_Refresh.TabIndex = 31;
            this.btn_Payment_Refresh.Text = "Refresh";
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
            // btn_TransferDate
            // 
            this.btn_TransferDate.AllowFocus = false;
            this.btn_TransferDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_TransferDate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_TransferDate.Location = new System.Drawing.Point(85, 0);
            this.btn_TransferDate.Name = "btn_TransferDate";
            this.btn_TransferDate.Size = new System.Drawing.Size(111, 43);
            this.btn_TransferDate.TabIndex = 32;
            this.btn_TransferDate.Text = "全部過帳";
            // 
            // PaymentTransferMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "PaymentTransferMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Payment_Refresh;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentInvoiceNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentItemNo;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentUse;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentMethod;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferDate;
        private DevExpress.XtraGrid.Columns.GridColumn colFileName;
        private DevExpress.XtraEditors.SimpleButton btn_TransferDate;
    }
}
