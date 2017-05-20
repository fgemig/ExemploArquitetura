using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FG.MusicStore.Application.ViewModels;

namespace FG.MusicStore.Application.Contracts
{
    public interface ICustomerAppService : IDisposable
    {
        void Add(CustomerViewModel model);
        void Update(CustomerViewModel model);
        void Remove(Guid id);        
        Task<CustomerViewModel> GetById(Guid id);
        Task<IEnumerable<CustomerViewModel>> GetCustomers();
        Task<IEnumerable<CustomerViewModel>> GetCustomerByName(string name);
    }
}
