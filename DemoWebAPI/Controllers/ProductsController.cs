using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPI.Services;
using DemoWebAPI.Models;
using Microsoft.Extensions.Logging;

namespace DemoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private ILogger _logger;
        private IProductsService _service;


        public ProductsController(ILogger<ProductsController> logger, IProductsService service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_service.GetProducts());
        }

        [HttpGet("/api/products/{id}")]
        public ActionResult<Product> GetProductsById(string id)
        {
            var product = _service.GetProductById(id);
            if(product == null)
            {
                NotFound();
            }
            return Ok(product);
        }

        [HttpPost("/api/products")]
        public ActionResult<Product> AddProduct(Product product)
        {
            _service.AddProduct(product);
            return Ok(product);
        }

        [HttpPut("/api/products/{id}")]
        public ActionResult<Product> UpdateProduct(string id, Product product)
        {
            _service.UpdateProduct(id, product);
            return Ok(product);
        }

        [HttpDelete("/api/products/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _service.DeleteProduct(id);
            return Ok(id);
        }
    }
}
