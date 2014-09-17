using System.ComponentModel.DataAnnotations;

namespace Finance.Server.Models
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