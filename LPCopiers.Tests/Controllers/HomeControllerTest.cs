using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LPCopiers;
using LPCopiers.Controllers;
using LPCopiers.Models;

namespace LPCopiers.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Providing cost effective copier and printer repair solutions", result.ViewBag.Heading);
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ContactBeforefive()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ContactAfterFive()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.OutOfHours() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ThankYou()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.ThankYou("Message") as ViewResult;

            Assert.AreEqual("Message", result.ViewBag.Request);

        }

        [TestMethod]
        public void Manufacturers()
        {
            HomeController controller = new HomeController();

            ViewResult result = controller.Manufacturers() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ManufacturersPost()
        {
            HomeController controller = new HomeController();

            Manufacture m = new Manufacture();
            m.Photocopier = "Canon";
            m.Printer = "HP";
            m.Fax = "Ricoh";

            string contents = "http://www.canon.co.uk/For_Work/business-products/office-printers/all-in-one-office-printers/index.aspx";

            ViewResult result = controller.Manufacturers(m) as ViewResult;

            Assert.AreEqual(contents, m.CopierURL);
        }

        [TestMethod]
        public void SelectedManufacturers()
        {
            HomeController controller = new HomeController();

            Manufacture m = new Manufacture();
            m.Photocopier = "Canon";
            m.Printer = "HP";
            m.Fax = "Ricoh";

            ViewResult result = controller.SelectedManufacturers(m) as ViewResult;

            Assert.IsNotNull(result);
        }

    }
}
