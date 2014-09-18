namespace Finance.Data
{
    using Finance.Models;
    using System.Data.Entity;

    public class FinanceContext : DbContext, IFinanceContext
    {
        public FinanceContext()
            : base("FinanceConnectionDB")
        {
            // Database.SetInitializer(new MigrateDatabaseToLatestVersion<MusicDataContext, Configuration>());
        }

        public IDbSet<Account> Accounts { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Stock> Stocks { get; set; }


        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
