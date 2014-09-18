using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finance.Server.Models
{
    public class Order
    {
        public Order()
        {

        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("StockId")]
        public int StockId { get; set; }

        public virtual Stock Stock { get; set; }

        public decimal Shares { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public bool IsExecuted { get; set; }

        [ForeignKey("AccountId")]
        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}