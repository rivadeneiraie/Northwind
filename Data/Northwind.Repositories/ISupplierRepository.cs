using System.Collections.Generic;
using Northwind.Models;

namespace Northwind.Repositories
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        IEnumerable<Supplier> SupplierPageList(int page, int rows);
    }
}