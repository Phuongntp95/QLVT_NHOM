using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLVT_NHOM
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            DN();
        }
        public void DN()
        {
            Form frm = this.CheckExists(typeof(DangNhap));
            if (frm != null) frm.Activate();
            else
            {
                DangNhap f = new DangNhap();
                f.MdiParent = this;
                f.Show();
            }
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }
        public void checkLogin(string username) 
        {
            if (username.CompareTo("") == 0)
            {
                rbBaoCao.Visible = false;
                rbNhapLieu.Visible = false;
                btDangNhap.Enabled = true;
                btDangXuat.Enabled = false;
            }
            else
            {
                rbBaoCao.Visible = true;
                rbNhapLieu.Visible = true;
                btDangNhap.Enabled = false;
                btDangXuat.Enabled = true;

            }
        }

        private void btNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btDangNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(DangNhap));
            if (frm != null) frm.Activate();
            else
            {
                DangNhap dn = new DangNhap();
                dn.MdiParent = this;
                dn.Show();
            }
        }

        private void btDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            toolStripStatusLabel1.Text = " ";
            if (Program.ThongTinKetNoi != 1)
            {
                MessageBox.Show("Chưa Đăng Nhập", "Thông Báo", MessageBoxButtons.OK);
            }
            else
            {
                rbNhapLieu.Visible = false;
                rbBaoCao.Visible = false;
                Form frm = this.CheckExists(typeof(DangNhap));
                if (frm != null) frm.Activate();
                else
                {
                    DangNhap nv = new DangNhap();
                    nv.MdiParent = this;
                    nv.Show();
                }
            }
        }

        private void btTruyCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            toolStripStatusLabel1.Text = Program.ThongTinDangNhap;
            if (Program.ThongTinKetNoi == 1 && Program.mGroup == "CONGTY")
            {
                rbHeThong.Visible = true;
                rbNhapLieu.Visible = true;
                rbBaoCao.Visible = true;

            }
            else if (Program.ThongTinKetNoi == 1 && Program.mGroup == "CHINHANH")
            {
                rbHeThong.Visible = true;
                rbNhapLieu.Visible = true;
                rbBaoCao.Visible = true;




            }
            else if (Program.ThongTinKetNoi == 1 && Program.mGroup == "USER")
            {
                rbHeThong.Visible = true;
                rbNhapLieu.Visible = true;
                rbBaoCao.Visible = false;
            }
            else
            {
                MessageBox.Show("Chưa đăng nhập", "Lỗi", MessageBoxButtons.OK);
            }
        }
        public void getLableThongTinDangNhap(string s)
        {
            toolStripStatusLabel1.Text = s;
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void btKho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Kho));
            if (frm != null) frm.Activate();
            else
            {
                Kho k = new Kho();
                k.MdiParent = this;
                k.Show();
            }
        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) // nút đặt hàng
        {
            Form frm = this.CheckExists(typeof(DatHang));
            if (frm != null) frm.Activate();
            else
            {
                DatHang dh = new DatHang();
                dh.MdiParent = this;
                dh.Show();
            }
        }

        private void btPhieuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(PhieuNhap));
            if (frm != null) frm.Activate();
            else
            {
                PhieuNhap dh = new PhieuNhap();
                dh.MdiParent = this;
                dh.Show();
            }
        }

        private void btBCnhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(NhanVieBCn));
            if (frm != null) frm.Activate();
            else
            {
                NhanVieBCn dh = new NhanVieBCn();
              dh.MdiParent = this;
                dh.Show();
            }
        }
    }
}
