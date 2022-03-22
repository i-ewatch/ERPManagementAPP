
namespace ERPManagementAPP.Maintain.AccountMaintainForm
{
    partial class AccountEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountEditForm));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.ckt_RememberFlag = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_ShowPassWord = new DevExpress.XtraEditors.SimpleButton();
            this.txt_PassWord = new DevExpress.XtraEditors.TextEdit();
            this.txt_Account = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ckt_RememberFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassWord.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Account.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.ckt_RememberFlag);
            this.layoutControl1.Controls.Add(this.panelControl1);
            this.layoutControl1.Controls.Add(this.btn_ShowPassWord);
            this.layoutControl1.Controls.Add(this.txt_PassWord);
            this.layoutControl1.Controls.Add(this.txt_Account);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(400, 123);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // ckt_RememberFlag
            // 
            this.ckt_RememberFlag.Location = new System.Drawing.Point(12, 72);
            this.ckt_RememberFlag.Name = "ckt_RememberFlag";
            this.ckt_RememberFlag.Properties.AllowFocused = false;
            this.ckt_RememberFlag.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.ckt_RememberFlag.Properties.Appearance.Options.UseFont = true;
            this.ckt_RememberFlag.Properties.Caption = "記住密碼";
            this.ckt_RememberFlag.Size = new System.Drawing.Size(201, 24);
            this.ckt_RememberFlag.StyleController = this.layoutControl1;
            this.ckt_RememberFlag.TabIndex = 8;
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_Login);
            this.panelControl1.Controls.Add(this.btn_Cancel);
            this.panelControl1.Location = new System.Drawing.Point(217, 72);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(171, 39);
            this.panelControl1.TabIndex = 7;
            // 
            // btn_Login
            // 
            this.btn_Login.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btn_Login.Appearance.Options.UseFont = true;
            this.btn_Login.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Login.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Login.ImageOptions.Image")));
            this.btn_Login.Location = new System.Drawing.Point(21, 0);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 39);
            this.btn_Login.TabIndex = 1;
            this.btn_Login.Text = "登入";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btn_Cancel.Appearance.Options.UseFont = true;
            this.btn_Cancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_Cancel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Cancel.ImageOptions.Image")));
            this.btn_Cancel.Location = new System.Drawing.Point(96, 0);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 39);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "取消";
            // 
            // btn_ShowPassWord
            // 
            this.btn_ShowPassWord.AllowFocus = false;
            this.btn_ShowPassWord.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btn_ShowPassWord.Appearance.Options.UseFont = true;
            this.btn_ShowPassWord.AppearancePressed.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btn_ShowPassWord.AppearancePressed.Options.UseFont = true;
            this.btn_ShowPassWord.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ShowPassWord.ImageOptions.Image")));
            this.btn_ShowPassWord.Location = new System.Drawing.Point(364, 42);
            this.btn_ShowPassWord.Name = "btn_ShowPassWord";
            this.btn_ShowPassWord.Size = new System.Drawing.Size(24, 22);
            this.btn_ShowPassWord.StyleController = this.layoutControl1;
            this.btn_ShowPassWord.TabIndex = 6;
            // 
            // txt_PassWord
            // 
            this.txt_PassWord.Location = new System.Drawing.Point(55, 42);
            this.txt_PassWord.Name = "txt_PassWord";
            this.txt_PassWord.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PassWord.Properties.Appearance.Options.UseFont = true;
            this.txt_PassWord.Properties.AppearanceFocused.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PassWord.Properties.AppearanceFocused.Options.UseFont = true;
            this.txt_PassWord.Properties.NullValuePrompt = "請輸入密碼";
            this.txt_PassWord.Properties.UseSystemPasswordChar = true;
            this.txt_PassWord.Size = new System.Drawing.Size(305, 26);
            this.txt_PassWord.StyleController = this.layoutControl1;
            this.txt_PassWord.TabIndex = 5;
            // 
            // txt_Account
            // 
            this.txt_Account.Location = new System.Drawing.Point(55, 12);
            this.txt_Account.Name = "txt_Account";
            this.txt_Account.Properties.Appearance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Account.Properties.Appearance.Options.UseFont = true;
            this.txt_Account.Properties.AppearanceFocused.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Account.Properties.AppearanceFocused.Options.UseFont = true;
            this.txt_Account.Properties.NullValuePrompt = "請輸入帳號";
            this.txt_Account.Size = new System.Drawing.Size(333, 26);
            this.txt_Account.StyleController = this.layoutControl1;
            this.txt_Account.TabIndex = 4;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(400, 123);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem1.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem1.Control = this.txt_Account;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(380, 30);
            this.layoutControlItem1.Text = "帳號  ";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(40, 20);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.AppearanceItemCaption.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.layoutControlItem2.AppearanceItemCaption.Options.UseFont = true;
            this.layoutControlItem2.Control = this.txt_PassWord;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(352, 30);
            this.layoutControlItem2.Text = "密碼";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(40, 20);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btn_ShowPassWord;
            this.layoutControlItem3.Location = new System.Drawing.Point(352, 30);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(28, 30);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.panelControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(205, 60);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(175, 43);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.ckt_RememberFlag;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 60);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(205, 43);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // AccountEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 123);
            this.ControlBox = false;
            this.Controls.Add(this.layoutControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ckt_RememberFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassWord.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Account.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Login;
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_ShowPassWord;
        private DevExpress.XtraEditors.TextEdit txt_PassWord;
        private DevExpress.XtraEditors.TextEdit txt_Account;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.CheckEdit ckt_RememberFlag;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
    }
}