using AutoMapper;
using Photo.Service.CustomException;
using Photo.Data;
using Photo.Service.Interface;
using Photo.Service.ModelRequest;

namespace Photo.Service;

public class GenreService : BaseService<Genre,GenreRequest,IGenreProvider> ,IGenreService

{
    private readonly IGenreProvider _genreProvider;
    
    private IMapper _mapper;
    public GenreService(IGenreProvider provider, IMapper mapper) : base(provider, mapper)
    {
        _genreProvider = provider;
        _mapper = mapper;
    }

    public override async Task<Guid> CreateAsync(GenreRequest entityRequest, CancellationToken cancellationToken)
    {
        if (await _genreProvider.FindAsync(entityRequest.Name, cancellationToken) != null)
            throw new ExistIsEntityException("Жанр с таким номером уже существует");
        var genreDb = new Genre(entityRequest.Name);
        await _genreProvider.AddAsync(genreDb, cancellationToken);
        return genreDb.Id;
    }
}
