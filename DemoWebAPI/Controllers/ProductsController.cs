using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using DemoWebAPI.Services;
using DemoWebAPI.Models;
using DemoWebAPI.Dtos;
using AutoMapper;

namespace DemoWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private IProductsService _service;
        private IMapper _mapper;

        public ProductsController(IProductsService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("/api/products")]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_service.GetProducts());
        }

        [HttpGet("/api/products/{id}")]
        public ActionResult<ProductReadDto> GetProductsById(string id)
        {
            var product = _service.GetProductById(id);
            if(product != null)
            {
                return Ok(_mapper.Map<ProductReadDto>(product));
            }
            return NotFound();
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
            var productUpdate = _service.GetProductById(id);
            if(productUpdate == null)
            {
                return NotFound();
            }
            _service.UpdateProduct(id, product);
            return Ok(product);
        }

        [HttpDelete("/api/products/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            var productDelete = _service.GetProductById(id);
            if(productDelete == null)
            {
                return NotFound();
            }
            _service.DeleteProduct(id);
            return Ok(id);
        }
        [HttpGet("/api/products/search={searchString}")]
        public ActionResult<IEnumerable<Product>> GetSearchProducts(string searchString)
        {
            var productSearch = _service.GetSearchProducts(searchString);
            if(!productSearch.Any())
            {
                return NotFound();
            }
            return productSearch.ToList();
        }
    }
}
