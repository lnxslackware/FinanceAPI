using System.Data.Entity;
using Finance.Server.Models;

namespace Finance.Server.Database
{
    public class FinanceContext : DbContext
    {
        public FinanceContext()
            : base("name=Finance")
        {
        }

       public IDbSet<Account> Accounts { get; set; }

        public IDbSet<Stock> Stocks { get; set; }

        public IDbSet<Order> Orders { get; set; }
    }
}