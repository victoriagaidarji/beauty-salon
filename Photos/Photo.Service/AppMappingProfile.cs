using Photo.Data;
using Photo.Service.ModelRequest;
using Profile = AutoMapper.Profile;

namespace Photo.Service;

public class AppMappingProfile:Profile
{
    public AppMappingProfile()
    {			
        CreateMap<Data.Picture, PictureRequest>();
        CreateMap<Client, ClientRequest>();
        
        
        
        
        
        
        
        
        
        
    }
}