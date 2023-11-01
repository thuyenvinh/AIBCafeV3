namespace AIBCafe3
{
    partial class Assembly_form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Assembly_form));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.quantitativeGridControl = new DevExpress.XtraGrid.GridControl();
            this.quantitativeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditChild = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.unitBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.colUnitID_Parent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEditParent = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.unitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.assemblyGridControl = new DevExpress.XtraGrid.GridControl();
            this.assemblyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProductID_Parent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Pro_Parent = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_Pro = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.productBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.colQuantity1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.simpleButtonChapNhan = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonDong = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantitativeGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantitativeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditChild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditParent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assemblyGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.assemblyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Pro_Parent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Pro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(795, 364);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.quantitativeGridControl);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(790, 338);
            this.xtraTabPage1.Text = "Công thức quy đổi đơn vị tính";
            // 
            // quantitativeGridControl
            // 
            this.quantitativeGridControl.DataSource = this.quantitativeBindingSource;
            this.quantitativeGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantitativeGridControl.Location = new System.Drawing.Point(0, 0);
            this.quantitativeGridControl.MainView = this.gridView1;
            this.quantitativeGridControl.Name = "quantitativeGridControl";
            this.quantitativeGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEditParent,
            this.repositoryItemLookUpEditChild});
            this.quantitativeGridControl.Size = new System.Drawing.Size(790, 338);
            this.quantitativeGridControl.TabIndex = 0;
            this.quantitativeGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // quantitativeBindingSource
            // 
            this.quantitativeBindingSource.DataSource = typeof(AIBCafe3.Quantitative);
            this.quantitativeBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.quantitativeBindingSource_AddingNew);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUnitID,
            this.colUnitID_Parent,
            this.colQuantity,
            this.colId});
            this.gridView1.GridControl = this.quantitativeGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colUnitID
            // 
            this.colUnitID.Caption = "Tên đơn vị 2";
            this.colUnitID.ColumnEdit = this.repositoryItemLookUpEditChild;
            this.colUnitID.FieldName = "UnitID";
            this.colUnitID.Name = "colUnitID";
            this.colUnitID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colUnitID.Visible = true;
            this.colUnitID.VisibleIndex = 2;
            this.colUnitID.Width = 252;
            // 
            // repositoryItemLookUpEditChild
            // 
            this.repositoryItemLookUpEditChild.AutoHeight = false;
            this.repositoryItemLookUpEditChild.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditChild.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitName", "Tên đơn vị", 59, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEditChild.DataSource = this.unitBindingSource1;
            this.repositoryItemLookUpEditChild.DisplayMember = "UnitName";
            this.repositoryItemLookUpEditChild.Name = "repositoryItemLookUpEditChild";
            this.repositoryItemLookUpEditChild.ValueMember = "Id";
            // 
            // unitBindingSource1
            // 
            this.unitBindingSource1.DataSource = typeof(AIBCafe3.Unit);
            // 
            // colUnitID_Parent
            // 
            this.colUnitID_Parent.Caption = "Tên đơn vị 1";
            this.colUnitID_Parent.ColumnEdit = this.repositoryItemLookUpEditParent;
            this.colUnitID_Parent.FieldName = "UnitID_Parent";
            this.colUnitID_Parent.Name = "colUnitID_Parent";
            this.colUnitID_Parent.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colUnitID_Parent.Visible = true;
            this.colUnitID_Parent.VisibleIndex = 0;
            this.colUnitID_Parent.Width = 243;
            // 
            // repositoryItemLookUpEditParent
            // 
            this.repositoryItemLookUpEditParent.AutoHeight = false;
            this.repositoryItemLookUpEditParent.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEditParent.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UnitName", "Tên đơn vị", 59, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEditParent.DataSource = this.unitBindingSource;
            this.repositoryItemLookUpEditParent.DisplayMember = "UnitName";
            this.repositoryItemLookUpEditParent.Name = "repositoryItemLookUpEditParent";
            this.repositoryItemLookUpEditParent.ValueMember = "Id";
            // 
            // unitBindingSource
            // 
            this.unitBindingSource.DataSource = typeof(AIBCafe3.Unit);
            // 
            // colQuantity
            // 
            this.colQuantity.Caption = "= Số lượng";
            this.colQuantity.FieldName = "Quantity";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colQuantity.Visible = true;
            this.colQuantity.VisibleIndex = 1;
            this.colQuantity.Width = 79;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.AutoScroll = true;
            this.xtraTabPage2.Controls.Add(this.assemblyGridControl);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(790, 338);
            this.xtraTabPage2.Text = "Công thức chế biến";
            // 
            // assemblyGridControl
            // 
            this.assemblyGridControl.DataSource = this.assemblyBindingSource;
            this.assemblyGridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assemblyGridControl.Location = new System.Drawing.Point(0, 0);
            this.assemblyGridControl.MainView = this.gridView2;
            this.assemblyGridControl.Name = "assemblyGridControl";
            this.assemblyGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_Pro_Parent,
            this.repositoryItemLookUpEdit_Pro});
            this.assemblyGridControl.Size = new System.Drawing.Size(790, 338);
            this.assemblyGridControl.TabIndex = 0;
            this.assemblyGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // assemblyBindingSource
            // 
            this.assemblyBindingSource.DataSource = typeof(AIBCafe3.Assembly);
            this.assemblyBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.assemblyBindingSource_AddingNew);
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId1,
            this.colProductID_Parent,
            this.colProductID,
            this.colQuantity1,
            this.colDescription,
            this.gridColumn1,
            this.gridColumn2});
            this.gridView2.GridControl = this.assemblyGridControl;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsView.AllowCellMerge = true;
            this.gridView2.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridView2.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colId1
            // 
            this.colId1.FieldName = "Id";
            this.colId1.Name = "colId1";
            // 
            // colProductID_Parent
            // 
            this.colProductID_Parent.Caption = "Tên thực đơn";
            this.colProductID_Parent.ColumnEdit = this.repositoryItemLookUpEdit_Pro_Parent;
            this.colProductID_Parent.FieldName = "ProductID_Parent";
            this.colProductID_Parent.Name = "colProductID_Parent";
            this.colProductID_Parent.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.True;
            this.colProductID_Parent.Visible = true;
            this.colProductID_Parent.VisibleIndex = 0;
            this.colProductID_Parent.Width = 151;
            // 
            // repositoryItemLookUpEdit_Pro_Parent
            // 
            this.repositoryItemLookUpEdit_Pro_Parent.AutoHeight = false;
            this.repositoryItemLookUpEdit_Pro_Parent.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Pro_Parent.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Product Name", 77, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unit", "Unit", 29, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price", 33, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit_Pro_Parent.DataSource = this.productBindingSource;
            this.repositoryItemLookUpEdit_Pro_Parent.DisplayMember = "ProductName";
            this.repositoryItemLookUpEdit_Pro_Parent.Name = "repositoryItemLookUpEdit_Pro_Parent";
            this.repositoryItemLookUpEdit_Pro_Parent.ValueMember = "ProductID";
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(AIBCafe3.Product);
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Tên thực đơn";
            this.colProductID.ColumnEdit = this.repositoryItemLookUpEdit_Pro;
            this.colProductID.FieldName = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colProductID.Visible = true;
            this.colProductID.VisibleIndex = 3;
            this.colProductID.Width = 131;
            // 
            // repositoryItemLookUpEdit_Pro
            // 
            this.repositoryItemLookUpEdit_Pro.AutoHeight = false;
            this.repositoryItemLookUpEdit_Pro.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_Pro.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ProductName", "Product Name", 77, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Unit", "Unit", 29, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Price", "Price", 33, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near)});
            this.repositoryItemLookUpEdit_Pro.DataSource = this.productBindingSource1;
            this.repositoryItemLookUpEdit_Pro.DisplayMember = "ProductName";
            this.repositoryItemLookUpEdit_Pro.Name = "repositoryItemLookUpEdit_Pro";
            this.repositoryItemLookUpEdit_Pro.ValueMember = "ProductID";
            // 
            // productBindingSource1
            // 
            this.productBindingSource1.DataSource = typeof(AIBCafe3.Product);
            // 
            // colQuantity1
            // 
            this.colQuantity1.Caption = "Số lượng";
            this.colQuantity1.FieldName = "Quantity";
            this.colQuantity1.Name = "colQuantity1";
            this.colQuantity1.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.colQuantity1.Visible = true;
            this.colQuantity1.VisibleIndex = 2;
            this.colQuantity1.Width = 105;
            // 
            // colDescription
            // 
            this.colDescription.Caption = "Ghi chú";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 5;
            this.colDescription.Width = 166;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "ĐV Tính.";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 51;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "ĐV Tính";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.False;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 51;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.simpleButtonChapNhan);
            this.groupControl1.Controls.Add(this.simpleButton1);
            this.groupControl1.Controls.Add(this.simpleButtonDong);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupControl1.Location = new System.Drawing.Point(0, 366);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(795, 40);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "groupControl1";
            // 
            // simpleButtonChapNhan
            // 
            this.simpleButtonChapNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonChapNhan.Location = new System.Drawing.Point(544, 10);
            this.simpleButtonChapNhan.Name = "simpleButtonChapNhan";
            this.simpleButtonChapNhan.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonChapNhan.TabIndex = 0;
            this.simpleButtonChapNhan.Text = "Lưu";
            this.simpleButtonChapNhan.Click += new System.EventHandler(this.simpleButtonChapNhan_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(625, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Xóa";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButtonDong
            // 
            this.simpleButtonDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButtonDong.Location = new System.Drawing.Point(706, 10);
            this.simpleButtonDong.Name = "simpleButtonDong";
            this.simpleButtonDong.Size = new System.Drawing.Size(75, 23);
            this.simpleButtonDong.TabIndex = 0;
            this.simpleButtonDong.Text = "Đóng";
            this.simpleButtonDong.Click += new System.EventHandler(this.simpleButtonDong_Click);
            // 
            // Assembly_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 406);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.xtraTabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Assembly_form";
            this.Text = "Thiết lập công thức quy đổi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Assembly_form_FormClosing);
            this.Load += new System.EventHandler(this.Assembly_form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quantitativeGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantitativeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditChild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEditParent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.unitBindingSource)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.assemblyGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.assemblyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Pro_Parent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_Pro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl quantitativeGridControl;
        private System.Windows.Forms.BindingSource quantitativeBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl assemblyGridControl;
        private System.Windows.Forms.BindingSource assemblyBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colId1;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID_Parent;
        private DevExpress.XtraGrid.Columns.GridColumn colProductID;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity1;
        private DevExpress.XtraGrid.Columns.GridColumn colDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitID_Parent;
        private DevExpress.XtraGrid.Columns.GridColumn colQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditChild;
        private System.Windows.Forms.BindingSource unitBindingSource1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEditParent;
        private System.Windows.Forms.BindingSource unitBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Pro_Parent;
        private System.Windows.Forms.BindingSource productBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_Pro;
        private System.Windows.Forms.BindingSource productBindingSource1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonChapNhan;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDong;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}