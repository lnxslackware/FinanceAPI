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

        IDbSet<Account> Accounts { get; set; }

        IDbSet<Stock> Stocks { get; set; }

        IDbSet<Order> Orders { get; set; }
    }
}