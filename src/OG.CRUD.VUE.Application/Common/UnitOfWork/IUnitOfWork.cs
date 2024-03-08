using OG.CRUD.VUE.Application.Common.Repositories;

namespace OG.CRUD.VUE.Application.Common.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonRepository PersonRepository { get; }
        void Commit();
    }
}
