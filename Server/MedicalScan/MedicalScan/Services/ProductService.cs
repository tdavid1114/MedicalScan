using MedicalScan.Repositories;

namespace MedicalScan.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            product.Id = productRepository.GetAllProducts().Count() + 1;
            productRepository.AddProduct(product);
        }

        public void DeleteProduct(int id)
        {
            productRepository.DeleteProduct(id);
        }

        public List<Product> GetAllProducts()
        {
            return productRepository.GetAllProducts();
        }

        public Product GetProduct(int id)
        {
            return productRepository.GetProduct(id);
        }

        public void UpdateProduct(Product product)
        {
            productRepository.UpdateProduct(product);
        }
    }
}