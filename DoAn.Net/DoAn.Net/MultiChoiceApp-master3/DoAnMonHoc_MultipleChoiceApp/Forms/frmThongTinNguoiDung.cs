using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    public partial class frmThongTinNguoiDung : Form
    {
        private string username;
        private KetNoiDB db;
        public frmThongTinNguoiDung(string username)
        {
            InitializeComponent();
            db = new KetNoiDB();    
            this.username = username;
            DisplayUserInfo();
        }
        private void DisplayUserInfo()
        {

            db.OpenDB();

               
                string query = "SELECT Ho, Ten, Email,Username FROM NguoiDung WHERE Username = @Username";

                using (SqlCommand command = new SqlCommand(query, db.Connection))
                {
                   
                    command.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                         
                            string ho = reader["Ho"].ToString();
                            string ten = reader["Ten"].ToString();
                            string email = reader["Email"].ToString();
                            string username = reader["Username"].ToString();


                      
                        lblHoTen.Text =  ho + " " + ten;
                        lblEmail.Text =   email;
                        lblUsername.Text = username;
                        }
                    }
                }
            
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frmThongTinNguoiDung_Load(object sender, EventArgs e)
        {

        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau form2 = new frmDoiMatKhau(username); 
            form2.Show();
            this.Hide();
        }
    }
}
