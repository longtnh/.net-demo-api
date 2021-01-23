using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Services
{
    public class ProductsService : IProductsService
    {
        private List<Product> _productItems = new List<Product>();

        public ProductsService()
        {
            _productItems = new List<Product>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _productItems;
        }
        public Product GetProductById(string id)
        {
            var product = _productItems.FirstOrDefault((p) => p.ID == id);
            return product;
        }

        public Product AddProduct(Product productItem)
        {
            _productItems.Add(productItem);
            return productItem;
        }

        public Product UpdateProduct(string id, Product productItem)
        {
            for (var index = _productItems.Count - 1; index >= 0; index--)
            {
                if (_productItems[index].ID == id)
                {
                    _productItems[index] = productItem;
                }
            }
            return productItem;
        }

        public string DeleteProduct(string id)
        {
            for (var index = _productItems.Count - 1; index >= 0; index--)
            {
                if (_productItems[index].ID == id)
                {
                    _productItems.RemoveAt(index);
                }
            }
            return id;
        }

        public IEnumerable<Product> GetSearchProducts(string searchString)
        {
            throw new NotImplementedException();
        }
    }
}
