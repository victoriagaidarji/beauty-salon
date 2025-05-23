using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using Beauty.Controller.Web.Common;
using Beauty.Service.Interface;

namespace Beauty.Api.Controllers
{
    public abstract class BaseEntityController<TEntity, TService> : WebApiController
        where TEntity : class
        where TService : class
    {
        protected readonly TService _service;
        protected readonly ILogger _logger;

        protected BaseEntityController(TService service, ILogger logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll(CancellationToken cancellationToken = default)
        {
            var method = _service.GetType().GetMethod("GetAllAsync");
            var result = await (Task<object>)method.Invoke(_service, new object[] { cancellationToken });
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public virtual async Task<IActionResult> GetById(int id, CancellationToken cancellationToken = default)
        {
            var method = _service.GetType().GetMethod("GetByIdAsync");
            var result = await (Task<object>)method.Invoke(_service, new object[] { id, cancellationToken });
            return result != null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public virtual async Task<IActionResult> Create([FromBody] TEntity model, CancellationToken cancellationToken = default)
        {
            var method = _service.GetType().GetMethod("CreateAsync");
            var created = await (Task<TEntity>)method.Invoke(_service, new object[] { model, cancellationToken });
            return CreatedAtAction(nameof(GetById), new { id = created.GetType().GetProperty("Id").GetValue(created) }, created);
        }

        [HttpPut("{id:int}")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] TEntity model, CancellationToken cancellationToken = default)
        {
            var method = _service.GetType().GetMethod("UpdateAsync");
            var updated = await (Task<TEntity>)method.Invoke(_service, new object[] { id, model, cancellationToken });
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]
        public virtual async Task<IActionResult> Delete(int id, CancellationToken cancellationToken = default)
        {
            var method = _service.GetType().GetMethod("DeleteAsync");
            var result = await (Task<bool>)method.Invoke(_service, new object[] { id, cancellationToken });
            return result ? NoContent() : NotFound();
        }
    }

    [Route("api/[controller]")]
    public class AppointmentController : BaseEntityController<Beauty.Data.Appointment, IAppointmentService>
    {
        public AppointmentController(IAppointmentService service, ILogger<AppointmentController> logger) : base(service, logger) { }
    }

    // Аналогично остальные можно сделать по этому шаблону.
}

