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
using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    public partial class frmQuanLyChung : Form
    {
        private KetNoiDB db;
        private SqlDataAdapter adap;
        private DataSet QLMonHoc = new DataSet();
        private DataSet QLNguoiDung = new DataSet();
        private DataTable DeThi = new DataTable();
        private DataTable CauHoi = new DataTable();
        private DataTable LuaChon = new DataTable();
        public frmQuanLyChung()
        {
            InitializeComponent();
            db = new KetNoiDB();
            cboSapXepQLND.SelectedIndexChanged += cboSapXepQLND_SelectedIndexChanged;
        }

        private bool isNumber(string s)
        {
            return int.TryParse(s, out int val1) || double.TryParse(s, out double val2);
        }

        private bool isPositiveInteger(string s)
        {
            return s.All(char.IsDigit);
        }

        private bool checkPK(string idValue, string tableName, string idName)
        {
            int kq = 0;
            try
            {
                db.OpenDB();

                string query = "SELECT COUNT(*) FROM " + tableName + " WHERE " + idName + " = '" + idValue + "'";

                kq = (int)db.GetScalar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }

            if (kq > 0)
            {
                return true;
            }
            return false;
        }

        private bool checkUniName(string tenMonHoc)
        {
            int kq = 0;
            try
            {
                db.OpenDB();

                string query = "SELECT COUNT(*) FROM MonHoc WHERE TenMonHoc = '" + tenMonHoc + "'";

                kq = (int)db.GetScalar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }

            if (kq > 0)
            {
                return true;
            }
            return false;
        }

        private bool checkDapAn(string maCauHoi)
        {
            int kq = 0;
            try
            {
                db.OpenDB();
                string query = "SELECT COUNT(*) FROM LuaChon WHERE MaCauHoi = '" + maCauHoi + "'";
                kq = (int)db.GetScalar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác");
            }
            finally
            {
                db.CloseDB();
            }

            if (kq == 1)
                return true;
            return false;
        }

        private bool checkDapAnDung(string maCauHoi)
        {
            int kq = 0;
            try
            {
                db.OpenDB();
                string query = "SELECT COUNT(*) FROM LuaChon WHERE MaCauHoi = '" + maCauHoi + "' AND DapAnDung = 1";
                kq = (int)db.GetScalar(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác");
            }
            finally
            {
                db.CloseDB();
            }

            if (kq == 1)
                return true;
            return false;
        }
        //Người Dùng
        private void LoadSapXepND()
        {
            cboSapXepQLND.Items.Add("Tăng dần");
            cboSapXepQLND.Items.Add("Giảm dần");
            cboSapXepQLND.SelectedIndex = 0;
        }
        private void LoadVaiTro()
        {
            cboVaiTro.Items.Add("SV");
            cboVaiTro.Items.Add("AD");
        }
        private DataTable SearchSinhVienByUsername(string username)
        {
            DataTable dataTable = new DataTable();



            string query = "SELECT * FROM NguoiDung WHERE Username = @Username";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@Username", username);
                adapter.Fill(dataTable);
            }

            return dataTable;
        }
        private DataTable GetSinhVienData()
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT * FROM NguoiDung";
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection))
            {
                adapter.Fill(dataTable);
            }
            return dataTable;
        }

        private void LoadSinhVienData()
        {
            dgVQLND.DataSource = GetSinhVienData();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string usernameToSearch = txtTimKiemND.Text.Trim();

            if (!string.IsNullOrEmpty(usernameToSearch))
            {
                dgVQLND.DataSource = SearchSinhVienByUsername(usernameToSearch);
            }
        }
        private void dgVQLND_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                txtMatKhau.DataBindings.Clear();
                DataGridViewRow mk = dgVQLND.Rows[e.RowIndex];
                string mkhau = Convert.ToString(mk.Cells["MatKhau"].Value);
                txtMatKhau.Text = mkhau;
                txtMatKhau.DataBindings.Clear();
                DataGridViewRow usn = dgVQLND.Rows[e.RowIndex];
                string username = Convert.ToString(usn.Cells["Username"].Value);
                txtUsername.Text = username;
                DataGridViewRow h = dgVQLND.Rows[e.RowIndex];
                string ho = Convert.ToString(h.Cells["Ho"].Value);
                txtHo.Text = ho;
                DataGridViewRow t = dgVQLND.Rows[e.RowIndex];
                string ten = Convert.ToString(t.Cells["Ten"].Value);
                txtTen.Text = ten;
                DataGridViewRow em = dgVQLND.Rows[e.RowIndex];
                string email = Convert.ToString(em.Cells["Email"].Value);
                txtEmail.Text = email;
                DataGridViewRow vt = dgVQLND.Rows[e.RowIndex];
                string vaitro = Convert.ToString(vt.Cells["MaVaiTro"].Value);
                cboVaiTro.Text = vaitro;

            }
        }
        private void DeleteSinhVienByUsername(string username)
        {
            db.Connection.Open();
            string query = "DELETE FROM NguoiDung WHERE Username = @Username";

            using (SqlCommand command = new SqlCommand(query, db.Connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.ExecuteNonQuery();
                LoadSinhVienData();
            }
            db.Connection.Close();

        }
        private void btnXoaQLND_Click(object sender, EventArgs e)
        {
            if (dgVQLND.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgVQLND.SelectedRows[0];
                string usernameToDelete = txtUsername.Text;

                DeleteSinhVienByUsername(usernameToDelete);
                LoadSinhVienData();
            }
            else
            {
                MessageBox.Show("Xóa thành công !");
            }
        }

        private void CapNhatSinhVien(string ho, string ten, string email, string username, string vaitro)
        {
            db.Connection.Open();

            string query = "UPDATE NguoiDung SET MaVaiTro = @Mavaitro, Ho = @Ho, Ten = @Ten, Email = @Email WHERE Username = @Username";

            using (SqlCommand command = new SqlCommand(query, db.Connection))
            {
                command.Parameters.AddWithValue("@Ho", ho);
                command.Parameters.AddWithValue("@Ten", ten);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Mavaitro", vaitro);

                command.ExecuteNonQuery();

            }
            db.Connection.Close();
        }
        private void btnCapNhapQLND_Click(object sender, EventArgs e)
        {
            if (dgVQLND.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgVQLND.SelectedRows[0];
                string username = Convert.ToString(selectedRow.Cells["Username"].Value);

                string hoMoi = txtHo.Text;
                string tenMoi = txtTen.Text;
                string emailMoi = txtEmail.Text;
                string vaitro = cboVaiTro.SelectedItem.ToString();
                CapNhatSinhVien(hoMoi, tenMoi, emailMoi, username,vaitro);
                LoadSinhVienData();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để cập nhật.");
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
        private bool Ktra_TenDN(string s)
        {
            try
            {
                db.OpenDB();
                string sql = "select Count(*) from NguoiDung where username = N'" + s + "'";
                SqlCommand cmd = new SqlCommand(sql, db.Connection);
                int dem = (int)(cmd.ExecuteScalar());
                db.CloseDB();
                if (dem > 0)
                    return true;
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string mk = HashPassword(txtMatKhau.Text);

            if (Ktra_TenDN(txtUsername.Text) == true)
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if(cboVaiTro.SelectedItem==null)
            {
                MessageBox.Show("Vui lòng chọn vai trò cho user");
                return;
            }    
            else
            {
                db.OpenDB();
                try
                {
                    string vaiTroValue = cboVaiTro.SelectedItem.ToString();
                    string sql = "insert into NguoiDung values( N'" + txtHo.Text + "',N'" + txtTen.Text + "',N'" + txtUsername.Text + "','" + mk + "','" + txtEmail.Text + "','" + vaiTroValue + "')";
                    SqlCommand cmd = new SqlCommand(sql, db.Connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công", "Thông báo", MessageBoxButtons.OK);
                    LoadSinhVienData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thêm thất bại thất bại", "Thông báo", MessageBoxButtons.OK);
                }
                db.CloseDB();
            }
        }
        //Môn Học
        private void LoadMonHoc()
        {
            string query = "SELECT * FROM MonHoc ORDER BY MaMonHoc";
            adap = new SqlDataAdapter(query, db.Connection);
            adap.Fill(QLMonHoc, "MONHOC");

            dgvMonHoc.DataSource = QLMonHoc.Tables["MONHOC"];

            dgvMonHoc.Columns["MaMonHoc"].HeaderText = "Mã Môn Học";
            dgvMonHoc.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";

            txtMaMonHoc.Enabled = false;
            btnThem.Enabled = false;
        }

        //Đề Thi
        private void LoadDeThi()
        {
            string query = "SELECT dt.MaDeThi, dt.TenDeThi, mh.MaMonHoc, mh.TenMonHoc, dt.MucDo, dt.ThoiGianLamBai, CONVERT(varchar, dt.NgayTao, 103) AS NgayTao FROM DeThi dt JOIN MonHoc mh ON dt.MaMonHoc = mh.MaMonHoc";
            adap = new SqlDataAdapter(query, db.Connection);
            adap.Fill(DeThi);

            dgvDeThi.DataSource = DeThi;

            dgvDeThi.Columns["MaMonHoc"].Visible = false;
            dgvDeThi.Columns["MaDeThi"].HeaderText = "Mã Đề Thi";
            dgvDeThi.Columns["TenDeThi"].HeaderText = "Tên Đề Thi";
            dgvDeThi.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";
            dgvDeThi.Columns["MucDo"].HeaderText = "Mức Độ";
            dgvDeThi.Columns["ThoiGianLamBai"].HeaderText = "Thời Gian Làm Bài (Phút)";
            dgvDeThi.Columns["NgayTao"].HeaderText = "Ngày Tạo";

            txtMaDeThi.Enabled = false;
            btnThemDT.Enabled = false;

            LoadCacMonHocDeThi();
            LoadMucDoDeThi();
            mstNgayTao.Text = DateTime.Today.ToString("dd/MM/yyyy");
        }

        private void LoadCacMonHocDeThi()
        {
            cboMonHoc.DataSource = QLMonHoc.Tables[0];
            cboMonHoc.DisplayMember = "TenMonHoc";
            cboMonHoc.ValueMember = "MaMonHoc";
        }

        private void LoadMucDoDeThi()
        {
            string[] arrMucDo = { "Dễ", "Trung Bình", "Khó" };
            cboMucDo.Items.Clear();
            cboMucDo.Items.AddRange(arrMucDo);
            cboMucDo.SelectedIndex = 0;
        }

        //Câu Hỏi
        private void LoadCauHoi()
        {
            string query = "SELECT ch.MaCauHoi, ch.NoiDungVanBan, ch.MucDo, mh.MaMonHoc, mh.TenMonHoc FROM MonHoc mh JOIN CauHoi ch ON mh.MaMonHoc = ch.MaMonHoc";
            adap = new SqlDataAdapter(query, db.Connection);
            adap.Fill(CauHoi);

            dgvCauHoi.DataSource = CauHoi;

            dgvCauHoi.Columns["MaCauHoi"].HeaderText = "Mã Câu Hỏi";
            dgvCauHoi.Columns["NoiDungVanBan"].HeaderText = "Nội Dung Văn Bản";
            dgvCauHoi.Columns["MucDo"].HeaderText = "Mức Độ";
            dgvCauHoi.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";
            dgvCauHoi.Columns["MaMonHoc"].Visible = false;

            txtMaCauHoi.Enabled = false;
            btnThemCauHoi.Enabled = false;

            LoadCacMonHocCauHoi();
            LoadMucDoMonHoc();
            tableLayoutPanel31.Enabled = false;
        }

        private void LoadCacMonHocCauHoi()
        {
            cboMHCauHoi.DataSource = QLMonHoc.Tables[0];
            cboMHCauHoi.DisplayMember = "TenMonHoc";
            cboMHCauHoi.ValueMember = "MaMonHoc";
        }

        private void LoadMucDoMonHoc()
        {
            string[] arrMucDo = { "Dễ", "Trung Bình", "Khó" };
            cboMucDoCH.Items.Clear();
            cboMucDoCH.Items.AddRange(arrMucDo);
            cboMucDoCH.SelectedIndex = 0;
        }

        //Lựa Chọn
        private void LoadLuaChon()
        {
            string query = "SELECT MaLuaChon, MaCauHoi, DapAnA, DapAnB, DapAnC, DapAnD, DapAnDung FROM LuaChon WHERE MaCauHoi = '" + txtMaCauHoi.Text.Trim() + "'";
            adap = new SqlDataAdapter(query, db.Connection);
            adap.Fill(LuaChon);

            dgvLuaChon.DataSource = LuaChon;

            dgvLuaChon.Columns["MaLuaChon"].HeaderText = "Mã Lựa Chọn";
            dgvLuaChon.Columns["MaCauHoi"].HeaderText = "Mã Câu Hỏi";
            dgvLuaChon.Columns["DapAnA"].HeaderText = "Đáp Án A";
            dgvLuaChon.Columns["DapAnB"].HeaderText = "Đáp Án B";
            dgvLuaChon.Columns["DapAnC"].HeaderText = "Đáp Án C";
            dgvLuaChon.Columns["DapAnD"].HeaderText = "Đáp Án D";
            dgvLuaChon.Columns["DapAnDung"].HeaderText = "Đáp Án Đúng";


            //Đáp án đúng
            LoadDapAnDung();
            txtMaLuaChon.Enabled = false;
            btnThemLuaChon.Enabled = false;
        }

        private void LoadDapAnDung()
        {
            //Đáp án đúng
            string[] isCorrectStr = new string[] { "A", "B", "C", "D" };
            cboDapAnDung.Items.Clear();
            cboDapAnDung.Items.AddRange(isCorrectStr);
            cboDapAnDung.SelectedIndex = 0;
        }

        private void frmQuanLyChung_Load(object sender, EventArgs e)
        {

            //Người dùng
            LoadSinhVienData();
            LoadSapXepND();
            LoadVaiTro();

            //Môn Học
            string[] arrSortMH = { "", "Tăng dần theo mã", "Giảm dần theo mã", "Tăng dần theo tên", "Giảm dần theo tên" };
            LoadMonHoc();
            cboSapXep.Items.Clear();
            cboSapXep.Items.AddRange(arrSortMH);

            //Đề Thi
            LoadDeThi();

            string[] arrSortDT = {
                                    "",
                                    "Tăng dần theo mã",
                                    "Tăng dần theo tên",
                                    "Tăng dần theo môn học",
                                    "Giảm dần theo mức độ",
                                    "Giảm dần theo ngày tạo",
                                    "Giảm dần theo thời gian làm bài"
                                 };
            cboSapXepDT.Items.Clear();
            cboSapXepDT.Items.AddRange(arrSortDT);

            //Câu Hỏi
            LoadCauHoi();

            string[] arrSortCH = new string[]
            {
                "",
                "Tăng dần theo mã",
                "Tăng dần theo môn học",
                "Tăng dần theo mức độ",
                "Giảm dần theo mã",
                "Giảm dần theo môn học",
                "Giảm dần theo mức độ"
            };
            cboSapXepCH.Items.Clear();
            cboSapXepCH.Items.AddRange(arrSortCH);

        }

        //Môn Học
        private void txtTenMonHoc_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctr = (System.Windows.Forms.Control)sender;
            if (ctr.Text.Trim().Length > 0 && isNumber(ctr.Text.Trim()))
            {
                errorProvider1.SetError(ctr, "Vui lòng nhập văn bản thay vì số!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtTenMonHoc_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctr = (System.Windows.Forms.Control)sender;
            if (ctr.Text.Trim().Length > 0 && isNumber(ctr.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập văn bản thay vì số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenMonHoc.Clear();
                txtTenMonHoc.Focus();
            }
        }

        int posMonHoc = -1;
        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posMonHoc = e.RowIndex;
            if (posMonHoc == -1) return;
            txtMaMonHoc.Text = dgvMonHoc.Rows[posMonHoc].Cells[0].Value.ToString();
            txtTenMonHoc.Text = dgvMonHoc.Rows[posMonHoc].Cells[1].Value.ToString();
        }

        private void themMonHoc(string maMonHoc, string tenMonHoc)
        {
            try
            {
                db.OpenDB();

                if (!checkPK(maMonHoc, "MonHoc", "MaMonHoc") && !checkUniName(tenMonHoc))
                {
                    string query = "INSERT INTO MonHoc VALUES(N'" + maMonHoc + "', N'" + tenMonHoc + "')";
                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                        QLMonHoc.Tables[0].Rows.Clear();
                        LoadMonHoc();
                        btnThem.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Môn học đã tồn tại, vui lòng nhập môn học khác!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaMonHoc.Text.Trim().Length > 0 && txtTenMonHoc.Text.Trim().Length > 0)
            {
                string maMonHoc = txtMaMonHoc.Text.Trim();
                string tenMonHoc = txtTenMonHoc.Text.Trim();

                themMonHoc(maMonHoc, tenMonHoc);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin môn học!");
            }
        }

        private void btnTaoMMH_Click(object sender, EventArgs e)
        {

            Random rand = new Random();
            int index = rand.Next(1, 1000);

            string maMonHoc = "MH" + index.ToString("000");

            txtMaMonHoc.Text = maMonHoc;
            btnThem.Enabled = true;
        }

        private void suaMonHoc(string maMonHoc, string tenMonHoc)
        {
            try
            {
                db.OpenDB();
                if (checkPK(maMonHoc, "MonHoc", "MaMonHoc"))
                {
                    string query = "UPDATE MonHoc SET TenMonHoc = N'" + tenMonHoc + "' WHERE MaMonHoc = '" + maMonHoc + "'";

                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa thành công!");
                        QLMonHoc.Tables[0].Rows.Clear();
                        LoadMonHoc();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy môn học cần chỉnh sửa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaMonHoc.Text.Trim().Length > 0)
            {
                string maMonHoc = txtMaMonHoc.Text.Trim();
                string tenMonHoc = txtTenMonHoc.Text.Trim();

                suaMonHoc(maMonHoc, tenMonHoc);
            }
            else
            {
                MessageBox.Show("Mã môn học không được là trống!");
            }
        }

        private void xoaMonHoc(string maMonHoc)
        {
            try
            {
                db.OpenDB();
                if (checkPK(maMonHoc, "MonHoc", "MaMonHoc"))
                {
                    string query = "DELETE FROM MonHoc WHERE MaMonHoc = '" + maMonHoc + "'";

                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        QLMonHoc.Tables[0].Rows.Clear();
                        LoadMonHoc();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy môn học cần xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaMonHoc.Text.Trim().Length > 0)
            {
                string maMonHoc = txtMaMonHoc.Text.Trim();

                DialogResult r;
                r = MessageBox.Show("Bạn chắc chắn muốn xóa môn học này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    xoaMonHoc(maMonHoc);
                }
            }
            else
            {
                MessageBox.Show("Mã môn học không được là trống!");
            }
        }

        private void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cboSapXep.SelectedIndex;
            if (idx != -1)
            {
                string strSort = (string)cboSapXep.Items[idx];
                string textSearch = txtTimKiem.Text.Trim();

                DataView dv = new DataView(QLMonHoc.Tables[0]);

                dv.RowFilter =
                    "TenMonHoc LIKE '%" + textSearch +
                "' OR TenMonHoc LIKE '" + textSearch + "%' OR TenMonHoc LIKE '%" + textSearch + "%'";

                if (strSort.Equals("Tăng dần theo tên", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "TenMonHoc ASC";

                    dgvMonHoc.DataSource = dv;
                }
                else if (strSort.Equals("Giảm dần theo tên", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "TenMonHoc DESC";

                    dgvMonHoc.DataSource = dv;
                }
                else if (strSort.Equals("Tăng dần theo mã", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "MaMonHoc ASC";

                    dgvMonHoc.DataSource = dv;
                }
                else if (strSort.Equals("Giảm dần theo mã", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "MaMonHoc DESC";

                    dgvMonHoc.DataSource = dv;
                }
                else
                {
                    dgvMonHoc.DataSource = dv;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trường cần sắp xếp!");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtTimKiem.Text.Trim().Length >= 0)
            {
                string textSearch = txtTimKiem.Text.Trim();

                DataView dv = new DataView(QLMonHoc.Tables[0]);

                dv.RowFilter =
                    "TenMonHoc LIKE '%" + textSearch +
                    "' OR TenMonHoc LIKE '" + textSearch + "%' OR TenMonHoc LIKE '%" + textSearch + "%'";

                dgvMonHoc.DataSource = dv;
            }
        }


        //Đề Thi
        private void txtTenDeThi_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctr = (System.Windows.Forms.Control)sender;
            if (ctr.Text.Trim().Length > 0 && isNumber(ctr.Text.Trim()))
            {
                errorProvider1.SetError(ctr, "Vui lòng nhập văn bản thay vì số!");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtTenDeThi_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctr = (System.Windows.Forms.Control)sender;
            if (ctr.Text.Trim().Length > 0 && isNumber(ctr.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập văn bản thay vì số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenDeThi.Clear();
                txtTenDeThi.Focus();
            }
        }

        private void txtTGLamBai_TextChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctr = (System.Windows.Forms.Control)sender;
            if (ctr.Text.Trim().Length > 0 && !isPositiveInteger(ctr.Text.Trim()))
            {
                errorProvider1.SetError(ctr, "Vui lòng nhập số nguyên (số phút) thay vì chữ!");
            }
            else
            {
                if (ctr.Text.Trim().Length > 0 && Int32.Parse(ctr.Text.Trim()) < 15)
                {
                    errorProvider1.SetError(ctr, "Vui lòng nhập số phút >= 15 phút!");
                }
                else
                {
                    errorProvider1.Clear();
                }
            }
        }

        private void txtTGLamBai_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.Control ctr = (System.Windows.Forms.Control)sender;
            if (ctr.Text.Trim().Length > 0 && !isPositiveInteger(ctr.Text.Trim()))
            {
                MessageBox.Show("Vui lòng nhập số nguyên (số phút) thay vì chữ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTGLamBai.Clear();
                txtTGLamBai.Focus();
            }
            else
            {
                if (ctr.Text.Trim().Length > 0 && Int32.Parse(ctr.Text.Trim()) < 15)
                {
                    MessageBox.Show("Vui lòng nhập số phút >= 15 phút!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        int posDeThi = -1;


        private void dgvDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posDeThi = e.RowIndex;
            if (posDeThi == -1) return;
            txtMaDeThi.Text = dgvDeThi.Rows[posDeThi].Cells["MaDeThi"].Value.ToString();
            txtTenDeThi.Text = dgvDeThi.Rows[posDeThi].Cells["TenDeThi"].Value.ToString();
            cboMonHoc.DataBindings.Clear();
            cboMonHoc.DataBindings.Add(new Binding("SelectedValue", dgvDeThi.Rows[posDeThi].Cells["MaMonHoc"], "Value"));
            cboMucDo.DataBindings.Clear();
            cboMucDo.DataBindings.Add(new Binding("SelectedItem", dgvDeThi.Rows[posDeThi].Cells["MucDo"], "Value"));
            txtTGLamBai.Text = dgvDeThi.Rows[posDeThi].Cells["ThoiGianLamBai"].Value.ToString();
            mstNgayTao.Text = dgvDeThi.Rows[posDeThi].Cells["NgayTao"].Value.ToString();
        }

        private void themDeThi(string maDeThi, string tenDeThi, string maMonHoc, string mucDo, string ngayTao, string tgLamBai)
        {
            try
            {
                db.OpenDB();

                if (!checkPK(maDeThi, "DeThi", "MaDeThi"))
                {
                    string query = "INSERT INTO DeThi VALUES('" + maDeThi + "', N'" + tenDeThi + "', N'" + mucDo + "', " + tgLamBai + ", '" + ngayTao + "', '" + maMonHoc + "', NULL)";
                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                        DeThi.Rows.Clear();
                        LoadDeThi();
                        btnThemDT.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Đề Thi đã tồn tại, vui lòng nhập Đề Thi khác!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
            if (txtMaDeThi.Text.Trim().Length > 0 &&
                txtTenDeThi.Text.Trim().Length > 0 &&
                cboMucDo.SelectedItem != null &&
                txtTGLamBai.Text.Trim().Length > 0 &&
                mstNgayTao.Text.Trim().Length > 0 &&
                cboMonHoc.SelectedValue != null)
            {
                string maDeThi = txtMaDeThi.Text.Trim();
                string tenDeThi = txtTenDeThi.Text.Trim();
                string mucDo = (string)cboMucDo.SelectedItem;
                string tgLamBai = txtTGLamBai.Text.Trim();
                string[] arrDate = mstNgayTao.Text.Split('/');
                int day = int.Parse(arrDate[0]);
                int month = int.Parse(arrDate[1]);
                int year = int.Parse(arrDate[arrDate.Length - 1]);
                DateTime nt = new DateTime(year, month, day);
                string ngayTao = nt.ToString("yyyy/MM/dd");
                string maMonHoc = (string)cboMonHoc.SelectedValue;


                themDeThi(maDeThi, tenDeThi, maMonHoc.Trim(), mucDo.Trim(), ngayTao, tgLamBai);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đề thi!");
            }
        }

        private void btnTaoMaDT_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int index = rand.Next(1, 1000);

            string maDeThi = "DT" + index.ToString("000");

            txtMaDeThi.Text = maDeThi;
            btnThemDT.Enabled = true;
        }

        private void suaDeThi(string maDeThi, string tenDeThi, string maMonHoc, string mucDo, string ngayTao, string tgLamBai)
        {
            try
            {
                db.OpenDB();
                if (checkPK(maDeThi, "DeThi", "MaDeThi"))
                {
                    string query = "UPDATE DeThi SET TenDeThi = N'" + tenDeThi +
                        "', MucDo = N'" + mucDo + "', NgayTao = '" + ngayTao +
                        "', ThoiGianLamBai = " + tgLamBai + ", MaMonHoc = '" + maMonHoc +
                        "' WHERE MaDeThi = '" + maDeThi + "'";

                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa thành công!");
                        DeThi.Rows.Clear();
                        LoadDeThi();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đề thi cần chỉnh sửa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnSuaDT_Click(object sender, EventArgs e)
        {
            if (txtMaDeThi.Text.Trim().Length > 0)
            {
                string maDeThi = txtMaDeThi.Text.Trim();
                string tenDeThi = txtTenDeThi.Text.Trim();
                string mucDo = (string)cboMucDo.SelectedItem;
                string tgLamBai = txtTGLamBai.Text.Trim();
                string[] arrDate = mstNgayTao.Text.Split('/');
                int day = int.Parse(arrDate[0]);
                int month = int.Parse(arrDate[1]);
                int year = int.Parse(arrDate[arrDate.Length - 1]);
                DateTime nt = new DateTime(year, month, day);
                string ngayTao = nt.ToString("yyyy/MM/dd");
                string maMonHoc = (string)cboMonHoc.SelectedValue;

                suaDeThi(maDeThi, tenDeThi, maMonHoc.Trim(), mucDo.Trim(), ngayTao, tgLamBai);
            }
            else
            {
                MessageBox.Show("Mã đề thi không được để trống!");
            }
        }

        private void xoaDeThi(string maDeThi)
        {
            try
            {
                db.OpenDB();
                if (checkPK(maDeThi, "DeThi", "MaDeThi"))
                {
                    string query = "DELETE FROM DeThi WHERE MaDeThi = '" + maDeThi + "'";

                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        DeThi.Rows.Clear();
                        LoadDeThi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đề thi cần xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnXoaDT_Click(object sender, EventArgs e)
        {
            if (txtMaDeThi.Text.Trim().Length > 0)
            {
                string maDeThi = txtMaDeThi.Text.Trim();

                DialogResult r;
                r = MessageBox.Show("Bạn chắc chắn muốn xóa đề thi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    xoaDeThi(maDeThi);
                }
            }
            else
            {
                MessageBox.Show("Mã đề thi không được là trống!");
            }
        }

        private void cboSapXepDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cboSapXepDT.SelectedIndex;
            if (idx != -1)
            {
                string strSort = (string)cboSapXepDT.Items[idx];
                string textSearch = txtTimKiemDT.Text.Trim();

                DataView dv = new DataView(DeThi);

                dv.RowFilter =
                    "(TenDeThi LIKE '" + textSearch + "%' OR TenDeThi LIKE '%" + textSearch + "' OR TenDeThi LIKE '%" + textSearch + "%') OR " +
                    "(TenMonHoc LIKE '" + textSearch + "%' OR TenMonHoc LIKE '%" + textSearch + "' OR TenMonHoc LIKE '%" + textSearch + "%') OR " +
                    "(MucDo LIKE '" + textSearch + "%' OR MucDo LIKE '%" + textSearch + "' OR MucDo LIKE '%" + textSearch + "%')";

                if (strSort.Equals("Tăng dần theo tên", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "TenDeThi ASC";

                    dgvDeThi.DataSource = dv;
                }
                else if (strSort.Equals("Tăng dần theo môn học", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "TenMonHoc ASC";

                    dgvDeThi.DataSource = dv;
                }
                else if (strSort.Equals("Giảm dần theo mức độ", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "MucDo DESC";

                    dgvDeThi.DataSource = dv;
                }
                else if (strSort.Equals("Giảm dần theo ngày tạo", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "NgayTao DESC";

                    dgvDeThi.DataSource = dv;
                }
                else if (strSort.Equals("Giảm dần theo thời gian làm bài", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "ThoiGianLamBai DESC";

                    dgvDeThi.DataSource = dv;
                }
                else if (strSort.Equals("Tăng dần theo mã", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "MaDeThi ASC";

                    dgvDeThi.DataSource = dv;
                }
                else
                {
                    dgvDeThi.DataSource = dv;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trường cần sắp xếp!");
            }
        }

        private void btnTimKiemDT_Click(object sender, EventArgs e)
        {
            if (txtTimKiemDT.Text.Trim().Length >= 0)
            {
                string textSearch = txtTimKiemDT.Text.Trim();

                DataView dv = new DataView(DeThi);

                dv.RowFilter =
                    "(TenDeThi LIKE '" + textSearch + "%' OR TenDeThi LIKE '%" + textSearch + "' OR TenDeThi LIKE '%" + textSearch + "%') OR " +
                    "(TenMonHoc LIKE '" + textSearch + "%' OR TenMonHoc LIKE '%" + textSearch + "' OR TenMonHoc LIKE '%" + textSearch + "%') OR " +
                    "(MucDo LIKE '" + textSearch + "%' OR MucDo LIKE '%" + textSearch + "' OR MucDo LIKE '%" + textSearch + "%')";

                dgvDeThi.DataSource = dv;
            }
        }

        //Câu Hỏi

        int posCauHoi = -1;

        private void dgvCauHoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            posCauHoi = e.RowIndex;
            if (posCauHoi == -1) return;

            txtMaCauHoi.DataBindings.Clear();
            txtMaCauHoi.DataBindings.Add(new Binding("Text", dgvCauHoi.Rows[posCauHoi].Cells["MaCauHoi"], "Value"));

            cboMHCauHoi.DataBindings.Clear();
            cboMHCauHoi.DataBindings.Add(new Binding("SelectedValue", dgvCauHoi.Rows[posCauHoi].Cells["MaMonHoc"], "Value"));


            txtCauHoi.DataBindings.Clear();
            txtCauHoi.DataBindings.Add(new Binding("Text", dgvCauHoi.Rows[posCauHoi].Cells["NoiDungVanBan"], "Value"));


            cboMucDoCH.DataBindings.Clear();
            cboMucDoCH.DataBindings.Add(new Binding("SelectedItem", dgvCauHoi.Rows[posCauHoi].Cells["MucDo"], "Value"));


            //Lựa Chọn
            LuaChon.Rows.Clear();
            LoadLuaChon();

            tableLayoutPanel31.Enabled = true;

            if (!checkDapAn(txtMaCauHoi.Text.Trim()))
            {
                MessageBox.Show("Vui lòng bổ sung hoặc giảm bớt các đáp án");
                txtMaLuaChon.Clear();
                txtDapAnA.Clear();
                txtDapAnB.Clear();
                txtDapAnC.Clear();
                txtDapAnD.Clear();
                cboDapAnDung.SelectedIndex = 0;
                tableLayoutPanel30.Enabled = false;
                tableLayoutPanel35.Enabled = false;
            }
            else
            {
                tableLayoutPanel30.Enabled = true;
                tableLayoutPanel35.Enabled = true;
            }
        }

        private void btnTaoMaCauHoi_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int index = rand.Next(1, 1000);

            string maCauHoi = "CH" + index.ToString("000");

            txtMaCauHoi.Text = maCauHoi;
            btnThemCauHoi.Enabled = true;
        }

        private void themCauHoi(string maCauHoi, string noiDungVanBan, string mucDo, string maMonHoc)
        {
            try
            {
                db.OpenDB();

                if (!checkPK(maCauHoi, "CauHoi", "MaCauHoi"))
                {
                    string query = "INSERT INTO CauHoi VALUES('" + maCauHoi + "', N'" + noiDungVanBan + "', '" + mucDo + "', '" + maMonHoc + "')";
                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                        CauHoi.Rows.Clear();
                        LoadCauHoi();
                        tableLayoutPanel31.Enabled = true;
                        btnThemCauHoi.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Câu Hỏi đã tồn tại, vui lòng nhập Câu Hỏi khác!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnThemCauHoi_Click(object sender, EventArgs e)
        {
            if (txtMaCauHoi.Text.Trim().Length > 0 &&
                txtCauHoi.Text.Trim().Length > 0 &&
                cboMucDoCH.SelectedItem != null &&
                cboMHCauHoi.SelectedValue != null)
            {
                string maCauHoi = txtMaCauHoi.Text.Trim();
                string noiDungVB = txtCauHoi.Text.Trim();
                string mucDo = (string)cboMucDoCH.SelectedItem;
                string maMonHoc = (string)cboMHCauHoi.SelectedValue;

                themCauHoi(maCauHoi, noiDungVB, mucDo, maMonHoc);
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin câu hỏi!");
            }
        }

        private void suaCauHoi(string maCauHoi, string noiDungVanBan, string mucDo, string maMonHoc)
        {
            try
            {
                db.OpenDB();
                if (checkPK(maCauHoi, "CauHoi", "MaCauHoi"))
                {
                    string query = "UPDATE CauHoi SET NoiDungVanBan = N'" + noiDungVanBan +
                        "', MucDo = N'" + mucDo +
                        "', MaMonHoc = '" + maMonHoc + "' WHERE MaCauHoi = '" + maCauHoi + "'";

                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa thành công!");
                        CauHoi.Rows.Clear();
                        LoadCauHoi();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Câu Hỏi cần chỉnh sửa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!" + ex.Message);
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnSuaCauHoi_Click(object sender, EventArgs e)
        {
            if (txtMaCauHoi.Text.Trim().Length > 0)
            {
                string maCauHoi = txtMaCauHoi.Text.Trim();
                string noiDungVB = txtCauHoi.Text.Trim();
                string mucDo = (string)cboMucDoCH.SelectedItem;
                string maMonHoc = (string)cboMHCauHoi.SelectedValue;

                suaCauHoi(maCauHoi, noiDungVB, mucDo, maMonHoc);
            }
            else
            {
                MessageBox.Show("Mã câu hỏi không được để trống!");
            }
        }

        private void xoaCauHoi(string maCauHoi)
        {
            try
            {
                db.OpenDB();
                if (checkPK(maCauHoi, "CauHoi", "MaCauHoi"))
                {
                    string query = "DELETE FROM CauHoi WHERE MaCauHoi = '" + maCauHoi + "'";

                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        CauHoi.Rows.Clear();
                        LoadCauHoi();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy câu hỏi cần xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnXoaCauHoi_Click(object sender, EventArgs e)
        {
            if (txtMaCauHoi.Text.Trim().Length > 0)
            {
                string maCauHoi = txtMaCauHoi.Text.Trim();

                DialogResult r;
                r = MessageBox.Show("Bạn chắc chắn muốn xóa câu hỏi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (r == DialogResult.Yes)
                {
                    xoaCauHoi(maCauHoi);
                }
            }
            else
            {
                MessageBox.Show("Mã câu hỏi không được là trống!");
            }
        }

        //Lựa Chọn

        int postLuaChon = -1;
        private void dgvLuaChon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            postLuaChon = e.RowIndex;
            if (postLuaChon == -1) return;
            txtMaLuaChon.DataBindings.Clear();
            txtMaLuaChon.DataBindings.Add(new Binding("Text", dgvLuaChon.Rows[postLuaChon].Cells["MaLuaChon"], "Value"));

            txtDapAnA.DataBindings.Clear();
            txtDapAnA.DataBindings.Add(new Binding("Text", dgvLuaChon.Rows[postLuaChon].Cells["DapAnA"], "Value"));
            txtDapAnB.DataBindings.Clear();
            txtDapAnB.DataBindings.Add(new Binding("Text", dgvLuaChon.Rows[postLuaChon].Cells["DapAnB"], "Value"));
            txtDapAnC.DataBindings.Clear();
            txtDapAnC.DataBindings.Add(new Binding("Text", dgvLuaChon.Rows[postLuaChon].Cells["DapAnC"], "Value"));
            txtDapAnD.DataBindings.Clear();
            txtDapAnD.DataBindings.Add(new Binding("Text", dgvLuaChon.Rows[postLuaChon].Cells["DapAnD"], "Value"));

            string dapAnDung = dgvLuaChon.Rows[postLuaChon].Cells["DapAnDung"].Value.ToString().Trim();
            if (dapAnDung == "A")
                cboDapAnDung.SelectedIndex = 0;
            else if (dapAnDung == "B")
                cboDapAnDung.SelectedIndex = 1;
            else if (dapAnDung == "C")
                cboDapAnDung.SelectedIndex = 2;
            else
                cboDapAnDung.SelectedIndex = 3;
        }

        private void btnTaoMaLuaChon_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int index = rand.Next(1, 9999);

            string maCauHoi = "LC" + index.ToString("0000");

            txtMaLuaChon.Text = maCauHoi;
            btnThemLuaChon.Enabled = true;
        }

        private void themLuaChon(string maLuaChon, string dapAnA, string dapAnB, string dapAnC, string dapAnD, string dapAnDung, string maCauHoi)
        {
            try
            {
                db.OpenDB();

                if (!checkPK(maLuaChon, "LuaChon", "MaLuaChon"))
                {
                    string query = "INSERT INTO LuaChon VALUES('" + maLuaChon + "', '" + maCauHoi + "', N'" + dapAnA + "', N'" + dapAnB + "', N'" + dapAnC + "', N'" + dapAnD + "', '" + dapAnDung + "')";
                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Thêm thành công!");
                        LuaChon.Rows.Clear();
                        LoadLuaChon();
                        btnThemLuaChon.Enabled = false;

                        if (!checkDapAn(maCauHoi))
                        {
                            MessageBox.Show("Vui lòng bổ sung hoặc giảm bớt các đáp án");
                            tableLayoutPanel30.Enabled = false;
                            tableLayoutPanel35.Enabled = false;
                        }
                        else
                        {
                            tableLayoutPanel30.Enabled = true;
                            tableLayoutPanel35.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Lựa Chọn đã tồn tại, vui lòng nhập Lựa Chọn khác!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnThemLuaChon_Click(object sender, EventArgs e)
        {
            if (txtMaCauHoi.Text.Trim().Length > 0 &&
                txtCauHoi.Text.Trim().Length > 0 &&
                cboMucDoCH.SelectedItem != null &&
                cboMHCauHoi.SelectedValue != null)
            {
                string dapAnA = txtDapAnA.Text.Trim();
                string dapAnB = txtDapAnB.Text.Trim();
                string dapAnC = txtDapAnC.Text.Trim();
                string dapAnD = txtDapAnD.Text.Trim();
                string maLuaChon = txtMaLuaChon.Text.Trim();
                string maCauHoi = txtMaCauHoi.Text.Trim();

                if (txtMaLuaChon.Text.Trim().Length > 0 &&
                    cboDapAnDung.SelectedItem != null &&
                    ((!string.IsNullOrEmpty(dapAnA) && !string.IsNullOrEmpty(dapAnB)) ||
                    (!string.IsNullOrEmpty(dapAnA) && !string.IsNullOrEmpty(dapAnC)) ||
                    (!string.IsNullOrEmpty(dapAnA) && !string.IsNullOrEmpty(dapAnD)) ||
                    (!string.IsNullOrEmpty(dapAnB) && !string.IsNullOrEmpty(dapAnC)) ||
                    (!string.IsNullOrEmpty(dapAnB) && !string.IsNullOrEmpty(dapAnD)) ||
                    (!string.IsNullOrEmpty(dapAnC) && !string.IsNullOrEmpty(dapAnD))
                    ))
                {
                    string dapAnDung = (string)cboDapAnDung.SelectedItem;
                    themLuaChon(maLuaChon, dapAnA, dapAnB, dapAnC, dapAnD, dapAnDung, maCauHoi);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin lựa chọn hoặc nhập tối thiểu là 2 đáp án!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Câu Hỏi cần thêm đáp án!");
            }

        }

        private void suaLuaChon(string maLuaChon, string dapAnA, string dapAnB, string dapAnC, string dapAnD, string dapAnDung, string maCauHoi)
        {
            try
            {
                db.OpenDB();
                if (checkPK(maLuaChon, "LuaChon", "MaLuaChon"))
                {
                    string query = "UPDATE LuaChon SET DapAnA = N'" + dapAnA +
                        "', DapAnB = N'" + dapAnB + "', DapAnC = N'" + dapAnC + "', DapAnD = N'" + dapAnD + "', DapAnDung = '" + dapAnDung + "', MaCauHoi = '" +
                        maCauHoi + "' WHERE MaLuaChon = '" + maLuaChon + "'";

                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Sửa thành công!");
                        LuaChon.Rows.Clear();
                        LoadLuaChon();
                    }
                    else
                    {
                        MessageBox.Show("Sửa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy Lựa Chọn cần chỉnh sửa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnSuaLuaChon_Click(object sender, EventArgs e)
        {
            if (txtMaCauHoi.Text.Trim().Length > 0 &&
                txtCauHoi.Text.Trim().Length > 0 &&
                cboMucDoCH.SelectedItem != null &&
                cboMHCauHoi.SelectedValue != null)
            {
                string dapAnA = txtDapAnA.Text.Trim();
                string dapAnB = txtDapAnB.Text.Trim();
                string dapAnC = txtDapAnC.Text.Trim();
                string dapAnD = txtDapAnD.Text.Trim();
                string maLuaChon = txtMaLuaChon.Text.Trim();
                string maCauHoi = txtMaCauHoi.Text.Trim();

                if (txtMaLuaChon.Text.Trim().Length > 0 &&
                    cboDapAnDung.SelectedItem != null &&
                    ((!string.IsNullOrEmpty(dapAnA) && !string.IsNullOrEmpty(dapAnB)) ||
                    (!string.IsNullOrEmpty(dapAnA) && !string.IsNullOrEmpty(dapAnC)) ||
                    (!string.IsNullOrEmpty(dapAnA) && !string.IsNullOrEmpty(dapAnD)) ||
                    (!string.IsNullOrEmpty(dapAnB) && !string.IsNullOrEmpty(dapAnC)) ||
                    (!string.IsNullOrEmpty(dapAnB) && !string.IsNullOrEmpty(dapAnD)) ||
                    (!string.IsNullOrEmpty(dapAnC) && !string.IsNullOrEmpty(dapAnD))
                    ))
                {
                    string dapAnDung = cboDapAnDung.SelectedItem.ToString();
                    suaLuaChon(maLuaChon, dapAnA, dapAnB, dapAnC, dapAnD, dapAnDung, maCauHoi);
                }
                else
                {
                    MessageBox.Show("Mã Lựa Chọn không được để trống!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Câu Hỏi cần để chỉnh sửa đáp án!");
            }
        }

        private void xoaLuaChon(string maLuaChon, string maCauHoi)
        {
            try
            {
                db.OpenDB();
                if (checkPK(maLuaChon, "LuaChon", "MaLuaChon"))
                {
                    string query = "DELETE FROM LuaChon WHERE MaLuaChon = '" + maLuaChon + "'";

                    int kq = db.GetNonQuery(query);
                    if (kq > 0)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LuaChon.Rows.Clear();
                        LoadLuaChon();

                        if (!checkDapAn(maCauHoi))
                        {
                            MessageBox.Show("Vui lòng bổ sung hoặc giảm bớt các đáp án");
                            tableLayoutPanel30.Enabled = false;
                            tableLayoutPanel35.Enabled = false;
                        }
                        else
                        {
                            tableLayoutPanel30.Enabled = true;
                            tableLayoutPanel35.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lựa chọn cần xóa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể thực hiện được thao tác!");
            }
            finally
            {
                db.CloseDB();
            }
        }

        private void btnXoaLuaChon_Click(object sender, EventArgs e)
        {
            if (txtMaCauHoi.Text.Trim().Length > 0 &&
                txtCauHoi.Text.Trim().Length > 0 &&
                cboMucDoCH.SelectedItem != null &&
                cboMHCauHoi.SelectedValue != null)
            {
                if (txtMaLuaChon.Text.Trim().Length > 0)
                {
                    string maLuaChon = txtMaLuaChon.Text.Trim();
                    string maCauHoi = txtMaCauHoi.Text.Trim();

                    DialogResult r;
                    r = MessageBox.Show("Bạn chắc chắn muốn xóa lựa chọn này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (r == DialogResult.Yes)
                    {
                        xoaLuaChon(maLuaChon, maCauHoi);
                    }
                }
                else
                {
                    MessageBox.Show("Mã lựa chọn không được là trống!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn Câu Hỏi cần để xóa đáp án!");
            }
        }

        private void cboDapAnDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cboDapAnDung.SelectedIndex;
            string dapAnA = txtDapAnA.Text.Trim();
            string dapAnB = txtDapAnB.Text.Trim();
            string dapAnC = txtDapAnC.Text.Trim();
            string dapAnD = txtDapAnD.Text.Trim();

            if (!string.IsNullOrEmpty(dapAnA) ||
                !string.IsNullOrEmpty(dapAnB) ||
                !string.IsNullOrEmpty(dapAnC) ||
                !string.IsNullOrEmpty(dapAnD))
            {
                if ((cboDapAnDung.Items[idx].ToString() == "A" && string.IsNullOrEmpty(dapAnA)) ||
                    (cboDapAnDung.Items[idx].ToString() == "B" && string.IsNullOrEmpty(dapAnB)) ||
                    (cboDapAnDung.Items[idx].ToString() == "C" && string.IsNullOrEmpty(dapAnC)) ||
                    (cboDapAnDung.Items[idx].ToString() == "D" && string.IsNullOrEmpty(dapAnD)))
                {
                    MessageBox.Show("Vui lòng chọn đáp án đúng tương ứng với đáp án đã tồn tại!");
                }
            }
        }

        private void btnResetCauHoi_Click(object sender, EventArgs e)
        {
            cboMHCauHoi.SelectedIndex = 0;
            txtMaCauHoi.Clear();
            txtCauHoi.Clear();
            cboMucDoCH.SelectedIndex = 0;
            txtMaLuaChon.Clear();
            txtDapAnA.Clear();
            txtDapAnB.Clear();
            txtDapAnC.Clear();
            txtDapAnD.Clear();
            cboDapAnDung.SelectedIndex = 0;
            LuaChon.Rows.Clear();
            tableLayoutPanel31.Enabled = false;
        }

        private void cboSapXepCH_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cboSapXepCH.SelectedIndex;
            if (idx != -1)
            {
                string strSort = (string)cboSapXepCH.Items[idx];
                string textSearch = txtSearchCH.Text.Trim();

                DataView dv = new DataView(CauHoi);

                dv.RowFilter =
                    "(NoiDungVanBan LIKE '" + textSearch + "%' OR NoiDungVanBan LIKE '%" + textSearch + "' OR NoiDungVanBan LIKE '%" + textSearch + "%') OR " +
                    "(TenMonHoc LIKE '" + textSearch + "%' OR TenMonHoc LIKE '%" + textSearch + "' OR TenMonHoc LIKE '%" + textSearch + "%') OR " +
                    "(MucDo LIKE '" + textSearch + "%' OR MucDo LIKE '%" + textSearch + "' OR MucDo LIKE '%" + textSearch + "%')";

                if (strSort.Equals("Tăng dần theo mã", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "MaCauHoi ASC";

                    dgvCauHoi.DataSource = dv;
                }
                else if (strSort.Equals("Tăng dần theo môn học", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "TenMonHoc ASC";

                    dgvCauHoi.DataSource = dv;
                }
                else if (strSort.Equals("Tăng dần theo mức độ", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "MucDo ASC";

                    dgvCauHoi.DataSource = dv;
                }
                else if (strSort.Equals("Giảm dần theo mã", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "MaCauHoi DESC";

                    dgvCauHoi.DataSource = dv;
                }
                else if (strSort.Equals("Giảm dần theo môn học", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "TenMonHoc DESC";

                    dgvCauHoi.DataSource = dv;
                }
                else if (strSort.Equals("Giảm dần theo mức độ", StringComparison.OrdinalIgnoreCase))
                {
                    dv.Sort = "MucDo DESC";

                    dgvCauHoi.DataSource = dv;
                }
                else
                {
                    dgvCauHoi.DataSource = dv;
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn trường cần sắp xếp!");
            }

        }

        private void btnSearchCH_Click(object sender, EventArgs e)
        {
            if (txtSearchCH.Text.Trim().Length >= 0)
            {
                string textSearch = txtSearchCH.Text.Trim();

                DataView dv = new DataView(CauHoi);

                dv.RowFilter =
                    "(NoiDungVanBan LIKE '" + textSearch + "%' OR NoiDungVanBan LIKE '%" + textSearch + "' OR NoiDungVanBan LIKE '%" + textSearch + "%') OR " +
                    "(TenMonHoc LIKE '" + textSearch + "%' OR TenMonHoc LIKE '%" + textSearch + "' OR TenMonHoc LIKE '%" + textSearch + "%') OR " +
                    "(MucDo LIKE '" + textSearch + "%' OR MucDo LIKE '%" + textSearch + "' OR MucDo LIKE '%" + textSearch + "%')";

                dgvCauHoi.DataSource = dv;
            }
        }

        private void tableLayoutPanel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel45_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvMonHoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDeThi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cboSapXepQLND_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sortOption = cboSapXepQLND.SelectedItem.ToString();
            string sortOrder = (sortOption == "Tăng dần") ? "ASC" : "DESC";
            SortAndRefreshDataGridView(sortOrder);
        }
        private void SortAndRefreshDataGridView(string sortOrder)
        {

            db.Connection.Open();

            string query = $"SELECT * FROM NguoiDung ORDER BY Username {sortOrder}";

            using (SqlDataAdapter adapter = new SqlDataAdapter(query, db.Connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dgVQLND.DataSource = dataTable;
            }
            db.Connection.Close();
        }

        private void cboUserName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        
    }
}
