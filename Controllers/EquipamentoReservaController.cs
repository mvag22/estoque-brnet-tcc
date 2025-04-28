using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBrnetEstoque.DTOs.EquipamentoReserva;
using ApiBrnetEstoque.Models;
using ApiBrnetEstoque.Services;

namespace ApiBrnetEstoque.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentoReservaController : ControllerBase
    {
        private readonly EquipmentService _svc;
        public EquipamentoReservaController(EquipmentService svc)
            => _svc = svc;

        // GET: api/EquipamentoReserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipamentoReservaDto>>> GetAll()
        {
            var list = await _svc.GetAllAsync();
            return Ok(list.Select(e => new EquipamentoReservaDto
            {
                IdEquipamento = e.IdEquipamento,
                Mac = e.Mac,
                Tipo = e.Tipo,
                Status = e.Status,
                CodCliente = e.CodCliente,
                Defeito = e.Defeito,
                DataPegou = e.DataPegou,
                UsuarioId = e.UsuarioId
            }));
        }

        // GET: api/EquipamentoReserva/5
        [HttpGet("{id:int}", Name = "GetEquipReservaById")]
        public async Task<ActionResult<EquipamentoReservaDto>> GetById(int id)
        {
            var e = await _svc.GetByIdAsync(id);
            if (e == null) return NotFound();
            return Ok(new EquipamentoReservaDto
            {
                IdEquipamento = e.IdEquipamento,
                Mac = e.Mac,
                Tipo = e.Tipo,
                Status = e.Status,
                CodCliente = e.CodCliente,
                Defeito = e.Defeito,
                DataPegou = e.DataPegou,
                UsuarioId = e.UsuarioId
            });
        }

        // POST: api/EquipamentoReserva
        [HttpPost]
        public async Task<ActionResult<EquipamentoReservaDto>> Create(
            [FromBody] EquipamentoReservaCreateDto dto)
        {
            try
            {
                var e = new EquipamentoReserva
                {
                    Mac = dto.Mac,
                    Tipo = dto.Tipo,
                    Status = dto.Status,
                    CodCliente = dto.CodCliente,
                    Defeito = dto.Defeito,
                    DataPegou = dto.DataPegou,
                    UsuarioId = dto.UsuarioId
                };
                e = await _svc.CreateAsync(e);

                var created = new EquipamentoReservaDto
                {
                    IdEquipamento = e.IdEquipamento,
                    Mac = e.Mac,
                    Tipo = e.Tipo,
                    Status = e.Status,
                    CodCliente = e.CodCliente,
                    Defeito = e.Defeito,
                    DataPegou = e.DataPegou,
                    UsuarioId = e.UsuarioId
                };
                return CreatedAtRoute("GetEquipReservaById",
                                      new { id = e.IdEquipamento },
                                      created);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/EquipamentoReserva/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id, [FromBody] EquipamentoReservaUpdateDto dto)
        {
            try
            {
                var e = await _svc.UpdateAsync(id, dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/EquipamentoReserva/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _svc.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
