using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongMay.DA
{
    public class Lesson
    {
        private static Lesson instance;

        public static Lesson Instance
        {
            get
            {
                if (instance == null) Lesson.instance = new Lesson();
                return Lesson.instance;
            }
            private set
            {
                Lesson.instance = value;
            }
        }
        private Lesson() { }
        public DataTable GetAll()
        {
            string query = "select  Name, Description, ID from lesson";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetByID(int ID)
        {
            string query = $"select * from lesson where id ={ID}";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }

    }
}
