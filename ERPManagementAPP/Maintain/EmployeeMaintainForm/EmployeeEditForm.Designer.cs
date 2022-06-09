
namespace ERPManagementAPP.Maintain.EmployeeMaintainForm
{
    partial class EmployeeEditForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeEditForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txt_PassWord = new DevExpress.XtraEditors.TextEdit();
            this.txt_Account = new DevExpress.XtraEditors.TextEdit();
            this.cbt_Token = new DevExpress.XtraEditors.ComboBoxEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.mmt_Address = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_EmployeeNumber = new DevExpress.XtraEditors.TextEdit();
            this.txt_Name = new DevExpress.XtraEditors.TextEdit();
            this.txt_Phone = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Account.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbt_Token.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmt_Address.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EmployeeNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Phone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txt_PassWord);
            this.layoutControl1.Controls.Add(this.txt_Account);
            this.layoutControl1.Controls.Add(this.cbt_Token);
            this.layoutControl1.Controls.Add(this.panelControl2);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.txt_EmployeeNumber);
            this.layoutControl1.Controls.Add(this.txt_Name);
            this.layoutControl1.Controls.Add(this.txt_Phone);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(569, 289);
            this.layoutControl1.TabIndex = 2;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Location = new System.Drawing.Point(83, 203);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PassWord.Properties.Appearance.Options.UseFont = true;
            this.txt_PassWord.Properties.NullValuePrompt = "請輸入密碼";
            this.txt_PassWord.Size = new System.Drawing.Size(474, 26);
            this.txt_PassWord.StyleController = this.layoutControl1;
            this.txt_PassWord.TabIndex = 10;
            // 
            // txt_Account
            // 
            this.txt_Account.EditValue = "";
            this.txt_Account.Location = new System.Drawing.Point(83, 173);
            this.txt_Account.Name = "txt_Account";
            this.txt_Account.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Account.Properties.Appearance.Options.UseFont = true;
            this.txt_Account.Properties.NullValuePrompt = "請輸入帳號";
            this.txt_Account.Size = new System.Drawing.Size(474, 26);
            this.txt_Account.StyleController = this.layoutControl1;
            this.txt_Account.TabIndex = 9;
            // 
            // cbt_Token
            // 
            this.cbt_Token.EditValue = "一般使用者";
            this.cbt_Token.Location = new System.Drawing.Point(453, 12);
            this.cbt_Token.Name = "cbt_Token";
            this.cbt_Token.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbt_Token.Properties.Appearance.Options.UseFont = true;
            this.cbt_Token.Properties.AppearanceDropDown.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbt_Token.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbt_Token.Properties.AppearanceItemSelected.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbt_Token.Properties.AppearanceItemSelected.Options.UseFont = true;
            this.cbt_Token.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbt_Token.Properties.Items.AddRange(new object[] {
            "一般使用者",
            "管理員",
            "合作夥伴"});
            this.cbt_Token.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbt_Token.Size = new System.Drawing.Size(104, 26);
            this.cbt_Token.StyleController = this.layoutControl1;
            this.cbt_Token.TabIndex = 8;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.btn_Save);
            this.panelControl2.Controls.Add(this.btn_Cancel);
            this.panelControl2.Location = new System.Drawing.Point(12, 233);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(545, 44);
            this.panelControl2.TabIndex = 7;
            // 
            // btn_Save
            // 
            this.btn_Save.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(357, 0);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(94, 44);
            this.btn_Save.TabIndex = 3;
            this.btn_Save.Text = "Save";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.ImageOptions.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(451, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(94, 44);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "Cancel";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.mmt_Address);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 102);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(545, 67);
            this.panelControl1.TabIndex = 6;
            // 
            // mmt_Address
            // 
            this.mmt_Address.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mmt_Address.Location = new System.Drawing.Point(72, 0);
            this.mmt_Address.Name = "mmt_Address";
            this.mmt_Address.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.mmt_Address.Properties.Appearance.Options.UseFont = true;
            this.mmt_Address.Size = new System.Drawing.Size(473, 67);
            this.mmt_Address.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelControl1.Location = new System.Drawing.Point(0, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 20);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "信箱          ";
            // 
            // txt_EmployeeNumber
            // 
            this.txt_EmployeeNumber.Location = new System.Drawing.Point(83, 12);
            this.txt_EmployeeNumber.Name = "txt_EmployeeNumber";
            this.txt_EmployeeNumber.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_EmployeeNumber.Properties.Appearance.Options.UseFont = true;
            this.txt_EmployeeNumber.Properties.AppearanceDisabled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.txt_EmployeeNumber.Properties.AppearanceDisabled.Options.UseForeColor = true;
            this.txt_EmployeeNumber.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txt_EmployeeNumber.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txt_EmployeeNumber.Properties.MaxLength = 6;
            this.txt_EmployeeNumber.Properties.NullValuePrompt = "XX-000";
            this.txt_EmployeeNumber.Size = new System.Drawing.Size(295, 26);
            this.txt_EmployeeNumber.StyleController = this.layoutControl1;
            this.txt_EmployeeNumber.TabIndex = 5;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(83, 42);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Name.Properties.Appearance.Options.UseFont = true;
            this.txt_Name.Properties.MaxLength = 10;
            this.txt_Name.Properties.NullValuePrompt = "請輸入姓名";
            this.txt_Name.Size = new System.Drawing.Size(474, 26);
            this.txt_Name.StyleController = this.layoutControl1;
            this.txt_Name.TabIndex = 5;
            // 
            // txt_Phone
            // 
            this.txt_Phone.Location = new System.Drawing.Point(83, 72);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Phone.Properties.Appearance.Options.UseFont = true;
            this.txt_Phone.Properties.MaxLength = 11;
            this.txt_Phone.Properties.NullValuePrompt = "09-12345678";
            this.txt_Phone.Size = new System.Drawing.Size(474, 26);
            this.txt_Phone.StyleController = this.layoutControl1;
            this.txt_Phone.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.layoutControlItem8});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(569, 289);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_EmployeeNumber;
            this.layoutControlItem2.CustomizationFormText = "編號";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(370, 30);
            this.layoutControlItem2.Text = "編號*";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(68, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem3.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem3.Control = this.txt_Name;
            this.layoutControlItem3.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem3.CustomizationFormText = "編號";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(549, 30);
            this.layoutControlItem3.Text = "姓名*";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(68, 20);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem4.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem4.Control = this.txt_Phone;
            this.layoutControlItem4.ControlAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.layoutControlItem4.CustomizationFormText = "手機    ";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(549, 30);
            this.layoutControlItem4.Text = "手機         ";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(68, 20);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.panelControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 90);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(549, 71);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.panelControl2;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 221);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(549, 48);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem6.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem6.Control = this.cbt_Token;
            this.layoutControlItem6.Location = new System.Drawing.Point(370, 0);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(179, 30);
            this.layoutControlItem6.Text = "權限";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(68, 20);
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem7.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem7.Control = this.txt_Account;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 161);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(549, 30);
            this.layoutControlItem7.Text = "帳號*";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(68, 20);
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem8.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem8.Control = this.txt_PassWord;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 191);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(549, 30);
            this.layoutControlItem8.Text = "密碼*";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(68, 20);
            // 
            // EmployeeEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 289);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EmployeeEditForm";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Account.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbt_Token.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mmt_Address.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_EmployeeNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Name.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Phone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.TextEdit txt_EmployeeNumber;
        private DevExpress.XtraEditors.TextEdit txt_Name;
        private DevExpress.XtraEditors.TextEdit txt_Phone;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.ComboBoxEdit cbt_Token;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraEditors.MemoEdit mmt_Address;
        private DevExpress.XtraEditors.TextEdit txt_PassWord;
        private DevExpress.XtraEditors.TextEdit txt_Account;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
    }
}