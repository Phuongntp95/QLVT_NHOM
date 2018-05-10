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
    public partial class PhieuNhap : Form
    {
        public static int status = 0;
        public int vitri = 0;
        public int vt = 0;
        public int tt = 0;
        public static string MaPN="";
        public static string ngay = "";
        public static string masoDDH = "";
        public static string makho = "";
        public static string manv = "";
        public static string mavt = "";
        public static int soluong;
        public static int dongia ;
        public PhieuNhap()
        {
            InitializeComponent();
        }

        private void dATHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void PhieuNhap_Load(object sender, EventArgs e)
        {
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
            this.dATHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.DATHANG' table. You can move, or remove it, as needed.
            this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
            this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Fill(this.dS.CTPN);
            this.pHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.PHIEUNHAP' table. You can move, or remove it, as needed.
            this.pHIEUNHAPTableAdapter.Fill(this.dS.PHIEUNHAP);    
            
            
            manv = Program.username;
            mANVTextBox.Text = manv;
            mANVTextBox.Enabled = false;
            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.ChiNhanh;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btGhi.Enabled = btUndo.Enabled = btSua.Enabled = btXoa.Enabled = btThem.Enabled = btReload.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                cTPNGridControl.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                groupBox1.Enabled = false;
                groupBox3.Enabled = false;
                btGhi.Enabled = btUndo.Enabled = false;
                btUndo.Enabled = btSua.Enabled = btXoa.Enabled = btThem.Enabled = btReload.Enabled = true;
                groupBox2.Enabled = false;
                cTPNGridControl.Enabled = false;
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
                this.pHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.pHIEUNHAPTableAdapter.Fill(this.dS.PHIEUNHAP);
                this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                this.cTPNTableAdapter.Fill(this.dS.CTPN);
            }
        }

        private void btThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            mAPNTextBox.Enabled = true;
            mANVTextBox.Text = manv;
            mANVTextBox.Enabled = false;
            vitri = pHIEUNHAPBindingSource.Position;
            pHIEUNHAPGridControl.Enabled = false;
            pHIEUNHAPBindingSource.AddNew();
            cTPNGridControl.Enabled = false;
            groupBox1.Enabled = true;
            btThem.Enabled =  btSua.Enabled = btXoa.Enabled = false;
            btGhi.Enabled = btReload.Enabled = btThoat.Enabled = btUndo.Enabled = true;
            cTPNGridControl.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            //mAKHOTextBox.Enabled = false;
        }

        private void btSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 2;
            groupBox3.Enabled = true;
            mAPNTextBox1.Text = mAPNTextBox.Text;
            mAPNTextBox.Enabled = mAPNTextBox1.Enabled = false;
            pHIEUNHAPGridControl.Enabled = false;            
            groupBox1.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btUndo.Enabled = false;
            btGhi.Enabled = btThoat.Enabled = btReload.Enabled = true;
            mANVTextBox.Enabled = false;
            cTPNGridControl.Enabled = true;
            groupBox2.Enabled = false;
           
            //MaPN = mAPNTextBox.Text.Trim();
            //masoDDH = masoDDHComboBox.SelectedValue.ToString().Trim();
            //manv = mANVTextBox.Text.Trim();
            //ngay = nGAYDateEdit.Text.Trim();
            //makho = mAKHOComboBox.SelectedValue.ToString().Trim();
        }

        private void btXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 3;
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            String strLenh = "check_PhieuNhapPhatSinh";
            Program.sqlcmd = Program.conn.CreateCommand();
            Program.sqlcmd.CommandType = CommandType.StoredProcedure;
            Program.sqlcmd.CommandText = strLenh;
            Program.sqlcmd.Parameters.Add("@MAPN", SqlDbType.Text).Value = mAPNTextBox.Text;
            Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.sqlcmd.ExecuteNonQuery();
            Program.conn.Close();
            String Ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
            if (Ret.Equals("1"))
            {
                MessageBox.Show("Phiếu Nhập được dùng để tạo phiếu, không thể xóa!", "", MessageBoxButtons.OK);
               // mAKHOTextBox.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa kho này ?? ", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                   
                    MaPN = ((DataRowView)pHIEUNHAPBindingSource[pHIEUNHAPBindingSource.Position])["MAPN"].ToString(); // giữ lại để khi xóa bị lỗi thì ta sẽ quay về lại
                    pHIEUNHAPBindingSource.RemoveCurrent();
                    this.pHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.pHIEUNHAPTableAdapter.Update(this.dS.PHIEUNHAP);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa kho. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.pHIEUNHAPTableAdapter.Fill(this.dS.PHIEUNHAP);
                    pHIEUNHAPBindingSource.Position = pHIEUNHAPBindingSource.Find("MAPN", MaPN);
                    return;
                }
            }
           pHIEUNHAPGridControl.Enabled = true;
            groupBox1.Enabled = true;
            btThem.Enabled =  btSua.Enabled = btXoa.Enabled = btThoat.Enabled = btReload.Enabled = true;
            btGhi.Enabled = false;
           // btUndo.Enabled = true;
            cTPNGridControl.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void btGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (status == 1)   // kiểm tra mã nhân viên vừa thêm có bị trùng ở cả 2 chi nhánh hay không
            {
                mANVTextBox.Text = manv;
                
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String strLenh = "check_PhieuNhap";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh;
                Program.sqlcmd.Parameters.Add("@MaPN", SqlDbType.Text).Value = mAPNTextBox.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                Program.conn.Close();
                String Ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                if (Ret.Equals("1"))
                {
                    MessageBox.Show("Mã số Phiếu Nhập bị trùng ở site chủ. Vui lòng nhập mã khác!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (masoDDHComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                   // mAKHOTextBox.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                if (nGAYDateEdit.Text.Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    nGAYDateEdit.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                if(mAKHOComboBox.SelectedValue== null)
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    mAKHOComboBox.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
              //  string makhothem = "";
                // thêm mã kho từ đặt hàng sang phiếu nhập
                //if (Program.conn.State == ConnectionState.Closed)
                //    Program.conn.Open();
                //String strLenh1 = "sp_MakhoPN1";
                //Program.sqlcmd = Program.conn.CreateCommand();
                //Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                //Program.sqlcmd.CommandText = strLenh1;
                //Program.sqlcmd.Parameters.Add("@masoddh", SqlDbType.NChar).Value = masoDDHComboBox.SelectedValue.ToString().Trim();
                //Program.sqlcmd.Parameters.Add("@makho", SqlDbType.NChar).Value = makhothem;
               // Program.sqlcmd.Parameters.Add("@makho", SqlDbType.NChar).Direction = ParameterDirection.ReturnValue;
               // Program.sqlcmd.ExecuteNonQuery();
               // Program.conn.Close();
               
               // String Ret1 = Program.sqlcmd.Parameters["@makho"].Value.ToString();
                //mAKHOTextBox.Text = makhothem.Trim();
               // mAKHOTextBox.Enabled = false;
                try
                {
                    pHIEUNHAPBindingSource.EndEdit();
                    pHIEUNHAPBindingSource.ResetCurrentItem();
                    this.pHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.pHIEUNHAPTableAdapter.Update(this.dS.PHIEUNHAP);                    
                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                }
                Program.conn.Close();
            }
            if (status == 2)
            {
                try
                {
                    pHIEUNHAPBindingSource.EndEdit();
                    pHIEUNHAPBindingSource.ResetCurrentItem();
                    this.pHIEUNHAPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.pHIEUNHAPTableAdapter.Update(this.dS.PHIEUNHAP);

                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            groupBox1.Enabled = false;
            this.tableAdapterManager.UpdateAll(this.dS);
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = true;
            btGhi.Enabled = false;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            btReload.Enabled = true;            
            pHIEUNHAPGridControl.Enabled =true;           
            cTPNGridControl.Enabled =false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void btReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PhieuNhap_Load(sender, e);
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btThoat.Enabled = btUndo.Enabled = btReload.Enabled = true;
            btGhi.Enabled = false;
            pHIEUNHAPGridControl.Enabled = true;
            cTPNGridControl.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void btThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            cTPNGridControl.Enabled = true;
        }

        private void btThemCT_Click(object sender, EventArgs e)
        {
            mAPNTextBox1.Text = mAPNTextBox.Text;
            mAPNTextBox1.Enabled = false;
           // vt = cTPNBindingSource.Count;
            tt = 1;            
            groupBox2.Enabled = true;
            cTPNBindingSource.AddNew();
            btThemCT.Enabled = btXoaCT.Enabled = btSuaCT.Enabled = false;
            btGhiCT.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btGhi.Enabled = btThoat.Enabled = btUndo.Enabled = false;
            btReload.Enabled = true;
        }

        private void dSMasoDDHBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btSuaCT_Click(object sender, EventArgs e)
        {
            tt = 2;
           mAPNTextBox1.Text = mAPNTextBox.Text;
            mAPNTextBox1.Enabled = false;
            pHIEUNHAPGridControl.Enabled = false;
            groupBox2.Enabled = true;
            btGhiCT.Enabled = true;
            btThemCT.Enabled = btXoaCT.Enabled = btSuaCT.Enabled = false;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btGhi.Enabled  = btUndo.Enabled = false;
            btReload.Enabled = btThoat.Enabled = true;
        }

        private void btXoaCT_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa kho này ?? ", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    mavt = ((DataRowView)cTPNBindingSource[cTPNBindingSource.Position])["MAVT"].ToString(); // giữ lại để khi xóa bị lỗi thì ta sẽ quay về lại
                    cTPNBindingSource.RemoveCurrent();
                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.dS.CTPN);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa kho. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                    cTDDHBindingSource.Position = cTDDHBindingSource.Find("MAVT", mavt);
                    return;
                }
            }
            cTPNGridControl.Enabled = true;
            groupBox3.Enabled = true;
            groupBox2.Enabled = false;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = false;
            btGhi.Enabled = btThoat.Enabled = btUndo.Enabled = btReload.Enabled = true;
        }

        private void btGhiCT_Click(object sender, EventArgs e)
        {
            if (tt == 1)   // kiểm tra mã nhân viên vừa thêm có bị trùng ở cả 2 chi nhánh hay không
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String strLenh = "sp_KiemTraCTPN";   // gõ tên sp
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh;
                Program.sqlcmd.Parameters.Add("MAVT", SqlDbType.Text).Value = mAVTComboBox.SelectedValue.ToString();
                Program.sqlcmd.Parameters.Add("MAPN", SqlDbType.Text).Value = mAPNTextBox.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                Program.conn.Close();
                String Ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                if (Ret.Equals("1"))
                {
                    MessageBox.Show("MAPN và MaVT không đc đồng thời trùng nhau. Vui lòng nhập mã khác!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (mAVTComboBox.SelectedValue.ToString().Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    mAVTComboBox.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                if (dONGIASpinEdit.Text.Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    dONGIASpinEdit.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                if (sOLUONGSpinEdit.Text.Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    sOLUONGSpinEdit.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                // kiểm soát số lượng nhập vào pahir bé hơn số lượng trong đơn đặt hàng
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String strLenh1 = "SP_KTSLVTPhieuNhap";   // trả về sl trong đơn đặt hàng
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh1;
                Program.sqlcmd.Parameters.Add("MAVT", SqlDbType.Text).Value = mAVTComboBox.SelectedValue.ToString();
                Program.sqlcmd.Parameters.Add("MASODDH", SqlDbType.Text).Value = masoDDHComboBox.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                Program.conn.Close();
                String Ret1 = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                if (Ret1.Equals("0"))
                {
                    MessageBox.Show("mavt không tồn tại trong masddh này.Vui lòng nhập mã khác!!!", "", MessageBoxButtons.OK);
                    mAVTComboBox.Focus();
                    return;
                }
                int sl = Int32.Parse(Ret1);
                int slnhap = Int32.Parse(sOLUONGSpinEdit.Text.Trim());
                if (slnhap>sl)
                {
                    MessageBox.Show("số lượng vật tư nhập vào phải nhỏ hơn hoặc bằng slvt trong đơn đặt hàng. Vui lòng nhâp lại khác!!!", "", MessageBoxButtons.OK);
                    sOLUONGSpinEdit.Focus();
                    return;
                }
                try
                {
                    cTPNBindingSource.EndEdit();
                    cTPNBindingSource.ResetCurrentItem();
                    pHIEUNHAPBindingSource.ResetCurrentItem();
                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.dS.CTPN);

                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            if (tt == 2)
            {
                try
                {
                    cTPNBindingSource.EndEdit();
                    cTPNBindingSource.ResetCurrentItem();
                    pHIEUNHAPBindingSource.ResetCurrentItem();
                    this.cTPNTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTPNTableAdapter.Update(this.dS.CTPN);

                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            pHIEUNHAPGridControl.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            cTPNGridControl.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btThoat.Enabled = btUndo.Enabled = false;
            btReload.Enabled = btGhi.Enabled = true;
            groupBox3.Enabled = true;
            btSuaCT.Enabled = btXoaCT.Enabled = btThemCT.Enabled = true;
            btGhiCT.Enabled = false;
        }
    }
}
