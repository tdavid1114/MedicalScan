using FakeItEasy;
using FluentAssertions;
using MedicalScan;
using MedicalScan.Controllers;
using MedicalScan.Services;

namespace MedicalScanTest
{
    public class ProductControllerTest
    {
        private IProductService productService;

        public ProductControllerTest()
        {
            this.productService = A.Fake<IProductService>();
        }

        [Fact]
        public void GetAllProducts_WhenProductExists_ReturnsOk()
        {
            //Arrange
            var product = A.Fake<List<Product>>();
            var controller = new ProductController(this.productService);

            //Act
            var restult = controller.GetAllProducts();

            //Assert
            restult.Should().NotBeNull();
        }
    }
}