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
    public partial class fReport : Form
    {
        public fReport()
        {
            InitializeComponent();
            GetData();
        }
        void GetData()
        {


            BO.Report.GetAll();
            DG.DataSource = BO.Report.DataSource;

        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            BO.Report Rpt = new BO.Report();
            BO.Computer Computer = new Computer();
            Computer.GetByID(Convert.ToInt32(comboBoxComputer.Text));
            Rpt.Computer = Computer;
            Rpt.Content = textBox2.Text;
            Report.Add(Rpt);
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fReport_Load(object sender, EventArgs e)
        {
            BO.Room.GetAll();
            comboBoxRoom.Items.Clear();
            foreach (DataRow Row in BO.Room.DataSource.Rows)
            {
                comboBoxRoom.Items.Add(Row.Field<int>("id"));
            }
            if (comboBoxRoom.Items.Count > 0) comboBoxRoom.SelectedItem = 0;
        }

        private void comboBoxComputer_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void comboBoxRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxRoom.Text != null)
                BO.Computer.GetAll(Convert.ToInt32(comboBoxRoom.Text));
            comboBoxComputer.Items.Clear();
            foreach (DataRow Row in BO.Computer.DataSource.Rows)
            {
                comboBoxComputer.Items.Add(Row.Field<int>("id"));
            }
            if (comboBoxRoom.Items.Count > 0) comboBoxRoom.SelectedItem = 0;
        }
    }
}
