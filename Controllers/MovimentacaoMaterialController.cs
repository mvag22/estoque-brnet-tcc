using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;
using ApiBrnetEstoque.DTOs.movimentacaoMaterial;
using Microsoft.AspNetCore.Authorization;

namespace ApiBrnetEstoque.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Policy = "AdminPolicy")]
    public class MovimentacaoMaterialController : ControllerBase
    {
        private readonly BdBrnetEstoqueContext _context;

        public MovimentacaoMaterialController(BdBrnetEstoqueContext context)
        {
            _context = context;
        }

        // GET: api/MovimentacaoMaterial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentacaoMaterialDto>>> GetAll()
        {
            var list = await _context.MovimentacaoMaterials
                .Select(mm => new MovimentacaoMaterialDto
                {
                    IdMovMaterial = mm.IdMovMaterial,
                    MovimentacaoEstoqueId = mm.MovimentacaoEstoqueId,
                    MaterialEstoqueId = mm.MaterialEstoqueId,
                    Quantidade = mm.Quantidade
                })
                .ToListAsync();

            return Ok(list);
        }

        // GET: api/MovimentacaoMaterial/5
        [HttpGet("{id:int}", Name = "GetMovMaterialById")]
        public async Task<ActionResult<MovimentacaoMaterialDto>> GetById(int id)
        {
            var mm = await _context.MovimentacaoMaterials.FindAsync(id);
            if (mm == null) return NotFound();

            return Ok(new MovimentacaoMaterialDto
            {
                IdMovMaterial = mm.IdMovMaterial,
                MovimentacaoEstoqueId = mm.MovimentacaoEstoqueId,
                MaterialEstoqueId = mm.MaterialEstoqueId,
                Quantidade = mm.Quantidade
            });
        }

        // POST: api/MovimentacaoMaterial
        [HttpPost]
        public async Task<ActionResult<MovimentacaoMaterialDto>> Create(
            [FromBody] MovimentacaoMaterialCreateDto dto)
        {
            // Opcional: validar existência de movimentação e material
            var mm = new MovimentacaoMaterial
            {
                MovimentacaoEstoqueId = dto.MovimentacaoEstoqueId,
                MaterialEstoqueId = dto.MaterialEstoqueId,
                Quantidade = dto.Quantidade
            };
            _context.MovimentacaoMaterials.Add(mm);
            await _context.SaveChangesAsync();

            var created = new MovimentacaoMaterialDto
            {
                IdMovMaterial = mm.IdMovMaterial,
                MovimentacaoEstoqueId = mm.MovimentacaoEstoqueId,
                MaterialEstoqueId = mm.MaterialEstoqueId,
                Quantidade = mm.Quantidade
            };

            return CreatedAtRoute("GetMovMaterialById",
                new { id = mm.IdMovMaterial },
                created);
        }

        // PUT: api/MovimentacaoMaterial/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id,
            [FromBody] MovimentacaoMaterialUpdateDto dto)
        {
            var mm = await _context.MovimentacaoMaterials.FindAsync(id);
            if (mm == null) return NotFound();

            mm.Quantidade = dto.Quantidade;
            _context.Entry(mm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/MovimentacaoMaterial/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mm = await _context.MovimentacaoMaterials.FindAsync(id);
            if (mm == null) return NotFound();

            _context.MovimentacaoMaterials.Remove(mm);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
