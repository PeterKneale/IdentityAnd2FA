using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace Demo.Data
{
    public interface IDataSource<T> where T : class, IData
    {
        void Save(T item);
        Task SaveAsync(T item);
        IEnumerable<T> List();
        T Get(Guid id);
        Task<T> GetAsync(Guid id);
        bool Exists(Guid id);
        void Delete(Guid id);
        Task DeleteAsync(Guid id);
        void Update(T item);
        Task UpdateAsync(T item);
    }

    public class DataSource<T> : IDataSource<T> where T : class, IData
    {
        protected IDbTransaction Transaction;
        protected IDbConnection Connection;

        public DataSource(IDbConnection connection, IDbTransaction transaction = null)
        {
            Connection = connection;
            Transaction = transaction;
        }

        public void Save(T item)
        {
            Connection.Insert<Guid, T>(item, Transaction);
        }

        public async Task SaveAsync(T item)
        {
            await Connection.InsertAsync<Guid, T>(item, Transaction);
        }

        public void Update(T item)
        {
            Connection.Update(item, Transaction);
        }

        public Task UpdateAsync(T item)
        {
            return Connection.UpdateAsync(item, Transaction);
        }

        public void Delete(Guid id)
        {
            Connection.Delete<T>(id, Transaction);
        }

        public async Task DeleteAsync(Guid id)
        {
            await Connection.DeleteAsync<T>(id, Transaction);
        }

        public T Get(Guid id)
        {
            return Connection.Get<T>(id, Transaction);
        }

        public Task<T> GetAsync(Guid id)
        {
            return Connection.GetAsync<T>(id, Transaction);
        }

        public IEnumerable<T> List()
        {
            return Connection.GetList<T>(null, transaction: Transaction);
        }

        public bool Exists(Guid id)
        {
            return Get(id)!=null;
        }
    }
}
