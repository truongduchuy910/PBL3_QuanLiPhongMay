using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace QuanLiPhongMay.BO
{
    public class Computer
    {

        public static DataTable DataSource;
        public static List<Computer> ListComputer;
        public Computer()
        {
            ListComputer = new List<Computer>();
        }

        //
        // Column in Database
        //
        private int _ID = 0;
        private int _RoomID = 0;
        private bool _IsAvailable = true;
        //
        // Fields
        //
        public int ID { get => _ID; set => _ID = value; }
        public Room Room;
        public bool IsAvailable { get => _IsAvailable; set => _IsAvailable = value; }
        void Mapping(DataRow Row)
        {
            this._ID = Row.Field<int>("ID");
            this._RoomID = Row.Field<int>("RoomID");
            this._IsAvailable = Row.Field<bool>("IsAvailable");
            this.Room = new Room();
            this.Room.GetByID(_RoomID);
        }

        public static void GetAll(int RoomID)
        {
            try
            {
                DataSource = DA.Computer.Instance.GetByRoomID(RoomID);
                foreach (DataRow Row in DataSource.Rows)
                {
                    Computer Cpt = new Computer();
                    Cpt.Mapping(Row);
                    ListComputer.Add(Cpt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static int GetAvailableByRoomID(int RoomID)
        {
            int result = 0;
            try
            {
                DataTable Data = DA.Computer.Instance.GetAvailableByRoomID(RoomID);
                result = Data.Rows.Count;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return result;

        }
        public void Update()
        {
            try
            {
                DA.Computer.Instance.Update(this);
                int Quantity = Computer.GetAvailableByRoomID(this.Room.ID);
                this.Room.Quantity = Quantity;
                this.Room.Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void GetByID(int ID)
        {
            try
            {
                DataTable DT = DA.Computer.Instance.GetByID(ID);
                this.Mapping(DT.Rows[0]);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
