namespace Finance.Data
{
    using Finance.Data.Migrations;
    using Finance.Models;
    using System.Data.Entity;

    public class FinanceContext : DbContext, IFinanceContext
    {
        public FinanceContext()
            : base("Finance")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<FinanceContext, Configuration>());
        }

        public IDbSet<User> Users { get; set; }

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
