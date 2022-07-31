using QuanLiPhongMay.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongMay.View
{
    public partial class fLesson : Form
    {
        DateTime _Date;
        int _RoomID;
        //Room room = new Room();
        Room _Room;
        private BO.Account _UserInfo;
        public Account UserInfo { get => _UserInfo; set => _UserInfo = value; }
        //public Room Room { get => _Room; set => _Room = value; }

        public fLesson(DateTime Date, int RoomID, BO.Account userInfo)
        {
            _Date = Date;
            _RoomID = RoomID;
            _Room = new Room();
            _Room.GetByID(_RoomID);
            _UserInfo = userInfo;
            InitializeComponent();
            GetData();
        }

        private void DG_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void DG_BindingContextChanged(object sender, EventArgs e)
        {
            DisabledSchedules();
        }

        private void DG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
