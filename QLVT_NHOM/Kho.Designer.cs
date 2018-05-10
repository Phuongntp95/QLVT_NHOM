namespace QLVT_NHOM
{
    partial class Kho
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
            System.Windows.Forms.Label mAKHOLabel;
            System.Windows.Forms.Label tENKHOLabel;
            System.Windows.Forms.Label dIACHILabel;
            System.Windows.Forms.Label mACNLabel;
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btThem = new DevExpress.XtraBars.BarButtonItem();
            this.btSua = new DevExpress.XtraBars.BarButtonItem();
            this.btXoa = new DevExpress.XtraBars.BarButtonItem();
            this.btGhi = new DevExpress.XtraBars.BarButtonItem();
            this.btUndo = new DevExpress.XtraBars.BarButtonItem();
            this.btReload = new DevExpress.XtraBars.BarButtonItem();
            this.btThoat = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dS = new QLVT_NHOM.DS();
            this.kHOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kHOTableAdapter = new QLVT_NHOM.DSTableAdapters.KHOTableAdapter();
            this.tableAdapterManager = new QLVT_NHOM.DSTableAdapters.TableAdapterManager();
            this.kHOGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENKHO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIACHI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMACN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mAKHOTextBox = new System.Windows.Forms.TextBox();
            this.tENKHOTextBox = new System.Windows.Forms.TextBox();
            this.dIACHITextBox = new System.Windows.Forms.TextBox();
            this.cmbChiNhanh = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.mACNTextBox = new System.Windows.Forms.TextBox();
            mAKHOLabel = new System.Windows.Forms.Label();
            tENKHOLabel = new System.Windows.Forms.Label();
            dIACHILabel = new System.Windows.Forms.Label();
            mACNLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHOGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mAKHOLabel
            // 
            mAKHOLabel.AutoSize = true;
            mAKHOLabel.Location = new System.Drawing.Point(70, 54);
            mAKHOLabel.Name = "mAKHOLabel";
            mAKHOLabel.Size = new System.Drawing.Size(68, 17);
            mAKHOLabel.TabIndex = 0;
            mAKHOLabel.Text = "MAKHO:";
            // 
            // tENKHOLabel
            // 
            tENKHOLabel.AutoSize = true;
            tENKHOLabel.Location = new System.Drawing.Point(70, 85);
            tENKHOLabel.Name = "tENKHOLabel";
            tENKHOLabel.Size = new System.Drawing.Size(73, 17);
            tENKHOLabel.TabIndex = 2;
            tENKHOLabel.Text = "TENKHO:";
            // 
            // dIACHILabel
            // 
            dIACHILabel.AutoSize = true;
            dIACHILabel.Location = new System.Drawing.Point(70, 116);
            dIACHILabel.Name = "dIACHILabel";
            dIACHILabel.Size = new System.Drawing.Size(64, 17);
            dIACHILabel.TabIndex = 4;
            dIACHILabel.Text = "DIACHI:";
            // 
            // mACNLabel
            // 
            mACNLabel.AutoSize = true;
            mACNLabel.Location = new System.Drawing.Point(70, 147);
            mACNLabel.Name = "mACNLabel";
            mACNLabel.Size = new System.Drawing.Size(56, 17);
            mACNLabel.TabIndex = 6;
            mACNLabel.Text = "MACN:";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btThem,
            this.btXoa,
            this.btSua,
            this.btGhi,
            this.btUndo,
            this.btReload,
            this.btThoat});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btThem),
            new DevExpress.XtraBars.LinkPersistInfo(this.btSua),
            new DevExpress.XtraBars.LinkPersistInfo(this.btXoa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btGhi),
            new DevExpress.XtraBars.LinkPersistInfo(this.btUndo),
            new DevExpress.XtraBars.LinkPersistInfo(this.btReload),
            new DevExpress.XtraBars.LinkPersistInfo(this.btThoat)});
            this.bar1.Text = "Tools";
            // 
            // btThem
            // 
            this.btThem.Caption = "Thêm";
            this.btThem.Id = 0;
            this.btThem.Name = "btThem";
            this.btThem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btThem_ItemClick);
            // 
            // btSua
            // 
            this.btSua.Caption = "Sửa";
            this.btSua.Id = 2;
            this.btSua.Name = "btSua";
            this.btSua.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btSua_ItemClick);
            // 
            // btXoa
            // 
            this.btXoa.Caption = "Xóa";
            this.btXoa.Id = 1;
            this.btXoa.Name = "btXoa";
            this.btXoa.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btXoa_ItemClick);
            // 
            // btGhi
            // 
            this.btGhi.Caption = "Ghi";
            this.btGhi.Id = 3;
            this.btGhi.Name = "btGhi";
            this.btGhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btGhi_ItemClick);
            // 
            // btUndo
            // 
            this.btUndo.Caption = "Undo";
            this.btUndo.Id = 4;
            this.btUndo.Name = "btUndo";
            this.btUndo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btUndo_ItemClick);
            // 
            // btReload
            // 
            this.btReload.Caption = "Reload";
            this.btReload.Id = 5;
            this.btReload.Name = "btReload";
            this.btReload.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btReload_ItemClick);
            // 
            // btThoat
            // 
            this.btThoat.Caption = "Thoát";
            this.btThoat.Id = 6;
            this.btThoat.Name = "btThoat";
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.bar2.Visible = false;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            this.bar3.Visible = false;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(880, 49);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 360);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(880, 23);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 49);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 311);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(880, 49);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 311);
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.EnforceConstraints = false;
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // kHOBindingSource
            // 
            this.kHOBindingSource.DataMember = "KHO";
            this.kHOBindingSource.DataSource = this.dS;
            // 
            // kHOTableAdapter
            // 
            this.kHOTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CHINHANHTableAdapter = null;
            this.tableAdapterManager.CTDDHTableAdapter = null;
            this.tableAdapterManager.CTPNTableAdapter = null;
            this.tableAdapterManager.CTPXTableAdapter = null;
            this.tableAdapterManager.DATHANGTableAdapter = null;
            this.tableAdapterManager.KHOTableAdapter = this.kHOTableAdapter;
            this.tableAdapterManager.NHANVIENTableAdapter = null;
            this.tableAdapterManager.PHIEUNHAPTableAdapter = null;
            this.tableAdapterManager.PHIEUXUATTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = QLVT_NHOM.DSTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            this.tableAdapterManager.VATTUTableAdapter = null;
            // 
            // kHOGridControl
            // 
            this.kHOGridControl.DataSource = this.kHOBindingSource;
            this.kHOGridControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.kHOGridControl.Location = new System.Drawing.Point(0, 49);
            this.kHOGridControl.MainView = this.gridView1;
            this.kHOGridControl.MenuManager = this.barManager1;
            this.kHOGridControl.Name = "kHOGridControl";
            this.kHOGridControl.Size = new System.Drawing.Size(432, 311);
            this.kHOGridControl.TabIndex = 5;
            this.kHOGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAKHO,
            this.colTENKHO,
            this.colDIACHI,
            this.colMACN});
            this.gridView1.GridControl = this.kHOGridControl;
            this.gridView1.Name = "gridView1";
            // 
            // colMAKHO
            // 
            this.colMAKHO.FieldName = "MAKHO";
            this.colMAKHO.Name = "colMAKHO";
            this.colMAKHO.Visible = true;
            this.colMAKHO.VisibleIndex = 0;
            // 
            // colTENKHO
            // 
            this.colTENKHO.FieldName = "TENKHO";
            this.colTENKHO.Name = "colTENKHO";
            this.colTENKHO.Visible = true;
            this.colTENKHO.VisibleIndex = 1;
            // 
            // colDIACHI
            // 
            this.colDIACHI.FieldName = "DIACHI";
            this.colDIACHI.Name = "colDIACHI";
            this.colDIACHI.Visible = true;
            this.colDIACHI.VisibleIndex = 2;
            // 
            // colMACN
            // 
            this.colMACN.FieldName = "MACN";
            this.colMACN.Name = "colMACN";
            this.colMACN.Visible = true;
            this.colMACN.VisibleIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(mAKHOLabel);
            this.groupBox1.Controls.Add(this.mAKHOTextBox);
            this.groupBox1.Controls.Add(tENKHOLabel);
            this.groupBox1.Controls.Add(this.tENKHOTextBox);
            this.groupBox1.Controls.Add(dIACHILabel);
            this.groupBox1.Controls.Add(this.dIACHITextBox);
            this.groupBox1.Controls.Add(mACNLabel);
            this.groupBox1.Controls.Add(this.mACNTextBox);
            this.groupBox1.Location = new System.Drawing.Point(438, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 274);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi Tiết Kho";
            // 
            // mAKHOTextBox
            // 
            this.mAKHOTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kHOBindingSource, "MAKHO", true));
            this.mAKHOTextBox.Location = new System.Drawing.Point(149, 51);
            this.mAKHOTextBox.Name = "mAKHOTextBox";
            this.mAKHOTextBox.Size = new System.Drawing.Size(186, 25);
            this.mAKHOTextBox.TabIndex = 1;
            // 
            // tENKHOTextBox
            // 
            this.tENKHOTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kHOBindingSource, "TENKHO", true));
            this.tENKHOTextBox.Location = new System.Drawing.Point(149, 82);
            this.tENKHOTextBox.Name = "tENKHOTextBox";
            this.tENKHOTextBox.Size = new System.Drawing.Size(186, 25);
            this.tENKHOTextBox.TabIndex = 3;
            // 
            // dIACHITextBox
            // 
            this.dIACHITextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kHOBindingSource, "DIACHI", true));
            this.dIACHITextBox.Location = new System.Drawing.Point(149, 113);
            this.dIACHITextBox.Name = "dIACHITextBox";
            this.dIACHITextBox.Size = new System.Drawing.Size(186, 25);
            this.dIACHITextBox.TabIndex = 5;
            // 
            // cmbChiNhanh
            // 
            this.cmbChiNhanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChiNhanh.FormattingEnabled = true;
            this.cmbChiNhanh.Location = new System.Drawing.Point(588, 55);
            this.cmbChiNhanh.Name = "cmbChiNhanh";
            this.cmbChiNhanh.Size = new System.Drawing.Size(185, 25);
            this.cmbChiNhanh.TabIndex = 7;
            this.cmbChiNhanh.SelectedIndexChanged += new System.EventHandler(this.cmbChiNhanh_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(490, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Chi Nhánh";
            // 
            // mACNTextBox
            // 
            this.mACNTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.kHOBindingSource, "MACN", true));
            this.mACNTextBox.Location = new System.Drawing.Point(149, 144);
            this.mACNTextBox.Name = "mACNTextBox";
            this.mACNTextBox.Size = new System.Drawing.Size(186, 25);
            this.mACNTextBox.TabIndex = 7;
            // 
            // Kho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 383);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbChiNhanh);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.kHOGridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Kho";
            this.Text = "Kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Kho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kHOGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btThem;
        private DevExpress.XtraBars.BarButtonItem btSua;
        private DevExpress.XtraBars.BarButtonItem btXoa;
        private DevExpress.XtraBars.BarButtonItem btGhi;
        private DevExpress.XtraBars.BarButtonItem btUndo;
        private DevExpress.XtraBars.BarButtonItem btReload;
        private DevExpress.XtraBars.BarButtonItem btThoat;
        private System.Windows.Forms.BindingSource kHOBindingSource;
        private DS dS;
        private DSTableAdapters.KHOTableAdapter kHOTableAdapter;
        private DSTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChiNhanh;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl kHOGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colMAKHO;
        private DevExpress.XtraGrid.Columns.GridColumn colTENKHO;
        private DevExpress.XtraGrid.Columns.GridColumn colDIACHI;
        private DevExpress.XtraGrid.Columns.GridColumn colMACN;
        private System.Windows.Forms.TextBox mAKHOTextBox;
        private System.Windows.Forms.TextBox tENKHOTextBox;
        private System.Windows.Forms.TextBox dIACHITextBox;
        private System.Windows.Forms.TextBox mACNTextBox;
    }
}