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

    public partial class fTeacher : Form
    {
        #region Properties;
        private List<List<Button>> matrix;

        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }


        #endregion

        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
        private BO.Account userInfo;
        public Account UserInfo { get => userInfo; set => userInfo = value; }

        public delegate void FloginFormShow();
        FloginFormShow eventHandle;
        public fTeacher(BO.Account userInfo, FloginFormShow eventHandle)
        {
            this.UserInfo = userInfo;
            this.eventHandle = eventHandle;
            InitializeComponent();
            lbAccountInfor.Text = fLogIn.USER;
            LoadMatrix();
        }

        void LoadMatrix()
        {
            Matrix = new List<List<Button>>();
            Button oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };
            for (int i = 0; i < Cons.DayOfColumn; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    Button btn = new Button() { Width = Cons.dateButtonWidth, Height = Cons.dateButtonHeight };
                    btn.Location = new Point(oldBtn.Location.X + oldBtn.Width + Cons.margin, oldBtn.Location.Y);
                    panelMatrix.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    oldBtn = btn;
                    oldBtn.Click += OldBtn_Click;                  
                }
                oldBtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldBtn.Location.Y + Cons.dateButtonHeight) };
            }
            SetDefaultDate();
        }

        private void OldBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as Button).Text)) 
                return;
            fRoom sh = new fRoom(new DateTime(dtpkDate.Value.Year, dtpkDate.Value.Month,Convert.ToInt32((sender as Button).Text)),UserInfo);
            sh.ShowDialog();
            
        }

        int DayOfMonth(DateTime date)
        {
            switch (date.Month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    if ((date.Year % 4 == 0 && date.Year % 100 != 0) || (date.Year % 400 == 0)) return 29;
                    else return 28;
                default:
                    return 30;
            }

        }
        void AddNumberIntoMatrixByDate(DateTime date)
        {
            ClearMatrix();
            DateTime useDate = new DateTime(date.Year, date.Month, 1);
            int line = 0;
            for (int i = 1; i <= DayOfMonth(date); i++)
            {
                int column = dateOfWeek.IndexOf(useDate.DayOfWeek.ToString());
                Button btn = Matrix[line][column];
                btn.Text = i.ToString();
                if (isEqualDate(useDate, DateTime.Now))
                {
                    btn.BackColor = Color.Yellow;
                }
                if (isEqualDate(useDate, date))
                {
                    btn.BackColor = Color.Aqua;
                }
                if (column >= 6) line++;
                useDate = useDate.AddDays(1);
            }
        }
        bool isEqualDate(DateTime dateA, DateTime dateB)
        {
            return dateA.Year == dateB.Year && dateA.Month == dateB.Month && dateA.Day == dateB.Day;
        }

        void ClearMatrix()
        {
            for (int i = 0; i < Matrix.Count; i++)
            {
                for (int j = 0; j <= Matrix.Count; j++)
                {
                    Button btn = Matrix[i][j];
                    btn.Text = "";
                    btn.BackColor = Color.LightGray;
                }
            }
        }

        void SetDefaultDate()
        {
            dtpkDate.Value = DateTime.Now;
        }
        #region Event
        private void dtpkDate_ValueChanged(object sender, EventArgs e)
        {
            AddNumberIntoMatrixByDate((sender as DateTimePicker).Value);
        }

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(1);
        }

        private void btnPreMonth_Click(object sender, EventArgs e)
        {
            dtpkDate.Value = dtpkDate.Value.AddMonths(-1);
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            SetDefaultDate();
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            fReport report = new fReport();
            report.ShowDialog();
        }
        private void btnOut_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có thật sự muốn đăng xuất hay không?","Thông báo!",MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }    
        }

        #endregion

        private void fTeacher_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.eventHandle();
        }

        private void fTeacher_Load(object sender, EventArgs e)
        {

        }

        private void buttonSchedule_Click(object sender, EventArgs e)
        {
            FSchedule FSch = new FSchedule(this.UserInfo);
            FSch.Show();
        }
    }
}
