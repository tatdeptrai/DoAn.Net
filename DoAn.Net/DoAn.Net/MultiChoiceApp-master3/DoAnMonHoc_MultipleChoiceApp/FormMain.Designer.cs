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
using FontAwesome.Sharp;
namespace DoAnMonHoc_MultipleChoiceApp
{
    partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.pnlMenu = new System.Windows.Forms.Panel();
			this.iconButton4 = new FontAwesome.Sharp.IconButton();
			this.iconButton3 = new FontAwesome.Sharp.IconButton();
			this.iconButton2 = new FontAwesome.Sharp.IconButton();
			this.iconButton1 = new FontAwesome.Sharp.IconButton();
			this.btnDangXuat = new FontAwesome.Sharp.IconButton();
			this.btnQuanLy = new FontAwesome.Sharp.IconButton();
			this.pnlLogo = new System.Windows.Forms.Panel();
			this.btnHome = new System.Windows.Forms.PictureBox();
			this.pnlTitleBar = new System.Windows.Forms.Panel();
			this.icnCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
			this.lblTitleChildForm = new System.Windows.Forms.Label();
			this.pnlShadow = new System.Windows.Forms.Panel();
			this.pnlDesktop = new System.Windows.Forms.Panel();
			this.iconButton5 = new FontAwesome.Sharp.IconButton();
			this.pnlMenu.SuspendLayout();
			this.pnlLogo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
			this.pnlTitleBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.icnCurrentChildForm)).BeginInit();
			this.SuspendLayout();
			// 
			// pnlMenu
			// 
			this.pnlMenu.BackColor = System.Drawing.Color.LavenderBlush;
			this.pnlMenu.Controls.Add(this.iconButton5);
			this.pnlMenu.Controls.Add(this.iconButton4);
			this.pnlMenu.Controls.Add(this.iconButton3);
			this.pnlMenu.Controls.Add(this.iconButton2);
			this.pnlMenu.Controls.Add(this.iconButton1);
			this.pnlMenu.Controls.Add(this.btnDangXuat);
			this.pnlMenu.Controls.Add(this.btnQuanLy);
			this.pnlMenu.Controls.Add(this.pnlLogo);
			this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlMenu.Location = new System.Drawing.Point(0, 0);
			this.pnlMenu.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.pnlMenu.Name = "pnlMenu";
			this.pnlMenu.Size = new System.Drawing.Size(289, 774);
			this.pnlMenu.TabIndex = 0;
			// 
			// iconButton4
			// 
			this.iconButton4.BackColor = System.Drawing.Color.Black;
			this.iconButton4.Dock = System.Windows.Forms.DockStyle.Top;
			this.iconButton4.FlatAppearance.BorderSize = 0;
			this.iconButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.iconButton4.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.iconButton4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconButton4.ForeColor = System.Drawing.Color.White;
			this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.Info;
			this.iconButton4.IconColor = System.Drawing.Color.White;
			this.iconButton4.IconSize = 32;
			this.iconButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton4.Location = new System.Drawing.Point(0, 360);
			this.iconButton4.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.iconButton4.Name = "iconButton4";
			this.iconButton4.Padding = new System.Windows.Forms.Padding(11, 0, 20, 0);
			this.iconButton4.Rotation = 0D;
			this.iconButton4.Size = new System.Drawing.Size(289, 62);
			this.iconButton4.TabIndex = 12;
			this.iconButton4.Text = "Xem kết quả";
			this.iconButton4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconButton4.UseVisualStyleBackColor = false;
			this.iconButton4.Click += new System.EventHandler(this.iconButton4_Click);
			// 
			// iconButton3
			// 
			this.iconButton3.BackColor = System.Drawing.Color.Black;
			this.iconButton3.Dock = System.Windows.Forms.DockStyle.Top;
			this.iconButton3.FlatAppearance.BorderSize = 0;
			this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.iconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.iconButton3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconButton3.ForeColor = System.Drawing.Color.White;
			this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
			this.iconButton3.IconColor = System.Drawing.Color.White;
			this.iconButton3.IconSize = 32;
			this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton3.Location = new System.Drawing.Point(0, 298);
			this.iconButton3.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.iconButton3.Name = "iconButton3";
			this.iconButton3.Padding = new System.Windows.Forms.Padding(11, 0, 20, 0);
			this.iconButton3.Rotation = 0D;
			this.iconButton3.Size = new System.Drawing.Size(289, 62);
			this.iconButton3.TabIndex = 11;
			this.iconButton3.Text = "Báo cáo và thống kê";
			this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconButton3.UseVisualStyleBackColor = false;
			this.iconButton3.Click += new System.EventHandler(this.iconButton3_Click);
			// 
			// iconButton2
			// 
			this.iconButton2.BackColor = System.Drawing.Color.Black;
			this.iconButton2.Dock = System.Windows.Forms.DockStyle.Top;
			this.iconButton2.FlatAppearance.BorderSize = 0;
			this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.iconButton2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconButton2.ForeColor = System.Drawing.Color.White;
			this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Ethernet;
			this.iconButton2.IconColor = System.Drawing.Color.White;
			this.iconButton2.IconSize = 32;
			this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton2.Location = new System.Drawing.Point(0, 236);
			this.iconButton2.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.iconButton2.Name = "iconButton2";
			this.iconButton2.Padding = new System.Windows.Forms.Padding(11, 0, 20, 0);
			this.iconButton2.Rotation = 0D;
			this.iconButton2.Size = new System.Drawing.Size(289, 62);
			this.iconButton2.TabIndex = 10;
			this.iconButton2.Text = "Tạo đề thi";
			this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconButton2.UseVisualStyleBackColor = false;
			this.iconButton2.Click += new System.EventHandler(this.iconButton2_Click_1);
			// 
			// iconButton1
			// 
			this.iconButton1.BackColor = System.Drawing.Color.Black;
			this.iconButton1.Dock = System.Windows.Forms.DockStyle.Top;
			this.iconButton1.FlatAppearance.BorderSize = 0;
			this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.iconButton1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconButton1.ForeColor = System.Drawing.Color.White;
			this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Question;
			this.iconButton1.IconColor = System.Drawing.Color.White;
			this.iconButton1.IconSize = 32;
			this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton1.Location = new System.Drawing.Point(0, 174);
			this.iconButton1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.iconButton1.Name = "iconButton1";
			this.iconButton1.Padding = new System.Windows.Forms.Padding(11, 0, 20, 0);
			this.iconButton1.Rotation = 0D;
			this.iconButton1.Size = new System.Drawing.Size(289, 62);
			this.iconButton1.TabIndex = 9;
			this.iconButton1.Text = "Đề thi";
			this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconButton1.UseVisualStyleBackColor = false;
			this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click_1);
			// 
			// btnDangXuat
			// 
			this.btnDangXuat.BackColor = System.Drawing.Color.Black;
			this.btnDangXuat.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnDangXuat.FlatAppearance.BorderSize = 0;
			this.btnDangXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDangXuat.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.btnDangXuat.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
			this.btnDangXuat.ForeColor = System.Drawing.Color.White;
			this.btnDangXuat.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
			this.btnDangXuat.IconColor = System.Drawing.Color.White;
			this.btnDangXuat.IconSize = 32;
			this.btnDangXuat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDangXuat.Location = new System.Drawing.Point(0, 726);
			this.btnDangXuat.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnDangXuat.Name = "btnDangXuat";
			this.btnDangXuat.Padding = new System.Windows.Forms.Padding(11, 0, 20, 0);
			this.btnDangXuat.Rotation = 0D;
			this.btnDangXuat.Size = new System.Drawing.Size(289, 48);
			this.btnDangXuat.TabIndex = 8;
			this.btnDangXuat.Text = "Đăng xuất";
			this.btnDangXuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDangXuat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnDangXuat.UseVisualStyleBackColor = false;
			this.btnDangXuat.Click += new System.EventHandler(this.btnDangXuat_Click_2);
			// 
			// btnQuanLy
			// 
			this.btnQuanLy.BackColor = System.Drawing.Color.Black;
			this.btnQuanLy.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnQuanLy.FlatAppearance.BorderSize = 0;
			this.btnQuanLy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnQuanLy.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.btnQuanLy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnQuanLy.ForeColor = System.Drawing.Color.White;
			this.btnQuanLy.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
			this.btnQuanLy.IconColor = System.Drawing.Color.White;
			this.btnQuanLy.IconSize = 32;
			this.btnQuanLy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQuanLy.Location = new System.Drawing.Point(0, 112);
			this.btnQuanLy.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnQuanLy.Name = "btnQuanLy";
			this.btnQuanLy.Padding = new System.Windows.Forms.Padding(11, 0, 20, 0);
			this.btnQuanLy.Rotation = 0D;
			this.btnQuanLy.Size = new System.Drawing.Size(289, 62);
			this.btnQuanLy.TabIndex = 2;
			this.btnQuanLy.Text = "Quản lý chung";
			this.btnQuanLy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnQuanLy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.btnQuanLy.UseVisualStyleBackColor = false;
			this.btnQuanLy.Click += new System.EventHandler(this.btnQuanLy_Click_1);
			// 
			// pnlLogo
			// 
			this.pnlLogo.BackColor = System.Drawing.Color.LavenderBlush;
			this.pnlLogo.Controls.Add(this.btnHome);
			this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlLogo.Location = new System.Drawing.Point(0, 0);
			this.pnlLogo.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.pnlLogo.Name = "pnlLogo";
			this.pnlLogo.Size = new System.Drawing.Size(289, 112);
			this.pnlLogo.TabIndex = 1;
			// 
			// btnHome
			// 
			this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
			this.btnHome.Location = new System.Drawing.Point(56, 20);
			this.btnHome.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.btnHome.Name = "btnHome";
			this.btnHome.Size = new System.Drawing.Size(155, 71);
			this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.btnHome.TabIndex = 0;
			this.btnHome.TabStop = false;
			this.btnHome.Click += new System.EventHandler(this.btnHome_Click_1);
			// 
			// pnlTitleBar
			// 
			this.pnlTitleBar.BackColor = System.Drawing.Color.LavenderBlush;
			this.pnlTitleBar.Controls.Add(this.icnCurrentChildForm);
			this.pnlTitleBar.Controls.Add(this.lblTitleChildForm);
			this.pnlTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitleBar.Location = new System.Drawing.Point(289, 0);
			this.pnlTitleBar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.pnlTitleBar.Name = "pnlTitleBar";
			this.pnlTitleBar.Size = new System.Drawing.Size(1382, 60);
			this.pnlTitleBar.TabIndex = 1;
			// 
			// icnCurrentChildForm
			// 
			this.icnCurrentChildForm.BackColor = System.Drawing.Color.Pink;
			this.icnCurrentChildForm.ForeColor = System.Drawing.Color.Black;
			this.icnCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.None;
			this.icnCurrentChildForm.IconColor = System.Drawing.Color.Black;
			this.icnCurrentChildForm.Location = new System.Drawing.Point(33, 14);
			this.icnCurrentChildForm.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.icnCurrentChildForm.Name = "icnCurrentChildForm";
			this.icnCurrentChildForm.Size = new System.Drawing.Size(40, 32);
			this.icnCurrentChildForm.TabIndex = 0;
			this.icnCurrentChildForm.TabStop = false;
			// 
			// lblTitleChildForm
			// 
			this.lblTitleChildForm.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblTitleChildForm.BackColor = System.Drawing.Color.LavenderBlush;
			this.lblTitleChildForm.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
			this.lblTitleChildForm.ForeColor = System.Drawing.Color.Black;
			this.lblTitleChildForm.Location = new System.Drawing.Point(226, 0);
			this.lblTitleChildForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.lblTitleChildForm.Name = "lblTitleChildForm";
			this.lblTitleChildForm.Size = new System.Drawing.Size(997, 58);
			this.lblTitleChildForm.TabIndex = 1;
			this.lblTitleChildForm.Text = "Trang chủ";
			this.lblTitleChildForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pnlShadow
			// 
			this.pnlShadow.BackColor = System.Drawing.Color.LavenderBlush;
			this.pnlShadow.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlShadow.Location = new System.Drawing.Point(289, 60);
			this.pnlShadow.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.pnlShadow.Name = "pnlShadow";
			this.pnlShadow.Size = new System.Drawing.Size(1382, 5);
			this.pnlShadow.TabIndex = 2;
			// 
			// pnlDesktop
			// 
			this.pnlDesktop.BackColor = System.Drawing.Color.Pink;
			this.pnlDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDesktop.Location = new System.Drawing.Point(289, 65);
			this.pnlDesktop.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.pnlDesktop.Name = "pnlDesktop";
			this.pnlDesktop.Size = new System.Drawing.Size(1382, 709);
			this.pnlDesktop.TabIndex = 3;
			// 
			// iconButton5
			// 
			this.iconButton5.BackColor = System.Drawing.Color.Black;
			this.iconButton5.Dock = System.Windows.Forms.DockStyle.Top;
			this.iconButton5.FlatAppearance.BorderSize = 0;
			this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.iconButton5.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
			this.iconButton5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.iconButton5.ForeColor = System.Drawing.Color.White;
			this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.Info;
			this.iconButton5.IconColor = System.Drawing.Color.White;
			this.iconButton5.IconSize = 32;
			this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton5.Location = new System.Drawing.Point(0, 422);
			this.iconButton5.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.iconButton5.Name = "iconButton5";
			this.iconButton5.Padding = new System.Windows.Forms.Padding(11, 0, 20, 0);
			this.iconButton5.Rotation = 0D;
			this.iconButton5.Size = new System.Drawing.Size(289, 62);
			this.iconButton5.TabIndex = 13;
			this.iconButton5.Text = "Thông tin người dùng";
			this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			this.iconButton5.UseVisualStyleBackColor = false;
			this.iconButton5.Click += new System.EventHandler(this.iconButton5_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1671, 774);
			this.Controls.Add(this.pnlDesktop);
			this.Controls.Add(this.pnlShadow);
			this.Controls.Add(this.pnlTitleBar);
			this.Controls.Add(this.pnlMenu);
			this.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
			this.Name = "FormMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "FormMain";
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.pnlMenu.ResumeLayout(false);
			this.pnlLogo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
			this.pnlTitleBar.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.icnCurrentChildForm)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Panel pnlMenu;
        private Panel pnlLogo;
        private PictureBox btnHome;
        private Panel pnlTitleBar;
        private FontAwesome.Sharp.IconPictureBox icnCurrentChildForm;
        private Label lblTitleChildForm;
        private Panel pnlShadow;
        private Panel pnlDesktop;
        private FontAwesome.Sharp.IconButton btnDangXuat;
        private IconButton iconButton4;
        private IconButton iconButton3;
        private IconButton iconButton2;
        private IconButton iconButton1;
        private IconButton btnQuanLy;
		private IconButton iconButton5;
	}
}