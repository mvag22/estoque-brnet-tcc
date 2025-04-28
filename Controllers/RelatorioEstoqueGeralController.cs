using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiBrnetEstoque.Controllers
{
    [ApiController]
    [Route("api/relatorios/estoque-geral")]
    [Authorize(Policy = "AdminPolicy")]
    public class RelatorioEstoqueGeralController : ControllerBase
    {
        private readonly BdBrnetEstoqueContext _context;
        public RelatorioEstoqueGeralController(BdBrnetEstoqueContext context)
            => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VEstoqueGeral>>> Get()
        {
            var lista = await _context.VEstoqueGerals.ToListAsync();
            return Ok(lista);
        }
    }
}
