using Beauty.Service;
using Beauty.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Beauty.DependencyInjection;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection service)
    {
        service.AddScoped<IMasterService, MasterService>();
        service.AddScoped<IUserService, UserService>();
        service.AddScoped<IAppointmentService, AppointmentService>();
        service.AddScoped<IPaymentService, PaymentService>();
        service.AddScoped<IProfessionalServiceService, ProfessionalServiceService>();
        service.AddScoped<ISalonService, SalonService>();
        
        return service;
    }
}