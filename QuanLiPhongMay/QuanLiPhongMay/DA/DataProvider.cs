using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace QuanLiPhongMay.DA
{
    public class DataProvider
    {

        private static DataProvider instance;
        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }
        string connectionStr = "Server=loaloa.database.windows.net;Database=loaloa;User Id=truongduchuy910;Password=Truongduc910.;";


        #region Execute
        public DataTable ExecuteQuery(string query, object[] obj = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {             
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    int i = 0;
                    if (obj != null)
                    {
                        string[] listObj = query.Split(' ');
                        foreach (string item in listObj)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, obj[i]);
                                i++;
                            }
                        }
                    }
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(data);
                    connection.Close();
            }
            return data;
        }
        public int ExecuteNonQuery(string query, object[] obj = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    int i = 0;
                    if (obj != null)
                    {
                        string[] listObj = query.Split(' ');
                        foreach (string item in listObj)
                        {
                            if (item.Contains('@'))
                            {
                                command.Parameters.AddWithValue(item, obj[i]);
                                i++;
                            }
                        }
                    }

                    data = command.ExecuteNonQuery();
                    connection.Close();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.ToString());
                }
            }

            return data;
        }
        public object ExecuteScarla(string query, object[] obj = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);

                int i = 0;
                if (obj != null)
                {
                    string[] listObj = query.Split(' ');
                    foreach (string item in listObj)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, obj[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();
                connection.Close();
            }

            return data;
        }
        #endregion
    }
}