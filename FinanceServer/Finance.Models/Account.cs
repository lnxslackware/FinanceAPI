namespace Finance.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Account
    {
        public Account()
        {
        }

        public int Id { get; set; }

        [StringLength(12, MinimumLength = 8)]
        public string Login { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastLogOn { get; set; }
    }
}