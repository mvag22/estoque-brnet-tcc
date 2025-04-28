using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApiBrnetEstoque.DTOs;
using ApiBrnetEstoque.Services;
using ApiBrnetEstoque.DTOs.movimentacaoEstoque;

namespace ApiBrnetEstoque.Controllers
{
    [Authorize(Policy = "AdminPolicy")]
    [ApiController]
    [Route("api/[controller]")]
    public class MovimentacaoEstoqueController : ControllerBase
    {
        private readonly StockService _stock;
        public MovimentacaoEstoqueController(StockService stockService)
            => _stock = stockService;

        // GET: api/MovimentacaoEstoque
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovimentacaoEstoqueDto>>> GetAll()
            => Ok(await _stock.GetAllMovimentacoesAsync());

        // GET: api/MovimentacaoEstoque/5
        [HttpGet("{id:int}", Name = "GetMovimentacaoById")]
        public async Task<ActionResult<MovimentacaoEstoqueDto>> GetById(int id)
        {
            var m = await _stock.GetMovimentacaoByIdAsync(id);
            if (m == null) return NotFound();
            return Ok(m);
        }

        // POST: api/MovimentacaoEstoque
        [HttpPost]
        public async Task<ActionResult<MovimentacaoEstoqueDto>> Create([FromBody] MovimentacaoEstoqueCreateDto dto)
        {
            try
            {
                var created = dto.TipoMovimentacao == "entrada"
                    ? await _stock.RegisterEntryAsync(dto.MaterialId, dto.Quantidade)
                    : await _stock.RegisterExitAsync(dto.MaterialId, dto.Quantidade, dto.UsuarioId);

                return CreatedAtRoute("GetMovimentacaoById",
                    new { id = created.IdMovimentacao },
                    created);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        // PUT: api/MovimentacaoEstoque/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovimentacaoEstoqueUpdateDto dto)
        {
            try
            {
                var updated = await _stock.UpdateMovimentacaoAsync(id, dto);
                return Ok(updated);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/MovimentacaoEstoque/5
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _stock.DeleteMovimentacaoAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
