using System.Data;

namespace OG.CRUD.VUE.Infrastructure.Repositories
{
    internal abstract class BaseRepository(IDbTransaction transaction)
    {
        private protected readonly IDbTransaction _transaction = transaction;
        private protected readonly IDbConnection _connection = transaction!.Connection;
    }
}
