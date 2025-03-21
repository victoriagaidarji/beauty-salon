using AutoMapper;
using Photo.Data;
using Photo.Service.Interface;

namespace Photo.Service.ModelRequest;

public class PortfolioService:BaseService<Portfolio, PortfolioRequest, IPortfolioProvider>, IPortfolioService
{
    public PortfolioService(IPortfolioProvider provider, IMapper mapper) : base(provider, mapper)
    {
        
    }
}