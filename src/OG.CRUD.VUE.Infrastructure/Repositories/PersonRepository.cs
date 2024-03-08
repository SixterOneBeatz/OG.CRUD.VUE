using Dapper;
using OG.CRUD.VUE.Application.Common.Repositories;
using OG.CRUD.VUE.Domain;
using System.Data;

namespace OG.CRUD.VUE.Infrastructure.Repositories
{
    internal class PersonRepository(IDbTransaction transaction) : BaseRepository(transaction), IPersonRepository
    {
        public async Task Add(PersonDOM person)
        {
            DynamicParameters parameters = new();
            parameters.Add("first_name", person.FirstName, DbType.String);
            parameters.Add("last_name", person.LastName, DbType.String);
            parameters.Add("dob", person.DoB, DbType.Date);

            await _connection.ExecuteAsync("sp_persons_ins", parameters, transaction: _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(int id)
        {
            DynamicParameters parameters = new();
            parameters.Add("person_id", id, DbType.Int32);

            await _connection.ExecuteAsync("sp_persons_del", parameters, transaction: _transaction, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<PersonDOM>> GetAll()
        {
            return (await _connection.QueryAsync<PersonDOM>("SELECT * FROM fn_persons_qry()")).ToList();
        }

        public async Task<PersonDOM> GetSingle(int id)
        {
            return await _connection.QueryFirstAsync<PersonDOM>("SELECT * FROM fn_persons_qry(@person_id)", new { person_id = id });
        }

        public async Task Update(PersonDOM person)
        {
            DynamicParameters parameters = new();
            parameters.Add("person_id", person.Id, DbType.Int32);
            parameters.Add("first_name", person.FirstName, DbType.String);
            parameters.Add("last_name", person.LastName, DbType.String);
            parameters.Add("dob", person.DoB, DbType.Date);

            await _connection.ExecuteAsync("sp_persons_upd", parameters, transaction: _transaction, commandType: CommandType.StoredProcedure);
        }
    }
}
