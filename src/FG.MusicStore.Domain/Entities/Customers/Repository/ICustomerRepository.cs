using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FG.MusicStore.Domain.Contracts.Repository;

namespace FG.MusicStore.Domain.Entities.Customers.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetCustomerByName(string name);
        Task<IEnumerable<Customer>> GetCustomers();
    }
}
