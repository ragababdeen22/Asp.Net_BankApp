using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using WebApp_Bank_App.Controllers;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Index()
        {
            User_TbController user = new User_TbController();
         
            ViewResult result = (ViewResult)user.Index();


            Assert.AreEqual("Testing view Data Result", result.ViewData["view Data Result"]);
        }

        [TestMethod]
        public void TestAbout()
        {
            User_TbController user = new User_TbController();


           ViewResult result = (ViewResult)user.Index();

            Assert.AreEqual("About", result.ViewBag.Title);

        }



    }
}