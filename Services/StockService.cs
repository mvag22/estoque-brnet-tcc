using Microsoft.EntityFrameworkCore;
using ApiBrnetEstoque.Data;
using ApiBrnetEstoque.Models;
using ApiBrnetEstoque.DTOs.movimentacaoEstoque;

namespace ApiBrnetEstoque.Services
{
    public class StockService
    {
        private readonly BdBrnetEstoqueContext _ctx;
        public StockService(BdBrnetEstoqueContext ctx) => _ctx = ctx;

        /// <summary>
        /// Registra uma entrada de material, incrementando o estoque.
        /// </summary>
        public async Task<MovimentacaoEstoqueDto> RegisterEntryAsync(int materialId, int quantity)
        {
            var m = await _ctx.MaterialEstoques.FindAsync(materialId)
                    ?? throw new KeyNotFoundException("Material não encontrado.");

            m.Quantidade += quantity;

            var mov = new MovimentacaoEstoque
            {
                TipoMovimentacao = "entrada",
                Observacao = null,
                UsuarioId = 0, // ajustar conforme contexto
                DataMovimentacao = DateTime.UtcNow
            };
            _ctx.MovimentacaoEstoques.Add(mov);
            await _ctx.SaveChangesAsync();

            _ctx.MovimentacaoMaterials.Add(new MovimentacaoMaterial
            {
                MovimentacaoEstoqueId = mov.IdMovimentacao,
                MaterialEstoqueId = materialId,
                Quantidade = quantity
            });
            await _ctx.SaveChangesAsync();

            return new MovimentacaoEstoqueDto
            {
                IdMovimentacao = mov.IdMovimentacao,
                DataMovimentacao = mov.DataMovimentacao,
                TipoMovimentacao = mov.TipoMovimentacao,
                Observacao = mov.Observacao,
                UsuarioId = mov.UsuarioId
            };
        }

        /// <summary>
        /// Registra uma saída de material, decrementando o estoque.
        /// </summary>
        public async Task<MovimentacaoEstoqueDto> RegisterExitAsync(int materialId, int quantity, int userId)
        {
            var m = await _ctx.MaterialEstoques.FindAsync(materialId)
                    ?? throw new KeyNotFoundException("Material não encontrado.");

            if (m.Quantidade < quantity)
                throw new ApplicationException("Estoque insuficiente.");

            using var tx = await _ctx.Database.BeginTransactionAsync();

            m.Quantidade -= quantity;

            var mov = new MovimentacaoEstoque
            {
                TipoMovimentacao = "saida_manual",
                Observacao = null,
                UsuarioId = userId,
                DataMovimentacao = DateTime.UtcNow
            };
            _ctx.MovimentacaoEstoques.Add(mov);
            await _ctx.SaveChangesAsync();

            _ctx.MovimentacaoMaterials.Add(new MovimentacaoMaterial
            {
                MovimentacaoEstoqueId = mov.IdMovimentacao,
                MaterialEstoqueId = materialId,
                Quantidade = quantity
            });
            await _ctx.SaveChangesAsync();

            await tx.CommitAsync();

            return new MovimentacaoEstoqueDto
            {
                IdMovimentacao = mov.IdMovimentacao,
                DataMovimentacao = mov.DataMovimentacao,
                TipoMovimentacao = mov.TipoMovimentacao,
                Observacao = mov.Observacao,
                UsuarioId = mov.UsuarioId
            };
        }

        /// <summary>
        /// Retorna todas as movimentações de estoque.
        /// </summary>
        public async Task<List<MovimentacaoEstoqueDto>> GetAllMovimentacoesAsync()
        {
            return await _ctx.MovimentacaoEstoques
                .Select(m => new MovimentacaoEstoqueDto
                {
                    IdMovimentacao = m.IdMovimentacao,
                    DataMovimentacao = m.DataMovimentacao,
                    TipoMovimentacao = m.TipoMovimentacao,
                    Observacao = m.Observacao,
                    UsuarioId = m.UsuarioId
                })
                .ToListAsync();
        }

        /// <summary>
        /// Retorna uma movimentação pelo ID.
        /// </summary>
        public async Task<MovimentacaoEstoqueDto?> GetMovimentacaoByIdAsync(int id)
        {
            return await _ctx.MovimentacaoEstoques
                .Where(m => m.IdMovimentacao == id)
                .Select(m => new MovimentacaoEstoqueDto
                {
                    IdMovimentacao = m.IdMovimentacao,
                    DataMovimentacao = m.DataMovimentacao,
                    TipoMovimentacao = m.TipoMovimentacao,
                    Observacao = m.Observacao,
                    UsuarioId = m.UsuarioId
                })
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Atualiza tipo, observação e usuário de uma movimentação existente.
        /// </summary>
        public async Task<MovimentacaoEstoqueDto> UpdateMovimentacaoAsync(int id, DTOs.MovimentacaoEstoqueUpdateDto dto)
        {
            var m = await _ctx.MovimentacaoEstoques.FindAsync(id)
                    ?? throw new KeyNotFoundException("Movimentação não encontrada.");

            m.TipoMovimentacao = dto.TipoMovimentacao;
            m.Observacao = dto.Observacao;
            m.UsuarioId = dto.UsuarioId;
            await _ctx.SaveChangesAsync();

            return new MovimentacaoEstoqueDto
            {
                IdMovimentacao = m.IdMovimentacao,
                DataMovimentacao = m.DataMovimentacao,
                TipoMovimentacao = m.TipoMovimentacao,
                Observacao = m.Observacao,
                UsuarioId = m.UsuarioId
            };
        }

        /// <summary>
        /// Exclui uma movimentação (itens em cascata).
        /// </summary>
        public async Task DeleteMovimentacaoAsync(int id)
        {
            var m = await _ctx.MovimentacaoEstoques.FindAsync(id)
                    ?? throw new KeyNotFoundException("Movimentação não encontrada.");

            _ctx.MovimentacaoEstoques.Remove(m);
            await _ctx.SaveChangesAsync();
        }
    }
}
