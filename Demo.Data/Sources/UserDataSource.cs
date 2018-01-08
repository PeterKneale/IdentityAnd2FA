using System.Data;
using System.Threading.Tasks;
using Dapper;
using DB = Demo.Database.DatabaseSchema;

namespace Demo.Data.Sources
{
    public interface IUserDataSource : IDataSource<UserData>
    {
        Task<UserData> GetByUserName(string username);
        Task<UserData> GetByEmail(string email);
    }

    public class UserDataSource : DataSource<UserData>, IUserDataSource
    {
        public UserDataSource(IDbConnection connection, IDbTransaction transaction = null) : base(connection, transaction)
        {
        }

        public async Task<UserData> GetByEmail(string email)
        {
            var query = $"select * from {DB.TableUser} where {DB.ColumnNormalizedEmail} = @email";
            return await Connection.QueryFirstOrDefaultAsync<UserData>(query, new { email }, Transaction);
        }

        public async Task<UserData> GetByUserName(string username)
        {
            var query = $"select * from {DB.TableUser} where {DB.ColumnNormalizedUserName} = @username";
            return await Connection.QueryFirstOrDefaultAsync<UserData>(query, new { username }, Transaction);
        }
    }
}
