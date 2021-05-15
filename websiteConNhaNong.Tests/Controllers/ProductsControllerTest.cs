using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using websiteConNhaNong.Controllers;
using System.Collections.Generic;
using websiteConNhaNong.Models;
using System.Linq;

namespace websiteConNhaNong.Tests.Controllers
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var controller = new ProductsController();
            
            var result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);

            var model = result.Model as List<Product>;
            Assert.IsNotNull(model);

            var db = new CT25Team18Entities1();
            Assert.AreEqual(db.Products.Count(), model.Count);
        }
    }
}
