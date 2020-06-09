using Northwind.Repositories;

namespace Northwind.UnitOfWork
{
    public class IUnitOfWork
    {
        ICustomerRepository Customer { get; }
    }
}
