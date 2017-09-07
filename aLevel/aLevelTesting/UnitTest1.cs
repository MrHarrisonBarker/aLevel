using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using aLevel.Controllers;
using System.Web.Mvc;

namespace aLevelTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SampleTest()
        {
            Assert.AreEqual("HomeController", "HomeController");
        }

        [TestMethod]
        public void TestView()
        {
            var controller = new HomeController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        
    }
}

