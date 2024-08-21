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
using System.Net.Http.Headers;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows;
using Grpc.Core;

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
	public partial class frmBaoCaoThongKe : Form
	{
		KetNoiDB db = new KetNoiDB();
		DataTable KetQua = new DataTable();
		DataTable BangDiemIn = new DataTable();
		DataTable MonHoc = new DataTable();
		DataTable DeThi = new DataTable();
		SqlDataAdapter da;
		public frmBaoCaoThongKe()
		{
			InitializeComponent();
		}

		//Mon Hoc
		private void LoadMonHoc()
		{
			string q = "SELECT * FROM MonHoc";
			da = new SqlDataAdapter(q, db.Connection);
			da.Fill(MonHoc);

			cboMonMonBaoCao.DataSource = MonHoc;
			cboMonMonBaoCao.DisplayMember = "TenMonHoc";
			cboMonMonBaoCao.ValueMember = "MaMonHoc";
		}

		//De Thi
		private void LoadDeThi(string maMonHoc)
		{
			string q = "SELECT * FROM DeThi WHERE MaMonHoc = '" + maMonHoc.Trim() + "'";
			da = new SqlDataAdapter(q, db.Connection);
			da.Fill(DeThi);

			cboDeThiBaoCao.DataSource = DeThi;
			cboDeThiBaoCao.DisplayMember = "TenDeThi";
			cboDeThiBaoCao.ValueMember = "MaDeThi";
		}

		//Ket Qua
		private void LoadKetQua(string maDeThi)
		{
			// Set font size for rows
			DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
			rowStyle.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			dgvKetQua.RowsDefaultCellStyle = rowStyle;

			// Set font size for header cells
			DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
			headerStyle.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
			dgvKetQua.ColumnHeadersDefaultCellStyle = headerStyle;

			string q = "SELECT Username, TenDeThi, LanThi, Diem, SoCauDung, SoCauSai, ThoiGianBatDau, ThoiGianKetThuc FROM DeThi dt JOIN KetQua kq ON dt.MaDeThi = kq.MaDeThi JOIN NguoiDung nd ON kq.MaNguoiDung = nd.MaNguoiDung WHERE dt.MaDeThi = '" + maDeThi + "'";
			da = new SqlDataAdapter(q, db.Connection);
			da.Fill(KetQua);

			dgvKetQua.DataSource = KetQua;

			dgvKetQua.Columns["Username"].HeaderText = "Tên Người Dùng";
			dgvKetQua.Columns["TenDeThi"].HeaderText = "Tên Đề Thi";
			dgvKetQua.Columns["LanThi"].HeaderText = "Lần Thi";
			dgvKetQua.Columns["Diem"].HeaderText = "Điểm";
			dgvKetQua.Columns["SoCauDung"].HeaderText = "Số Câu Đúng";
			dgvKetQua.Columns["SoCauSai"].HeaderText = "Số Câu Sai";
			dgvKetQua.Columns["ThoiGianBatDau"].HeaderText = "TG Bắt Đầu";
			dgvKetQua.Columns["ThoiGianKetThuc"].HeaderText = "TG Kết Thúc";
		}

		private void frmBaoCaoThongKe_Load(object sender, EventArgs e)
		{
			//Mon Hoc
			LoadMonHoc();
		}

		private void cboMonMonBaoCao_SelectedIndexChanged(object sender, EventArgs e)
		{
			//De Thi
			if (cboMonMonBaoCao.SelectedValue != null)
			{
				string maMonHoc = cboMonMonBaoCao.SelectedValue.ToString();
				DeThi.Rows.Clear();
				LoadDeThi(maMonHoc);
			}
		}

		private void cboDeThiBaoCao_SelectedIndexChanged(object sender, EventArgs e)
		{
			//Ket Qua
			if (cboDeThiBaoCao.SelectedValue != null)
			{
				string maDeThi = cboDeThiBaoCao.SelectedValue.ToString();
				KetQua.Rows.Clear();
				LoadKetQua(maDeThi);
			}
		}

		int posKetQua = -1;
		private void dgvKetQua_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			int posKetQua = e.RowIndex;
			if (posKetQua == -1) return;

			string username = dgvKetQua.Rows[posKetQua].Cells["Username"].Value.ToString().Trim();
			string tenDeThi = dgvKetQua.Rows[posKetQua].Cells["TenDeThi"].Value.ToString().Trim();
			int lanThi = int.Parse(dgvKetQua.Rows[posKetQua].Cells["LanThi"].Value.ToString().Trim());

			if (dgvKetQua.Rows[posKetQua].Cells["Diem"].Value.ToString() != "")
			{
				decimal diemSo = decimal.Parse(dgvKetQua.Rows[posKetQua].Cells["Diem"].Value.ToString().Trim());
				lblDiem.Text = diemSo.ToString("F2");
			}
			else
			{
				lblDiem.Text = "";
			}

			if (dgvKetQua.Rows[posKetQua].Cells["SoCauDung"].Value.ToString() != "")
			{
				int soCauDung = int.Parse(dgvKetQua.Rows[posKetQua].Cells["SoCauDung"].Value.ToString().Trim());
				lblSoCauDung.Text = soCauDung.ToString();
			}
			else
			{
				lblSoCauDung.Text = "";
			}

			if (dgvKetQua.Rows[posKetQua].Cells["SoCauSai"].Value.ToString() != "")
			{
				int soCauSai = int.Parse(dgvKetQua.Rows[posKetQua].Cells["SoCauSai"].Value.ToString().Trim());
				lblSoCauSai.Text = soCauSai.ToString();
			}
			else
			{
				lblSoCauSai.Text = "";
			}
			DateTime tgBatDau = Convert.ToDateTime(dgvKetQua.Rows[posKetQua].Cells["ThoiGianBatDau"].Value.ToString().Trim());
			DateTime tgKetThuc = new DateTime();
			if (dgvKetQua.Rows[posKetQua].Cells["ThoiGianKetThuc"].Value.ToString() != "")
			{
				tgKetThuc = Convert.ToDateTime(dgvKetQua.Rows[posKetQua].Cells["ThoiGianKetThuc"].Value.ToString().Trim());
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

		private void btnInBaoCao_Click(object sender, EventArgs e)
		{
			string maMonHoc = cboMonMonBaoCao.SelectedValue.ToString().Trim();
			string maDeThi = cboDeThiBaoCao.SelectedValue.ToString().Trim();

			string q = "SELECT mh.MaMonHoc, mh.TenMonHoc, dt.MaDeThi, dt.TenDeThi, Ho, Ten, Username, AVG(Diem) " +
				"FROM NguoiDung nd JOIN KetQua kq ON nd.MaNguoiDung = kq.MaNguoiDung " +
				"JOIN DeThi dt ON kq.MaDeThi = dt.MaDeThi JOIN MonHoc mh ON dt.MaMonHoc = mh.MaMonHoc " +
				"WHERE mh.MaMonHoc = '" + maMonHoc + "' AND dt.MaDeThi = '" + maDeThi + "' " +
				"GROUP BY mh.MaMonHoc, mh.TenMonHoc, dt.MaDeThi, dt.TenDeThi, Username, Ho, Ten";
			da = new SqlDataAdapter(q, db.Connection);
			da.Fill(BangDiemIn);

			//Gán nguồn dữ liệu cho Crystal Report
				
			rptBangDiem baoCao = new rptBangDiem();
			baoCao.SetDataSource(BangDiemIn);

			//Hiển thị báo cáo
			frmInBaoCao f = new frmInBaoCao();
			f.crystalReportViewer1.ReportSource = baoCao;
			f.ShowDialog();
		}
	}
}
