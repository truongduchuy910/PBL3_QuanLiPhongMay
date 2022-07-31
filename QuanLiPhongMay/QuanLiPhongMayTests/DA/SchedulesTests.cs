using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLiPhongMay.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongMay.DA.Tests
{
    [TestClass()]
    public class SchedulesTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            DateTime From = new DateTime(1990, 12, 01);
            DateTime To = new DateTime(2090, 12, 01);

            DataTable Schs = DA.Schedules.Instance.GetAll(From, To);
            foreach(DataRow Row in Schs.Rows)
            {
                Assert.IsNotNull(Row[0]);
            }

        }
    }
}