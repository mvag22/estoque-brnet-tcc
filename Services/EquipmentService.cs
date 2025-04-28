using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.DTOs.EquipamentoReserva;
using ApiBrnetEstoque.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBrnetEstoque.Services
{
    public class EquipmentService
    {
        private readonly BdBrnetEstoqueContext _ctx;
        public EquipmentService(BdBrnetEstoqueContext ctx) => _ctx = ctx;


        // Criação
        public async Task<EquipamentoReserva> CreateAsync(EquipamentoReserva e)
        {
            if (await _ctx.EquipamentoReservas.AnyAsync(x => x.Mac == e.Mac))
                throw new ApplicationException("MAC já cadastrado.");
            _ctx.EquipamentoReservas.Add(e);
            await _ctx.SaveChangesAsync();
            return e;
        }

        // Leitura
        public Task<List<EquipamentoReserva>> GetAllAsync()
            => _ctx.EquipamentoReservas.ToListAsync();

        public async Task<EquipamentoReserva?> GetByIdAsync(int id)
            => await _ctx.EquipamentoReservas.FindAsync(id);



        // Atualização parcial
        public async Task<EquipamentoReserva> UpdateAsync(int id, EquipamentoReservaUpdateDto dto)
        {
            var e = await GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Equipamento não encontrado.");

            if (dto.Mac != null) e.Mac = dto.Mac;
            if (dto.Tipo != null) e.Tipo = dto.Tipo;
            if (dto.Status != null) e.Status = dto.Status;
            if (dto.CodCliente != null) e.CodCliente = dto.CodCliente;
            if (dto.Defeito != null) e.Defeito = dto.Defeito;
            if (dto.DataPegou != null) e.DataPegou = dto.DataPegou.Value;
            if (dto.UsuarioId != null) e.UsuarioId = dto.UsuarioId.Value;

            await _ctx.SaveChangesAsync();
            return e;
        }

        // Exclusão
        public async Task DeleteAsync(int id)
        {
            var e = await GetByIdAsync(id)
                ?? throw new KeyNotFoundException("Equipamento não encontrado.");
            _ctx.EquipamentoReservas.Remove(e);
            await _ctx.SaveChangesAsync();
        }
    }
}
