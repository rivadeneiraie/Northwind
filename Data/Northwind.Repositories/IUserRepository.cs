using Northwind.Models;

namespace Northwind.Repositories
{

    public interface IUserRepository : IRepository<User>
    {
        User ValidaterUser(string email, string password);
    }
}