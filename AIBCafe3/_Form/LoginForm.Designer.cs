namespace AIBCafe3
{
    partial class LoginForm
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.checkEdit1 = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.usertext = new DevExpress.XtraEditors.TextEdit();
            this.passwordEdit = new DevExpress.XtraEditors.TextEdit();
            this.huy_Button = new DevExpress.XtraEditors.SimpleButton();
            this.dangNhap_Button = new DevExpress.XtraEditors.SimpleButton();
            this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usertext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.checkEdit1);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Controls.Add(this.usertext);
            this.groupControl1.Controls.Add(this.passwordEdit);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(409, 188);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Đăng nhập hệ thống";
            // 
            // checkEdit1
            // 
            this.checkEdit1.Location = new System.Drawing.Point(174, 157);
            this.checkEdit1.Name = "checkEdit1";
            this.checkEdit1.Properties.Caption = "Nhớ thông tin";
            this.checkEdit1.Size = new System.Drawing.Size(223, 19);
            this.checkEdit1.TabIndex = 4;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.LineLocation = DevExpress.XtraEditors.LineLocation.Bottom;
            this.labelControl3.LineOrientation = DevExpress.XtraEditors.LabelLineOrientation.Horizontal;
            this.labelControl3.LineVisible = true;
            this.labelControl3.Location = new System.Drawing.Point(174, 34);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(223, 24);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "AIBCafe Offline v3.0";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(174, 112);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Mật khẩu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(174, 67);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tên đăng nhập";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::AIBCafe3.Properties.Resources.LOgin;
            this.pictureEdit1.Location = new System.Drawing.Point(5, 25);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(146, 158);
            this.pictureEdit1.TabIndex = 1;
            // 
            // usertext
            // 
            this.usertext.Location = new System.Drawing.Point(174, 85);
            this.usertext.Name = "usertext";
            this.usertext.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usertext.Properties.Appearance.Options.UseFont = true;
            this.usertext.Size = new System.Drawing.Size(223, 22);
            this.usertext.TabIndex = 0;
            this.usertext.Click += new System.EventHandler(this.textEdit2_Click);
            this.usertext.Enter += new System.EventHandler(this.textEdit2_Enter);
            // 
            // passwordEdit
            // 
            this.passwordEdit.Location = new System.Drawing.Point(174, 130);
            this.passwordEdit.Name = "passwordEdit";
            this.passwordEdit.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordEdit.Properties.Appearance.Options.UseFont = true;
            this.passwordEdit.Properties.Mask.EditMask = "*";
            this.passwordEdit.Properties.PasswordChar = '*';
            this.passwordEdit.Properties.UseSystemPasswordChar = true;
            this.passwordEdit.Size = new System.Drawing.Size(223, 22);
            this.passwordEdit.TabIndex = 0;
            this.passwordEdit.Click += new System.EventHandler(this.textEdit1_Click);
            this.passwordEdit.Enter += new System.EventHandler(this.textEdit1_Enter);
            // 
            // huy_Button
            // 
            this.huy_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.huy_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.huy_Button.Location = new System.Drawing.Point(328, 196);
            this.huy_Button.Name = "huy_Button";
            this.huy_Button.Size = new System.Drawing.Size(75, 23);
            this.huy_Button.TabIndex = 1;
            this.huy_Button.Text = "Hủy";
            this.huy_Button.Click += new System.EventHandler(this.huy_Button_Click);
            // 
            // dangNhap_Button
            // 
            this.dangNhap_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dangNhap_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.dangNhap_Button.Location = new System.Drawing.Point(238, 196);
            this.dangNhap_Button.Name = "dangNhap_Button";
            this.dangNhap_Button.Size = new System.Drawing.Size(75, 23);
            this.dangNhap_Button.TabIndex = 1;
            this.dangNhap_Button.Text = "Đăng nhập";
            this.dangNhap_Button.Click += new System.EventHandler(this.dangNhap_Button_Click);
            // 
            // buttonEdit1
            // 
            this.buttonEdit1.Location = new System.Drawing.Point(5, 197);
            this.buttonEdit1.Name = "buttonEdit1";
            this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.buttonEdit1.Size = new System.Drawing.Size(180, 20);
            toolTipTitleItem1.Text = "Hướng dẫn";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Đường dẫn cơ sỡ dữ liệu, chọn nut ... để chọn cơ sở làm việc";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.buttonEdit1.SuperTip = superToolTip1;
            this.buttonEdit1.TabIndex = 2;
            this.buttonEdit1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.buttonEdit1_ButtonClick);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(192, 197);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(26, 20);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "+";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // LoginForm
            // 
            this.AcceptButton = this.dangNhap_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.huy_Button;
            this.ClientSize = new System.Drawing.Size(409, 227);
            this.ControlBox = false;
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.buttonEdit1);
            this.Controls.Add(this.dangNhap_Button);
            this.Controls.Add(this.huy_Button);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AIBCafe - Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usertext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.passwordEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton huy_Button;
        private DevExpress.XtraEditors.SimpleButton dangNhap_Button;
        private DevExpress.XtraEditors.TextEdit usertext;
        private DevExpress.XtraEditors.TextEdit passwordEdit;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraEditors.CheckEdit checkEdit1;
    }
}