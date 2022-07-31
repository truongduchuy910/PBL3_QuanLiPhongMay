using System;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace QuanLiPhongMay.BO
{
    public class Lesson
    {

        public static DataTable DataSource;
        public static List<Lesson> ListLesson;
        
        public Lesson()
        {
            ListLesson = new List<Lesson>();
        }

        //
        // Column in Database
        //
        private int _ID;
        private string _Name;
        private string _Description;
        //
        // Fields
        //
        public int ID { get => _ID; set => _ID = value; }
        public string Name { get => _Name; set => _Name = value; }
        public string Description { get => _Description; set => _Description = value; }
        private void Mapping(DataRow Row)
        {
            this._ID = Row.Field<int>("ID");
            this._Name = Row.Field<string>("Name");
            this._Description = Row.Field<String>("Description");
        }
        public void GetByID(int ID)
        {
            try
            {
                DataSource = DA.Lesson.Instance.GetByID(ID);
                this.Mapping(DataSource.Rows[0]);
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
                DataSource = DA.Lesson.Instance.GetAll();
                foreach (DataRow Row in DataSource.Rows)
                {
                    Lesson Lss = new Lesson();
                    Lss.Mapping(Row);
                    ListLesson.Add(Lss);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
