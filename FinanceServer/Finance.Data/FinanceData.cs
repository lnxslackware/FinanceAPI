namespace Finance.Data
{
    using System;
    using System.Collections.Generic;

    using Finance.Models;
    using Finance.Repository;

    public class FinanceData : IFinanceData
    {
        private IFinanceContext context;
        private IDictionary<Type, object> repositories;

        public FinanceData()
            : this(new FinanceContext())
        {
        }

        public FinanceData(IFinanceContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<Account> Accounts
        {
            get
            {
                return this.GetRepository<Account>();
            }
        }

        public IGenericRepository<Order> Orders
        {
            get
            {
                return this.GetRepository<Order>();
            }
        }

        public IGenericRepository<Stock> Stocks
        {
            get
            {
                return this.GetRepository<Stock>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}