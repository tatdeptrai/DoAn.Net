using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using FontAwesome.Sharp;
using DoAnMonHoc_MultipleChoiceApp.Forms;

namespace DoAnMonHoc_MultipleChoiceApp
{
    public partial class FormMain : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private string tenDangNhap;
        KetNoiDB DB = new KetNoiDB();
        //Constructor
        public FormMain( )
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            pnlMenu.Controls.Add(leftBorderBtn);

            //Form
            this.Text = string.Empty;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
            OpenChildForm(new frmTrangChu());
        }

        public void getUserName(string usn)
        {
            this.tenDangNhap = usn.Trim();
        }

        //Structs
        private struct RGBColors
        {
            public static System.Drawing.Color color1 = System.Drawing.Color.Black;
        }

        //Methods
        private void ActivateButton(object senderBtn, System.Drawing.Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = System.Drawing.Color.Pink;
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                //Icon Current Child Form
                icnCurrentChildForm.IconChar = currentBtn.IconChar;
                icnCurrentChildForm.IconColor = color;
            }
        }
        private string check_VaiTro()
        {
            string maVT = "";
            try
            {
                DB.OpenDB();
                string sql = "select MaVaiTro from NguoiDung where username = '" + tenDangNhap + "'";
                maVT = DB.GetScalar(sql).ToString();
                DB.CloseDB();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loi:" + ex.Message);
            }
            return maVT.Trim();
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = System.Drawing.Color.Black;
                currentBtn.ForeColor = System.Drawing.Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = System.Drawing.Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        public void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlDesktop.Controls.Add(childForm);
            pnlDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }

        private void btnQuanLy_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

        }

        private void btnBaiThi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void btnTaoBaiThi_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

        }

        private void btnBaoCaoThongKe_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            
            DangNhap fm = new DangNhap();
            fm.Show();
            this.Close();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmTrangChu());
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;

            icnCurrentChildForm.IconChar = IconChar.Home;
            icnCurrentChildForm.IconColor = System.Drawing.Color.Black;
            lblTitleChildForm.Text = "Trang chủ";
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }


        

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

     

        private void iconButton2_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
        }

        private void btnQuanLy_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender,  RGBColors.color1);
            OpenChildForm(new frmQuanLyChung());
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmBaiThi(tenDangNhap));
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new frmXemKetQuaThi(tenDangNhap));
        }

		private void iconButton5_Click(object sender, EventArgs e)
		{
			ActivateButton(sender, RGBColors.color1);
			OpenChildForm(new frmThongTinNguoiDung(tenDangNhap));
		}

		private void iconButton2_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new FrmTaoDeThi());
        }

        private void btnHome_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frmTrangChu());

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if(check_VaiTro().Equals("SV"))
            {
                btnQuanLy.Hide();
                iconButton2.Hide();
                iconButton3.Hide();


            }
            iconButton5.Text = tenDangNhap;
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
			ActivateButton(sender, RGBColors.color1);
			OpenChildForm(new frmBaoCaoThongKe());
		}

        private void btnDangXuat_Click_2(object sender, EventArgs e)
        {
            
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Form() { Text = "Đăng Xuất" });
            DangNhap fm = new DangNhap();
            fm.Show();
            this.Close();

        }
	}
}
