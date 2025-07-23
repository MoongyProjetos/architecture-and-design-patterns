using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguradora.Data.CacheService;
using Seguradora.Data;
using Seguradora.Data.CQRS;

namespace Seguradora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinistrosController : ControllerBase
    {
        private readonly SeguradoraDbContext _db;
        private readonly ISinistroCacheService _cache;
        private readonly IMediator _mediator;

        public SinistrosController(SeguradoraDbContext db, ISinistroCacheService cache, IMediator mediator)
        {
            _db = db;
            _cache = cache;
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var sinistro = await _cache.GetAsync(id);
            if (sinistro != null)
                return Ok(sinistro);

            sinistro = await _db.Sinistros.FindAsync(id);
            if (sinistro == null)
                return NotFound();

            await _cache.SetAsync(sinistro); // Cache-Aside
            return Ok(sinistro);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CriarSinistroCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(Get), new { id }, id);
        }
    }
}
