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
    public partial class NhanVieBCn : Form
    {
        public NhanVieBCn()
        {
            InitializeComponent();
        }

        private void btReview_Click(object sender, EventArgs e)
        {
            BCDS_NhanVien obj;
            obj = new BCDS_NhanVien();

            string strLenh;
            strLenh = "EXEC SP_BCNhanVien " + cmbChiNhanh.ValueMember;
            DataTable MyTable;
            MyTable = Program.ExecSqlDataTable(strLenh, Program.connstr);

            obj.SetDataSource(MyTable);
            obj.SetParameterValue("MACN", cmbChiNhanh.SelectedIndex);
           // crptView.ReportSource = obj;

        }

        private void NhanVieBCn_Load(object sender, EventArgs e)
        {
            
            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.ChiNhanh;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                
            }
            else
            {
                cmbChiNhanh.Enabled = false;                
            }

        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            }
            catch
            {

            }

            try
            {
                Program.servername = cmbChiNhanh.SelectedValue.ToString();
            }
            catch
            {

            }

            if (cmbChiNhanh.SelectedIndex != Program.ChiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            else
            {
                
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
