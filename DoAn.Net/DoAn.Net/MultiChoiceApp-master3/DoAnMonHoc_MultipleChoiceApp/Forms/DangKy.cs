using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    public partial class DangKy : Form
    {
        SqlConnection conn;

        public DangKy()
        {
            conn = new SqlConnection(ConnStringConfig.ketnoistring);
            InitializeComponent();
            txt_MatKhau.PasswordChar = '*';
            txt_NLMatKhau.PasswordChar = '*';
        }

        private void txt_TenDN_TextChanged(object sender, EventArgs e)
        {
            if (txt_TenDN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void txt_MatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txt_MatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mật khẩu không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
            }
        }

        private void txt_NLMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (txt_NLMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mật khẩu nhập lại không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                if (txt_MatKhau != txt_NLMatKhau)
                    MessageBox.Show("Mật khẩu nhập lại không đúng vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
            }
        }
        public bool IsGmailAddress(string input)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";
            return Regex.IsMatch(input, pattern);
        }
        public bool ktra_DK()
        {
            if (txt_TenDN.Text.Trim().Length == 0)
            {
                MessageBox.Show("Tên đăng nhập không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (txt_MatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mật khẩu không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (txt_NLMatKhau.Text.Trim().Length == 0)
            {
                MessageBox.Show("Mật khẩu nhập lại không được bỏ trống", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (!string.Equals(txt_MatKhau.Text, txt_NLMatKhau.Text, StringComparison.Ordinal))
            {
                MessageBox.Show("Mật khẩu nhập lại không đúng vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            if (!IsGmailAddress(txt_Gmail.Text))
            {
                MessageBox.Show("Gmail nhập vào sai cấu trúc vui lòng nhập lại", "Thông báo", MessageBoxButtons.OK);
                return false;
            }
            return true;
        }
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
        private bool Ktra_TenDN(string s)
        {
            try
            {
                conn.Open();
                string sql = "select Count(*) from NguoiDung where username = N'" + s + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                int dem = (int)(cmd.ExecuteScalar());
                conn.Close();
                if (dem > 0)
                    return true;
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }  
        private void DangKy_Load(object sender, EventArgs e)
        {

            //cbo_Vaitrro.SelectedIndex = 0;

        }

        private void btn_DangKy_Click_1(object sender, EventArgs e)
        {
            string mk = HashPassword(txt_MatKhau.Text);
            string nlmk = HashPassword(txt_NLMatKhau.Text); // Ma hoa mat khau
            if (ktra_DK() == true)
            {
                if (mk != nlmk)
                {
                    MessageBox.Show("Mật khẩu và mật khẩu xác nhận không khớp", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (Ktra_TenDN(txt_TenDN.Text) == true)
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                }

                else
                {
                    conn.Open();
                    ktra_DK();
                    try
                    {

                        string sql = "insert into NguoiDung values( N'" + txt_ho.Text + "',N'" + txt_ten.Text + "',N'" + txt_TenDN.Text + "','" + mk + "','" + txt_Gmail.Text + "','SV' )";
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đăng ký thất bại", "Thông báo", MessageBoxButtons.OK);
                    }
                    conn.Close();
                }
            }
            
        }

        private void chk_HienMK_CheckedChanged_1(object sender, EventArgs e)
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

        private void chk_HienNLMK_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chk_HienNLMK.Checked == true)
            {
                txt_NLMatKhau.PasswordChar = '\0';
            }
            else
            {
                txt_NLMatKhau.PasswordChar = '*';
            }
        }

        private void btn_dangNhap_Click_1(object sender, EventArgs e)
        {

            DangNhap dn = new DangNhap();
            this.Hide();
            dn.Show();
        }

        private void DangKy_Load_1(object sender, EventArgs e)
        {

        }

        private void txt_Gmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

