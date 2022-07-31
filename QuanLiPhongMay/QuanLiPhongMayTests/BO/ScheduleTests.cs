using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLiPhongMay.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongMay.BO.Tests
{
    [TestClass()]
    public class ScheduleTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            DateTime From = new DateTime(1990, 12, 01);
            DateTime To = new DateTime(2090, 12, 01);
            List<Schedule> Schedules = BO.Schedule.GetAll(From, To);
            foreach(Schedule Sch in Schedules)
            {
                Assert.IsNotNull(Sch);
            }
        }

        [TestMethod()]
        public void AddTest()
        {

        }

        [TestMethod()]
        public void RemoveTest()
        {

        }
    }
}