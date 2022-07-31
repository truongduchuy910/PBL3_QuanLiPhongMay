using System.Data;

namespace QuanLiPhongMay.DA
{
    public class Account
    {
        private static Account instance;

        public static Account Instance
        {
            get
            {
                if (instance == null) instance = new Account();
                return Account.instance;
            }
            private set
            {
                Account.instance = value;
            }
        }
        private Account() { }
        //Method
        public bool InsertAccount(string userID, string passWord, bool isTeacher, bool isManager)
        {
            string query = string.Format("Insert into Users values('{0}','{1}',{2},{3},{4})", userID, passWord, isTeacher, isManager,false);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool Login(string userID, string passWord)
        {
            string query = "USP_Login @userID , @passWords";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userID, passWord });

            return result.Rows.Count > 0;
        }
        public DataTable Auth(string UserID, string PassWord)
        {
            string query = "USP_Login @userID , @passWords";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { UserID, PassWord });
            return result;
        }
        public DataTable GetByID(string ID)
        {
            string query = $"select * from Account where userID = '{ID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
    }
}
