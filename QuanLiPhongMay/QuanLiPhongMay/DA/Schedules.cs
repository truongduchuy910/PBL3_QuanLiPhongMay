using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongMay.DA
{
    public class Schedules
    {
        private static Schedules instance;

        public static Schedules Instance
        {
            get
            {
                if (instance == null) Schedules.instance = new Schedules();
                return Schedules.instance;
            }
            private set
            {
                Schedules.instance = value;
            }
        }
        private Schedules() { }

        public DataTable GetAll(DateTime from, DateTime to)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            string query = "Select * from Schedules WHERE bookTime BETWEEN '" + from.ToShortDateString() + "' AND '" + to.ToShortDateString() + "'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetOwn(DateTime from, DateTime to, BO.Account User)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            string query = $"Select * from Schedules WHERE bookTime BETWEEN '{ from.ToShortDateString() }' AND '{ to.ToShortDateString() }' AND UserId = '{User.UserID}'";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetAll(DateTime from, DateTime to, BO.Room room)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            string query = $"Select * from Schedules WHERE bookTime BETWEEN '{ from.ToShortDateString() }' AND '{ to.ToShortDateString() }' and roomId={room.ID}";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetAll()
        {
            string query = "Select * from Schedules";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

        public void AddAll(BO.Account account, DateTime date, BO.Room room, List<BO.Lesson> lesson)
        {
            for (int i = 0; i < lesson.Count; i++)
            {
                string query = $"insert into Schedules values('{room.ID}','{account.UserID}','{lesson[i].ID}','{date.ToString()}')";
                DataProvider.Instance.ExecuteNonQuery(query);
            }
        }
        public DataTable GetByPrimaryKey(DateTime date, int roomID, int lessionID)
        {
            string query = $"select * from Schedules where bookTime = '{date.ToShortDateString()}' and roomID = {roomID} and lessonID = {lessionID}";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
        public void Remove(string RoomID, string LessonID, string bookTime)
        {
            string query = $"delete from Schedules where RoomId = {RoomID} And LessonId = {LessonID} And bookTime = '{bookTime}'";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
