using Microsoft.Extensions.DependencyInjection;
using Photo.Service;
using Photo.Service.Interface;
using Photo.Service.ModelRequest;

namespace Pictures.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IClientService, ClientService>();
        service.AddScoped<IGenreService, GenreService>();
        service.AddScoped<IPictureService, PictureService>();
        service.AddScoped<IPortfolioService, PortfolioService>();
        service.AddScoped<IRegistrationService, RegistrationService>();
        return service;
    }
}