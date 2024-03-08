using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace MedicalScan.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string filePath = "Products.json";

        public void AddProduct(Product product)
        {
            List<Product> products = GetAllProducts();
            products.Add(product);
            SaveAllProducts(products);
        }

        public void DeleteProduct(int id)
        {
            List<Product> products = GetAllProducts();
            products.RemoveAll(x => x.Id == id);
            SaveAllProducts(products);
        }

        public Product GetProduct(int id)
        {
            string json = File.ReadAllText(filePath);
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(json);
            return products.Find(x => x.Id == id);
        }

        public List<Product> GetAllProducts()
        {
            if (!File.Exists(filePath))
                return new List<Product>();

            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<Product>>(json);
        }

        public void UpdateProduct(Product product)
        {
            List<Product> products = GetAllProducts();
            List<Product> updatedProducts = products.ConvertAll(x => x.Id == product.Id ? product : x);
            SaveAllProducts(updatedProducts);
        }

        public void SaveAllProducts(List<Product> products)
        {
            string json = JsonConvert.SerializeObject(products);
            File.WriteAllText(filePath, json);
        }
    }
}