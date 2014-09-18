namespace Finance.Models
{
    using System.ComponentModel.DataAnnotations;

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