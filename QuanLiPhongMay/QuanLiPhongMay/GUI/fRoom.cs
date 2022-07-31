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
    public partial class fRoom : Form
    {
        private DateTime date;
        private BO.Account _UserInfo;

        public DateTime Date { get => date; set => date = value; }
        public Account UserInfo { get => _UserInfo; set => _UserInfo = value; }

        public fRoom(DateTime date, BO.Account userInfo)
        {
            InitializeComponent();
            GetData();
            this._UserInfo = userInfo;
            this.Date = date;
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RoomID = BO.Room.DataSource.Rows[e.RowIndex].Field<int>("id");
            fLesson ls = new fLesson(date, RoomID,_UserInfo);
            ls.Text = "Phòng " + RoomID;
            ls.ShowDialog();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DG_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
