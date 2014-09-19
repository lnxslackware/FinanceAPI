namespace Finance.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Finance.Models;

    public interface IFinanceContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Stock> Stocks { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
