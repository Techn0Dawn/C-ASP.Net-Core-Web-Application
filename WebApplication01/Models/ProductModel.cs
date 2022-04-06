using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication01.Models
{
    public class ProductModel
    {   
        [DisplayName("ID number")]
        public int Id { get; set; }
        [DisplayName("Product Name")]
        public string Name { get; set; }
        [DisplayName("Cost to customer")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DisplayName("What you get ...")]
        public string Description { get; set; }
    }
}
