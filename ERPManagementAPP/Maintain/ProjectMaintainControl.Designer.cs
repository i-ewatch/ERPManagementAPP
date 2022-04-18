
namespace ERPManagementAPP.Maintain
{
    partial class ProjectMaintainControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectMaintainControl));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.CompanyDirectorygroupControl = new DevExpress.XtraEditors.GroupControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProjectNumber1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmployeeNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBonusRatio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.CompanyDirectory_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.CompanygroupControl = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colProjectNumber = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProjectName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colRemark = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProjectIncome = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProjectCost = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProjectProfit = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProjectBonusCommission = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colPostingDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProfitSharingDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFileName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.Company_BarpanelControl = new DevExpress.XtraEditors.PanelControl();
            this.btn_Project_Refresh = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Project_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Project_Edit = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Project_Add = new DevExpress.XtraEditors.SimpleButton();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDirectorygroupControl)).BeginInit();
            this.CompanyDirectorygroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDirectory_BarpanelControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanygroupControl)).BeginInit();
            this.CompanygroupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).BeginInit();
            this.Company_BarpanelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.CompanyDirectorygroupControl);
            this.layoutControl1.Controls.Add(this.CompanygroupControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1325, 554, 650, 400);
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(1278, 846);
            this.layoutControl1.TabIndex = 1;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // CompanyDirectorygroupControl
            // 
            this.CompanyDirectorygroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.CompanyDirectorygroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.CompanyDirectorygroupControl.Controls.Add(this.gridControl2);
            this.CompanyDirectorygroupControl.Controls.Add(this.CompanyDirectory_BarpanelControl);
            this.CompanyDirectorygroupControl.Location = new System.Drawing.Point(874, 12);
            this.CompanyDirectorygroupControl.Name = "CompanyDirectorygroupControl";
            this.CompanyDirectorygroupControl.Size = new System.Drawing.Size(392, 822);
            this.CompanyDirectorygroupControl.TabIndex = 5;
            this.CompanyDirectorygroupControl.Text = "專案成員";
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 66);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(388, 754);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProjectNumber1,
            this.colEmployeeNumber,
            this.colBonusRatio});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // colProjectNumber1
            // 
            this.colProjectNumber1.Caption = "專案代碼";
            this.colProjectNumber1.FieldName = "ProjectNumber";
            this.colProjectNumber1.Name = "colProjectNumber1";
            this.colProjectNumber1.OptionsColumn.AllowEdit = false;
            this.colProjectNumber1.Visible = true;
            this.colProjectNumber1.VisibleIndex = 0;
            // 
            // colEmployeeNumber
            // 
            this.colEmployeeNumber.Caption = "員工編號";
            this.colEmployeeNumber.FieldName = "EmployeeNumber";
            this.colEmployeeNumber.Name = "colEmployeeNumber";
            this.colEmployeeNumber.OptionsColumn.AllowEdit = false;
            this.colEmployeeNumber.Visible = true;
            this.colEmployeeNumber.VisibleIndex = 1;
            // 
            // colBonusRatio
            // 
            this.colBonusRatio.Caption = "獎金比率";
            this.colBonusRatio.DisplayFormat.FormatString = "{0}%";
            this.colBonusRatio.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.colBonusRatio.FieldName = "BonusRatio";
            this.colBonusRatio.Name = "colBonusRatio";
            this.colBonusRatio.OptionsColumn.AllowEdit = false;
            this.colBonusRatio.Visible = true;
            this.colBonusRatio.VisibleIndex = 2;
            // 
            // CompanyDirectory_BarpanelControl
            // 
            this.CompanyDirectory_BarpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.CompanyDirectory_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.CompanyDirectory_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.CompanyDirectory_BarpanelControl.Name = "CompanyDirectory_BarpanelControl";
            this.CompanyDirectory_BarpanelControl.Size = new System.Drawing.Size(388, 43);
            this.CompanyDirectory_BarpanelControl.TabIndex = 1;
            // 
            // CompanygroupControl
            // 
            this.CompanygroupControl.AppearanceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.CompanygroupControl.AppearanceCaption.Options.UseForeColor = true;
            this.CompanygroupControl.Controls.Add(this.gridControl1);
            this.CompanygroupControl.Controls.Add(this.Company_BarpanelControl);
            this.CompanygroupControl.Location = new System.Drawing.Point(12, 12);
            this.CompanygroupControl.Name = "CompanygroupControl";
            this.CompanygroupControl.Size = new System.Drawing.Size(853, 822);
            this.CompanygroupControl.TabIndex = 4;
            this.CompanygroupControl.Text = "專案資料";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 66);
            this.gridControl1.MainView = this.advBandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(849, 754);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView1});
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colProjectNumber,
            this.colProjectName,
            this.colRemark,
            this.colProjectIncome,
            this.colProjectCost,
            this.colProjectProfit,
            this.colProjectBonusCommission,
            this.colPostingDate,
            this.colProfitSharingDate,
            this.colFileName});
            this.advBandedGridView1.GridControl = this.gridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            this.advBandedGridView1.OptionsView.ShowBands = false;
            this.advBandedGridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Columns.Add(this.colProjectNumber);
            this.gridBand1.Columns.Add(this.colProjectName);
            this.gridBand1.Columns.Add(this.colRemark);
            this.gridBand1.Columns.Add(this.colProjectIncome);
            this.gridBand1.Columns.Add(this.colProjectCost);
            this.gridBand1.Columns.Add(this.colProjectProfit);
            this.gridBand1.Columns.Add(this.colProjectBonusCommission);
            this.gridBand1.Columns.Add(this.colPostingDate);
            this.gridBand1.Columns.Add(this.colProfitSharingDate);
            this.gridBand1.Columns.Add(this.colFileName);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 750;
            // 
            // colProjectNumber
            // 
            this.colProjectNumber.Caption = "專案代碼";
            this.colProjectNumber.FieldName = "ProjectNumber";
            this.colProjectNumber.Name = "colProjectNumber";
            this.colProjectNumber.OptionsColumn.AllowEdit = false;
            this.colProjectNumber.Visible = true;
            // 
            // colProjectName
            // 
            this.colProjectName.Caption = "專案名稱";
            this.colProjectName.FieldName = "ProjectName";
            this.colProjectName.Name = "colProjectName";
            this.colProjectName.OptionsColumn.AllowEdit = false;
            this.colProjectName.Visible = true;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "備註";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.OptionsColumn.AllowEdit = false;
            this.colRemark.Visible = true;
            // 
            // colProjectIncome
            // 
            this.colProjectIncome.Caption = "專案總收入";
            this.colProjectIncome.DisplayFormat.FormatString = "c0";
            this.colProjectIncome.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProjectIncome.FieldName = "ProjectIncome";
            this.colProjectIncome.Name = "colProjectIncome";
            this.colProjectIncome.OptionsColumn.AllowEdit = false;
            this.colProjectIncome.Visible = true;
            // 
            // colProjectCost
            // 
            this.colProjectCost.Caption = "專案總成本";
            this.colProjectCost.DisplayFormat.FormatString = "c0";
            this.colProjectCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProjectCost.FieldName = "ProjectCost";
            this.colProjectCost.Name = "colProjectCost";
            this.colProjectCost.OptionsColumn.AllowEdit = false;
            this.colProjectCost.Visible = true;
            // 
            // colProjectProfit
            // 
            this.colProjectProfit.Caption = "專案獲利";
            this.colProjectProfit.DisplayFormat.FormatString = "c0";
            this.colProjectProfit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colProjectProfit.FieldName = "ProjectProfit";
            this.colProjectProfit.Name = "colProjectProfit";
            this.colProjectProfit.OptionsColumn.AllowEdit = false;
            this.colProjectProfit.Visible = true;
            // 
            // colProjectBonusCommission
            // 
            this.colProjectBonusCommission.Caption = "專案獎金提成";
            this.colProjectBonusCommission.FieldName = "ProjectBonusCommission";
            this.colProjectBonusCommission.Name = "colProjectBonusCommission";
            this.colProjectBonusCommission.OptionsColumn.AllowEdit = false;
            this.colProjectBonusCommission.Visible = true;
            // 
            // colPostingDate
            // 
            this.colPostingDate.Caption = "結案日期";
            this.colPostingDate.FieldName = "PostingDate";
            this.colPostingDate.Name = "colPostingDate";
            this.colPostingDate.OptionsColumn.AllowEdit = false;
            this.colPostingDate.Visible = true;
            // 
            // colProfitSharingDate
            // 
            this.colProfitSharingDate.Caption = "分潤日期";
            this.colProfitSharingDate.FieldName = "ProfitSharingDate";
            this.colProfitSharingDate.Name = "colProfitSharingDate";
            this.colProfitSharingDate.OptionsColumn.AllowEdit = false;
            this.colProfitSharingDate.Visible = true;
            // 
            // colFileName
            // 
            this.colFileName.Caption = "附件檔名";
            this.colFileName.FieldName = "FileName";
            this.colFileName.Name = "colFileName";
            this.colFileName.Visible = true;
            // 
            // Company_BarpanelControl
            // 
            this.Company_BarpanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Company_BarpanelControl.Controls.Add(this.btn_Project_Refresh);
            this.Company_BarpanelControl.Controls.Add(this.btn_Project_Delete);
            this.Company_BarpanelControl.Controls.Add(this.btn_Project_Edit);
            this.Company_BarpanelControl.Controls.Add(this.btn_Project_Add);
            this.Company_BarpanelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.Company_BarpanelControl.Location = new System.Drawing.Point(2, 23);
            this.Company_BarpanelControl.Name = "Company_BarpanelControl";
            this.Company_BarpanelControl.Size = new System.Drawing.Size(849, 43);
            this.Company_BarpanelControl.TabIndex = 0;
            // 
            // btn_Project_Refresh
            // 
            this.btn_Project_Refresh.AllowFocus = false;
            this.btn_Project_Refresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Project_Refresh.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Project_Refresh.ImageOptions.Image")));
            this.btn_Project_Refresh.Location = new System.Drawing.Point(255, 0);
            this.btn_Project_Refresh.Name = "btn_Project_Refresh";
            this.btn_Project_Refresh.Size = new System.Drawing.Size(85, 43);
            this.btn_Project_Refresh.TabIndex = 3;
            this.btn_Project_Refresh.Text = "Refresh";
            // 
            // btn_Project_Delete
            // 
            this.btn_Project_Delete.AllowFocus = false;
            this.btn_Project_Delete.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Project_Delete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Project_Delete.ImageOptions.Image")));
            this.btn_Project_Delete.Location = new System.Drawing.Point(170, 0);
            this.btn_Project_Delete.Name = "btn_Project_Delete";
            this.btn_Project_Delete.Size = new System.Drawing.Size(85, 43);
            this.btn_Project_Delete.TabIndex = 2;
            this.btn_Project_Delete.Text = "Delete";
            // 
            // btn_Project_Edit
            // 
            this.btn_Project_Edit.AllowFocus = false;
            this.btn_Project_Edit.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Project_Edit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Project_Edit.ImageOptions.Image")));
            this.btn_Project_Edit.Location = new System.Drawing.Point(85, 0);
            this.btn_Project_Edit.Name = "btn_Project_Edit";
            this.btn_Project_Edit.Size = new System.Drawing.Size(85, 43);
            this.btn_Project_Edit.TabIndex = 1;
            this.btn_Project_Edit.Text = "Edit";
            // 
            // btn_Project_Add
            // 
            this.btn_Project_Add.AllowFocus = false;
            this.btn_Project_Add.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_Project_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Project_Add.ImageOptions.Image")));
            this.btn_Project_Add.Location = new System.Drawing.Point(0, 0);
            this.btn_Project_Add.Name = "btn_Project_Add";
            this.btn_Project_Add.Size = new System.Drawing.Size(85, 43);
            this.btn_Project_Add.TabIndex = 0;
            this.btn_Project_Add.Text = "Add";
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
            this.Root.Size = new System.Drawing.Size(1278, 846);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.CompanygroupControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(857, 826);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.CompanyDirectorygroupControl;
            this.layoutControlItem2.Location = new System.Drawing.Point(862, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(396, 826);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.Location = new System.Drawing.Point(857, 0);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(5, 826);
            // 
            // ProjectMaintainControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "ProjectMaintainControl";
            this.Size = new System.Drawing.Size(1278, 846);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDirectorygroupControl)).EndInit();
            this.CompanyDirectorygroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanyDirectory_BarpanelControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CompanygroupControl)).EndInit();
            this.CompanygroupControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Company_BarpanelControl)).EndInit();
            this.Company_BarpanelControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.GroupControl CompanyDirectorygroupControl;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colProjectNumber1;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeeNumber;
        private DevExpress.XtraEditors.PanelControl CompanyDirectory_BarpanelControl;
        private DevExpress.XtraEditors.GroupControl CompanygroupControl;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.PanelControl Company_BarpanelControl;
        private DevExpress.XtraEditors.SimpleButton btn_Project_Refresh;
        private DevExpress.XtraEditors.SimpleButton btn_Project_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_Project_Edit;
        private DevExpress.XtraEditors.SimpleButton btn_Project_Add;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProjectNumber;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProjectName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colRemark;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFileName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProjectIncome;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProjectCost;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProjectProfit;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProjectBonusCommission;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colPostingDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProfitSharingDate;
        private DevExpress.XtraGrid.Columns.GridColumn colBonusRatio;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
    }
}
