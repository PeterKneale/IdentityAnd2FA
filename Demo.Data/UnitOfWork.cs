using System;
using System.Data;
using System.Data.SqlClient;
using Demo.Data.Sources;
using Demo.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Demo.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Begin();
        void Commit();
        void Rollback();
        IUserDataSource Users { get; }
    }

    public class UnitOfWork : IUnitOfWork
    {
        private IDbTransaction _transaction;
        private IDbConnection _connection;
        private readonly ILogger<UnitOfWork> _log;

        public UnitOfWork(IConfig config, ILogger<UnitOfWork> log)
        {
            _log = log;
            Connect(config);
        }

        private void Connect(IConfig config)
        {
            try
            {
                _connection = new SqlConnection(config.AppConnectionString);
            }
            catch (Exception ex)
            {
                _log.LogCritical(ex, $"Unable to connect to database. {ex.Message}");
                throw;
            }
        }

        public void Begin()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _log.LogDebug("Opening connection.");
                _connection.Open();
            }

            _log.LogDebug("Begin transaction.");
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _log.LogDebug("Commit transaction.");
            _transaction.Commit();
        }

        public void Rollback()
        {
            _log.LogWarning("Rollback Transaction.");
            _transaction.Rollback();
        }

        public IUserDataSource Users => new UserDataSource(_connection, _transaction);
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
            if (_connection == null)
            {
                return;
            }
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
            _connection = null;
        }
    }
}
