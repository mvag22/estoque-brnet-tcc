using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;
using ApiBrnetEstoque.DTOs;
using ApiBrnetEstoque.DTOs.Atendimentos;
using ApiBrnetEstoque.DTOs.ControleKm;

namespace ApiBrnetEstoque.Services
{
    public class KmService
    {
        private readonly BdBrnetEstoqueContext _ctx;
        public KmService(BdBrnetEstoqueContext ctx)
            => _ctx = ctx;

        public Task<List<ControleKm>> GetAllControleKmsAsync()
            => _ctx.ControleKms.ToListAsync();

        public Task<ControleKm?> GetControleKmByIdAsync(int id)
            => _ctx.ControleKms.FindAsync(id).AsTask();

        // Cria um novo controle diário de km
        public async Task<ControleKm> StartDayAsync(int veiculoId, int usuarioId1, int? usuarioId2)
        {
            var ck = new ControleKm
            {
                Data = DateOnly.FromDateTime(DateTime.UtcNow),
                VeiculoId = veiculoId,
                UsuarioId1 = usuarioId1,
                UsuarioId2 = usuarioId2
            };
            _ctx.ControleKms.Add(ck);
            await _ctx.SaveChangesAsync();
            return ck;
        }

        // Atualiza um controle de km existente
        public async Task<ControleKm> UpdateControleKmAsync(int id, ControleKmUpdateDto dto)
        {
            var ck = await GetControleKmByIdAsync(id)
                     ?? throw new KeyNotFoundException("ControleKm não encontrado.");
            ck.Data = dto.Data;
            ck.VeiculoId = dto.VeiculoId;
            ck.UsuarioId1 = dto.UsuarioId1;
            ck.UsuarioId2 = dto.UsuarioId2;
            await _ctx.SaveChangesAsync();
            return ck;
        }

        public async Task DeleteControleKmAsync(int id)
        {
            var ck = await GetControleKmByIdAsync(id)
                     ?? throw new KeyNotFoundException("ControleKm não encontrado.");
            _ctx.ControleKms.Remove(ck);
            await _ctx.SaveChangesAsync();
        }

        // Lista todos os atendimentos de um controle de km
        public Task<List<Atendimento>> GetAtendimentosAsync(int controleKmId)
            => _ctx.Atendimentos
                   .Where(a => a.ControleKmId == controleKmId)
                   .ToListAsync();

        // Retorna um atendimento por ID (dentro de um controle)
        public Task<Atendimento?> GetAtendimentoByIdAsync(int controleKmId, int id)
            => _ctx.Atendimentos
                   .FirstOrDefaultAsync(a =>
                       a.ControleKmId == controleKmId &&
                       a.IdAtendimentos == id);

        // Registra um novo atendimento (parada) no dia
        public async Task<Atendimento> RegisterStopAsync(
            int controleKmId,
            TimeOnly hora,
            string? codCliente,
            string? nomeCliente,
            string? observacao)
        {
            // garante que o controle de km existe
            var maybe = await GetControleKmByIdAsync(controleKmId);
            if (maybe is null)
                throw new KeyNotFoundException("ControleKm não encontrado.");

            var at = new Atendimento
            {
                ControleKmId = controleKmId,
                Hora = hora,
                CodCliente = codCliente,
                NomeCliente = nomeCliente,
                Observacao = observacao
            };
            _ctx.Atendimentos.Add(at);
            await _ctx.SaveChangesAsync();
            return at;
        }

        public async Task<Atendimento> UpdateAtendimentoAsync(
            int controleKmId,
            int id,
            AtendimentoUpdateDto dto)
        {
            var at = await GetAtendimentoByIdAsync(controleKmId, id)
                     ?? throw new KeyNotFoundException("Atendimento não encontrado.");

            at.Hora = dto.Hora;
            at.CodCliente = dto.CodCliente;
            at.NomeCliente = dto.NomeCliente;
            at.Observacao = dto.Observacao;
            await _ctx.SaveChangesAsync();
            return at;
        }

        public async Task DeleteAtendimentoAsync(int controleKmId, int id)
        {
            var at = await GetAtendimentoByIdAsync(controleKmId, id)
                     ?? throw new KeyNotFoundException("Atendimento não encontrado.");
            _ctx.Atendimentos.Remove(at);
            await _ctx.SaveChangesAsync();
        }
    }
}
