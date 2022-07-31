using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLiPhongMay.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiPhongMay.BO.Tests
{
    [TestClass()]
    public class ComputerTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            List<Room> Rooms = BO.Room.GetAll();
            foreach (Room Room in Rooms)
            {
                Assert.IsNotNull(BO.Computer.GetAll(Room.ID));
            }

        }
    }
}