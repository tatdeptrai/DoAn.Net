namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    partial class frmDoiMatKhau
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
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.btnDoi = new System.Windows.Forms.Button();
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.txtNhapLaiMatKhau = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkMK = new System.Windows.Forms.CheckBox();
            this.chkNLmk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mật khẩu cũ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.Location = new System.Drawing.Point(179, 47);
            this.txtMatKhauCu.Margin = new System.Windows.Forms.Padding(1);
            this.txtMatKhauCu.Multiline = true;
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.Size = new System.Drawing.Size(122, 24);
            this.txtMatKhauCu.TabIndex = 6;
            // 
            // btnDoi
            // 
            this.btnDoi.BackColor = System.Drawing.Color.Black;
            this.btnDoi.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold);
            this.btnDoi.ForeColor = System.Drawing.Color.Pink;
            this.btnDoi.Location = new System.Drawing.Point(131, 205);
            this.btnDoi.Margin = new System.Windows.Forms.Padding(1);
            this.btnDoi.Name = "btnDoi";
            this.btnDoi.Size = new System.Drawing.Size(102, 37);
            this.btnDoi.TabIndex = 7;
            this.btnDoi.Text = "Đổi";
            this.btnDoi.UseVisualStyleBackColor = false;
            this.btnDoi.Click += new System.EventHandler(this.btnDoi_Click);
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.Location = new System.Drawing.Point(179, 105);
            this.txtMatKhauMoi.Margin = new System.Windows.Forms.Padding(1);
            this.txtMatKhauMoi.Multiline = true;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.Size = new System.Drawing.Size(122, 24);
            this.txtMatKhauMoi.TabIndex = 8;
            // 
            // txtNhapLaiMatKhau
            // 
            this.txtNhapLaiMatKhau.Location = new System.Drawing.Point(179, 158);
            this.txtNhapLaiMatKhau.Margin = new System.Windows.Forms.Padding(1);
            this.txtNhapLaiMatKhau.Multiline = true;
            this.txtNhapLaiMatKhau.Name = "txtNhapLaiMatKhau";
            this.txtNhapLaiMatKhau.Size = new System.Drawing.Size(122, 24);
            this.txtNhapLaiMatKhau.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(10, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mật khẩu mới :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(10, 162);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "Nhập lại mật khẩu :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkMK
            // 
            this.chkMK.AutoSize = true;
            this.chkMK.ForeColor = System.Drawing.Color.Black;
            this.chkMK.Location = new System.Drawing.Point(239, 137);
            this.chkMK.Name = "chkMK";
            this.chkMK.Size = new System.Drawing.Size(72, 17);
            this.chkMK.TabIndex = 11;
            this.chkMK.Text = "Hiện / Ẩn";
            this.chkMK.UseVisualStyleBackColor = true;
            this.chkMK.CheckedChanged += new System.EventHandler(this.chkMK_CheckedChanged);
            // 
            // chkNLmk
            // 
            this.chkNLmk.AutoSize = true;
            this.chkNLmk.ForeColor = System.Drawing.Color.Black;
            this.chkNLmk.Location = new System.Drawing.Point(239, 186);
            this.chkNLmk.Name = "chkNLmk";
            this.chkNLmk.Size = new System.Drawing.Size(72, 17);
            this.chkNLmk.TabIndex = 12;
            this.chkNLmk.Text = "Hiện / Ẩn";
            this.chkNLmk.UseVisualStyleBackColor = true;
            this.chkNLmk.CheckedChanged += new System.EventHandler(this.chkNLmk_CheckedChanged);
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.ClientSize = new System.Drawing.Size(346, 252);
            this.Controls.Add(this.chkNLmk);
            this.Controls.Add(this.chkMK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNhapLaiMatKhau);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDoi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMatKhauCu);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDoiMatKhau";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tạo bài thi và câu hỏi";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label1;
        private TextBox txtMatKhauCu;
        private Button btnDoi;
        private TextBox txtMatKhauMoi;
        private TextBox txtNhapLaiMatKhau;
        private Label label3;
        private Label label2;
        private CheckBox chkMK;
        private CheckBox chkNLmk;
    }
}