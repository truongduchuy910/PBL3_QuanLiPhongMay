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
    public partial class fSignUp : Form
    {
        public fSignUp()
        {
            InitializeComponent();
        }
        void AddAccount(string user, string password, bool isTeacher, bool isManager)
        {
            if(DA.Account.Instance.InsertAccount(user,password,isTeacher,isManager))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }    
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }    
        }

        private void btSignUp_Click(object sender, EventArgs e)
        {
            string user = txtUser.Text;
            string password = txtPass.Text;
            bool isTeacher = rdb1.Checked;
            bool isManager = rdb2.Checked;
           
            if(txtPass.Text == txtConfirm.Text)
            {
                AddAccount(user, password, isTeacher, isManager);
            }


        }

        private void btReset_Click(object sender, EventArgs e)
        {

        }
    }
}
