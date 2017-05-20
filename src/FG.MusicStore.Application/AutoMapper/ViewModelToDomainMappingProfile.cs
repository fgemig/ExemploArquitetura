using AutoMapper;
using FG.MusicStore.Application.ViewModels;
using FG.MusicStore.Domain.Entities.Customers;

namespace FG.MusicStore.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CustomerViewModel, Customer>()
                .ConstructUsing(c => new Customer(c.Name, c.Email));
        }
    }
}