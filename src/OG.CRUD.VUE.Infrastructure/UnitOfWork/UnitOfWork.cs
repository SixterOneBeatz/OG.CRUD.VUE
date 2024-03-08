using OG.CRUD.VUE.Application.Common.Repositories;
using OG.CRUD.VUE.Application.Common.UnitOfWork;
using OG.CRUD.VUE.Infrastructure.Repositories;
using System.Data;

namespace OG.CRUD.VUE.Infrastructure.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;
        public UnitOfWork(IDbConnection connection)
        {
            _connection = connection;
            _connection.Open();
            _transaction = _connection.BeginTransaction();

            PersonRepository = new PersonRepository(_transaction);
        }
        public IPersonRepository PersonRepository { get; }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();

            GC.SuppressFinalize(this);
        }

        ~UnitOfWork() => Dispose();
    }
}
