namespace AIBCafe3
{
    partial class Employee_Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Employee_Form));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.Luu_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Xoa_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.Close_simpleButton = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.employeeBindingSource = new System.Windows.Forms.BindingSource();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colEmployeesID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colLoginName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSell = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colReport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmpl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProduct = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colItem = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.Luu_simpleButton);
            this.groupControl1.Controls.Add(this.Xoa_simpleButton);
            this.groupControl1.Controls.Add(this.Close_simpleButton);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 360);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(971, 38);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // Luu_simpleButton
            // 
            this.Luu_simpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Luu_simpleButton.Location = new System.Drawing.Point(722, 8);
            this.Luu_simpleButton.Name = "Luu_simpleButton";
            this.Luu_simpleButton.Size = new System.Drawing.Size(75, 23);
            this.Luu_simpleButton.TabIndex = 0;
            this.Luu_simpleButton.Text = "Lưu";
            this.Luu_simpleButton.Click += new System.EventHandler(this.Luu_simpleButton_Click);
            // 
            // Xoa_simpleButton
            // 
            this.Xoa_simpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Xoa_simpleButton.Location = new System.Drawing.Point(803, 8);
            this.Xoa_simpleButton.Name = "Xoa_simpleButton";
            this.Xoa_simpleButton.Size = new System.Drawing.Size(75, 23);
            this.Xoa_simpleButton.TabIndex = 0;
            this.Xoa_simpleButton.Text = "Xóa";
            this.Xoa_simpleButton.Click += new System.EventHandler(this.Xoa_simpleButton_Click);
            // 
            // Close_simpleButton
            // 
            this.Close_simpleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close_simpleButton.Location = new System.Drawing.Point(884, 8);
            this.Close_simpleButton.Name = "Close_simpleButton";
            this.Close_simpleButton.Size = new System.Drawing.Size(75, 23);
            this.Close_simpleButton.TabIndex = 0;
            this.Close_simpleButton.Text = "Đóng";
            this.Close_simpleButton.Click += new System.EventHandler(this.Close_simpleButton_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.employeeBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.gridControl1.Size = new System.Drawing.Size(971, 360);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // employeeBindingSource
            // 
            this.employeeBindingSource.DataSource = typeof(AIBCafe3.Employee);
            this.employeeBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.employeeBindingSource_AddingNew);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colEmployeesID,
            this.colLoginName,
            this.colPassword,
            this.colName,
            this.colSell,
            this.colReport,
            this.colEmpl,
            this.colProduct,
            this.colItem});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colEmployeesID
            // 
            this.colEmployeesID.Caption = "Tên đăng nhập";
            this.colEmployeesID.ColumnEdit = this.repositoryItemTextEdit2;
            this.colEmployeesID.FieldName = "EmployeesID";
            this.colEmployeesID.Name = "colEmployeesID";
            this.colEmployeesID.Width = 149;
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.NullValuePrompt = "Chưa có tên đăng nhập";
            this.repositoryItemTextEdit2.NullValuePromptShowForEmptyValue = true;
            // 
            // colLoginName
            // 
            this.colLoginName.Caption = "Tên đăng nhập";
            this.colLoginName.ColumnEdit = this.repositoryItemTextEdit2;
            this.colLoginName.FieldName = "LoginName";
            this.colLoginName.Name = "colLoginName";
            this.colLoginName.Visible = true;
            this.colLoginName.VisibleIndex = 0;
            this.colLoginName.Width = 122;
            // 
            // colPassword
            // 
            this.colPassword.Caption = "Mật khẩu";
            this.colPassword.ColumnEdit = this.repositoryItemTextEdit1;
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            this.colPassword.Visible = true;
            this.colPassword.VisibleIndex = 1;
            this.colPassword.Width = 165;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.PasswordChar = '*';
            // 
            // colName
            // 
            this.colName.Caption = "Họ và tên";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            this.colName.Width = 313;
            // 
            // colSell
            // 
            this.colSell.Caption = "Bán hàng";
            this.colSell.FieldName = "Sell";
            this.colSell.Name = "colSell";
            this.colSell.Visible = true;
            this.colSell.VisibleIndex = 3;
            this.colSell.Width = 80;
            // 
            // colReport
            // 
            this.colReport.Caption = "Báo cáo";
            this.colReport.FieldName = "Report";
            this.colReport.Name = "colReport";
            this.colReport.Visible = true;
            this.colReport.VisibleIndex = 7;
            this.colReport.Width = 69;
            // 
            // colEmpl
            // 
            this.colEmpl.Caption = "Nhân viên";
            this.colEmpl.FieldName = "Empl";
            this.colEmpl.Name = "colEmpl";
            this.colEmpl.Visible = true;
            this.colEmpl.VisibleIndex = 4;
            this.colEmpl.Width = 78;
            // 
            // colProduct
            // 
            this.colProduct.Caption = "Thực đơn";
            this.colProduct.FieldName = "Product";
            this.colProduct.Name = "colProduct";
            this.colProduct.Visible = true;
            this.colProduct.VisibleIndex = 5;
            this.colProduct.Width = 59;
            // 
            // colItem
            // 
            this.colItem.Caption = "Bàn";
            this.colItem.FieldName = "Item";
            this.colItem.Name = "colItem";
            this.colItem.Visible = true;
            this.colItem.VisibleIndex = 6;
            this.colItem.Width = 64;
            // 
            // Employee_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 398);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Employee_Form";
            this.Text = "DANH SÁCH NHÂN VIÊN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Employee_Form_FormClosing);
            this.Load += new System.EventHandler(this.Employee_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton Luu_simpleButton;
        private DevExpress.XtraEditors.SimpleButton Xoa_simpleButton;
        private DevExpress.XtraEditors.SimpleButton Close_simpleButton;
        private System.Windows.Forms.BindingSource employeeBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colEmployeesID;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colSell;
        private DevExpress.XtraGrid.Columns.GridColumn colReport;
        private DevExpress.XtraGrid.Columns.GridColumn colEmpl;
        private DevExpress.XtraGrid.Columns.GridColumn colProduct;
        private DevExpress.XtraGrid.Columns.GridColumn colItem;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colLoginName;

    }
}