namespace QuanLiPhongMay.View
{
    partial class fTeacher
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
            this.panelMatrix = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNextMonth = new System.Windows.Forms.Button();
            this.btnPreMonth = new System.Windows.Forms.Button();
            this.btReport = new System.Windows.Forms.Button();
            this.btnToday = new System.Windows.Forms.Button();
            this.lbAccountInfor = new System.Windows.Forms.Label();
            this.dtpkDate = new System.Windows.Forms.DateTimePicker();
            this.buttonSchedule = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelMatrix
            // 
            this.panelMatrix.Location = new System.Drawing.Point(11, 35);
            this.panelMatrix.Margin = new System.Windows.Forms.Padding(2);
            this.panelMatrix.Name = "panelMatrix";
            this.panelMatrix.Size = new System.Drawing.Size(509, 252);
            this.panelMatrix.TabIndex = 1;
            // 
            // btnNextMonth
            // 
            this.btnNextMonth.Location = new System.Drawing.Point(134, 291);
            this.btnNextMonth.Margin = new System.Windows.Forms.Padding(2);
            this.btnNextMonth.Name = "btnNextMonth";
            this.btnNextMonth.Size = new System.Drawing.Size(29, 29);
            this.btnNextMonth.TabIndex = 8;
            this.btnNextMonth.Text = ">>";
            this.btnNextMonth.UseVisualStyleBackColor = true;
            this.btnNextMonth.Click += new System.EventHandler(this.btnNextMonth_Click);
            // 
            // btnPreMonth
            // 
            this.btnPreMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreMonth.Location = new System.Drawing.Point(11, 291);
            this.btnPreMonth.Margin = new System.Windows.Forms.Padding(2);
            this.btnPreMonth.Name = "btnPreMonth";
            this.btnPreMonth.Size = new System.Drawing.Size(29, 29);
            this.btnPreMonth.TabIndex = 7;
            this.btnPreMonth.Text = "<<";
            this.btnPreMonth.UseVisualStyleBackColor = true;
            this.btnPreMonth.Click += new System.EventHandler(this.btnPreMonth_Click);
            // 
            // btReport
            // 
            this.btReport.Location = new System.Drawing.Point(342, 292);
            this.btReport.Name = "btReport";
            this.btReport.Size = new System.Drawing.Size(86, 29);
            this.btReport.TabIndex = 5;
            this.btReport.Text = "Báo hỏng";
            this.btReport.UseVisualStyleBackColor = true;
            this.btReport.Click += new System.EventHandler(this.btReport_Click);
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(44, 291);
            this.btnToday.Margin = new System.Windows.Forms.Padding(2);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(86, 29);
            this.btnToday.TabIndex = 2;
            this.btnToday.Text = "Hôm nay";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // lbAccountInfor
            // 
            this.lbAccountInfor.AutoSize = true;
            this.lbAccountInfor.Location = new System.Drawing.Point(677, 9);
            this.lbAccountInfor.Name = "lbAccountInfor";
            this.lbAccountInfor.Size = new System.Drawing.Size(0, 13);
            this.lbAccountInfor.TabIndex = 6;
            // 
            // dtpkDate
            // 
            this.dtpkDate.Location = new System.Drawing.Point(11, 11);
            this.dtpkDate.Margin = new System.Windows.Forms.Padding(2);
            this.dtpkDate.Name = "dtpkDate";
            this.dtpkDate.Size = new System.Drawing.Size(509, 20);
            this.dtpkDate.TabIndex = 0;
            this.dtpkDate.UseWaitCursor = true;
            this.dtpkDate.ValueChanged += new System.EventHandler(this.dtpkDate_ValueChanged);
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Location = new System.Drawing.Point(434, 292);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(86, 29);
            this.buttonSchedule.TabIndex = 9;
            this.buttonSchedule.Text = "Lịch của thôi";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // fTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 340);
            this.Controls.Add(this.buttonSchedule);
            this.Controls.Add(this.dtpkDate);
            this.Controls.Add(this.btReport);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.btnNextMonth);
            this.Controls.Add(this.btnPreMonth);
            this.Controls.Add(this.panelMatrix);
            this.Controls.Add(this.lbAccountInfor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "fTeacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giảng viên";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fTeacher_FormClosed);
            this.Load += new System.EventHandler(this.fTeacher_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel panelMatrix;
        private System.Windows.Forms.Button btnNextMonth;
        private System.Windows.Forms.Button btnPreMonth;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btReport;
        private System.Windows.Forms.Label lbAccountInfor;
        private System.Windows.Forms.DateTimePicker dtpkDate;
        private System.Windows.Forms.Button buttonSchedule;
    }
}