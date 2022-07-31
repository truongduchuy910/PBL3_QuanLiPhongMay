using QuanLiPhongMay.BO;
using QuanLiPhongMay.GUI;
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
    public partial class fManager : Form
    {
        private BO.Account userInfo;
        public delegate void FloginForm();
        FloginForm eventHandle;
        public fManager(BO.Account userInfo, FloginForm eventHandle)
        {
            this.userInfo = userInfo;
            this.eventHandle = eventHandle;
            InitializeComponent();
            GetData();
        }

        private void fManager_Load(object sender, EventArgs e)
        {

        }

        private void buttonFix_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow Row in DGComputer.SelectedRows)
            {

                BO.Report Rpt = new BO.Report();
                Rpt.ID = Convert.ToInt32(Row.Cells[0].Value);
                Rpt.GetByID();
                Rpt.Remove();

            }
            GetData();
        }

        private void fManager_FormClosed(object sender, FormClosedEventArgs e)
        {
            eventHandle();
        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            FSchedule FSch = new FSchedule(userInfo);
            FSch.Show();
        }
    }
}
