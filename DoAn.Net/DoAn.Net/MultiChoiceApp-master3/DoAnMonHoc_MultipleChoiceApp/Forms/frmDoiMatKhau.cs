using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    public partial class frmDoiMatKhau : Form
    {
         KetNoiDB db = new KetNoiDB();
        private string username;
        public frmDoiMatKhau(string username)
        {
            
            this.username = username;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMatKhauMoi.PasswordChar = '*';
            txtNhapLaiMatKhau.PasswordChar = '*';
        }
        
     
     private bool ktra_NhapLaiMK()
        {
            if(txtMatKhauMoi.Text == txtNhapLaiMatKhau.Text)
                return true;
            return false;
        }
        private void btnDoi_Click(object sender, EventArgs e)
        {
            string mkmoi = HashPassword(txtMatKhauMoi.Text);
            string mkcu = HashPassword(txtMatKhauCu.Text).Trim() ;
            if (ktra_NhapLaiMK() == true)
            {
                try
                {
                    db.OpenDB();
                    string query = "update Nguoidung set matkhau = '" + mkmoi + "' where Username = '" + username + "' and Matkhau = '" + mkcu + "' ";
                    db.GetNonQuery(query);
                    db.CloseDB();
                    MessageBox.Show("Doi mat khau thanh cong");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loi " + ex);
                }
            }
            else
            {
                MessageBox.Show("Mat khau va nhap lai mat khau khong khop");
            }
         
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

        private void chkMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMK.Checked == true)
            {
                txtMatKhauMoi.PasswordChar = '\0';
            }
            else
            {
                txtMatKhauMoi.PasswordChar = '*';
            }
        }

        private void chkNLmk_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNLmk.Checked == true)
            {
                txtNhapLaiMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtNhapLaiMatKhau.PasswordChar = '*';
            }
        }
    }
}
