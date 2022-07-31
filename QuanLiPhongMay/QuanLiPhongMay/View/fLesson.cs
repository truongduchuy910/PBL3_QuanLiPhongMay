using QuanLiPhongMay.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongMay.View
{
    public partial class fLesson : Form
    {
        public fLesson()
        {
            InitializeComponent();
            GetData();
        }

        public void LoadCheckBox(DateTime date)
        {

        }
        
        // btnAdd
        private void button1_Click(object sender, EventArgs e)
        {
            //int rows = Convert.ToInt32(DG.Rows);
            //for (int i = 0; i < rows; i++)
            //{

            //}
            //if (true)
            //{
            //    MessageBox.Show("Đã thêm lịch học thành công!");

            //}
            for(int i = 0; i < DG.Rows.Count - 1; i++)
            {
                string message = string.Empty;
                bool isSelected = Convert.ToBoolean(DG.Rows[i].Cells[3].Value);
                if (isSelected)
                {
                    message += Environment.NewLine;
                    message += DG.Rows[i].Cells[1].Value.ToString();
                }
            }
        }
        //private void btnGet_Click(object sender, EventArgs e)
        //{
        //    string message = string.Empty;
        //    foreach (DataGridViewRow row in DG.Rows)
        //    {
        //        bool isSelected = Convert.ToBoolean(row.Cells["State"].Value);
        //        if (isSelected)
        //        {
        //            message += Environment.NewLine;
        //            message += row.Cells["Name"].Value.ToString();
        //        }
        //    }

        //    MessageBox.Show("Selected Values" + message);
        //}

        //btnBack
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
