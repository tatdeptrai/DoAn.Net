namespace DoAnMonHoc_MultipleChoiceApp.Forms
{
    partial class frmTrangChu
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
            label1 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Trebuchet MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(1008, 241);
            label1.Name = "label1";
            label1.Size = new Size(116, 40);
            label1.TabIndex = 0;
            label1.Text = "HELLO";
            // 
            // frmTrangChu
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.undraw_Hello_re_3evm__1_;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1335, 784);
            Controls.Add(label1);
            Margin = new Padding(5);
            Name = "frmTrangChu";
            Text = "Trang chủ";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
    }
}