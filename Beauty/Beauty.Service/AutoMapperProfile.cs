using AutoMapper;
using Beauty.Data;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserRequest>().ReverseMap();
        CreateMap<Master, MasterRequest>().ReverseMap();
        CreateMap<ProfessionalService, ProfessionalServiceRequest>().ReverseMap();
        CreateMap<Appointment, AppointmentRequest>().ReverseMap();
        CreateMap<Payment, PaymentRequest>().ReverseMap();
        CreateMap<Salon, SalonRequest>().ReverseMap();
    }
}