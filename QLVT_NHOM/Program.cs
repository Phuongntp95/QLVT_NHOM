using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using System.Data.SqlClient;
using System.Data;

namespace QLVT_NHOM
{
    static class Program
    {
        public static string ThongTinDangNhap = "";
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static int ThongTinKetNoi = 0;
        public static int ChiNhanh = 0;
        public static SqlDataAdapter da;
        public static SqlDataReader myReader;
        public static String servername = "";
        public static String servername1 = "DESKTOP-9HDLFKD//SERVER1";

        internal static DataTable ExecSqlDataTable(string strLenh, string connstr)
        {
            throw new NotImplementedException();
        }

        public static String servername2 = "DESKTOP-9HDLFKD//SERVER2";
        public static String username = "";
        public static String password = "";
        public static String database = "QLVT_NHOM";
        public static String mlogin = "";
        public static String mloginDN = "";   // luu lai thong tin dang nhap
        public static String passwordDN = "";
        public static String mGroup;
        public static String mHoten;
        public static String remotelogin = "SUPPORT_CONNECT";
        public static String remotepassword = "123456";
        public static BindingSource bds_dspm = new BindingSource();  // giữ bdsPM khi đăng nhập
        public static Form1 frmchinh;
        public static SqlCommand sqlcmd;
        public static int KetNoi()
        {
            if (Program.conn != null && Program.conn.State == ConnectionState.Open) Program.conn.Close();
            try
            {
                Program.connstr = "Data Source=" + Program.servername + ";Initial Catalog=" + Program.database + ";User ID=" + Program.mlogin + ";password=" + Program.password;
                Program.conn.ConnectionString = Program.connstr;
                Program.conn.Open();
                ThongTinKetNoi = 1;
                //   MessageBox.Show("Đăng nhâp thành công", "Thông Báo", MessageBoxButtons.OK);
                return 1;
            }

            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu.\nBạn xem lại user name và password.\n " + e.Message, "", MessageBoxButtons.OK);
                return 0;
            }
        }

        public static SqlDataReader ExecSqlDataReader(String cmd)
        {
            SqlDataReader myreader;
            //Program.conn = new SqlConnection(connectionstring);

            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.Connection = Program.conn;
            sqlcmd.CommandText = cmd;
            sqlcmd.CommandType = CommandType.Text;

            if (Program.conn.State == ConnectionState.Closed) Program.conn.Open();
            try
            {
                myreader = sqlcmd.ExecuteReader(); return myreader;
            }
            catch (SqlException ex)
            {
                Program.conn.Close();
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static DataTable ExecSqlQuery(String cmd)
        {
            DataTable dt1 = new DataTable();
            // conn = new SqlConnection(connectionstring);
            da = new SqlDataAdapter(cmd, conn);
            da.Fill(dt1);
            return dt1;

        }


        public static int ExecSqlNonQuery(String cmd)
        {
            //conn = new SqlConnection(connectionstring);
            SqlCommand Sqlcmd = new SqlCommand();
            Sqlcmd.Connection = conn;
            Sqlcmd.CommandText = cmd;
            Sqlcmd.CommandType = CommandType.Text;
            Sqlcmd.CommandTimeout = 300;
            if (conn.State == ConnectionState.Closed) conn.Open();
            try
            {

                Sqlcmd.ExecuteNonQuery(); conn.Close(); return 1;
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                conn.Close();
                return 0;
            }
        }
        public static void SetEnableOfButton(Form frm, Boolean Active)
        {

            foreach (Control ctl in frm.Controls)
                if ((ctl) is Button)
                    ctl.Enabled = Active;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
    [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            frmchinh = new Form1();
            Application.Run(frmchinh);
        }
    }
}
