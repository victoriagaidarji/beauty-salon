using AutoMapper;
using Photo.Data;
using Photo.Service.CustomException;
using Photo.Service.Interface;
using Photo.Service.ModelRequest;

namespace Photo.Service;

public class PictureService:BaseService<Picture, PictureRequest, IPictureProvider>, IPictureService

{
    private readonly IPictureProvider _pictureProvider;
    private IMapper _mapper;

    public PictureService(IPictureProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _pictureProvider = provider;
        _mapper = mapper;
    }

    public async Task<List<Data.Picture>> GetAllAsync(Registration registration, CancellationToken cancellationToken)
    {
        List<Data.Picture> photos;
        /* способ 1 */

        photos = _pictureProvider.GetAllAsync(cancellationToken).Result.Where(Ph => Ph.Registration == registration).ToList();
        photos = await _pictureProvider.GetAllAsyncByRegistration(registration, cancellationToken);
        return photos;
    }
}