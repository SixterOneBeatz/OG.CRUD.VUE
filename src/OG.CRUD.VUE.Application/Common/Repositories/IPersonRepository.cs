using OG.CRUD.VUE.Domain;

namespace OG.CRUD.VUE.Application.Common.Repositories
{
    public interface IPersonRepository
    {
        Task<List<PersonDOM>> GetAll();
        Task<PersonDOM> GetSingle(int id);
        Task Add(PersonDOM person);
        Task Update(PersonDOM person);
        Task Delete(int id);
    }
}
