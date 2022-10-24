using eUseControl.BusinessLogic.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eUseControl.BusinessLogic
{
    internal class Tests
    {
        IProduct products = new ProductBL();
        [Test]
        public void ProductInsert()
        {
            var result = products.Insert(new Domain.Entities.Products.PDbTable()
            {
                ImagePath = "Images/123.jpg",
                Name = "123",
                Price = 123
            }).Status;
            Assert.IsTrue(result);
        }
        [Test]
        public void DeleteUnexistentProduct()
        {
            Assert.IsFalse(products.Delete(123).Status);
        }
        [Test]
        public void DeleteExistentProduct()
        {
            var product = products.Get().Last();
            var result = products.Delete(product.Id).Status;
            products.Insert(product);
            Assert.IsTrue(result);
        }
    }
}
