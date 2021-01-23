using System.Collections.Generic;
using DemoWebAPI.Models;

namespace DemoWebAPI.Services
{
    public interface IProductsService
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(string id);
        Product AddProduct(Product productItem);
        Product UpdateProduct(string id, Product productItem);
        string DeleteProduct(string id);
        IEnumerable<Product> GetSearchProducts(string searchString);
    }
}
