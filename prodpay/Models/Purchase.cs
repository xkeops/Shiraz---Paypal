using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdPay.Models
{
    public class Purchase
    {
        [Required(ErrorMessage = "Mandatory Field")]
        [RegularExpression("\\d+", ErrorMessage = "Must be a number")]
        [Range(1000, 2000, ErrorMessage = "ID phải từ 1000-2000")]
        public int item_number { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Product name 5 to 100 characters")]
        public string item_name { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [Range(1.0, 100.0, ErrorMessage = "Prices from US $ 1-100")]
        public double amount { get; set; }

        [Required(ErrorMessage = "Mandatory Field")]
        [RegularExpression("\\d+", ErrorMessage = "Must be a number")]
        [Range(1, 100, ErrorMessage = "The number must be between 1-100")]
        public int quantity { get; set; }
    }
}
