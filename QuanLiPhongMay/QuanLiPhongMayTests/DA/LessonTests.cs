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
    public class LessonTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            DataTable Lss = DA.Lesson.Instance.GetAll();
            foreach (DataRow Row in Lss.Rows)
            {
                Assert.IsNotNull(Row);
            }
        }
    }
}