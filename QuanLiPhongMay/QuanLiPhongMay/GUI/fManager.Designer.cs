using System;
using System.Windows.Forms;

namespace QuanLiPhongMay.View
{
    partial class fManager
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
            this.DS = new System.Data.DataSet();
            this.DGComputer = new System.Windows.Forms.DataGridView();
            this.buttonFix = new System.Windows.Forms.Button();
            this.buttonSchedule = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGComputer)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "NewDataSet";
            // 
            // DGComputer
            // 
            this.DGComputer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGComputer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGComputer.Location = new System.Drawing.Point(12, 12);
            this.DGComputer.Name = "DGComputer";
            this.DGComputer.ReadOnly = true;
            this.DGComputer.RowHeadersWidth = 51;
            this.DGComputer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGComputer.Size = new System.Drawing.Size(520, 349);
            this.DGComputer.TabIndex = 1;
            // 
            // buttonFix
            // 
            this.buttonFix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFix.Location = new System.Drawing.Point(457, 367);
            this.buttonFix.Name = "buttonFix";
            this.buttonFix.Size = new System.Drawing.Size(75, 23);
            this.buttonFix.TabIndex = 2;
            this.buttonFix.Text = "Đã sửa";
            this.buttonFix.UseVisualStyleBackColor = true;
            this.buttonFix.Click += new System.EventHandler(this.buttonFix_Click);
            // 
            // buttonSchedule
            // 
            this.buttonSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSchedule.Location = new System.Drawing.Point(328, 367);
            this.buttonSchedule.Name = "buttonSchedule";
            this.buttonSchedule.Size = new System.Drawing.Size(123, 23);
            this.buttonSchedule.TabIndex = 3;
            this.buttonSchedule.Text = "Lịch 10 ngày tới";
            this.buttonSchedule.UseVisualStyleBackColor = true;
            this.buttonSchedule.Click += new System.EventHandler(this.buttonSchedule_Click);
            // 
            // fManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 402);
            this.Controls.Add(this.buttonSchedule);
            this.Controls.Add(this.buttonFix);
            this.Controls.Add(this.DGComputer);
            this.Name = "fManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fManager_FormClosed);
            this.Load += new System.EventHandler(this.fManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGComputer)).EndInit();
            this.ResumeLayout(false);

        }
        void GetData()
        {


            BO.Report.GetAll();
            DGComputer.DataSource = BO.Report.DataSource;
            
        }
        #endregion
        private System.Data.DataSet DS;
        private System.Windows.Forms.DataGridView DGComputer;
        private System.Windows.Forms.Button buttonFix;
        private Button buttonSchedule;
    }
}