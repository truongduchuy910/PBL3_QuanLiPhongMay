using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiPhongMay.DA
{
    class Reports
    {
        private static Reports instance;
        public static Reports Instance
        {
            get
            {
                if (instance == null) Reports.instance = new Reports();
                return Reports.instance;
            }
            private set
            {
                Reports.instance = value;
            }
        }
        private Reports() { }
        public DataTable GetAll()
        {
            string query = "select * from Reports";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public DataTable GetByID(int ID)
        {
            string query = $"select * from Reports where id = {ID}";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result;
        }
        public void Add(BO.Report Rpt)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            string time = DateTime.Now.ToShortDateString();
            string query = $"Insert into Reports values(N'{ Rpt.Content }','{ time }',{ Rpt.Computer.ID })";
            DA.DataProvider.Instance.ExecuteNonQuery(query);

        }
        public void Remove(BO.Report Rpt)
        {
            string query = $"Delete Reports where ID = '{Rpt.ID}'";
            DA.DataProvider.Instance.ExecuteNonQuery(query);
        }

    }

}
