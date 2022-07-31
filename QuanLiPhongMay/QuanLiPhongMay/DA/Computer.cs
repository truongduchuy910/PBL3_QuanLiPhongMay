using System.Data;

namespace QuanLiPhongMay.DA
{
    public class Computer
    {
        private static Computer instance;

        public static Computer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Computer();
                }
                return Computer.instance;
            }
            private set
            {
                Computer.instance = value;
            }
        }
        private Computer() { }
        public DataTable GetAll(int RoomID)
        {
            string query = "Select * from Computers";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetAvailableByRoomID(int RoomID)
        {
            string query = $"Select * from Computers WHERE roomID = {RoomID} and IsAvailable = 1";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetByRoomID(int id)
        {
            string query = "Select * from Computers WHERE roomID = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public DataTable GetByID(int id)
        {
            string query = "Select * from Computers WHERE ID = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public void Update(BO.Computer computer)
        {
            if (computer.IsAvailable == false)
            {
                string query = "Update Computers Set isAvailable = 0 WHERE ID = " + computer.ID;
                DataProvider.Instance.ExecuteNonQuery(query);
            }
            if (computer.IsAvailable == true)
            {
                string query = "Update Computers Set isAvailable = 1 WHERE ID = " + computer.ID;
                DataProvider.Instance.ExecuteNonQuery(query);
            }

        }
    }
}
