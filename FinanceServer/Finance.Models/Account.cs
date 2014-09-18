namespace Finance.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

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