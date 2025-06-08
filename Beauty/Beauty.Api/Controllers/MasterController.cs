using Beauty.Controller.Web.Common;
using Beauty.Service.Interface;
using Beauty.Service.ModelsRequest;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Beauty.Api.Controllers
{
    public class MasterController : WebApiController
    {
        private readonly IMasterService _masterService;
        private readonly ILogger<MasterController> _logger;

        public MasterController(IMasterService masterService, ILogger<MasterController> logger)
        {
            _masterService = masterService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var masters = await _masterService.GetAllAsync(cancellationToken);
            return Ok(masters);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var master = await _masterService.GetAsync(id, cancellationToken);
            if (master == null)
                return NotFound($"Master with id {id} not found.");
            return Ok(master);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MasterRequest request, CancellationToken cancellationToken)
        {
            var id = await _masterService.CreateAsync(request, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id }, request);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MasterRequest request, CancellationToken cancellationToken)
        {
            if (id != request.Id)
                return BadRequest("Id in URL and request body do not match.");

            var updatedMaster = await _masterService.UpdateAsync(request, cancellationToken);
            if (updatedMaster == null)
                return NotFound($"Master with id {id} not found.");

            return Ok(updatedMaster);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> ChangeState(Guid id, CancellationToken cancellationToken)
        {
            var result = await _masterService.ChangeState(id, cancellationToken);
            if (!result)
                return NotFound($"Master with id {id} not found or unable to change state.");

            return NoContent();
        }
    }
}
