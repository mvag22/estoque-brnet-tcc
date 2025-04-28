using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;

namespace ApiBrnetEstoque.Controllers
{
    [ApiController]
    [Route("api/relatorios/checklist")]
    public class RelatorioChecklistController : ControllerBase
    {
        private readonly BdBrnetEstoqueContext _context;
        public RelatorioChecklistController(BdBrnetEstoqueContext context)
            => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VRelatorioChecklist>>> Get()
        {
            var lista = await _context.VRelatorioChecklists.ToListAsync();
            return Ok(lista);
        }
    }
}
