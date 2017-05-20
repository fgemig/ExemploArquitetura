using AutoMapper;
using FG.MusicStore.Application.Contracts;
using FG.MusicStore.Application.Services;
using FG.MusicStore.Domain.Contracts.Repository;
using FG.MusicStore.Domain.Entities.Customers.Repository;
using FG.MusicStore.Infra.Data.Context;
using FG.MusicStore.Infra.Data.Repository;
using FG.MusicStore.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace FG.MusicStore.Infra.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // ASPNET
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Application Auto Mapper
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
           
            // Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();           
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<MusicStoreContext>();

        }
    }
}
