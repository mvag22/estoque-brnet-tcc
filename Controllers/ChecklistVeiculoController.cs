using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBrnetEstoque.DTOs.Checklist;
using ApiBrnetEstoque.Models;
using ApiBrnetEstoque.Services;

namespace ApiBrnetEstoque.Controllers
{
    [Authorize(Policy = "TecnicoPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class ChecklistVeiculoController : ControllerBase
    {
        private readonly ChecklistService _svc;

        public ChecklistVeiculoController(ChecklistService svc)
            => _svc = svc;

        // GET: api/ChecklistVeiculo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChecklistVeiculoDto>>> GetAll()
        {
            var list = await _svc.GetAllAsync();
            return Ok(list.Select(c => new ChecklistVeiculoDto
            {
                IdChecklist = c.IdChecklist,
                Data = c.Data,
                KmAtual = c.KmAtual,
                KmTrocaOleo = c.KmTrocaOleo,
                UsuarioId = c.UsuarioId,
                VeiculoId = c.VeiculoId,
                ObsOleoFreio = c.ObsOleoFreio,
                ObsAguaRadiador = c.ObsAguaRadiador,
                ObsBuzina = c.ObsBuzina,
                ObsEspelhoRetrovisor = c.ObsEspelhoRetrovisor,
                ObsTriangulo = c.ObsTriangulo,
                ObsFreioEstacionamento = c.ObsFreioEstacionamento,
                ObsEstepe = c.ObsEstepe,
                ObsVidroParabrisa = c.ObsVidroParabrisa,
                ObsPortas = c.ObsPortas,
                ObsPneus = c.ObsPneus,
                ObsFarolFaroletes = c.ObsFarolFaroletes,
                ObsLimpadorParabrisas = c.ObsLimpadorParabrisas,
                ObsSetas = c.ObsSetas,
                ObsLuzesRe = c.ObsLuzesRe,
                ObsMotorLimpo = c.ObsMotorLimpo,
                ObsCones = c.ObsCones,
                ObsEscadas = c.ObsEscadas
            }));
        }

        // GET: api/ChecklistVeiculo/5
        [HttpGet("{id:int}", Name = "GetChecklistById")]
        public async Task<ActionResult<ChecklistVeiculoDto>> GetById(int id)
        {
            var c = await _svc.GetByIdAsync(id);
            if (c == null) return NotFound();
            return Ok(new ChecklistVeiculoDto
            {
                IdChecklist = c.IdChecklist,
                Data = c.Data,
                KmAtual = c.KmAtual,
                KmTrocaOleo = c.KmTrocaOleo,
                UsuarioId = c.UsuarioId,
                VeiculoId = c.VeiculoId,
                ObsOleoFreio = c.ObsOleoFreio,
                ObsAguaRadiador = c.ObsAguaRadiador,
                ObsBuzina = c.ObsBuzina,
                ObsEspelhoRetrovisor = c.ObsEspelhoRetrovisor,
                ObsTriangulo = c.ObsTriangulo,
                ObsFreioEstacionamento = c.ObsFreioEstacionamento,
                ObsEstepe = c.ObsEstepe,
                ObsVidroParabrisa = c.ObsVidroParabrisa,
                ObsPortas = c.ObsPortas,
                ObsPneus = c.ObsPneus,
                ObsFarolFaroletes = c.ObsFarolFaroletes,
                ObsLimpadorParabrisas = c.ObsLimpadorParabrisas,
                ObsSetas = c.ObsSetas,
                ObsLuzesRe = c.ObsLuzesRe,
                ObsMotorLimpo = c.ObsMotorLimpo,
                ObsCones = c.ObsCones,
                ObsEscadas = c.ObsEscadas
            });
        }

        // POST: api/ChecklistVeiculo
        [HttpPost]
        public async Task<ActionResult<ChecklistVeiculoDto>> Create(
            [FromBody] ChecklistVeiculoCreateDto dto)
        {
            var c = new ChecklistVeiculo
            {
                Data = dto.Data,
                KmAtual = dto.KmAtual,
                KmTrocaOleo = dto.KmTrocaOleo,
                UsuarioId = dto.UsuarioId,
                VeiculoId = dto.VeiculoId,
                ObsOleoFreio = dto.ObsOleoFreio,
                ObsAguaRadiador = dto.ObsAguaRadiador,
                ObsBuzina = dto.ObsBuzina,
                ObsEspelhoRetrovisor = dto.ObsEspelhoRetrovisor,
                ObsTriangulo = dto.ObsTriangulo,
                ObsFreioEstacionamento = dto.ObsFreioEstacionamento,
                ObsEstepe = dto.ObsEstepe,
                ObsVidroParabrisa = dto.ObsVidroParabrisa,
                ObsPortas = dto.ObsPortas,
                ObsPneus = dto.ObsPneus,
                ObsFarolFaroletes = dto.ObsFarolFaroletes,
                ObsLimpadorParabrisas = dto.ObsLimpadorParabrisas,
                ObsSetas = dto.ObsSetas,
                ObsLuzesRe = dto.ObsLuzesRe,
                ObsMotorLimpo = dto.ObsMotorLimpo,
                ObsCones = dto.ObsCones,
                ObsEscadas = dto.ObsEscadas
            };

            c = await _svc.CreateAsync(c);

            var result = new ChecklistVeiculoDto
            {
                IdChecklist = c.IdChecklist,
                Data = c.Data,
                KmAtual = c.KmAtual,
                KmTrocaOleo = c.KmTrocaOleo,
                UsuarioId = c.UsuarioId,
                VeiculoId = c.VeiculoId,
                ObsOleoFreio = c.ObsOleoFreio,
                ObsAguaRadiador = c.ObsAguaRadiador,
                ObsBuzina = c.ObsBuzina,
                ObsEspelhoRetrovisor = c.ObsEspelhoRetrovisor,
                ObsTriangulo = c.ObsTriangulo,
                ObsFreioEstacionamento = c.ObsFreioEstacionamento,
                ObsEstepe = c.ObsEstepe,
                ObsVidroParabrisa = c.ObsVidroParabrisa,
                ObsPortas = c.ObsPortas,
                ObsPneus = c.ObsPneus,
                ObsFarolFaroletes = c.ObsFarolFaroletes,
                ObsLimpadorParabrisas = c.ObsLimpadorParabrisas,
                ObsSetas = c.ObsSetas,
                ObsLuzesRe = c.ObsLuzesRe,
                ObsMotorLimpo = c.ObsMotorLimpo,
                ObsCones = c.ObsCones,
                ObsEscadas = c.ObsEscadas
            };

            return CreatedAtRoute("GetChecklistById", new { id = result.IdChecklist }, result);
        }

        // PUT: api/ChecklistVeiculo/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id, [FromBody] ChecklistVeiculoUpdateDto dto)
        {
            try
            {
                await _svc.UpdateAsync(id, c =>
                {
                    c.Data = dto.Data;
                    c.KmAtual = dto.KmAtual;
                    c.KmTrocaOleo = dto.KmTrocaOleo;
                    c.UsuarioId = dto.UsuarioId;
                    c.VeiculoId = dto.VeiculoId;
                    c.ObsOleoFreio = dto.ObsOleoFreio;
                    c.ObsAguaRadiador = dto.ObsAguaRadiador;
                    c.ObsBuzina = dto.ObsBuzina;
                    c.ObsEspelhoRetrovisor = dto.ObsEspelhoRetrovisor;
                    c.ObsTriangulo = dto.ObsTriangulo;
                    c.ObsFreioEstacionamento = dto.ObsFreioEstacionamento;
                    c.ObsEstepe = dto.ObsEstepe;
                    c.ObsVidroParabrisa = dto.ObsVidroParabrisa;
                    c.ObsPortas = dto.ObsPortas;
                    c.ObsPneus = dto.ObsPneus;
                    c.ObsFarolFaroletes = dto.ObsFarolFaroletes;
                    c.ObsLimpadorParabrisas = dto.ObsLimpadorParabrisas;
                    c.ObsSetas = dto.ObsSetas;
                    c.ObsLuzesRe = dto.ObsLuzesRe;
                    c.ObsMotorLimpo = dto.ObsMotorLimpo;
                    c.ObsCones = dto.ObsCones;
                    c.ObsEscadas = dto.ObsEscadas;
                });
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/ChecklistVeiculo/5
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
