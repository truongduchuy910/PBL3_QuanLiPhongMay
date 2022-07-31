using System.Windows.Forms;

namespace QuanLiPhongMay
{
    partial class fLogIn
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
            this.lbUser = new System.Windows.Forms.Label();
            this.lbPassWord = new System.Windows.Forms.Label();
            this.tfUser = new System.Windows.Forms.TextBox();
            this.tfPassWord = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(25, 35);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(73, 16);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "Tài Khoản";
            // 
            // lbPassWord
            // 
            this.lbPassWord.AutoSize = true;
            this.lbPassWord.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPassWord.Location = new System.Drawing.Point(25, 93);
            this.lbPassWord.Name = "lbPassWord";
            this.lbPassWord.Size = new System.Drawing.Size(68, 16);
            this.lbPassWord.TabIndex = 1;
            this.lbPassWord.Text = "Mật Khẩu";
            // 
            // tfUser
            // 
            this.tfUser.Location = new System.Drawing.Point(28, 54);
            this.tfUser.Name = "tfUser";
            this.tfUser.Size = new System.Drawing.Size(205, 20);
            this.tfUser.TabIndex = 1;
            // 
            // tfPassWord
            // 
            this.tfPassWord.Location = new System.Drawing.Point(28, 112);
            this.tfPassWord.Name = "tfPassWord";
            this.tfPassWord.Size = new System.Drawing.Size(205, 20);
            this.tfPassWord.TabIndex = 2;
            this.tfPassWord.UseSystemPasswordChar = true;
            // 
            // btnLogIn
            // 
            this.btnLogIn.Location = new System.Drawing.Point(80, 152);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(100, 28);
            this.btnLogIn.TabIndex = 3;
            this.btnLogIn.Text = "Đăng nhập";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // fLogIn
            // 
            this.AcceptButton = this.btnLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 215);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.tfPassWord);
            this.Controls.Add(this.tfUser);
            this.Controls.Add(this.lbPassWord);
            this.Controls.Add(this.lbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "fLogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Label lbPassWord;
        private System.Windows.Forms.TextBox tfUser;
        private System.Windows.Forms.TextBox tfPassWord;
        private System.Windows.Forms.Button btnLogIn;
    }
}

