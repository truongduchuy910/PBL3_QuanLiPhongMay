
using QuanLiPhongMay.BO;
using QuanLiPhongMay.GUI;
using QuanLiPhongMay.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongMay
{
    public partial class fLogIn : Form
    {
        public static string USER;
        public fLogIn()
        {
            InitializeComponent();
        }
        #region Method
        #endregion
        #region Event
        public delegate void onCloseEvent();
        public onCloseEvent MyClose() { return this.Close; }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Account User = new Account();
            string userID = tfUser.Text;
            string passWord = tfPassWord.Text;
            bool AuthStatus = User.Auth(userID, passWord);
            if (AuthStatus == true)
            {
                if (User.IsAdmin)
                {
                    FAdmin FAd = new FAdmin(User, this.Show);
                    FAd.Show();
                    this.Hide();

                }
                else if (User.IsTeacher)
                {
                    fTeacher fc = new fTeacher(User, this.Show);
                    fc.Show();
                    this.Hide();

                }
                else if
                (User.IsManager)
                {
                    fManager fm = new fManager(User, this.Show);
                    fm.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Người dùng chưa được phân quyền!");
                    // this.Close();
                }
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!");
            }

        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
