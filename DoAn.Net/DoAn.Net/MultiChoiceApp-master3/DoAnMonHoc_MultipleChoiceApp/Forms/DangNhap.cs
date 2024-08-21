using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    public partial class DangNhap : Form
    {

        SqlConnection conn;
        public DangNhap()
        {

            InitializeComponent();
            conn = new SqlConnection(ConnStringConfig.ketnoistring);
            txt_MatKhau.PasswordChar = '*';
        }

        public string HashPassword(string password)
        {
			StringBuilder builder = new StringBuilder();
			using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool ktra_DangNhap(string tnd, string mk)
        {
            string mkk = HashPassword(mk);
            //string mkk = "8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92";


			try
            {
                conn.Open();
                string sql = "Select count(*) from Nguoidung where Username = N'" + tnd.Trim() + "' and MatKhau = '" + mkk.Trim() + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count >= 1)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

        }

        private void chk_HienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_HienMK.Checked == true)
            {
                txt_MatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_MatKhau.PasswordChar = '*';
            }
        }

        private void btn_DangNhap_Click(object sender, EventArgs e)
        {

            if (!ktra_DangNhap(txt_TenDN.Text.Trim(), txt_MatKhau.Text.Trim()))
            {
                MessageBox.Show("Tài khoản không tồn tại, kiểm tra lại vai trò", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                this.Hide();
                FormMain fm= new FormMain();
                fm.getUserName(txt_TenDN.Text);
                fm.Show();
               
            }
        }
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DangKy dk = new DangKy();
            this.Hide();
            dk.Show();
        }

        private void DangNhap_Load_1(object sender, EventArgs e)
        {

        }
    }
}
