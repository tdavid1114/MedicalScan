namespace MedicalScan.Services
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product GetProduct(int id);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);
    }
}