using Northwind.Models;
using Northwind.Repositories;
using System.Data.SqlClient;
using Dapper;

namespace Northwind.DataAcces
{
    public class UserRepository : Repository<User> , IUserRepository
    {

        public UserRepository(string connectionString) : base(connectionString)
        {

        }

        public User ValidaterUser(string email, string password)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@email",    email);
            parameters.Add("@password", password);

            using (var connection = new SqlConnection(_connectionString)){

                return connection.QueryFirstOrDefault<User>("dbo.ValidateUser", 
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure    
                                                );
            }
        }
    }

}