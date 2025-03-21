using AutoMapper;
using Photo.Service.CustomException;
using Photo.Data;
using Photo.Service.Interface;
using Photo.Service.ModelRequest;

public class BaseService<TEntityDb,TEntityRequest,IEntityProvaider>:IBaseService<TEntityDb,TEntityRequest> 
where TEntityDb:BaseModel
where TEntityRequest: BaseModelRequest
where IEntityProvaider:IBaseProvider<TEntityDb>
{
    private readonly IMapper _mapper;
    private IEntityProvaider _provider;
    public BaseService(IEntityProvaider provider,IMapper mapper)
    {
        _provider = provider;
        _mapper = mapper;
    }
    public virtual async Task<Guid> CreateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken)
    {
        var model = await _provider.FindAsync(entityRequest.Id, cancellationToken);
        if (model != null)
            throw new ExistIsEntityException("Такая записи не существует");
        var newmodel = _mapper.Map<TEntityDb>(entityRequest);  
        await _provider.AddAsync(newmodel, cancellationToken);
        return newmodel.Id;
    }

    public Task<TEntityDb?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var model = _provider.FindAsync(id, cancellationToken);
        if (model == null)
            throw new NotExistException("Такой записи не существует");
        return model;
    }

    public async Task<TEntityDb> UpdateAsync(TEntityRequest entityRequest, CancellationToken cancellationToken)
    {

        var model = _mapper.Map<TEntityDb>(entityRequest);
      
        await _provider.UpdateAsync(model, cancellationToken);
        return model;
    }

    public async Task<List<TEntityDb>> GetAllAsync(CancellationToken cancellationToken)
    {
        var all = _provider.GetAllAsync(new CancellationToken());
        return await all;
    }
}