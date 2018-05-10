namespace QLVT_NHOM
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.rbHeThong = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btDangNhap = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btTruyCap = new DevExpress.XtraBars.BarButtonItem();
            this.rbBaoCao = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbNhapLieu = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup16 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btNhanVien = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup15 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btVatTu = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup14 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btKho = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup13 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btDatHang = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup12 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btPhieuNhap = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageGroup11 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btPhieuXuat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl2 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btBCnhanVien = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(125, 17);
            this.toolStripStatusLabel1.Text = "Thông Tin Đăng Nhập";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = null;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 493);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(927, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // rbHeThong
            // 
            this.rbHeThong.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup9,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8});
            this.rbHeThong.Image = ((System.Drawing.Image)(resources.GetObject("rbHeThong.Image")));
            this.rbHeThong.Name = "rbHeThong";
            this.rbHeThong.Text = "Hệ Thống";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btDangNhap);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            // 
            // btDangNhap
            // 
            this.btDangNhap.Caption = "Đăng Nhập";
            this.btDangNhap.Id = 5;
            this.btDangNhap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btDangNhap.ImageOptions.LargeImage")));
            this.btDangNhap.Name = "btDangNhap";
            this.btDangNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDangNhap_ItemClick);
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btDangXuat);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // btDangXuat
            // 
            this.btDangXuat.Caption = "Đăng Xuất";
            this.btDangXuat.Id = 6;
            this.btDangXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btDangXuat.ImageOptions.LargeImage")));
            this.btDangXuat.Name = "btDangXuat";
            this.btDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btDangXuat_ItemClick);
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btTruyCap);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // btTruyCap
            // 
            this.btTruyCap.Caption = "Truy Cập";
            this.btTruyCap.Id = 7;
            this.btTruyCap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btTruyCap.ImageOptions.LargeImage")));
            this.btTruyCap.Name = "btTruyCap";
            this.btTruyCap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btTruyCap_ItemClick);
            // 
            // rbBaoCao
            // 
            this.rbBaoCao.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup10});
            this.rbBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("rbBaoCao.Image")));
            this.rbBaoCao.Name = "rbBaoCao";
            this.rbBaoCao.Text = "Báo Cáo";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.btBCnhanVien);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            this.ribbonPageGroup10.Text = "ribbonPageGroup2";
            // 
            // rbNhapLieu
            // 
            this.rbNhapLieu.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup16,
            this.ribbonPageGroup15,
            this.ribbonPageGroup14,
            this.ribbonPageGroup13,
            this.ribbonPageGroup12,
            this.ribbonPageGroup11});
            this.rbNhapLieu.Image = ((System.Drawing.Image)(resources.GetObject("rbNhapLieu.Image")));
            this.rbNhapLieu.Name = "rbNhapLieu";
            this.rbNhapLieu.Text = "Nhập Liệu";
            // 
            // ribbonPageGroup16
            // 
            this.ribbonPageGroup16.ItemLinks.Add(this.btNhanVien);
            this.ribbonPageGroup16.Name = "ribbonPageGroup16";
            // 
            // btNhanVien
            // 
            this.btNhanVien.Caption = "Nhân Viên";
            this.btNhanVien.Id = 1;
            this.btNhanVien.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btNhanVien.ImageOptions.LargeImage")));
            this.btNhanVien.Name = "btNhanVien";
            this.btNhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btNhanVien_ItemClick);
            // 
            // ribbonPageGroup15
            // 
            this.ribbonPageGroup15.ItemLinks.Add(this.btVatTu);
            this.ribbonPageGroup15.Name = "ribbonPageGroup15";
            // 
            // btVatTu
            // 
            this.btVatTu.Caption = "Vật Tư";
            this.btVatTu.Id = 2;
            this.btVatTu.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btVatTu.ImageOptions.LargeImage")));
            this.btVatTu.Name = "btVatTu";
            // 
            // ribbonPageGroup14
            // 
            this.ribbonPageGroup14.ItemLinks.Add(this.btKho);
            this.ribbonPageGroup14.Name = "ribbonPageGroup14";
            // 
            // btKho
            // 
            this.btKho.Caption = "Kho";
            this.btKho.Id = 3;
            this.btKho.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btKho.ImageOptions.LargeImage")));
            this.btKho.Name = "btKho";
            this.btKho.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btKho_ItemClick);
            // 
            // ribbonPageGroup13
            // 
            this.ribbonPageGroup13.ItemLinks.Add(this.btDatHang);
            this.ribbonPageGroup13.Name = "ribbonPageGroup13";
            // 
            // btDatHang
            // 
            this.btDatHang.Caption = "Đặt Hàng";
            this.btDatHang.Id = 9;
            this.btDatHang.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btDatHang.ImageOptions.LargeImage")));
            this.btDatHang.Name = "btDatHang";
            this.btDatHang.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // ribbonPageGroup12
            // 
            this.ribbonPageGroup12.ItemLinks.Add(this.btPhieuNhap);
            this.ribbonPageGroup12.Name = "ribbonPageGroup12";
            // 
            // btPhieuNhap
            // 
            this.btPhieuNhap.Caption = "Phiếu Nhập";
            this.btPhieuNhap.Id = 4;
            this.btPhieuNhap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btPhieuNhap.ImageOptions.LargeImage")));
            this.btPhieuNhap.Name = "btPhieuNhap";
            this.btPhieuNhap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btPhieuNhap_ItemClick);
            // 
            // ribbonPageGroup11
            // 
            this.ribbonPageGroup11.ItemLinks.Add(this.btPhieuXuat);
            this.ribbonPageGroup11.Name = "ribbonPageGroup11";
            // 
            // btPhieuXuat
            // 
            this.btPhieuXuat.Caption = "Phiếu Xuất";
            this.btPhieuXuat.Id = 8;
            this.btPhieuXuat.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btPhieuXuat.ImageOptions.LargeImage")));
            this.btPhieuXuat.Name = "btPhieuXuat";
            // 
            // ribbonControl2
            // 
            this.ribbonControl2.ExpandCollapseItem.Id = 0;
            this.ribbonControl2.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl2.ExpandCollapseItem,
            this.btNhanVien,
            this.btVatTu,
            this.btKho,
            this.btPhieuNhap,
            this.btDangNhap,
            this.btDangXuat,
            this.btTruyCap,
            this.btPhieuXuat,
            this.btDatHang,
            this.btBCnhanVien});
            this.ribbonControl2.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl2.MaxItemId = 11;
            this.ribbonControl2.Name = "ribbonControl2";
            this.ribbonControl2.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbNhapLieu,
            this.rbBaoCao,
            this.rbHeThong});
            this.ribbonControl2.Size = new System.Drawing.Size(927, 178);
            // 
            // btBCnhanVien
            // 
            this.btBCnhanVien.Caption = "Danh Sách Nhân Viên";
            this.btBCnhanVien.Id = 10;
            this.btBCnhanVien.Name = "btBCnhanVien";
            this.btBCnhanVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btBCnhanVien_ItemClick);
            // 
            // Form1
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 515);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl2);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl2;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbHeThong;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem btDangNhap;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btDangXuat;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btTruyCap;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbBaoCao;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbNhapLieu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup16;
        private DevExpress.XtraBars.BarButtonItem btNhanVien;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup15;
        private DevExpress.XtraBars.BarButtonItem btVatTu;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup14;
        private DevExpress.XtraBars.BarButtonItem btKho;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup13;
        private DevExpress.XtraBars.BarButtonItem btDatHang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup12;
        private DevExpress.XtraBars.BarButtonItem btPhieuNhap;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup11;
        private DevExpress.XtraBars.BarButtonItem btPhieuXuat;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl2;
        private DevExpress.XtraBars.BarButtonItem btBCnhanVien;
    }
}

