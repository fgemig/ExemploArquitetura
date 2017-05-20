using AutoMapper;
using FG.MusicStore.Application.ViewModels;
using FG.MusicStore.Domain.Entities.Customers;

namespace FG.MusicStore.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Customer, CustomerViewModel>();                        
        }
    }
}