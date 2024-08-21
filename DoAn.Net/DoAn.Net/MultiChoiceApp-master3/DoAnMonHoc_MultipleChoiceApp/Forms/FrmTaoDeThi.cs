using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
	public partial class FrmTaoDeThi : Form
	{
		private KetNoiDB db;
		private SqlDataAdapter adap;
		private DataTable MonHoc = new DataTable();
		private DataTable DeThi = new DataTable();
		private DataTable CauHoi = new DataTable();
		private DataTable ChiTietDeThi = new DataTable();
		public FrmTaoDeThi()
		{
			InitializeComponent();
			db = new KetNoiDB();
		}

		private void LoadMonHoc()
		{
			string query = "SELECT * FROM MonHoc";
			adap = new SqlDataAdapter(query, db.Connection);
			adap.Fill(MonHoc);

			cboMHTaoDeThi.DataSource = MonHoc;
			cboMHTaoDeThi.DisplayMember = "TenMonHoc";
			cboMHTaoDeThi.ValueMember = "MaMonHoc";
		}

		private void LoadDeThi_MonHoc(string maMonHoc)
		{
			// Set font size for rows
			DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
			rowStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
			dgvDeThiTDT.RowsDefaultCellStyle = rowStyle;

			// Set font size for header cells
			DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
			headerStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
			dgvDeThiTDT.ColumnHeadersDefaultCellStyle = headerStyle;

			string query = "SELECT dt.MaDeThi, dt.TenDeThi, mh.MaMonHoc, mh.TenMonHoc, dt.MucDo, dt.ThoiGianLamBai, CONVERT(varchar, dt.NgayTao, 103) AS NgayTao FROM DeThi dt JOIN MonHoc mh ON dt.MaMonHoc = mh.MaMonHoc WHERE dt.MaMonHoc = '" + maMonHoc + "'";
			adap = new SqlDataAdapter(query, db.Connection);
			adap.Fill(DeThi);

			dgvDeThiTDT.DataSource = DeThi;

			dgvDeThiTDT.Columns["MaDeThi"].HeaderText = "Mã Đề Thi";
			dgvDeThiTDT.Columns["TenDeThi"].HeaderText = "Tên Đề Thi";
			dgvDeThiTDT.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";
			dgvDeThiTDT.Columns["MucDo"].HeaderText = "Mức Độ";
			dgvDeThiTDT.Columns["ThoiGianLamBai"].HeaderText = "Thời Gian Làm Bài";
			dgvDeThiTDT.Columns["NgayTao"].HeaderText = "Ngày Tạo";

			dgvDeThiTDT.Columns["MaMonHoc"].Visible = false;
		}

		private void LoadCauHoi_MonHoc(string maMonHoc)
		{
			// Set font size for rows
			DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
			rowStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
			dgvCauHoiTDT.RowsDefaultCellStyle = rowStyle;

			// Set font size for header cells
			DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
			headerStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
			dgvCauHoiTDT.ColumnHeadersDefaultCellStyle = headerStyle;

			string query = "SELECT ch.MaCauHoi, ch.NoiDungVanBan, ch.MucDo, mh.MaMonHoc, mh.TenMonHoc FROM MonHoc mh JOIN CauHoi ch ON mh.MaMonHoc = ch.MaMonHoc WHERE ch.MaMonHoc = '" + maMonHoc + "'";
			adap = new SqlDataAdapter(query, db.Connection);
			adap.Fill(CauHoi);

			dgvCauHoiTDT.DataSource = CauHoi;

			dgvCauHoiTDT.Columns["MaCauHoi"].HeaderText = "Mã Câu Hỏi";
			dgvCauHoiTDT.Columns["NoiDungVanBan"].HeaderText = "Nội Dung";
			dgvCauHoiTDT.Columns["MucDo"].HeaderText = "Mức Độ";
			dgvCauHoiTDT.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";

			dgvCauHoiTDT.Columns["MaMonHoc"].Visible = false;
		}

		//Chi Tiết Đề Thi
		private void LoadChiTietDeThi(string maMonHoc)
		{
			// Set font size for rows
			DataGridViewCellStyle rowStyle = new DataGridViewCellStyle();
			rowStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
			dgvChiTietDeThi.RowsDefaultCellStyle = rowStyle;

			// Set font size for header cells
			DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
			headerStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
			dgvChiTietDeThi.ColumnHeadersDefaultCellStyle = headerStyle;

			string q = "SELECT dt.MaDeThi, TenDeThi, ch.MaCauHoi, NoiDungVanBan, TenMonHoc FROM CauHoi ch JOIN ChiTietDeThi ct ON ch.MaCauHoi = ct.MaCauHoi JOIN DeThi dt ON ct.MaDeThi = dt.MaDeThi JOIN MonHoc mh ON dt.MaMonHoc = mh.MaMonHoc WHERE dt.MaMonHoc = '" + maMonHoc + "'";
			adap = new SqlDataAdapter(q, db.Connection);
			adap.Fill(ChiTietDeThi);

			dgvChiTietDeThi.DataSource = ChiTietDeThi;

			dgvChiTietDeThi.Columns["MaDeThi"].HeaderText = "Mã Đề Thi";
			dgvChiTietDeThi.Columns["TenDeThi"].HeaderText = "Tên Đề Thi";
			dgvChiTietDeThi.Columns["MaCauHoi"].HeaderText = "Mã Câu Hỏi";
			dgvChiTietDeThi.Columns["NoiDungVanBan"].HeaderText = "Nội Dung";
			dgvChiTietDeThi.Columns["TenMonHoc"].HeaderText = "Tên Môn Học";
		}

		private void FrmTaoDeThi_Load(object sender, EventArgs e)
		{
			//Môn Học
			LoadMonHoc();

			txtMaCauHoiTDT.Enabled = false;
			txtMaDeThiTDT.Enabled = false;

			txtMaDT_CTDT.Enabled = false;
			txtMaCH_CTDT.Enabled = false;

			string[] arrSort = new string[] { " ", "Tăng dần theo mã đề thi", "Giảm dần theo mã đề thi" };
			cboSortTaoDeThi.Items.AddRange(arrSort);
			cboSortTaoDeThi.SelectedIndex = 0;

		}

		int idx = -1;

		private void cboMHTaoDeThi_SelectedIndexChanged(object sender, EventArgs e)
		{
			idx = cboMHTaoDeThi.SelectedIndex;
			string maMonHoc = cboMHTaoDeThi.SelectedValue.ToString();

			//Đề Thi
			DeThi.Rows.Clear();
			LoadDeThi_MonHoc(maMonHoc);

			//Câu Hỏi
			CauHoi.Rows.Clear();
			LoadCauHoi_MonHoc(maMonHoc);

			//Chi Tiết Đề Thi
			ChiTietDeThi.Rows.Clear();
			LoadChiTietDeThi(maMonHoc);
		}

		//Đề Thi

		int posDeThi = -1;
		private void dgvDeThiTDT_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			posDeThi = e.RowIndex;
			if (posDeThi == -1) return;

			txtMaDeThiTDT.DataBindings.Clear();
			txtMaDeThiTDT.DataBindings.Add(new Binding("Text", dgvDeThiTDT.Rows[posDeThi].Cells["MaDeThi"] , "Value"));
		}


		//Câu Hỏi
		int posCauHoi = -1;

		private void dgvCauHoiTDT_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			posCauHoi = e.RowIndex;
			if (posCauHoi == -1) return;
			
			txtMaCauHoiTDT.DataBindings.Clear();
			txtMaCauHoiTDT.DataBindings.Add(new Binding("Text", dgvCauHoiTDT.Rows[posCauHoi].Cells["MaCauHoi"] , "Value"));
		}

		//Chi Tiết Đề Thi
		int posChiTietDeThi = -1;
		private void dgvChiTietDeThi_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			posChiTietDeThi = e.RowIndex;
			if (posChiTietDeThi == -1) return;

			txtMaCH_CTDT.DataBindings.Clear();
			txtMaCH_CTDT.DataBindings.Add(new Binding("Text", dgvChiTietDeThi.Rows[posChiTietDeThi].Cells["MaCauHoi"], "Value"));

			txtMaDT_CTDT.DataBindings.Clear();
			txtMaDT_CTDT.DataBindings.Add(new Binding("Text", dgvChiTietDeThi.Rows[posChiTietDeThi].Cells["MaDeThi"], "Value"));
		}

		private void btnAddDeThiTDT_Click(object sender, EventArgs e)
		{
			string maDeThi = txtMaDeThiTDT.Text.Trim();
			if (maDeThi.Length > 0)
			{
				txtMaDT_CTDT.Clear();
				txtMaDT_CTDT.Text = maDeThi;
			}
			else
			{
				MessageBox.Show("Vui lòng chọn đề thi cần thêm");
			}
		}

		private void btnAddCauHoiTDT_Click(object sender, EventArgs e)
		{
			string maCauHoi = txtMaCauHoiTDT.Text.Trim();
			if (maCauHoi.Length > 0)
			{
				txtMaCH_CTDT.Clear();
				txtMaCH_CTDT.Text = maCauHoi;
			}
			else
			{
				MessageBox.Show("Vui lòng chọn câu hỏi cần thêm");
			}
		}

		private void btnDelDeThiTDT_Click(object sender, EventArgs e)
		{
			txtMaDT_CTDT.Clear();
		}

		private void btnDelCauHoiTDT_Click(object sender, EventArgs e)
		{
			txtMaCH_CTDT.Clear();
		}

		//Reset
		private void btnResetCTDT_Click(object sender, EventArgs e)
		{
			txtMaDT_CTDT.Clear();
			txtMaCH_CTDT.Clear();
		}

		private bool checkPK(string maDeThi, string maCauHoi)
		{
			int kq = 0;
			try
			{
				db.OpenDB();
				string q = "SELECT COUNT(*) FROM ChiTietDeThi WHERE MaDeThi = '" + maDeThi + "' AND MaCauHoi = '" + maCauHoi + "'";
				kq = Convert.ToInt32(db.GetScalar(q));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thực hiện được thao tác");
			}
			finally
			{
				db.CloseDB();
			}
			if (kq == 1)
				return true;
			return false;
		}

		private bool checkPKMaDT(string maDeThi)
		{
			int kq = 0;
			try
			{
				db.OpenDB();
				string q = "SELECT COUNT(*) FROM ChiTietDeThi WHERE MaDeThi = '" + maDeThi + "'";
				kq = Convert.ToInt32(db.GetScalar(q));
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thực hiện được thao tác");
			}
			finally
			{
				db.CloseDB();
			}
			if (kq >= 1)
				return true;
			return false;
		}

		private void themCTDT(string maDeThi, string maCauHoi)
		{
			try
			{
				db.OpenDB();
				if (!checkPK(maDeThi, maCauHoi))
				{
					string q = "INSERT INTO ChiTietDeThi VALUES('" + maDeThi + "', '" + maCauHoi + "')";
					int kq = db.GetNonQuery(q);

					if (kq > 0)
					{
						MessageBox.Show("Thêm thành công!");
						ChiTietDeThi.Rows.Clear();
						LoadChiTietDeThi(cboMHTaoDeThi.SelectedValue.ToString());
					}
					else
					{
						MessageBox.Show("Thêm thất bại!");
					}	
				}	
				else
				{
					MessageBox.Show("Câu hỏi này đã có trong đề thi này rồi!");
				}	
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thực hiện được thao tác");
			}
			finally
			{
				db.CloseDB();
			}
		}

		private void btnAddCTDT_Click(object sender, EventArgs e)
		{
			string maDeThi = txtMaDT_CTDT.Text.Trim();
			string maCauHoi = txtMaCH_CTDT.Text.Trim();
			if (maDeThi.Length > 0 && maCauHoi.Length > 0)
			{
				themCTDT(maDeThi, maCauHoi);
			}	
			else
			{
				MessageBox.Show("Vui lòng chọn đề thi và câu hỏi cần thêm");
			}	
		}

		private void xoaCTDT(string maDeThi, string maCauHoi)
		{
			try
			{
				db.OpenDB();
				if (checkPK(maDeThi, maCauHoi))
				{
					string q = "DELETE FROM ChiTietDeThi WHERE MaDeThi = '" + maDeThi + "' AND MaCauHoi = '" + maCauHoi + "'";
					int kq = db.GetNonQuery(q);

					if (kq > 0)
					{
						MessageBox.Show("Xóa thành công!");
						ChiTietDeThi.Rows.Clear();
						LoadChiTietDeThi(cboMHTaoDeThi.SelectedValue.ToString());
					}
					else
					{
						MessageBox.Show("Xóa thất bại!");
					}
				}
				else
				{
					MessageBox.Show("Không tìm thấy câu hỏi của đề thi cần xóa!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thực hiện được thao tác");
			}
			finally
			{
				db.CloseDB();
			}
		}
		private void btnDelCTDT_Click(object sender, EventArgs e)
		{
			string maDeThi = txtMaDT_CTDT.Text.Trim();
			string maCauHoi = txtMaCH_CTDT.Text.Trim();
			if (maDeThi.Length > 0 && maCauHoi.Length > 0)
			{
				DialogResult r;
				r = MessageBox.Show("Bạn chắc chắn muốn xóa bản ghi này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (r == DialogResult.Yes)
				{
					xoaCTDT(maDeThi, maCauHoi);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn đề thi và câu hỏi cần xóa");
			}
		}

		private void themCTDTRandom(string maDeThi)
		{
			try
			{
				db.OpenDB();
				if (!checkPKMaDT(maDeThi))
				{
					string maMonHoc = cboMHTaoDeThi.SelectedValue.ToString();
					string q = "SELECT MaCauHoi FROM CauHoi WHERE MaMonHoc = '" + maMonHoc + "'";
					List<string> list = new List<string>();
					SqlDataReader reader = db.GetDataReader(q);

					if (reader.HasRows)
					{
						while (reader.Read())
						{
							list.Add(reader[0].ToString());
						}
					}
					reader.Close();

					Random r = new Random();
					int kq = 0;
					int slCauHoi = 20;

					if (list.Count <= slCauHoi)
						slCauHoi = list.Count;

					for (int i = 0; i < slCauHoi; i++)
					{
						while (true)
						{
							int idx = r.Next(list.Count);
							string maCauHoi = list[idx];

							if (!checkPK(maDeThi, maCauHoi))
							{
								try
								{
									db.OpenDB();
									string query = "INSERT INTO ChiTietDeThi VALUES('" + maDeThi + "', '" + maCauHoi + "')";
									kq = db.GetNonQuery(query);
								}
								catch (Exception ex)
								{
									MessageBox.Show("Không thực hiện được thao tác");
									return;
								}
								finally
								{
									db.CloseDB();
								}
								break;
							}

						}
					}
					if (kq > 0)
					{
						MessageBox.Show("Thêm thành công!");
						ChiTietDeThi.Rows.Clear();
						LoadChiTietDeThi(maMonHoc);
					}
					else
					{
						MessageBox.Show("Thêm thất bại!");
					}
				}	
				else
				{
					MessageBox.Show("Đề thi này đã tồn tại!");
				}	
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thực hiện được thao tác");
			}
			finally
			{
				db.CloseDB();
			}
		}

		private void btnAddRandCTDT_Click(object sender, EventArgs e)
		{
			string maDeThi = txtMaDT_CTDT.Text.Trim();
			if (maDeThi.Length > 0)
			{
				themCTDTRandom(maDeThi);
			}
			else
			{
				MessageBox.Show("Vui lòng chọn đề thi cần thêm");
			}
		}

		private void xoaAllCTDT(string maDeThi)
		{
			try
			{
				db.OpenDB();
				if (checkPKMaDT(maDeThi))
				{
					string q = "DELETE FROM ChiTietDeThi WHERE MaDeThi = '" + maDeThi + "'";
					int kq = db.GetNonQuery(q);

					if (kq > 0)
					{
						MessageBox.Show("Xóa thành công!");
						ChiTietDeThi.Rows.Clear();
						LoadChiTietDeThi(cboMHTaoDeThi.SelectedValue.ToString());
					}
					else
					{
						MessageBox.Show("Xóa thất bại!");
					}
				}
				else
				{
					MessageBox.Show("Không tìm thấy đề thi cần xóa!");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Không thực hiện được thao tác");
			}
			finally
			{
				db.CloseDB();
			}
		}

		private void btnXoaAllCTDT_Click(object sender, EventArgs e)
		{
			string maDeThi = txtMaDT_CTDT.Text.Trim();
			if (maDeThi.Length > 0)
			{
				DialogResult r;
				r = MessageBox.Show("Bạn chắc chắn muốn xóa tất cả bản ghi?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (r == DialogResult.Yes)
				{
					xoaAllCTDT(maDeThi);
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn đề thi cần xóa");
			}
		}

		private void cboSortTaoDeThi_SelectedIndexChanged(object sender, EventArgs e)
		{
			int idx = cboSortTaoDeThi.SelectedIndex;
			if (idx != -1)
			{
				string strSort = (string)cboSortTaoDeThi.Items[idx];
				string textSearch = txtSearchTaoDeThi.Text.Trim();

				DataView dv = new DataView(ChiTietDeThi);

				dv.RowFilter =
					"(MaDeThi LIKE '" + textSearch + "%' OR MaDeThi LIKE '%" + textSearch + "' OR MaDeThi LIKE '%" + textSearch + "%') OR " +
					"(TenDeThi LIKE '" + textSearch + "%' OR TenDeThi LIKE '%" + textSearch + "' OR TenDeThi LIKE '%" + textSearch + "%') OR " +
					"(MaCauHoi LIKE '" + textSearch + "%' OR MaCauHoi LIKE '%" + textSearch + "' OR MaCauHoi LIKE '%" + textSearch + "%') OR " +
					"(NoiDungVanBan LIKE '" + textSearch + "%' OR NoiDungVanBan LIKE '%" + textSearch + "' OR NoiDungVanBan LIKE '%" + textSearch + "%')";

				if (strSort.Equals("Tăng dần theo mã đề thi", StringComparison.OrdinalIgnoreCase))
				{
					dv.Sort = "MaDeThi ASC";

					dgvChiTietDeThi.DataSource = dv;
				}
				else if (strSort.Equals("Giảm dần theo mã đề thi", StringComparison.OrdinalIgnoreCase))
				{
					dv.Sort = "MaDeThi DESC";

					dgvChiTietDeThi.DataSource = dv;
				}
				else
				{
					dgvChiTietDeThi.DataSource = dv;
				}
			}
			else
			{
				MessageBox.Show("Vui lòng chọn trường cần sắp xếp!");
			}
		}

		private void btnSearchTaoDeThi_Click(object sender, EventArgs e)
		{
			if (txtSearchTaoDeThi.Text.Trim().Length >= 0)
			{
				string textSearch = txtSearchTaoDeThi.Text.Trim();

				DataView dv = new DataView(ChiTietDeThi);

				dv.RowFilter =
					"(MaDeThi LIKE '" + textSearch + "%' OR MaDeThi LIKE '%" + textSearch + "' OR MaDeThi LIKE '%" + textSearch + "%') OR " +
					"(TenDeThi LIKE '" + textSearch + "%' OR TenDeThi LIKE '%" + textSearch + "' OR TenDeThi LIKE '%" + textSearch + "%') OR " +
					"(MaCauHoi LIKE '" + textSearch + "%' OR MaCauHoi LIKE '%" + textSearch + "' OR MaCauHoi LIKE '%" + textSearch + "%') OR " +
					"(NoiDungVanBan LIKE '" + textSearch + "%' OR NoiDungVanBan LIKE '%" + textSearch + "' OR NoiDungVanBan LIKE '%" + textSearch + "%')";

				dgvChiTietDeThi.DataSource = dv;
			}
		}
	}
}
