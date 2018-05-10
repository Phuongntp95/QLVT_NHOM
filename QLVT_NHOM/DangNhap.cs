using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT_NHOM
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLVTDataSet.DS_PHANMANH' table. You can move, or remove it, as needed.
            this.dS_PHANMANHTableAdapter.Fill(this.qLVTDataSet.DS_PHANMANH);
            cmbChiNhanh.SelectedIndex = 1;
            cmbChiNhanh.SelectedIndex = 0;
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            if (txtTen.Text.Trim() == "" || txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản và mật khẩu không được bỏ trống!");
                txtTen.Focus();
                return;
            }
            // SqlDataReader myReader;
            Program.mlogin = txtTen.Text.Trim();
            Program.password = txtPass.Text.Trim();
            if (Program.KetNoi() == 0) return;
            Program.servername = cmbChiNhanh.SelectedValue.ToString().Trim();
            Program.ChiNhanh = cmbChiNhanh.SelectedIndex;
            Program.ChiNhanh = cmbChiNhanh.SelectedIndex;
            Program.bds_dspm = dSPHANMANHBindingSource;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            String strLenh = "exec sp_DANGNHAP '" + Program.mlogin + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();


            Program.username = Program.myReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n ", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.ThongTinDangNhap = "User:   " + Program.myReader.GetString(0) + "     Họ và tên:" + Program.myReader.GetString(1) + "           Nhóm" + Program.myReader.GetString(2);
            Program.frmchinh.getLableThongTinDangNhap(Program.ThongTinDangNhap);
            MessageBox.Show("Đăng nhập thành công ! ", "", MessageBoxButtons.OK);


            Program.myReader.Close();
            Program.conn.Close();
            // this.Dispose();
            //  trangChu.checkLogin(Program.username);
            // btDangNhap.Enabled = false;

        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue != null)
                Program.servername = cmbChiNhanh.SelectedValue.ToString();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
