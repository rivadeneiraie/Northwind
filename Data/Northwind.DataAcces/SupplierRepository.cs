using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using Northwind.Repositories;
using Northwind.Models;

namespace Northwind.DataAcces
{

    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(string connectionString) : base(connectionString)
        {

        }
        public IEnumerable<Supplier> SupplierPageList(int page, int rows)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString)){

                return connection.Query<Supplier>("dbo.SupplierPagedList", 
                                                    parameters,
                                                    commandType: System.Data.CommandType.StoredProcedure    
                                                );
            }

        }

    }
}