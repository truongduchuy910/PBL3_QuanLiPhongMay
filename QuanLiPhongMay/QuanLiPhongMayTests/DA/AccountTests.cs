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
    public class AccountTests
    {
        [TestMethod()]
        public void AuthTest()
        {
            DataTable data =  DA.Account.Instance.Auth("sa1", "123456");
            Assert.AreEqual("True", data.Rows[0]["IsTeacher"].ToString(), "OK");
        }
    }
}