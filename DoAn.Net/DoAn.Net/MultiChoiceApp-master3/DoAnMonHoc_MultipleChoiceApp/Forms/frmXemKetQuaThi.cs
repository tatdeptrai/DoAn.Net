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

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
	public partial class frmXemKetQuaThi : Form
	{
		KetNoiDB db = new KetNoiDB();
		DataTable KetQua = new DataTable();
		DataTable MonHoc = new DataTable();
		DataTable DeThi = new DataTable();
		SqlDataAdapter da;
		private string username;
		private string maND;
		public frmXemKetQuaThi(string username)
		{
			InitializeComponent();
			this.username = username;
		}

		private string Get_MaNguoiDung()
		{
			string mnd = "";
			try
			{
				db.OpenDB();
				string sql = "select manguoidung from nguoidung where Username = '" + username + "'";
				mnd = db.GetScalar(sql).ToString();
				db.CloseDB();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message);
			}
			return mnd;
		}

		//Mon Hoc
		private void LoadMonHoc()
		{
			string q = "SELECT * FROM MonHoc";
			da = new SqlDataAdapter(q, db.Connection);
			da.Fill(MonHoc);

			cboMonHocXKQ.DataSource = MonHoc;
			cboMonHocXKQ.DisplayMember = "TenMonHoc";
			cboMonHocXKQ.ValueMember = "MaMonHoc";
		}	

		//De Thi
		private void LoadDeThi(string maMonHoc)
		{
			string q = "SELECT * FROM DeThi WHERE MaMonHoc = '" + maMonHoc.Trim() + "'";
			da = new SqlDataAdapter(q, db.Connection);
			da.Fill(DeThi);

			cboDeThiXKQ.DataSource = DeThi;
			cboDeThiXKQ.DisplayMember = "TenDeThi";
			cboDeThiXKQ.ValueMember = "MaDeThi";
		}

		//Ket Qua
		private void LoadKetQua(string maDeThi)
		{
			// Set font size for rows
			DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
			rowStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
			dgvKetQuaDiemThi.RowsDefaultCellStyle = rowStyle;

			// Set font size for header cells
			DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
			headerStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
			dgvKetQuaDiemThi.ColumnHeadersDefaultCellStyle = headerStyle;


			string maNguoiDung = Get_MaNguoiDung().Trim();
			string q = "SELECT Username, TenDeThi, LanThi, Diem, SoCauDung, SoCauSai, ThoiGianBatDau, ThoiGianKetThuc FROM DeThi dt JOIN KetQua kq ON dt.MaDeThi = kq.MaDeThi JOIN NguoiDung nd ON kq.MaNguoiDung = nd.MaNguoiDung WHERE nd.MaNguoiDung = " + maNguoiDung + " AND dt.MaDeThi = '" + maDeThi + "'";
			da = new SqlDataAdapter(q, db.Connection);
			da.Fill(KetQua);

			dgvKetQuaDiemThi.DataSource = KetQua;

			dgvKetQuaDiemThi.Columns["Username"].HeaderText = "Tên Người Dùng";
			dgvKetQuaDiemThi.Columns["TenDeThi"].HeaderText = "Tên Đề Thi";
			dgvKetQuaDiemThi.Columns["LanThi"].HeaderText = "Lần Thi";
			dgvKetQuaDiemThi.Columns["Diem"].HeaderText = "Điểm";
			dgvKetQuaDiemThi.Columns["SoCauDung"].HeaderText = "Số Câu Đúng";
			dgvKetQuaDiemThi.Columns["SoCauSai"].HeaderText = "Số Câu Sai";
			dgvKetQuaDiemThi.Columns["ThoiGianBatDau"].HeaderText = "TG Bắt Đầu";
			dgvKetQuaDiemThi.Columns["ThoiGianKetThuc"].HeaderText = "TG Kết Thúc";
		}

		private void frmXemKetQuaThi_Load(object sender, EventArgs e)
		{
			//Mon Hoc
			LoadMonHoc();

		}

		private void cboMonHocXKQ_SelectedIndexChanged(object sender, EventArgs e)
		{
			//De Thi
			if (cboMonHocXKQ.SelectedValue != null) 
			{
				string maMonHoc = cboMonHocXKQ.SelectedValue.ToString();
				DeThi.Rows.Clear();
				LoadDeThi(maMonHoc);
			}
		}

		private void cboDeThiXKQ_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Ket Qua
			if (cboDeThiXKQ.SelectedValue != null)
			{
				string maDeThi = cboDeThiXKQ.SelectedValue.ToString();
				KetQua.Rows.Clear();
				LoadKetQua(maDeThi);
			}	
		}

		int posKetQua = -1;
		private void dgvKetQuaDiemThi_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int posKetQua = e.RowIndex;
			if (posKetQua == -1) return;

			string username = dgvKetQuaDiemThi.Rows[posKetQua].Cells["Username"].Value.ToString().Trim();
			string tenDeThi = dgvKetQuaDiemThi.Rows[posKetQua].Cells["TenDeThi"].Value.ToString().Trim();
			int lanThi = int.Parse(dgvKetQuaDiemThi.Rows[posKetQua].Cells["LanThi"].Value.ToString().Trim());
			
			if (dgvKetQuaDiemThi.Rows[posKetQua].Cells["Diem"].Value.ToString() != "")
			{
				decimal diemSo = decimal.Parse(dgvKetQuaDiemThi.Rows[posKetQua].Cells["Diem"].Value.ToString().Trim());
				lblDiemSo.Text = diemSo.ToString("F2");
			}
			else
			{
				lblDiemSo.Text = "";
			}

			if (dgvKetQuaDiemThi.Rows[posKetQua].Cells["SoCauDung"].Value.ToString() != "")
			{
				int soCauDung = int.Parse(dgvKetQuaDiemThi.Rows[posKetQua].Cells["SoCauDung"].Value.ToString().Trim());
				lblSoCauDung.Text = soCauDung.ToString();
			}
			else
			{
				lblSoCauDung.Text = "";
			}	

			if (dgvKetQuaDiemThi.Rows[posKetQua].Cells["SoCauSai"].Value.ToString() != "")
			{
				int soCauSai = int.Parse(dgvKetQuaDiemThi.Rows[posKetQua].Cells["SoCauSai"].Value.ToString().Trim());
				lblSoCauSai.Text = soCauSai.ToString();
			}
			else
			{
				lblSoCauSai.Text = "";
			}
			DateTime tgBatDau = Convert.ToDateTime(dgvKetQuaDiemThi.Rows[posKetQua].Cells["ThoiGianBatDau"].Value.ToString().Trim());
			DateTime tgKetThuc = new DateTime();
			if (dgvKetQuaDiemThi.Rows[posKetQua].Cells["ThoiGianKetThuc"].Value.ToString() != "")
			{
				tgKetThuc = Convert.ToDateTime(dgvKetQuaDiemThi.Rows[posKetQua].Cells["ThoiGianKetThuc"].Value.ToString().Trim());
				lblTGKetThuc.Text = tgKetThuc.ToString("dd-MM-yyyy HH:mm:ss");
			}
			else
			{
				lblTGKetThuc.Text = "";
			}	

			lblUsername.Text = username;
			lblDeThi.Text = tenDeThi;
			lblLanThi.Text = lanThi.ToString();
			lblTGBatDau.Text = tgBatDau.ToString("dd-MM-yyyy HH:mm:ss");
			
		}
	}
}
