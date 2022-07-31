using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongMay.DA
{
    public class Rooms
    {
        private static Rooms instance;

        public static Rooms Instance
        {
            get
            {
                if (instance == null) Rooms.instance = new Rooms();
                return Rooms.instance;
            }
            private set
            {
                Rooms.instance = value;
            }
        }
        private Rooms() { }
        public DataTable GetByID(BO.Schedule schedule)
        {
            string query = "USP_GetByID @ID";
            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { schedule.ID });
            return result;
        }
        public DataTable GetByID(int ID)
        {
            string query = $"Select * from Rooms where id = {ID}";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetAll()
        {
            string query = $"Select * from Rooms";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public void Update(BO.Room room)
        {
            string query = $"Update Rooms Set Quantity = {room.Quantity} WHERE ID = {room.ID}";
            DataProvider.Instance.ExecuteNonQuery(query);


        }
    }
}
