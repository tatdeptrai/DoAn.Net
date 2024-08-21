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
    public partial class frmBaiThi : Form
    {
        SqlConnection ketnoi;
        SqlDataAdapter da;
        DataSet ds;
        private string tdn;
        public frmBaiThi(string tdn)
        {
            InitializeComponent();
            string ketnoistring = ConnStringConfig.ketnoistring;
            ketnoi = new SqlConnection(ketnoistring);
            this.tdn = tdn;
        }

        public void baithicombo()
        {
            ketnoi.Open();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from Monhoc", ketnoi);
            da.Fill(ds, "MonHoc");
            cbtenbaithi.DataSource = ds.Tables["MonHoc"];
            cbtenbaithi.DisplayMember = "TenMonHoc";
            cbtenbaithi.ValueMember = "MaMonHoc"; // Corrected column name
            ketnoi.Close();
        }
      
        private void frmBaiThi_Load_1(object sender, EventArgs e)
        {
            mtxt_Ngaythi.Text = DateTime.Now.ToString();
            baithicombo();
            txt_hoTen.Text = tdn;
          
        }

        private void load_DT( string mmh)
        {
            //ketnoi.Open();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from dethi where mamonhoc = '"+mmh+"'", ketnoi);
            da.Fill(ds, "Dethi");
           cmb_dethi.DataSource = ds.Tables["Dethi"];
            cmb_dethi.DisplayMember = "Tendethi";
            cmb_dethi.ValueMember = "Madethi"; // Corrected column name          
            ketnoi.Close();
        }
        private void load_TG(string mdt)
        {
            //ketnoi.Open();
            ds = new DataSet();
            da = new SqlDataAdapter("select * from dethi where madethi = '" + mdt + "'", ketnoi);
            da.Fill(ds, "Dethii");
            if (ds.Tables["Dethii"].Rows.Count > 0)
            {
                int thoiGianLamBai = Convert.ToInt32(ds.Tables["Dethii"].Rows[0]["Thoigianlambai"]);
                txt_thoiGian.Text = thoiGianLamBai.ToString();
            }
            ketnoi.Close();
        }
        private void cbtenbaithi_SelectedIndexChanged(object sender, EventArgs e)
        {
            string mmh = cbtenbaithi.SelectedValue.ToString();
			load_DT(mmh); 
        }
        int chillF = 1;
        private void btnbatdau_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            string mmh = cbtenbaithi.SelectedValue.ToString();
            string mdt = cmb_dethi.SelectedValue.ToString();
            int tg = int.Parse(txt_thoiGian.Text);
            frmlambaithi flb = new frmlambaithi();
            flb.goiData(mmh, mdt,tg, txt_hoTen.Text);
            flb.Show();
        }

        private void cmb_dethi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_dethi.SelectedValue != null)
            {
                string mdt = cmb_dethi.SelectedValue.ToString();
                //ds.Tables["Dethii"].Rows.Clear();
				load_TG(mdt);
            }    

        }
    }
}
