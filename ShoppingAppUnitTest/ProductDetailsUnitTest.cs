using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShoppingAppAPI;
using ShoppingAppAPI.Controllers;
using ShoppingAppAPI.Model;

namespace ShoppingAppUnitTest
{
    [TestClass]
    public class ProductDetailsUnitTest
    {
        [TestMethod]
        public void TestMethod_GetProductDetails()
        {
            // Arrange
            var mock = new Mock<ILogger<ShoppingController>>();
            ILogger<ShoppingController> logger = mock.Object;
            var _productdetail = new Mock<IProductDetails>();
           
            // Act
              // var controller = new ShoppingController(logger, (IProductDetails)_productdetail);
              // var data = controller.Get();

            ProductDetails product = new ProductDetails();
            var data =  product.GetDetails();

            // Assert
            Assert.IsNotNull(data);
        }
    }
}
