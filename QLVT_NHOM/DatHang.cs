using System;
using System.Collections;
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
    public partial class DatHang : Form
    {
        public int vitri = 0;
         
        public string macn = "";
        public int status = 0;
        public string masoDDH;
        public string ngay;
        public string nhaCC;
        public string manv;
        public string makho;
        public int vt = 0;// luu vị trí của CTDDH
        public int tt = 0; // luu trạng thái để thực hiện với form ctddh
        public Stack st = new Stack();
        public class ObjectUndo
        {
            int type;
            String lenh;
            public ObjectUndo(int t, String l)
            {
                this.type = t;
                this.lenh = l;
            }
            public int getType()
            {
                return type;
            }
            public String getLenh()
            {
                return lenh;
            }
        }
        public DatHang()
        {
            InitializeComponent();
        }

        private void dATHANGBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.dATHANGBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void DatHang_Load(object sender, EventArgs e)
        {
            this.vATTUTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.VATTU' table. You can move, or remove it, as needed.
            this.vATTUTableAdapter.Fill(this.dS.VATTU);
            this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.KHO' table. You can move, or remove it, as needed.
            this.kHOTableAdapter.Fill(this.dS.KHO);
            this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dATHANGTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
            // TODO: This line of code loads data into the 'dS.DATHANG' table. You can move, or remove it, as needed.
            this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.ChiNhanh;
            manv = Program.username;
            mANVTextBox.Text = Program.username;
            mANVTextBox.Enabled = false;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                btGhi.Enabled = btUndo.Enabled = btSua.Enabled = btXoa.Enabled = btThem.Enabled = btReload.Enabled = false;
                groupBox2.Enabled = cTDDHGridControl.Enabled = false;
                groupBox1.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btSua.Enabled = btXoa.Enabled = btThem.Enabled = btReload.Enabled = true;
                btCT.Enabled = true;
                groupBox1.Enabled = groupBox3.Enabled = groupBox2.Enabled = false;
                btUndo.Enabled = btGhi.Enabled = false;
                cTDDHGridControl.Enabled = false;
            }
        }

        private void btThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 1;
            vitri = dATHANGBindingSource.Position;
            dATHANGGridControl.Enabled = false;
            dATHANGBindingSource.AddNew();
            groupBox1.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btUndo.Enabled = false;
            btGhi.Enabled = btThoat.Enabled  = true;
            btReload.Enabled = true;
            cTDDHGridControl.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void btSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 2;
            masoDDHTextEdit.Text = masoDDHTextBox.Text;           
            masoDDHTextBox.Enabled =masoDDHTextEdit.Enabled= false;
            dATHANGGridControl.Enabled = false;
            masoDDHTextBox.Enabled = false;
            groupBox1.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btUndo.Enabled = false;
            btGhi.Enabled = btThoat.Enabled=  btReload.Enabled = true;
            mANVTextBox.Enabled = false;
            cTDDHGridControl.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = true;
            masoDDH = masoDDHTextBox.Text.Trim();
            manv = mANVTextBox.Text.Trim();
            ngay = nGAYDateEdit.Text.Trim();
            makho = cmbMAKHO.SelectedValue.ToString().Trim();
            nhaCC = nhaCCTextBox.Text.Trim();
        }

        private void btXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 3;
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            String strLenh = "sp_KiemTraMasoDDHPhatSinh";
            Program.sqlcmd = Program.conn.CreateCommand();
            Program.sqlcmd.CommandType = CommandType.StoredProcedure;
            Program.sqlcmd.CommandText = strLenh;
            Program.sqlcmd.Parameters.Add("@MasoDDH", SqlDbType.Text).Value = masoDDHTextBox.Text;
            Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.sqlcmd.ExecuteNonQuery();
            Program.conn.Close();
            String Ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
            if (Ret.Equals("1"))
            {
                MessageBox.Show("Đơn Đặt hàng được dùng để tạo phiếu, không thể xóa!", "", MessageBoxButtons.OK);
                cmbMAKHO.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa kho này ?? ", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    masoDDH = masoDDHTextBox.Text;
                    ngay = nGAYDateEdit.Text;
                    nhaCC = nhaCCTextBox.Text;
                    makho = cmbMAKHO.Text;
                    masoDDH = ((DataRowView)dATHANGBindingSource[dATHANGBindingSource.Position])["MasoDDH"].ToString(); // giữ lại để khi xóa bị lỗi thì ta sẽ quay về lại
                    dATHANGBindingSource.RemoveCurrent();
                    this.dATHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.dATHANGTableAdapter.Update(this.dS.DATHANG);

                    int type = 3;
                    string lenh = "exec sp_UndoXoaDatHang '" + masoDDH + "','" + ngay + "','" + nhaCC + "','" + manv + "','" + makho + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa kho. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
                    dATHANGBindingSource.Position = dATHANGBindingSource.Find("MasoDDH", masoDDH);
                    return;
                }
            }
            dATHANGGridControl.Enabled = true;
            groupBox1.Enabled = true;
            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            btGhi.Enabled = true;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            btReload.Enabled = true;
            cTDDHGridControl.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void btGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            mANVTextBox.Text = Program.username;
            mANVTextBox.Enabled = false;
            if (status == 1)   // kiểm tra mã nhân viên vừa thêm có bị trùng ở cả 2 chi nhánh hay không
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String strLenh = "SP_CheckDatHang";
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh;
                Program.sqlcmd.Parameters.Add("@MaDDH", SqlDbType.Text).Value = masoDDHTextBox.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                Program.conn.Close();
                String Ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                if (Ret.Equals("1"))
                {
                    MessageBox.Show("Mã số đơn đặt hàng bị trùng ở site chủ. Vui lòng nhập mã khác!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (cmbMAKHO.SelectedValue.ToString().Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    cmbMAKHO.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                if (masoDDHTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    masoDDHTextBox.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                if (nhaCCTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    nhaCCTextBox.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                try
                {
                    int type = 1;
                    string lenh = "exec sp_UndoThemDatHang '" + masoDDHTextBox.Text + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                    dATHANGBindingSource.EndEdit();
                    dATHANGBindingSource.ResetCurrentItem();
                    cTDDHBindingSource.ResetCurrentItem();
                    this.dATHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.dATHANGTableAdapter.Update(this.dS.DATHANG);                   
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
                    
                    int type = 2;
                    string lenh = "exec sp_UndoHieuDatHang '" +masoDDH+"','"+ nhaCC + "','" + ngay + "','" + manv + "','" + makho + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                    dATHANGBindingSource.EndEdit();
                    dATHANGBindingSource.ResetCurrentItem();
                    cTDDHBindingSource.ResetCurrentItem();
                    this.dATHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.dATHANGTableAdapter.Update(this.dS.DATHANG);

                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            groupBox1.Enabled = false;
            masoDDHTextEdit.Text = masoDDHTextBox.Text;
            this.tableAdapterManager.UpdateAll(this.dS);
            dATHANGGridControl.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = true;
            btGhi.Enabled = false;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            btReload.Enabled = true;
            cTDDHGridControl.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
        }

        private void btUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btSua.Enabled == false || btThem.Enabled == false)
            {
                cTDDHBindingSource.CancelEdit();
                dATHANGBindingSource.CancelEdit();   //Bỏ qua các dữ liệu trong row hiện hành đang hiệu chỉnh, và cho con trỏ mẫu tin về row cuối cùng.
                if (btThem.Enabled == false)
                    dATHANGBindingSource.Position = vitri;
                dATHANGGridControl.Enabled = true;
                groupBox1.Enabled = false;
                btThem.Enabled =  btSua.Enabled =  btXoa.Enabled = true;
                btGhi.Enabled = false;
                btThoat.Enabled = true;
                btUndo.Enabled = true;
                btReload.Enabled = true;
            }
            else
            {
                ObjectUndo ob = (ObjectUndo)st.Pop();
                if (ob.getType() == 1)   // undo thêm dathang
                {
                    MessageBox.Show("Khôi phục sau khi thêm đặt hàng " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
                    this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (ob.getType() == 2) // undo sửa đặt hàng
                {
                    MessageBox.Show("Khôi phục sau khi sửa Đặt hàng " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
                    this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (ob.getType() == 4)  //undo thêm ctddh
                {
                    MessageBox.Show("Khôi phục sau khi thêm CTDDH " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
                    this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (ob.getType() == 5) // undo sua ctddh
                {
                    MessageBox.Show("Khôi phục sau khi sửa CTDDH " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
                    this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (ob.getType() == 6)  // undo xoa ctddh
                {
                    MessageBox.Show("Khôi phục sau khi xóa CTDDH " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
                    this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (ob.getType() == 3) // xóa đơn đặt hàng không có phiếu mới có thể xóa nên không cần undo lại ctddh bị xóa
                {
                    MessageBox.Show("Khôi phục sau khi xóa " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
                    this.cTDDHTableAdapter.Fill(this.dS.CTDDH);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
        }

        private void btReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DatHang_Load(sender, e);
            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            btGhi.Enabled = true;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            btReload.Enabled = true;
            dATHANGGridControl.Enabled = true;
            cTDDHGridControl.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox1.Enabled = false;
        }

        private void btThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
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
                this.dATHANGTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dATHANGTableAdapter.Fill(this.dS.DATHANG);
                //this.PHATSINHTableAdapter.Connection.ConnectionString = Program.connstr;
                // this.PHATSINHTableAdapter.Fill(this.DS.PHATSINH);
                //macn = ((DataRowView)bdsNhanVien[0])["MACN"].ToString();
            }
        }

        private void btCT_Click(object sender, EventArgs e)
        {
            masoDDHTextEdit.Text = masoDDHTextBox.Text;
            cTDDHGridControl.Enabled = true;
            groupBox2.Enabled = false;
            groupBox1.Enabled = true;
            groupBox3.Enabled = false;
            dATHANGGridControl.Enabled = true;
        }
        public string mavt, soluong, dongia;

        private void btXoaCT_Click(object sender, EventArgs e)
        {
            masoDDHTextEdit.Text = masoDDHTextBox.Text;
            if (MessageBox.Show("Bạn có thật sự muốn xóa kho này ?? ", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    string msddh = masoDDHTextEdit.Text;
                    mavt = cmbMAVT.SelectedValue.ToString();
                    soluong = sOLUONGSpinEdit.Text;
                    dongia = dONGIASpinEdit.Text;
                    mavt = ((DataRowView)cTDDHBindingSource[cTDDHBindingSource.Position])["MAVT"].ToString(); // giữ lại để khi xóa bị lỗi thì ta sẽ quay về lại
                    cTDDHBindingSource.RemoveCurrent();
                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Update(this.dS.CTDDH);

                    int type = 6;// undo xoa CTDDH
                    string lenh = "exec sp_UndoXoaCTDDH '" + msddh + "','" + mavt + "','" + soluong + "','" + dongia + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
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
            cTDDHGridControl.Enabled = true;
            groupBox3.Enabled = true;
            groupBox2.Enabled = false;
            btThem.Enabled =  btSua.Enabled = btXoa.Enabled = false;
            btGhi.Enabled =  btThoat.Enabled = btUndo.Enabled =btReload.Enabled = true;
        }

        private void btGhiCT_Click(object sender, EventArgs e)
        {
            /// lỗi thêm ctddh 
            if (tt == 1)   // kiểm tra mã nhân viên vừa thêm có bị trùng ở cả 2 chi nhánh hay không
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String strLenh = "sp_KiemTraCTDDH";   // gõ tên sp
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh;
                Program.sqlcmd.Parameters.Add("MAVT", SqlDbType.Text).Value = cmbMAVT.SelectedValue.ToString();
                Program.sqlcmd.Parameters.Add("MasoDDH", SqlDbType.Text).Value = masoDDHTextEdit.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                Program.conn.Close();
                String Ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                if (Ret.Equals("1"))
                {
                    MessageBox.Show("MasoDDH và MaVT không đc đồng thời trùng nhau. Vui lòng nhập mã khác!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (cmbMAVT.SelectedValue.ToString().Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    cmbMAVT.Focus(); // con trỏ sẽ đặt vào textbox mã cn
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
                try
                {
                    // thực hiện undo
                    int type = 4;// undo thêm ctddh; sp xóa hết tất cả ctddh vừa được thêm vào 
                    string lenh = "exec sp_UndoThemCTDDH '" + masoDDHTextEdit.Text + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                    cTDDHBindingSource.EndEdit();// kết thúc quá trình thêm
                    cTDDHBindingSource.ResetCurrentItem();// làm mới lại item hiện tại
                   dATHANGBindingSource.ResetCurrentItem();
                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Update(this.dS.CTDDH);
                   
                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                Program.conn.Close();
            }
            if (tt == 2)
            {
                try
                {
                    int type = 5;
                    string lenh = "exec sp_UndoHieuCTDDH '" + masoDDH +"','"+ mavt + "','" + soluong + "','" + dongia + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                    cTDDHBindingSource.EndEdit();
                    cTDDHBindingSource.ResetCurrentItem();
                    dATHANGBindingSource.ResetCurrentItem();
                    this.cTDDHTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.cTDDHTableAdapter.Update(this.dS.CTDDH);
                    this.tableAdapterManager.UpdateAll(this.dS);
                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            dATHANGGridControl.Enabled = true;
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            cTDDHGridControl.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled  = btThoat.Enabled = btUndo.Enabled = false;
            btReload.Enabled  = btGhi.Enabled = true;
            if (st.Count == 0)
            {
                btUndo.Enabled = false;
                //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                return;
            }
            else
                btUndo.Enabled = true;
            groupBox3.Enabled = true;
            btSuaCT.Enabled = btXoaCT.Enabled = btThemCT.Enabled = true;
            btGhiCT.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btThemCT_Click(object sender, EventArgs e)
        {
            masoDDHTextEdit.Text = masoDDHTextBox.Text;
            vt = cTDDHBindingSource.Count;
            tt = 1;
            masoDDHTextEdit.Enabled = false;           
            groupBox2.Enabled = true;
            cTDDHBindingSource.AddNew();
            btThemCT.Enabled = false;
            btSuaCT.Enabled = false;
            btXoaCT.Enabled = false;
            btGhiCT.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btGhi.Enabled = btThoat.Enabled = btUndo.Enabled = false;
            btReload.Enabled = true;
        }

        private void btSuaCT_Click(object sender, EventArgs e)
        {
            tt = 2;
            masoDDHTextEdit.Text = masoDDHTextBox.Text;
            masoDDHTextEdit.Enabled = false;
            
            mavt = cmbMAVT.SelectedValue.ToString();
            soluong = sOLUONGSpinEdit.Text;
            dongia = dONGIASpinEdit.Text;
            cTDDHGridControl.Enabled = false;
            groupBox2.Enabled = true;
            btGhiCT.Enabled = true;
            btThemCT.Enabled = btXoaCT.Enabled = btSuaCT.Enabled = false;
            btReload.Enabled = true;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = btGhi.Enabled = btThoat.Enabled = btUndo.Enabled = false;
        }

    }
}
