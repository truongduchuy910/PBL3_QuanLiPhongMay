using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace QuanLiPhongMay.BO
{
    public class Room
    {
        public static DataTable DataSource;
        public static List<Room> ListRoom;
        public Room()
        {
            ListRoom = new List<Room>();
        }

        //
        // Column in Database
        //
        private int _ID;
        private int _Quantity;
        //
        // Fields
        //
        public int ID { get => _ID; set => _ID = value; }
        public int Quantity { get => _Quantity; set => _Quantity = value; }

        private void Mapping(DataRow Row)
        {

            this.ID = Row.Field<int>("ID");
            this.Quantity = Row.Field<int>("quantity");
        }

        public void GetByID(int ID)
        {
            try
            {
                DataTable DT = DA.Rooms.Instance.GetByID(ID);
                this.Mapping(DT.Rows[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void GetAll()
        {
            try
            {
                DataSource = DA.Rooms.Instance.GetAll();
                foreach (DataRow Row in DataSource.Rows)
                {
                    Room Rpt = new Room();
                    Rpt.Mapping(Row);
                    ListRoom.Add(Rpt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Update()
        {
            try
            {
                DA.Rooms.Instance.Update(this);
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
