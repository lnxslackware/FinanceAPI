using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinanceAPI.Models
{
    public class Account
    {
        public int Id { get; set; }

        [StringLength(12,MinimumLength = 8)]
        public string Login { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastLogOn { get; set; }
    }
}