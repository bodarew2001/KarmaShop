using eUseControl.BusinessLogic;
using eUseControl.BusinessLogic.Interfaces;

namespace Tests
{
    public class Tests
    {
        IProduct products = new ProductBL();

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var result=products.Insert(new eUseControl.Domain.Entities.Products.PDbTable()
            {
                ImagePath = "123",
                Name = "123",
                Price = 123
            }).Status;
            Assert.AreEqual(result, true);
        }
    }
}       