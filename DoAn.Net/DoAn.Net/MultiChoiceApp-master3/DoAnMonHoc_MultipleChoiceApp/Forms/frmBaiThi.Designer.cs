namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    partial class frmBaiThi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.btnbatdau = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.cbtenbaithi = new System.Windows.Forms.ComboBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.txt_hoTen = new System.Windows.Forms.TextBox();
			this.txt_thoiGian = new System.Windows.Forms.TextBox();
			this.mtxt_Ngaythi = new System.Windows.Forms.MaskedTextBox();
			this.cmb_dethi = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Trebuchet MS", 16.125F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(51, 23);
			this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(154, 35);
			this.label1.TabIndex = 0;
			this.label1.Text = "UserName:";
			// 
			// btnbatdau
			// 
			this.btnbatdau.BackColor = System.Drawing.Color.Black;
			this.btnbatdau.Font = new System.Drawing.Font("Trebuchet MS", 13.875F, System.Drawing.FontStyle.Bold);
			this.btnbatdau.ForeColor = System.Drawing.Color.Pink;
			this.btnbatdau.Location = new System.Drawing.Point(299, 302);
			this.btnbatdau.Margin = new System.Windows.Forms.Padding(1);
			this.btnbatdau.Name = "btnbatdau";
			this.btnbatdau.Size = new System.Drawing.Size(121, 41);
			this.btnbatdau.TabIndex = 4;
			this.btnbatdau.Text = "Bắt đầu ";
			this.btnbatdau.UseVisualStyleBackColor = false;
			this.btnbatdau.Click += new System.EventHandler(this.btnbatdau_Click_1);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Trebuchet MS", 16.125F, System.Drawing.FontStyle.Bold);
			this.label2.Location = new System.Drawing.Point(51, 81);
			this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 35);
			this.label2.TabIndex = 5;
			this.label2.Text = "Ngày thi :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Trebuchet MS", 16.125F, System.Drawing.FontStyle.Bold);
			this.label3.Location = new System.Drawing.Point(55, 139);
			this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 35);
			this.label3.TabIndex = 6;
			this.label3.Text = "Môn :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Trebuchet MS", 16.125F, System.Drawing.FontStyle.Bold);
			this.label4.Location = new System.Drawing.Point(51, 257);
			this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(233, 35);
			this.label4.TabIndex = 7;
			this.label4.Text = "Thời gian làm bài";
			// 
			// cbtenbaithi
			// 
			this.cbtenbaithi.FormattingEnabled = true;
			this.cbtenbaithi.Location = new System.Drawing.Point(237, 148);
			this.cbtenbaithi.Margin = new System.Windows.Forms.Padding(1);
			this.cbtenbaithi.Name = "cbtenbaithi";
			this.cbtenbaithi.Size = new System.Drawing.Size(221, 24);
			this.cbtenbaithi.TabIndex = 8;
			this.cbtenbaithi.SelectedIndexChanged += new System.EventHandler(this.cbtenbaithi_SelectedIndexChanged);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::DoAnMonHoc_MultipleChoiceApp.Properties.Resources.quiz;
			this.pictureBox1.Location = new System.Drawing.Point(537, 38);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(239, 252);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 9;
			this.pictureBox1.TabStop = false;
			// 
			// txt_hoTen
			// 
			this.txt_hoTen.Location = new System.Drawing.Point(237, 30);
			this.txt_hoTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txt_hoTen.Name = "txt_hoTen";
			this.txt_hoTen.Size = new System.Drawing.Size(221, 22);
			this.txt_hoTen.TabIndex = 10;
			// 
			// txt_thoiGian
			// 
			this.txt_thoiGian.Location = new System.Drawing.Point(311, 266);
			this.txt_thoiGian.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.txt_thoiGian.Name = "txt_thoiGian";
			this.txt_thoiGian.Size = new System.Drawing.Size(148, 22);
			this.txt_thoiGian.TabIndex = 12;
			// 
			// mtxt_Ngaythi
			// 
			this.mtxt_Ngaythi.Location = new System.Drawing.Point(237, 89);
			this.mtxt_Ngaythi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.mtxt_Ngaythi.Name = "mtxt_Ngaythi";
			this.mtxt_Ngaythi.Size = new System.Drawing.Size(221, 22);
			this.mtxt_Ngaythi.TabIndex = 13;
			// 
			// cmb_dethi
			// 
			this.cmb_dethi.FormattingEnabled = true;
			this.cmb_dethi.Location = new System.Drawing.Point(237, 208);
			this.cmb_dethi.Margin = new System.Windows.Forms.Padding(1);
			this.cmb_dethi.Name = "cmb_dethi";
			this.cmb_dethi.Size = new System.Drawing.Size(221, 24);
			this.cmb_dethi.TabIndex = 15;
			this.cmb_dethi.SelectedIndexChanged += new System.EventHandler(this.cmb_dethi_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Trebuchet MS", 16.125F, System.Drawing.FontStyle.Bold);
			this.label5.Location = new System.Drawing.Point(55, 197);
			this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(102, 35);
			this.label5.TabIndex = 14;
			this.label5.Text = "Đề thi:";
			// 
			// frmBaiThi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.MediumSlateBlue;
			this.ClientSize = new System.Drawing.Size(809, 363);
			this.Controls.Add(this.cmb_dethi);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.mtxt_Ngaythi);
			this.Controls.Add(this.txt_thoiGian);
			this.Controls.Add(this.txt_hoTen);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.cbtenbaithi);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnbatdau);
			this.Controls.Add(this.label1);
			this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.Name = "frmBaiThi";
			this.Text = "Đề thi";
			this.Load += new System.EventHandler(this.frmBaiThi_Load_1);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button btnbatdau;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbtenbaithi;
        private PictureBox pictureBox1;
        private TextBox txt_hoTen;
        private TextBox txt_thoiGian;
        private MaskedTextBox mtxt_Ngaythi;
        private ComboBox cmb_dethi;
        private Label label5;
    }
}