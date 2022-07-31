using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace QuanLiPhongMay
{
    public class OLEAAdapter
    {
        private OleDbConnection cnn;
        readonly private String ConnectStr;
        public OLEAAdapter(string database = "loaloa", string user = "truongduchuy910", string password = "Truongduc910.")
        {
            ConnectStr = $"Provider=MSOLEDBSQL;Server=loaloa.database.windows.net;Database={database};UID={user};PWD={password};";
        }
        public DataTable GetTableNames()
        {
            DataTable data = new DataTable();
            cnn = new OleDbConnection(ConnectStr);
            string selectStr = $"SELECT TABLE_NAME as Name FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME != 'database_firewall_rules'";
            try
            {
                cnn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(selectStr, cnn);
                da.Fill(data);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return data;
        }
        public DataTable GetAlls(string table)
        {
            DataTable data = new DataTable();
            cnn = new OleDbConnection(ConnectStr);
            string selectStr = $"select * from dbo.{table}";
            try
            {
                cnn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(selectStr, cnn);
                da.Fill(data);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cnn.Close();
            }
            return data;
        }
        public bool Update(string table, DataTable DT)
        {
            string selectStr = $"select * from dbo.{table}";
            int count = 0;
            using (OleDbConnection connection = new OleDbConnection(ConnectStr))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand(selectStr, connection);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(adapter);
                connection.Open();
                count = adapter.Update(DT);

            }
            return Convert.ToBoolean(count);
        }
    }
}