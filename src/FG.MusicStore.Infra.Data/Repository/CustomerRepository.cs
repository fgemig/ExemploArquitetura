using System;
using FG.MusicStore.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FG.MusicStore.Domain.Entities.Customers.Repository;
using FG.MusicStore.Domain.Entities.Customers;

namespace FG.MusicStore.Infra.Data.Repository
{
    public sealed class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(MusicStoreContext context) : base(context)
        {
           
        }       

        public async Task<IEnumerable<Customer>> GetCustomerByName(string name)
        {
            return await Find(c => c.Name.StartsWith(name));
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await DbSet.OrderBy(c => c.Name).Where(c => c.Email != string.Empty).AsNoTracking().ToListAsync();
        }
        
    }
}
