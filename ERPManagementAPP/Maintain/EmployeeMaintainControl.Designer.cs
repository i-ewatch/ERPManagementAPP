
namespace ERPManagementAPP.Maintain
{
    partial class EmployeeMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.EmployeegroupControl = new DevExpress.XtraEditors.GroupControl();
            this.EmployeegridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeeNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToken = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Company_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btn_Employee_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Employee_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Employee_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Employee_Add = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeegroupControl)).BeginInit();
            this.EmployeegroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EmployeegridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).BeginInit();
            this.Company_BarpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.EmployeegroupControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 846);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // EmployeegroupControl
            // 
            this.EmployeegroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.EmployeegroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.EmployeegroupControl.Controls.Add(this.EmployeegridControl);
            this.EmployeegroupControl.Controls.Add(this.Company_BarpanelControl);
            this.EmployeegroupControl.Location = new System.Drawing.Point(12, 12);
            this.EmployeegroupControl.Name = "EmployeegroupControl";
            this.EmployeegroupControl.Size = new System.Drawing.Size(1254, 822);
            this.EmployeegroupControl.TabIndex = 4;
            this.EmployeegroupControl.Text = "員工資料";
            // 
            // EmployeegridControl
            // 
            this.EmployeegridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EmployeegridControl.Location = new System.Drawing.Point(2, 66);
            this.EmployeegridControl.MainView = this.gridView1;
            this.EmployeegridControl.Name = "EmployeegridControl";
            this.EmployeegridControl.Size = new System.Drawing.Size(1250, 754);
            this.EmployeegridControl.TabIndex = 3;
            this.EmployeegridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeeNumber,
            this.colEmployeeName,
            this.colPhone,
            this.colAddress,
            this.colToken});
            this.gridView1.GridControl = this.EmployeegridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colEmployeeNumber
            // 
            this.colEmployeeNumber.Caption = "編號";
            this.colEmployeeNumber.FieldName = "EmployeeNumber";
            this.colEmployeeNumber.Name = "colEmployeeNumber";
            this.colEmployeeNumber.OptionsColumn.AllowEdit = false;
            this.colEmployeeNumber.Visible = true;
            this.colEmployeeNumber.VisibleIndex = 0;
            // 
            // colEmployeeName
            // 
            this.colEmployeeName.Caption = "姓名";
            this.colEmployeeName.FieldName = "EmployeeName";
            this.colEmployeeName.Name = "colEmployeeName";
            this.colEmployeeName.OptionsColumn.AllowEdit = false;
            this.colEmployeeName.Visible = true;
            this.colEmployeeName.VisibleIndex = 1;
            // 
            // colPhone
            // 
            this.colPhone.Caption = "手機";
            this.colPhone.FieldName = "Phone";
            this.colPhone.Name = "colPhone";
            this.colPhone.OptionsColumn.AllowEdit = false;
            this.colPhone.Visible = true;
            this.colPhone.VisibleIndex = 2;
            // 
            // colAddress
            // 
            this.colAddress.Caption = "戶籍地址";
            this.colAddress.FieldName = "Address";
            this.colAddress.Name = "colAddress";
            this.colAddress.OptionsColumn.AllowEdit = false;
            this.colAddress.Visible = true;
            this.colAddress.VisibleIndex = 3;
            // 
            // colToken
            // 
            this.colToken.Caption = "權限";
            this.colToken.FieldName = "Token";
            this.colToken.Name = "colToken";
            this.colToken.OptionsColumn.AllowEdit = false;
            this.colToken.Visible = true;
            this.colToken.VisibleIndex = 4;
            // 
            // Company_BarpanelControl
            // 
            this.Company_BarpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Company_BarpanelControl.Controls.Add(this.btn_Employee_Refresh);
            this.Company_BarpanelControl.Controls.Add(this.btn_Employee_Delete);
            this.Company_BarpanelControl.Controls.Add(this.btn_Employee_Edit);
            this.Company_BarpanelControl.Controls.Add(this.btn_Employee_Add);
            this.Company_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Company_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.Company_BarpanelControl.Name = "Company_BarpanelControl";
            this.Company_BarpanelControl.Size = new System.Drawing.Size(1250, 43);
            this.Company_BarpanelControl.TabIndex = 2;
            // 
            // btn_Employee_Refresh
            // 
            this.btn_Employee_Refresh.AllowFocus = false;
            this.btn_Employee_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Employee_Refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Employee_Refresh.ImageOptions.Image")));
            this.btn_Employee_Refresh.Location = new System.Drawing.Point(255, 0);
            this.btn_Employee_Refresh.Name = "btn_Employee_Refresh";
            this.btn_Employee_Refresh.Size = new System.Drawing.Size(85, 43);
            this.btn_Employee_Refresh.TabIndex = 3;
            this.btn_Employee_Refresh.Text = "Refresh";
            // 
            // btn_Employee_Delete
            // 
            this.btn_Employee_Delete.AllowFocus = false;
            this.btn_Employee_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Employee_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Employee_Delete.ImageOptions.Image")));
            this.btn_Employee_Delete.Location = new System.Drawing.Point(170, 0);
            this.btn_Employee_Delete.Name = "btn_Employee_Delete";
            this.btn_Employee_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Employee_Delete.TabIndex = 2;
            this.btn_Employee_Delete.Text = "Delete";
            // 
            // btn_Employee_Edit
            // 
            this.btn_Employee_Edit.AllowFocus = false;
            this.btn_Employee_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Employee_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Employee_Edit.ImageOptions.Image")));
            this.btn_Employee_Edit.Location = new System.Drawing.Point(85, 0);
            this.btn_Employee_Edit.Name = "btn_Employee_Edit";
            this.btn_Employee_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Employee_Edit.TabIndex = 1;
            this.btn_Employee_Edit.Text = "Edit";
            // 
            // btn_Employee_Add
            // 
            this.btn_Employee_Add.AllowFocus = false;
            this.btn_Employee_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Employee_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Employee_Add.ImageOptions.Image")));
            this.btn_Employee_Add.Location = new System.Drawing.Point(0, 0);
            this.btn_Employee_Add.Name = "btn_Employee_Add";
            this.btn_Employee_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Employee_Add.TabIndex = 0;
            this.btn_Employee_Add.Text = "Add";
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
            this.layoutControlItem1.Control = this.EmployeegroupControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1258, 826);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // EmployeeMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "EmployeeMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeegroupControl)).EndInit();
            this.EmployeegroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EmployeegridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).EndInit();
            this.Company_BarpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.GroupControl EmployeegroupControl;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.PanelControl Company_BarpanelControl;
        private DevExpress.XtraEditors.SimpleButton btn_Employee_Refresh;
        private DevExpress.XtraEditors.SimpleButton btn_Employee_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Employee_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Employee_Add;
        private DevExpress.XtraGrid.GridControl EmployeegridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn colPhone;
        private DevExpress.XtraGrid.Columns.GridColumn colAddress;
        private DevExpress.XtraGrid.Columns.GridColumn colToken;
    }
}
