using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBrnetEstoque.DTOs;
using ApiBrnetEstoque.Services;
using ApiBrnetEstoque.DTOs.ControleKm;

namespace ApiBrnetEstoque.Controllers
{
    [Authorize(Policy = "TecnicoPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class ControleKmController : ControllerBase
    {
        private readonly KmService _svc;
        public ControleKmController(KmService svc) => _svc = svc;

        // GET: api/ControleKm
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ControleKmDto>>> GetAll()
        {
            var list = await _svc.GetAllControleKmsAsync();
            return Ok(list.Select(k => new ControleKmDto
            {
                IdKm = k.IdKm,
                Data = k.Data,
                VeiculoId = k.VeiculoId,
                UsuarioId1 = k.UsuarioId1,
                UsuarioId2 = k.UsuarioId2 ?? 0
            }));
        }

        // GET: api/ControleKm/5
        [HttpGet("{id:int}", Name = "GetControleKmById")]
        public async Task<ActionResult<ControleKmDto>> GetById(int id)
        {
            var k = await _svc.GetControleKmByIdAsync(id);
            if (k == null) return NotFound();
            return Ok(new ControleKmDto
            {
                IdKm = k.IdKm,
                Data = k.Data,
                VeiculoId = k.VeiculoId,
                UsuarioId1 = k.UsuarioId1,
                UsuarioId2 = k.UsuarioId2 ?? 0
            });
        }

        // POST: api/ControleKm
        [HttpPost]
        public async Task<ActionResult<ControleKmDto>> Create([FromBody] ControleKmCreateDto dto)
        {
            var k = await _svc.StartDayAsync(dto.VeiculoId, dto.UsuarioId1, dto.UsuarioId2);
            var result = new ControleKmDto
            {
                IdKm = k.IdKm,
                Data = k.Data,
                VeiculoId = k.VeiculoId,
                UsuarioId1 = k.UsuarioId1,
                UsuarioId2 = k.UsuarioId2 ?? 0
            };
            return CreatedAtRoute("GetControleKmById", new { id = result.IdKm }, result);
        }

        // PUT: api/ControleKm/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] ControleKmUpdateDto dto)
        {
            try
            {
                var k = await _svc.UpdateControleKmAsync(id, dto);
                return Ok(new ControleKmDto
                {
                    IdKm = k.IdKm,
                    Data = k.Data,
                    VeiculoId = k.VeiculoId,
                    UsuarioId1 = k.UsuarioId1,
                    UsuarioId2 = k.UsuarioId2 ?? 0
                });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/ControleKm/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _svc.DeleteControleKmAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
