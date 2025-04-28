using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;

namespace ApiBrnetEstoque.Controllers
{
    [ApiController]
    [Route("api/relatorios/km")]
    public class RelatorioKmController : ControllerBase
    {
        private readonly BdBrnetEstoqueContext _context;
        public RelatorioKmController(BdBrnetEstoqueContext context)
            => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VRelatorioKm>>> Get()
        {
            var lista = await _context.VRelatorioKms.ToListAsync();
            return Ok(lista);
        }
    }
}
