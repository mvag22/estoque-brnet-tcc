using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;
using ApiBrnetEstoque.DTOs.Veiculo;
using Microsoft.AspNetCore.Authorization;

namespace ApiBrnetEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminPolicy")]
    public class VeiculoController : ControllerBase
    {
        private readonly BdBrnetEstoqueContext _context;

        public VeiculoController(BdBrnetEstoqueContext context)
        {
            _context = context;
        }

        // GET all
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VeiculoDto>>> GetVeiculos()
        {
            var lista = await _context.Veiculos
                .Select(v => new VeiculoDto
                {
                    IdVeiculo = v.IdVeiculo,
                    Placa = v.Placa,
                    Modelo = v.Modelo
                })
                .ToListAsync();

            return Ok(lista);
        }

        // GET by id
        [HttpGet("{id:int}", Name = "GetVeiculoById")]
        public async Task<ActionResult<VeiculoDto>> GetVeiculo(int id)
        {
            var v = await _context.Veiculos.FindAsync(id);
            if (v == null) return NotFound();

            return Ok(new VeiculoDto
            {
                IdVeiculo = v.IdVeiculo,
                Placa = v.Placa,
                Modelo = v.Modelo
            });
        }

        // POST
        [HttpPost]
        public async Task<ActionResult<VeiculoDto>> CreateVeiculo([FromBody] VeiculoCreateDto dto)
        {
            var v = new Veiculo
            {
                Placa = dto.Placa,
                Modelo = dto.Modelo
            };
            _context.Veiculos.Add(v);
            await _context.SaveChangesAsync();

            var created = new VeiculoDto
            {
                IdVeiculo = v.IdVeiculo,
                Placa = v.Placa,
                Modelo = v.Modelo
            };

            return CreatedAtRoute("GetVeiculoById",
                new { id = v.IdVeiculo },
                created);
        }

        // PUT
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateVeiculo(int id, [FromBody] VeiculoUpdateDto dto)
        {
            var v = await _context.Veiculos.FindAsync(id);
            if (v == null) return NotFound();

            v.Placa = dto.Placa;
            v.Modelo = dto.Modelo;

            _context.Entry(v).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            var v = await _context.Veiculos.FindAsync(id);
            if (v == null) return NotFound();

            _context.Veiculos.Remove(v);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
