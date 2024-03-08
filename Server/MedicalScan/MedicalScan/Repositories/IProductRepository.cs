namespace MedicalScan.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product GetProduct(int id);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(int id);

        void SaveAllProducts(List<Product> products);
    }
}