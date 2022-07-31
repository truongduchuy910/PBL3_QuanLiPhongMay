using QuanLiPhongMay.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLiPhongMay.View
{
    partial class fLesson
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
            this.DG = new System.Windows.Forms.DataGridView();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DG)).BeginInit();
            this.SuspendLayout();
            // 
            // DG
            // 
            this.DG.AllowUserToOrderColumns = true;
            this.DG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DG.Location = new System.Drawing.Point(12, 12);
            this.DG.Name = "DG";
            this.DG.RowHeadersWidth = 51;
            this.DG.RowTemplate.Height = 24;
            this.DG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DG.Size = new System.Drawing.Size(487, 256);
            this.DG.TabIndex = 0;
            this.DG.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DG_CellContentClick);
            this.DG.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DG_CellFormatting);
            this.DG.Sorted += new System.EventHandler(this.DG_BindingContextChanged);
            this.DG.BindingContextChanged += new System.EventHandler(this.DG_BindingContextChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(12, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 36);
            this.button2.TabIndex = 1;
            this.button2.Text = "Trở về";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(406, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Thêm";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fLesson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 316);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.DG);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "fLesson";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.DG)).EndInit();
            this.ResumeLayout(false);

        }
        void GetData()
        {
            BO.Schedule.GetAll(_Date, _Date, _Room);
            BO.Lesson.GetAll();
            DG.DataSource = BO.Lesson.DataSource;
        }
        void DisabledSchedules()
        {
            for (int i = 0; i < DG.Rows.Count - 1; i++)
            {
                foreach (BO.Schedule Sch in BO.Schedule.ListSchedule)
                {
                    if (DG.Rows[i].Cells[0].Value.ToString() == Sch.Lesson.Name)
                    {
                        DG.Rows[i].Cells[0].Style.BackColor = Color.Red;
                        DG.Rows[i].Cells[0].Style.ForeColor = Color.White;
                        DG.Rows[i].Cells[0].ReadOnly = true;

                    }
                }
            }



        }
        // btnAdd
        private void button1_Click(object sender, EventArgs e)
        {
            int count = DG.Rows.Count;
            List<Lesson> ls = new List<Lesson>();
            foreach (DataGridViewRow Row in DG.SelectedRows)
            {
                Lesson Lss = new Lesson();
                Lss.GetByID((int)(Row.Cells[2].Value));
                ls.Add(Lss);

            }
            bool AddStatus = BO.Schedule.Add(_UserInfo, _Date, _Room, ls);
            if (AddStatus)
            {
                GetData();
                DisabledSchedules();
            }
            else MessageBox.Show("Trùng lịch!");
        }


        //btnBack
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private System.Windows.Forms.DataGridView DG;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}