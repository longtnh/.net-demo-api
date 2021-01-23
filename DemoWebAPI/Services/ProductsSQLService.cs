using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Services
{
    public class ProductsSQLService : IProductsService
    {
        private readonly ProductsContext _context;

        public ProductsSQLService(ProductsContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        public Product GetProductById(string id)
        {
            return _context.Products.FirstOrDefault((p) => p.ID == id);
        }
        public Product AddProduct(Product productItem)
        {
            _context.Products.Add(productItem);
            _context.SaveChanges();
            return productItem;
        }

        public string DeleteProduct(string id)
        {
            Product productItem = _context.Products.Find(id);
            _context.Products.Remove(productItem);
            _context.SaveChanges();
            return id;
        }

        public Product UpdateProduct(string id, Product productItem)
        {
            Product productUpdate = _context.Products.Find(id);
            if (productUpdate.ID == id)
            {
                productUpdate.Name = productItem.Name;
                productUpdate.Brand = productItem.Brand;
                _context.SaveChanges();
            }
            return productItem;
        }

        public IEnumerable<Product> GetSearchProducts(string searchString)
        {
            IEnumerable<Product> products = _context.Products;
            products = products.Where(p => p.Name.ToLower().Contains(searchString.Trim().ToLower()));
            return products;
        }
    }
}
