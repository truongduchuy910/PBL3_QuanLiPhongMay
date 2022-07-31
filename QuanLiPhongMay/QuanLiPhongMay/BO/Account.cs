using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace QuanLiPhongMay.BO
{
    public class Account
    {

        //
        // Column in Database
        //
        private string _UserID;
        private string _Password;
        private bool _IsTeacher = false;
        private bool _IsManager = false;
        private bool _IsAdmin = false;
        //
        // Fields
        //
        public string UserID { get => _UserID; set => _UserID = value; }
        public string Password { get => null; set => _Password = null; }
        public bool IsTeacher { get => _IsTeacher; set => _IsTeacher = value; }
        public bool IsManager { get => _IsManager; set => _IsManager = value; }
        public bool IsAdmin { get => _IsAdmin; set => _IsAdmin = value; }

        private void Mapping(DataRow Row)
        {
            this.UserID = Row.Field<string>("UserID");
            try
            {
                this.IsAdmin = Row.Field<bool>("IsAdmin");
                //this.IsTeacher = Row.Field<bool>("IsTeacher");
                //this.IsManager = Row.Field<bool>("IsManager");
            }
            catch { }
            try
            {
                //this.IsAdmin = Row.Field<bool>("IsAdmin");
                this.IsTeacher = Row.Field<bool>("IsTeacher");
                //this.IsManager = Row.Field<bool>("IsManager");
            }
            catch { }
            try
            {
                //this.IsAdmin = Row.Field<bool>("IsAdmin");
                //this.IsTeacher = Row.Field<bool>("IsTeacher");
                this.IsManager = Row.Field<bool>("IsManager");
            }
            catch { }
        }
        public bool Auth(string User, string Password)
        {
            DataTable Data = new DataTable();
            try
            {

                Data = DA.Account.Instance.Auth(User, Password);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (Data.Rows.Count > 0)
            {
                Mapping(Data.Rows[0]);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void GetByID(string ID)
        {
            try
            {
                DataTable Data;
                Data = DA.Account.Instance.GetByID(ID);
                this.Mapping(Data.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
