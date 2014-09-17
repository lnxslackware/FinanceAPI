using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Finance.Server.Models
{
    public class Account
    {
        public Account()
        {
            this.Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [StringLength(12, MinimumLength = 8)]
        public string Login { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastLogOn { get; set; }

        public virtual HashSet<Order> Orders { get; set; }
    }
}