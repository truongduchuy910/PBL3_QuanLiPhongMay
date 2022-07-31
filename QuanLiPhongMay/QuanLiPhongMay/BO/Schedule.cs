using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace QuanLiPhongMay.BO
{
    public class Schedule
    {
        public static DataTable DataSource = new DataTable();
        public static List<Schedule> ListSchedule = new List<Schedule>();
        Schedule()
        {
        }
        //
        // Column in Database
        //
        private int _ID;
        private DateTime _Date;

        // Relationship ID
        private string _CreateByUserID;
        private int _RoomID;
        private int _LessonID;
        //
        // Fields
        //
        public int ID { get => _ID; set => _ID = value; }
        public DateTime Date { get => _Date; set => _Date = value; }
        public Account CreateByUserID;
        public Room Room;
        public Lesson Lesson;

        private void Mapping(DataRow Row)
        {
            this._ID = Row.Field<int>("ID");
            this._Date = Row.Field<DateTime>("BookTime");
            this._CreateByUserID = Row.Field<string>("UserID");
            this._RoomID = Row.Field<int>("RoomID");
            this._LessonID = Row.Field<int>("LessonID");
            this.CreateByUserID = new Account();
            this.Lesson = new Lesson();
            this.Room = new Room();
            this.CreateByUserID.GetByID(_CreateByUserID);
            this.Lesson.GetByID(_LessonID);
            this.Room.GetByID(_RoomID);
        }
        public static void GetAll()
        {
            try
            {
                DataSource.Clear();
                DataSource = DA.Schedules.Instance.GetAll();
                ListSchedule.Clear();
                foreach (DataRow Row in DataSource.Rows)
                {
                    Schedule Sch = new Schedule();
                    Sch.Mapping(Row);
                    ListSchedule.Add(Sch);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        static public void GetAll(DateTime From, DateTime To)
        {
            try
            {
                DataSource.Clear();
                DataSource = DA.Schedules.Instance.GetAll(From, To);
                ListSchedule.Clear();
                foreach (DataRow Row in DataSource.Rows)
                {
                    Schedule Lss = new Schedule();
                    Lss.Mapping(Row);
                    ListSchedule.Add(Lss);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        static public void GetOwn(DateTime From, DateTime To, Account User)
        {
            try
            {
                DataSource.Clear();
                DataSource = DA.Schedules.Instance.GetOwn(From, To, User);
                ListSchedule.Clear();
                foreach (DataRow Row in DataSource.Rows)
                {
                    Schedule Lss = new Schedule();
                    Lss.Mapping(Row);
                    ListSchedule.Add(Lss);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        static public List<Schedule> GetAll(DateTime From, DateTime To, Room room)
        {
            List<Schedule> Schedules = new List<Schedule>();
            try
            {
                DataSource.Clear();
                DataSource = DA.Schedules.Instance.GetAll(From, To, room);
                ListSchedule.Clear(); foreach (DataRow Row in DataSource.Rows)
                {
                    Schedule Lss = new Schedule();
                    Lss.Mapping(Row);
                    ListSchedule.Add(Lss);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return Schedules;
        }
        static public Boolean Add(Account User, DateTime Date, Room Room, List<Lesson> Lessons)
        {
            Boolean AllIsAvailable = true;
            foreach (Lesson Lesson in Lessons)
            {
                DataTable Data = new DataTable();
                Data = DA.Schedules.Instance.GetByPrimaryKey(Date, Room.ID, Lesson.ID);
                if (Data.Rows.Count > 0)
                {
                    AllIsAvailable = false;
                }
            }
            if (AllIsAvailable)
            {
                DA.Schedules.Instance.AddAll(User, Date, Room, Lessons);
                return true;

            }
            else return false;
        }
        static public void Remove(Account User, string RoomID, string LessonID, string BookTime)
        {
            try
            {
                DA.Schedules.Instance.Remove(RoomID, LessonID, BookTime);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
    }
}
