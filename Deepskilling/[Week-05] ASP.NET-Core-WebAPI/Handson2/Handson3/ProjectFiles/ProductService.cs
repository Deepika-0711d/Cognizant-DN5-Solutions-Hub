using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService
    {
        private static List<Product> productsList = new List<Product>
        {
            new Product { productId = 1, productName = "Laptop", productDescription = "High performance laptop", productPrice = 75000, productStock = 10, productCategory = "Electronics", createdDate = DateTime.Now },
            new Product { productId = 2, productName = "Mouse", productDescription = "Wireless mouse", productPrice = 1500, productStock = 50, productCategory = "Electronics", createdDate = DateTime.Now },
            new Product { productId = 3, productName = "Keyboard", productDescription = "Mechanical keyboard", productPrice = 5000, productStock = 25, productCategory = "Electronics", createdDate = DateTime.Now }
        };

        public List<Product> GetAllProducts()
        {
            return productsList;
        }

        public Product GetProductById(int id)
        {
            return productsList.FirstOrDefault(p => p.productId == id);
        }

        public Product CreateProduct(Product newProduct)
        {
            newProduct.productId = productsList.Count > 0 ? productsList.Max(p => p.productId) + 1 : 1;
            newProduct.createdDate = DateTime.Now;
            productsList.Add(newProduct);
            return newProduct;
        }

        public Product UpdateProduct(int id, Product updatedProduct)
        {
            var productRecord = productsList.FirstOrDefault(p => p.productId == id);
            if (productRecord == null)
                return null;

            productRecord.productName = updatedProduct.productName;
            productRecord.productDescription = updatedProduct.productDescription;
            productRecord.productPrice = updatedProduct.productPrice;
            productRecord.productStock = updatedProduct.productStock;
            productRecord.productCategory = updatedProduct.productCategory;

            return productRecord;
        }

        public bool DeleteProduct(int id)
        {
            var productRecord = productsList.FirstOrDefault(p => p.productId == id);
            if (productRecord == null)
                return false;

            productsList.Remove(productRecord);
            return true;
        }

        public List<Product> SearchByCategory(string categoryName)
        {
            return productsList.Where(p => p.productCategory.ToLower() == categoryName.ToLower()).ToList();
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            return productsList.Where(p => p.productStock <= threshold).ToList();
        }
    }
}
