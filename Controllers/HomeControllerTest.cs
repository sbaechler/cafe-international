using System;
using System.Web.Mvc;
using CafeInternational.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeInternational.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var homeController = new HomeController();
            ActionResult response = homeController.Index();
            Assert.IsNotNull(response);
            Assert.IsTrue(response is ViewResult);
        }
    }
}
