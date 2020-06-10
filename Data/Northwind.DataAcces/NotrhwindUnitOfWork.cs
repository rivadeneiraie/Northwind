using Northwind.UnitOfWork;
using Northwind.Repositories;

namespace Northwind.DataAcces
{
    public class NorthwindUnitOfWork : IUnitOfWork
    {
        public NorthwindUnitOfWork(string connectionString){

            Customer = new CustomerRepository(connectionString);
            
            User = new UserRepository(connectionString);
        }
        public ICustomerRepository Customer { get; private set;}
        public IUserRepository User { get ; private set; }
    }
}