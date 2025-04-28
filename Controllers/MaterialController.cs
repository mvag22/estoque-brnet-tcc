using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBrnetEstoque.Models;
using ApiBrnetEstoque.Services;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.DTOs.Material;
using Microsoft.EntityFrameworkCore;


namespace ApiBrnetEstoque.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class MaterialController : ControllerBase
    {
        private readonly BdBrnetEstoqueContext _context;
        private readonly StockService _stock;

        public MaterialController(
            BdBrnetEstoqueContext context,
            StockService stockService)
        {
            _context = context;
            _stock = stockService;
        }

        // GET: api/material
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialDto>>> GetAll()
        {
            var lista = await _context.MaterialEstoques
                .Select(m => new MaterialDto
                {
                    IdMaterial = m.IdMaterial,
                    Nome = m.Nome,
                    Marca = m.Marca,
                    Modelo = m.Modelo,
                    Quantidade = m.Quantidade
                })
                .ToListAsync();

            return Ok(lista);
        }

        // GET: api/material/5
        [HttpGet("{id:int}", Name = "GetMaterialById")]
        public async Task<ActionResult<MaterialDto>> GetById(int id)
        {
            var m = await _context.MaterialEstoques.FindAsync(id);
            if (m == null) return NotFound();
            return Ok(new MaterialDto
            {
                IdMaterial = m.IdMaterial,
                Nome = m.Nome,
                Marca = m.Marca,
                Modelo = m.Modelo,
                Quantidade = m.Quantidade
            });
        }

        // POST: api/material
        // Cria um novo material com quantidade inicial
        [HttpPost]
        public async Task<ActionResult<MaterialDto>> Create([FromBody] MaterialCreateDto dto)
        {
            var m = new MaterialEstoque
            {
                Nome = dto.Nome,
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Quantidade = dto.Quantidade
            };
            _context.MaterialEstoques.Add(m);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetMaterialById",
                new { id = m.IdMaterial },
                new MaterialDto
                {
                    IdMaterial = m.IdMaterial,
                    Nome = m.Nome,
                    Marca = m.Marca,
                    Modelo = m.Modelo,
                    Quantidade = m.Quantidade
                });
        }

        // PUT: api/material/5
        // Atualiza dados e, se a quantidade mudou, delega ao StockService
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaterialUpdateDto dto)
        {
            var m = await _context.MaterialEstoques.FindAsync(id);
            if (m == null) return NotFound();

            // Atualiza metadados
            m.Nome = dto.Nome;
            m.Marca = dto.Marca;
            m.Modelo = dto.Modelo;

            // Se mudou quantidade, chama o StockService
            if (dto.Quantidade != m.Quantidade)
            {
                var delta = dto.Quantidade - m.Quantidade;
                if (delta > 0)
                {
                    // entrada
                    await _stock.RegisterEntryAsync(id, delta);
                }
                else
                {
                    // saída manual
                    // para fins de auditoria, enviamos um userId fixo ou extraímos do JWT
                    var userId = int.Parse(User.FindFirst("sub")!.Value);
                    await _stock.RegisterExitAsync(id, -delta, userId);
                }
            }
            else
            {
                // apenas metadados
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        // DELETE: api/material/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var m = await _context.MaterialEstoques.FindAsync(id);
            if (m == null) return NotFound();

            _context.MaterialEstoques.Remove(m);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
