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
    public partial class Kho : Form
    {
        public int vitri = 0;
        public int status = 0;
        public string macn = "";
        public string tenKho="";
        public string diaChi="";
        public string maKho = "";
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
        public Kho()
        {
            InitializeComponent();
        }

        private void kHOBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.kHOBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void Kho_Load(object sender, EventArgs e)
        {
            this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.KHO' table. You can move, or remove it, as needed.
            this.kHOTableAdapter.Fill(this.dS.KHO);
            this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
            this.kHOTableAdapter.Fill(this.dS.KHO);
            macn = ((DataRowView)kHOBindingSource[0])["MACN"].ToString();
           // mACNTextBox.Text = macn;
            cmbChiNhanh.DataSource = Program.bds_dspm;  // sao chép bds_dspm đã load ở form đăng nhập  qua
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.ChiNhanh;
            if (Program.mGroup == "CONGTY")
            {
                cmbChiNhanh.Enabled = true;  // bật tắt theo phân quyền
                mACNTextBox.Text = cmbChiNhanh.SelectedValue.ToString();
                btGhi.Enabled = btUndo.Enabled = btSua.Enabled = btXoa.Enabled = btThem.Enabled = btReload.Enabled = false;
                groupBox1.Enabled = false;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btGhi.Enabled =false;
                btSua.Enabled = btXoa.Enabled = btThem.Enabled = btReload.Enabled = true;
                groupBox1.Enabled = false;
                btUndo.Enabled = false;
            }

        }

        private void kHOBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.kHOBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void btUndo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btSua.Enabled == false || btThem.Enabled == false)
            {
                kHOBindingSource.CancelEdit();   //
                if (btThem.Enabled == false)
                    kHOBindingSource.Position = vitri;
                kHOGridControl.Enabled = true;
                groupBox1.Enabled = false;
                btThem.Enabled = true;
                btSua.Enabled = true;
                btXoa.Enabled = true;
                btGhi.Enabled = false;
                btThoat.Enabled = true;
                btUndo.Enabled = false;
                btReload.Enabled = true;
            }
            else
            {
                ObjectUndo ob = (ObjectUndo)st.Pop();
                if (ob.getType() == 1)  
                {
                    MessageBox.Show("Khôi phục sau khi thêm " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.kHOTableAdapter.Fill(this.dS.KHO);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (ob.getType() == 2)
                {
                    MessageBox.Show("Khôi phục sau khi sữa " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.kHOTableAdapter.Fill(this.dS.KHO);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }
                if (ob.getType() == 3)
                {
                    MessageBox.Show("Khôi phục sau khi xóa " + ob.getLenh());
                    Program.ExecSqlDataReader(ob.getLenh());
                    this.kHOTableAdapter.Fill(this.dS.KHO);
                    if (st.Count == 0)
                    {
                        btUndo.Enabled = false;
                        //MessageBox.Show("Không có gì để Phục hồi", "THÔNG BÁO", MessageBoxButtons.OK);
                        return;
                    }
                }

            }
        }

        private void btThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //vitri = kHOBindingSource.Position;
            status = 1;
           
            // kHOGridControl.Enabled = false;
            kHOBindingSource.AddNew();
            groupBox1.Enabled = true;
            mAKHOTextBox.Enabled = true;
            mACNTextBox.Text = macn.Trim();
            mACNTextBox.Enabled = false;
            btThem.Enabled = btSua.Enabled = btXoa.Enabled = false;
            
            btGhi.Enabled = true;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            kHOGridControl.Enabled = false;
        }

        private void btSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tenKho = tENKHOTextBox.Text;
            diaChi = dIACHITextBox.Text;
            maKho = mAKHOTextBox.Text.Trim();
            status = 2;
            vitri = kHOBindingSource.Position;
            kHOGridControl.Enabled = false;
            mAKHOTextBox.Enabled=mACNTextBox.Enabled = false;
            groupBox1.Enabled = true;
            btThem.Enabled = false;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            btGhi.Enabled = true;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            btReload.Enabled = true;
        }

        private void btXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            status = 3;
            string maKho = "";
            if (Program.conn.State == ConnectionState.Closed)
                Program.conn.Open();
            String strLenh = "sp_KiemTraMAKHOPhatSinh";
            Program.sqlcmd = Program.conn.CreateCommand();
            Program.sqlcmd.CommandType = CommandType.StoredProcedure;
            Program.sqlcmd.CommandText = strLenh;
            Program.sqlcmd.Parameters.Add("@MAKHO", SqlDbType.Text).Value = mAKHOTextBox.Text;
            Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
            Program.sqlcmd.ExecuteNonQuery();
            Program.conn.Close();
            String Ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
            if (Ret.Equals("1"))
            {
                MessageBox.Show("Kho được dùng để tạo phiếu, không thể xóa!", "", MessageBoxButtons.OK);
                mAKHOTextBox.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa kho này ?? ", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maKho = mAKHOTextBox.Text.Trim();
                    string tenKho = tENKHOTextBox.Text.Trim();
                    string diaChi = dIACHITextBox.Text.Trim();
                    int type = 3;// undo xóa kho;
                                 // đưa xóa kho vào stack
                    string lenh = "exec sp_UndoXoaKho '" + maKho + "','" + tenKho + "','" + diaChi + "','" + macn + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                    maKho = ((DataRowView)kHOBindingSource[kHOBindingSource.Position])["MAKHO"].ToString(); // giữ lại để khi xóa bị lỗi thì ta sẽ quay về lại
                    kHOBindingSource.RemoveCurrent();
                    this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOTableAdapter.Update(this.dS.KHO);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa kho. Bạn hãy xóa lại\n" + ex.Message, "",
                        MessageBoxButtons.OK);
                    this.kHOTableAdapter.Fill(this.dS.KHO);
                    kHOBindingSource.Position = kHOBindingSource.Find("MAKHO", maKho);
                    return;
                }
            }
            kHOGridControl.Enabled = true;
            groupBox1.Enabled = true;
            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            btGhi.Enabled = true;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            btReload.Enabled = true;
        }

        private void btGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (status == 1)   // kiểm tra mã nhân viên vừa thêm có bị trùng ở cả 2 chi nhánh hay không
            {
                if (Program.conn.State == ConnectionState.Closed)
                    Program.conn.Open();
                String strLenh = "SP_CheckKho";   // gõ tên sp
                Program.sqlcmd = Program.conn.CreateCommand();
                Program.sqlcmd.CommandType = CommandType.StoredProcedure;
                Program.sqlcmd.CommandText = strLenh;
                Program.sqlcmd.Parameters.Add("@MAKHO", SqlDbType.Text).Value = mAKHOTextBox.Text;
                Program.sqlcmd.Parameters.Add("@Ret", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;
                Program.sqlcmd.ExecuteNonQuery();
                Program.conn.Close();
                String Ret = Program.sqlcmd.Parameters["@Ret"].Value.ToString();
                if (Ret.Equals("1"))
                {
                    MessageBox.Show("Mã Kho bị trùng ở site chủ. Vui lòng nhập mã khác!!!", "", MessageBoxButtons.OK);
                    return;
                }
                if (mAKHOTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    mAKHOTextBox.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                if (tENKHOTextBox.Text.Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    tENKHOTextBox.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                if (dIACHITextBox.Text.Trim() == "")
                {
                    MessageBox.Show("Không được bỏ trống bất kì thông tin nào", "thông báo", MessageBoxButtons.OK);
                    dIACHITextBox.Focus(); // con trỏ sẽ đặt vào textbox mã cn
                    return;
                }
                try {
                    maKho = mAKHOTextBox.Text.Trim();
                     // thực hiện undo
                    int type = 1;// undo thêm kho;
                                     // đưa thêm kho vào stack
                    string lenh = "exec sp_UndoThemKho '" + mAKHOTextBox.Text + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                    kHOBindingSource.EndEdit();// kết thúc quá trình thêm
                    kHOBindingSource.ResetCurrentItem();// làm mới lại item hiện tại
                    this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOTableAdapter.Update(this.dS.KHO);
                   
                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
                
            }
            if (status == 2)
            {
                try
                {
                    maKho = mAKHOTextBox.Text.Trim();
                    tenKho = tENKHOTextBox.Text.Trim();
                    diaChi = dIACHITextBox.Text.Trim();
                    
                    int type = 2;// undo sua kho;
                                 // đưa sua kho vào stack
                                 //////////// CÚ PHÁP CÂU LỆNH TRONG SQL
                    string lenh = "exec sp_UndoHieuChinhKho '" + maKho + "','" + tenKho + "','" + diaChi + "'";
                    ObjectUndo ob = new ObjectUndo(type, lenh);
                    st.Push(ob);
                    kHOBindingSource.EndEdit();
                    kHOBindingSource.ResetCurrentItem();
                    this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.kHOTableAdapter.Update(this.dS.KHO);
                    this.tableAdapterManager.UpdateAll(this.dS);
                    MessageBox.Show("cập nhật dữ liệu thành công", "thông báo", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ghi thất bại", "Lỗi", MessageBoxButtons.OK);
                    return;
                }
            }
            kHOGridControl.Enabled = true;
            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            btGhi.Enabled = false;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            btReload.Enabled = true;
            groupBox1.Enabled = false;
        }

        private void btReload_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Kho_Load(sender, e);
            btThem.Enabled = true;
            btXoa.Enabled = true;
            btGhi.Enabled = true;
            btThoat.Enabled = true;
            btUndo.Enabled = true;
            btReload.Enabled = true;
            kHOGridControl.Enabled = true;
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") return;
            Program.servername = cmbChiNhanh.SelectedValue.ToString();
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
                this.kHOTableAdapter.Connection.ConnectionString = Program.connstr;
                this.kHOTableAdapter.Fill(this.dS.KHO);
                macn = ((DataRowView)kHOBindingSource[0])["MACN"].ToString();

            }
        }
    }
}
