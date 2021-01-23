using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoWebAPI.Models;

namespace DemoWebAPI.Services
{
    public class ProductsContext : DbContext
    {
        public ProductsContext(DbContextOptions<ProductsContext> opt) : base(opt)
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
