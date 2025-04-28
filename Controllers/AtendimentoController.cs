using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBrnetEstoque.DTOs;
using ApiBrnetEstoque.Services;
using ApiBrnetEstoque.DTOs.Atendimentos;

namespace ApiBrnetEstoque.Controllers
{
    [Authorize(Policy = "TecnicoPolicy")]
    [ApiController]
    [Route("api/controlekm/{controleKmId:int}/[controller]")]
    public class AtendimentosController : ControllerBase
    {
        private readonly KmService _svc;
        public AtendimentosController(KmService svc) => _svc = svc;

        // GET: api/controlekm/5/atendimentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtendimentoDto>>> GetAll(int controleKmId)
        {
            var list = await _svc.GetAtendimentosAsync(controleKmId);
            return Ok(list.Select(a => new AtendimentoDto
            {
                IdAtendimentos = a.IdAtendimentos,
                Hora = a.Hora,
                CodCliente = a.CodCliente,
                NomeCliente = a.NomeCliente,
                Observacao = a.Observacao,
                ControleKmId = a.ControleKmId
            }));
        }

        // GET: api/controlekm/5/atendimentos/10
        [HttpGet("{id:int}", Name = "GetAtendimentoById")]
        public async Task<ActionResult<AtendimentoDto>> GetById(int controleKmId, int id)
        {
            var a = await _svc.GetAtendimentoByIdAsync(controleKmId, id);
            if (a == null) return NotFound();
            return Ok(new AtendimentoDto
            {
                IdAtendimentos = a.IdAtendimentos,
                Hora = a.Hora,
                CodCliente = a.CodCliente,
                NomeCliente = a.NomeCliente,
                Observacao = a.Observacao,
                ControleKmId = a.ControleKmId
            });
        }

        // POST: api/controlekm/5/atendimentos
        [HttpPost]
        public async Task<ActionResult<AtendimentoDto>> Create(
            int controleKmId,
            [FromBody] AtendimentoCreateDto dto)
        {
            try
            {
                var a = await _svc.RegisterStopAsync(
                    controleKmId,
                    dto.Hora,
                    dto.CodCliente,
                    dto.NomeCliente,
                    dto.Observacao);

                var result = new AtendimentoDto
                {
                    IdAtendimentos = a.IdAtendimentos,
                    Hora = a.Hora,
                    CodCliente = a.CodCliente,
                    NomeCliente = a.NomeCliente,
                    Observacao = a.Observacao,
                    ControleKmId = a.ControleKmId
                };

                return CreatedAtRoute("GetAtendimentoById",
                    new { controleKmId, id = result.IdAtendimentos },
                    result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
        }

        // PUT: api/controlekm/5/atendimentos/10
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int controleKmId,
            int id,
            [FromBody] AtendimentoUpdateDto dto)
        {
            try
            {
                var a = await _svc.UpdateAtendimentoAsync(controleKmId, id, dto);
                return Ok(new AtendimentoDto
                {
                    IdAtendimentos = a.IdAtendimentos,
                    Hora = a.Hora,
                    CodCliente = a.CodCliente,
                    NomeCliente = a.NomeCliente,
                    Observacao = a.Observacao,
                    ControleKmId = a.ControleKmId
                });
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/controlekm/5/atendimentos/10
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int controleKmId, int id)
        {
            try
            {
                await _svc.DeleteAtendimentoAsync(controleKmId, id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
