using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBrnetEstoque.Services
{
    public class ChecklistService
    {
        private readonly BdBrnetEstoqueContext _ctx;
        public ChecklistService(BdBrnetEstoqueContext ctx)
            => _ctx = ctx;


        public async Task<List<ChecklistVeiculo>> GetAllAsync()
            => await _ctx.ChecklistVeiculos.ToListAsync();

        public async Task<ChecklistVeiculo?> GetByIdAsync(int id)
            => await _ctx.ChecklistVeiculos.FindAsync(id);


        public async Task<ChecklistVeiculo> CreateAsync(ChecklistVeiculo c)
        {
            _ctx.ChecklistVeiculos.Add(c);
            await _ctx.SaveChangesAsync();
            return c;
        }

        public async Task<ChecklistVeiculo> UpdateAsync(int id, Action<ChecklistVeiculo> updater)
        {
            var c = await _ctx.ChecklistVeiculos.FindAsync(id)
                    ?? throw new KeyNotFoundException("Checklist não encontrado.");
            updater(c);
            await _ctx.SaveChangesAsync();
            return c;
        }

       
        public async Task DeleteAsync(int id)
        {
            var c = await _ctx.ChecklistVeiculos.FindAsync(id)
                    ?? throw new KeyNotFoundException("Checklist não encontrado.");
            _ctx.ChecklistVeiculos.Remove(c);
            await _ctx.SaveChangesAsync();
        }
    }
}
