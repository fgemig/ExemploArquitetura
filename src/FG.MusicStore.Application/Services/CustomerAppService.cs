using AutoMapper;
using FG.MusicStore.Application.Contracts;
using FG.MusicStore.Application.ViewModels;
using FG.MusicStore.Domain.Contracts.Repository;
using FG.MusicStore.Domain.Entities.Customers;
using FG.MusicStore.Domain.Entities.Customers.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FG.MusicStore.Application.Services
{
    public class CustomerAppService : ICustomerAppService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomerAppService(
            ICustomerRepository customerRepository, IUnitOfWork uow, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _uow = uow;
            _mapper = mapper;
        }

        public void Add(CustomerViewModel model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepository.Add(customer);
            _uow.Commit();
        }

        public void Update(CustomerViewModel model)
        {
            var customer = _mapper.Map<Customer>(model);
            _customerRepository.Update(customer);
            _uow.Commit();
        }

        public void Remove(Guid id)
        {
            _customerRepository.Remove(id);
            _uow.Commit();
        }

        public async Task<CustomerViewModel> GetById(Guid id)
        {
            var customerById = await _customerRepository.GetById(id);
            return _mapper.Map<CustomerViewModel>(customerById);
        }

        public async Task<IEnumerable<CustomerViewModel>> GetCustomerByName(string name)
        {
            var customersByName = await _customerRepository.GetCustomerByName(name);
            return _mapper.Map<IEnumerable<CustomerViewModel>>(customersByName);
        }
        
        public async Task<IEnumerable<CustomerViewModel>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            return _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
        }

        public void Dispose()
        {
            _customerRepository.Dispose();
        }

    }
}
