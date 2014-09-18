namespace Finance.Data
{
    using Finance.Models;
    using Finance.Repository;

    public interface IFinanceData
    {
        IGenericRepository<Account> Accounts { get; }

        IGenericRepository<Order> Orders { get; }

        IGenericRepository<Stock> Stocks { get; }

        void SaveChanges();
    }
}