using AutoMapper;
using Beauty.Data;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;

namespace Beauty.Service
{
    public class MasterService : BaseService<Master, MasterRequest, IMasterProvider>, IMasterService
    {
        private readonly IMasterProvider _provider;
        private readonly IMapper _mapper;

        public MasterService(IMasterProvider provider, IMapper mapper) : base(provider, mapper)
        {
            _provider = provider;
            _mapper = mapper;
        }

        public async Task<List<Master>> GetMastersBySpecialization(string specialization, CancellationToken cancellationToken)
        {
            var allMasters = await _provider.GetAllAsync(cancellationToken);
            return allMasters
                .Where(m => m.IsActive && m.Specialization.Equals(specialization, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public async Task<bool> ChangeState(Guid id, CancellationToken cancellationToken)
        {
            var master = await _provider.FindAsync(id, cancellationToken);
            if (master == null)
                return false;

            // Пример логики изменения состояния (предположим, есть поле IsActive)
            master.IsActive = !master.IsActive;
            master.DataUpdate = DateTime.Now;

            await _provider.UpdateAsync(master, cancellationToken);
            return true;
        }
    }
}