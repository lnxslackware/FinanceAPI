using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceAPI.Models
{
    public class Order
    {
        public Order()
        {

        }

        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public int StockId { get; set; }

        [ForeignKey("StockId")]
        public virtual Stock Stock { get; set; }

        public decimal Shares { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public bool IsExecuted { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
    }
}