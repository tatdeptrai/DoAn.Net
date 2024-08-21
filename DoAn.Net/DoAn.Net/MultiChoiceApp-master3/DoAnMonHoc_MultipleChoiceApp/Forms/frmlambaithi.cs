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
using System.Collections.Specialized;

namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    public partial class frmlambaithi : Form
    {
        SqlConnection ketnoi;
        DataSet ds_mh;
        SqlDataAdapter da_mh;
        int[] a;
        List<pair> ketquaa = new List<pair>();
        Dictionary<int, int> dapann = new Dictionary<int, int>();
        Dictionary<int, string> ketqua = new Dictionary<int, string>();
        string[] kq;
        int soCauDung;
        int soCauSai;
        int questionNumber;
        string mmh, mdt, usn,mnd;
        int lanthi;
        int tgianLambai;
        KetNoiDB db = new KetNoiDB();
        public frmlambaithi()
        {
            InitializeComponent();
            string ketnoistring = ConnStringConfig.ketnoistring;
            ketnoi = new SqlConnection(ketnoistring);
            timer1.Start();
        }


        public void goiData(string mmh, string mdt, int tg, string usn)
        {
            this.mmh = mmh;
            this.mdt = mdt;
            this.tgianLambai = tg;
            this.usn = usn;
           
        }
        private int currentQuestionNumber = 1;
        private int sl_cauhoi()
        {
            int sl = 0;
            string ketnoistring = ConnStringConfig.ketnoistring;
            ketnoi = new SqlConnection(ketnoistring);
            using (ketnoi)
            {
                ketnoi.Open();

                string query = "select count(stt) from dbo.GetQuestionsAndOptions('"+mmh+"','"+mdt+"')";

                using (SqlCommand command = new SqlCommand(query, ketnoi))
                {
                    sl = (int)command.ExecuteScalar() +1;
                }
            }
            kq = new string[sl];
            a = new int[sl];
            return sl;
        }

        private void taobtn(int sl_cauhoi)
        {
            float sl_dong = sl_cauhoi / 5;
            int top = 0;
            int k = 1;
            int l = 1;
            for (int i = 1; i <= 5; i++)
            {
                int left = 0;
                for (int j = 1; j <= sl_dong; j++)
                {
                    string m = k.ToString("000");
                    Button bt = new Button();
                    bt.Name = string.Format("cau{0}", k++);
                    bt.Tag = string.Format("{0}", m);
                    bt.Text = string.Format("Câu {0}", l++);
                    bt.Size = new Size(60, 35);
                    bt.Click += new EventHandler(bt_click);
                    bt.Margin = new Padding(10, 0, 0, 0);
                    lst_cauhoi.Controls.Add(bt);
                    bt.Top = top;
                    bt.Left = left;

                    left += 100;

                }
                top += 50;
            }

        }

        private async void bt_click(object sender, EventArgs e)
        {
            lbl_cauhoi.Text = string.Empty;
            txt_cauA.Text = string.Empty;
            txt_cauB.Text = string.Empty;
            txt_cauC.Text = string.Empty;
            txt_cauD.Text = string.Empty;
            if (rd1.Checked == true)
            {
                a[questionNumber] = 1;
                dapann[questionNumber] = 1;
            }
            else if (rd2.Checked == true)
            {
                a[questionNumber] = 2;
                dapann[questionNumber] = 2;
            }
            else if (rd3.Checked == true)
            {
                a[questionNumber] = 3;


                dapann[questionNumber] = 3;

            }
            else if (rd4.Checked == true)
            {
                a[questionNumber] = 4;


                dapann[questionNumber] = 4;

            }
           

            RefreshRd();
            if (sender is Button button)
            {
                questionNumber = int.Parse(button.Tag.ToString());
                LoadQuestion(questionNumber);

                if (a[questionNumber] != 0)
                {
                    RefreshRd();
                    switch (a[questionNumber])
                    {
                        case 1:
                            rd1.Checked = true;
                            break;
                        case 2:
                            rd2.Checked = true;
                            break;
                        case 3:
                            rd3.Checked = true;
                            break;
                        case 4:
                            rd4.Checked = true;
                            break;
                    }
                }
            }
        }
        private void check_cauhoi()
        {

            for (int i = 1; i <= dapann.Count; i++)
            {
                string tam = "";
                string ketquua = ketqua[i];

                if (dapann[i] == 1)
                {
                    tam = "A";
                    if (tam.ToLower() == ketquua.ToLower())
                    {
                        soCauDung++;
                    }
                    else
                    {
                        soCauSai++;
                    }
                }
                else if (dapann[i] == 2)
                {
                    tam = "B";
                    if (tam.ToLower() == ketquua.ToLower())
                    {
                        soCauDung++;
                    }
                    else
                    {
                        soCauSai++;
                    }

                }
                else if (dapann[i] == 3)
                {
                    tam = "C";
              
                    if (string.Equals(tam, ketquua, StringComparison.OrdinalIgnoreCase))
                    {
                        soCauSai++;
                    }
                    else
                    {
                        soCauDung++;
                    }
                }
                else if (dapann[i] == 4)
                {
                    tam = "D";
                    
                    if (string.Equals(tam, ketquua, StringComparison.OrdinalIgnoreCase))
                    {
                        soCauSai++;
                    }
                    else
                    {
                        soCauDung++;
                    }
                }
            }
        }
        private void RefreshRd()
        {

            rd1.Checked = false;
            rd2.Checked = false;
            rd3.Checked = false;
            rd4.Checked = false;


            rd1.ForeColor = Color.Black;
            rd2.ForeColor = Color.Black;
            rd3.ForeColor = Color.Black;
            rd4.ForeColor = Color.Black;
        }
        private void LoadQuestion(int questionNumber)
        {
            try
            {
                string ketnoistring = ConnStringConfig.ketnoistring;
                ketnoi = new SqlConnection(ketnoistring);
                ketnoi.Close();
                using (ketnoi)
                {
                    ketnoi.Open();

                    string query = "SELECT * FROM dbo.GetQuestionsAndOptions('"+mmh+"','"+mdt+"') WHERE STT = @QuestionNumber";

                    using (SqlCommand command = new SqlCommand(query, ketnoi))
                    {
                        // Assuming "STT" is an integer; adjust the SqlDbType accordingly
                        command.Parameters.AddWithValue("@QuestionNumber", questionNumber);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string cauHoi = reader["NoiDungVanBan"].ToString();
                                string dapAnA = reader["DapAnA"].ToString();
                                string dapAnB = reader["DapAnB"].ToString();
                                string dapAnC = reader["DapAnC"].ToString();
                                string dapAnD = reader["DapAnD"].ToString();
                                string dapAnDung = reader["DapAnDung"].ToString().Trim();
                                ketqua[questionNumber] = dapAnDung;                              
                                this.Invoke((MethodInvoker)delegate
                                {
                                    lbl_cauhoi.Text ="Câu "+questionNumber+": "+ cauHoi;
                                    txt_cauA.Text = dapAnA;
                                    txt_cauB.Text = dapAnB;
                                    txt_cauC.Text = dapAnC;
                                    txt_cauD.Text = dapAnD;
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ ở đây. Bạn có thể in ra thông báo, ghi vào log, hoặc thực hiện hành động phù hợp.
                MessageBox.Show($"Đã xảy ra ngoại lệ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rd1_CheckedChanged(object sender, EventArgs e)
        {
            if (rd1.Checked)
            {
                a[questionNumber] = 1;
            }

        }
        private string Get_MaNguoiDung()
        {
            string mnd = "";
            try
            {
                db.OpenDB();
                string sql = "select manguoidung from nguoidung where Username = '" + usn + "'";
                mnd = db.GetScalar(sql).ToString();
                db.CloseDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return mnd;
        }

        private bool checkMaNguoiDung(string mnd) 
        {
            mnd = mnd.Trim();
            int kq = 0;
            try
            {
                db.OpenDB();
                string q = "SELECT COUNT(*) FORM KetQua WHERE MaNguoiDung = " + mnd + "";
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
        private int Get_LanThi()
        {
            string mnd = Get_MaNguoiDung();
            int lanthi = -1;
            try
            {
                if (checkMaNguoiDung(mnd))
                {
					db.OpenDB();
					string sql = "select count(*) from ketqua where manguoidung = '" + mnd + "' and madethi = '" + mdt + "'";
					lanthi = Convert.ToInt32(db.GetScalar(sql));
					db.CloseDB();
				}
                else
                {
                    lanthi = 0;
                }    
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return lanthi ;
        }
        private void ins_Ketqua()
        {
            mnd = Get_MaNguoiDung();
            lanthi = Get_LanThi();
            lanthi++;
            string batdau = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                db.OpenDB();
                string sql = "insert into Ketqua Values(" + mnd + ",'" + mdt.Trim() + "'," + lanthi + ", NULL, NULL, NULL, '" + batdau + "', NULL)";
                db.GetNonQuery(sql);
                db.CloseDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void update_ketqua(decimal diem, int soCauDung, int soCauSai)
        {

            string THoiGianKT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            try
            {
                db.OpenDB();
                string sql = "update ketqua set diem = " + diem + ", SoCauDung = " + soCauDung + ", SoCauSai = " + soCauSai + ", thoigianketthuc = '" + THoiGianKT + "' where manguoidung = " + mnd + " and madethi = '" + mdt + "' and lanthi = " + lanthi + "";
                db.GetNonQuery(sql);
                db.CloseDB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ins_DapanSV( string macauhoi, string dapAn )
        {
            try
            {
                db.OpenDB();
                string sql = "insert into dapancuanguoidung values (" + mnd + ",'" + mdt + "'," + lanthi + ",'" + macauhoi + "','" + dapAn + "')";
                db.GetNonQuery(sql);
                db.CloseDB();
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private string Macauhoi(int stt)
        {
            string mch = "";
            try
            {
                db.OpenDB();
                string sql = "select macauhoi from dbo.GetQuestionsAndOptions('" + mmh + "','" + mdt + "') WHERE STT = " + stt + "";
                mch = db.GetScalar(sql).ToString();
                db.CloseDB();
            }catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            return mch;
        }
        private void dapAnSinhVien()
        {
            
            //string sql = "insert into Ketqua values()"
            for (int i = 1; i <= dapann.Count; i++)
            {
                int f = dapann[i];
                string mch = Macauhoi(i);
                switch (f)
                {
                    case 1:
                        {
                            ins_DapanSV(mch, "A");
                            break;
                        }
                    case 2:
                        {
                            ins_DapanSV(mch, "B");
                            break;
                        }
                    case 3:
                        {
                            ins_DapanSV(mch, "C");
                            break;
                        }
                    case 4:
                        {
                            ins_DapanSV(mch, "D");
                            break;
                        }
                }


            }
        }

        private void rd2_CheckedChanged(object sender, EventArgs e)
        {
            if (rd2.Checked)
            {
                a[questionNumber] = 2;
            }


        }

        private void rd3_CheckedChanged(object sender, EventArgs e)
        {
            if (rd3.Checked)
            {
                a[questionNumber] = 3;
            }

        }

        private void rd4_CheckedChanged(object sender, EventArgs e)
        {
            if (rd4.Checked)
            {
                a[questionNumber] = 4;
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btn_Nopbai_Click_1(object sender, EventArgs e)
        {
            timer1.Stop();
            check_cauhoi();
            txt_dung.Text = soCauDung.ToString();
            soCauSai = (sl_cauhoi() - soCauDung) - 1;
            txt_sai.Text = soCauSai.ToString();
            double diemMoiCau = 10.0 / (sl_cauhoi() - 1);
            decimal diem = (decimal)diemMoiCau * soCauDung;
            txt_diem.Text = diem.ToString();
            dapAnSinhVien();
            update_ketqua(diem, soCauDung, soCauSai);

        }

        private int remainingTimeInSeconds;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (remainingTimeInSeconds > 0)
            {
                remainingTimeInSeconds--;
                UpdateTimeLabel();

                if (remainingTimeInSeconds == 0)
                {
                    // Hết thời gian, thực hiện hành động sau khi hết thời gian (ví dụ: kiểm tra câu hỏi)
                    check_cauhoi();
                }
            }
        }
        private void UpdateTimeLabel()
        {
            int minutes = remainingTimeInSeconds / 60;
            int seconds = remainingTimeInSeconds % 60;

            lbphut.Text = minutes.ToString("D2");
            lbgiay.Text = seconds.ToString("D2");
        }

        private void StartTimer(int totalMinutes)
        {
            remainingTimeInSeconds = totalMinutes * 60;
            UpdateTimeLabel();

            timer1.Start();
        }

        private void frmlambaithi_Load_1(object sender, EventArgs e)
        {
            ins_Ketqua();
            LoadQuestion(currentQuestionNumber);
            StartTimer(tgianLambai);
            taobtn(sl_cauhoi());
            lbl_cauhoi.Text = string.Empty;
            txt_cauA.Text = string.Empty;
            txt_cauB.Text = string.Empty;
            txt_cauC.Text = string.Empty;
            txt_cauD.Text = string.Empty;
           
        }
    }
}
