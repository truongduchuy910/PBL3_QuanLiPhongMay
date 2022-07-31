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

namespace QuanLiPhongMay.GUI
{
    public partial class FSchedule : Form
    {
        private Account User;
        public FSchedule(Account User)
        {
            this.User = User;
            InitializeComponent();
            GetData();
        }
        void GetData()
        {


            DateTime From = DateTime.Now;
            DateTime To = DateTime.Now.AddDays(10);
            if (User.IsTeacher)
                BO.Schedule.GetOwn(From, To, User);
            else BO.Schedule.GetAll(From, To);
            DGSchedule.DataSource = BO.Schedule.DataSource;

        }

        private void FSchedule_Load(object sender, EventArgs e)
        {

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (User.IsTeacher)
            {
                MessageBox.Show("Bạn có chắc chắn muốn xóa không?");
                MessageBox.Show(DGSchedule.SelectedRows.Count.ToString());
                foreach (DataGridViewRow Row in DGSchedule.SelectedRows)
                {
                    BO.Schedule.Remove(User, Row.Cells[1].Value.ToString(), Row.Cells[3].Value.ToString(), Row.Cells[4].Value.ToString());
                }
                GetData();
            }
            else
                MessageBox.Show("Cán bộ phòng máy không thể xóa lịch");
        }
    }

}
