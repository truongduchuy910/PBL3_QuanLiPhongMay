using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuanLiPhongMay.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLiPhongMay.BO.Tests
{
    [TestClass()]
    public class AccountTests
    {


        [TestMethod()]
        public void AuthTest()
        {

            BO.Account User = new BO.Account();
            User = BO.Account.Auth("sa1", "123456");
            Assert.AreEqual(true, User.IsTeacher, "OK");
            User = BO.Account.Auth("sa2", "123456");
            Assert.AreEqual(false, User.IsTeacher, "OK");
        }

    }
}