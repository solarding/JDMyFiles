using Microsoft.VisualStudio.TestTools.UnitTesting;
using JD.MF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JD.MF.Tests
{
    [TestClass()]
    public class ZHTests
    {
        [TestMethod()]
        public void ToDBCTest()
        {
            string strSBC = "中华１２５９ｔｅｓｔ【】＜＞";
            string result = ZH.ToDBC(strSBC);
            Console.WriteLine(result);
            Assert.AreEqual(result, "中华1259test[]<>");
        }
    }
}