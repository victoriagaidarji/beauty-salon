using ClassLibrary;
using ClassLibrary.Providers;
using Microsoft.Extensions.DependencyInjection;
using Photo.Service.Interface;

namespace Pictures.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection service)
    {
        service.AddDbContext<ApplicationContext>();
        service.AddScoped<IClientProvider, ClientProvider>();
        service.AddScoped<IGenreProvider, GenreProvider>();
        service.AddScoped<IPictureProvider, PictureProvider>();
        service.AddScoped<IPortfolioProvider, PortfolioProvider>();
        service.AddScoped<IRegistrationProvider, RegistrationProvider>();
        return service;
    }
}