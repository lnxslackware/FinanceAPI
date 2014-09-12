using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceAPI.Models
{
    public class Stock
    {
        public Stock()
        {
            
        }

        public int Id { get; set; }

        [Required]
        [StringLength(4)]
        public string Name { get; set; }
    }
}