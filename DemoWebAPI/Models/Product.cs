using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPI.Models
{
    public class Product
    {
        [Key]
        public String ID { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Brand { get; set; }
    }
}
