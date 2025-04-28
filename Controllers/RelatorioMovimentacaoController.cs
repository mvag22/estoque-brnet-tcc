using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiBrnetEstoque.Controllers
{
    [ApiController]
    [Route("api/relatorios/movimentacao")]
    [Authorize(Policy = "AdminPolicy")]
    public class RelatorioMovimentacaoController : ControllerBase
    {
        private readonly BdBrnetEstoqueContext _context;
        public RelatorioMovimentacaoController(BdBrnetEstoqueContext context)
            => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VRelatorioMovimentacao>>> Get()
        {
            var lista = await _context.VRelatorioMovimentacaos.ToListAsync();
            return Ok(lista);
        }
    }
}
