using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace QuanLiPhongMay.BO
{
    public class Report
    {
        public static DataTable DataSource;
        public static List<Report> ListReport;
        public Report()
        {
            ListReport = new List<Report>();
        }

        //
        // Column in Database
        //
        private int _ID;
        private string _Content;
        private DateTime _Date;
        private int _ComputerID;
        //
        // Fields
        //
        public int ID { get => _ID; set => _ID = value; }
        public string Content { get => _Content; set => _Content = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public Computer Computer;
        private void Mapping(DataRow Row)
        {
            this._ID = Row.Field<int>("ID");
            this._Content = Row.Field<string>("Content");
            //this._Date = Row.Field<DateTime>("reportTime");
            this._ComputerID = Row.Field<int>("computerID");
            //
            //
            //
            this.Computer = new Computer();
            this.Computer.GetByID(_ComputerID);
        }
        public void GetByID()
        {
            try
            {
                DataTable DT = DA.Reports.Instance.GetByID(this.ID);
                Mapping(DT.Rows[0]);
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
                DataSource = DA.Reports.Instance.GetAll();
                foreach (DataRow Row in DataSource.Rows)
                {
                    Report Rpt = new Report();
                    Rpt.Mapping(Row);
                    ListReport.Add(Rpt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public static void Add(Report Rpt)
        {
            try
            {
                DA.Reports.Instance.Add(Rpt);
                Rpt.Computer.IsAvailable = false;
                Rpt.Computer.Update();
                int Quantity = Computer.GetAvailableByRoomID(Rpt.Computer.Room.ID);
                Rpt.Computer.Room.Quantity = Quantity;
                Rpt.Computer.Room.Update();
            }
            catch
            {
                MessageBox.Show("Không thể thêm");
            }
        }
        public void Remove()
        {
            try
            {
                DA.Reports.Instance.Remove(this);
                if (this.Computer!=null)
                {
                    this.Computer.IsAvailable = true;
                    this.Computer.Update();
                    int Quantity = Computer.GetAvailableByRoomID(this.Computer.Room.ID);
                    this.Computer.Room.Quantity = Quantity;
                    this.Computer.Room.Update();
                }
            }
            catch
            {
                MessageBox.Show("Không thể xóa");
            }
        }
    }
}
