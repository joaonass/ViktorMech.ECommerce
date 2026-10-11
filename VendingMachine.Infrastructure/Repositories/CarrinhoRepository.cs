using Microsoft.EntityFrameworkCore;
using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Infrastructure.Data;

namespace VendingMachine.Infrastructure.Repositories
{
    public class CarrinhoRepository : ICarrinhoRepository
    {
        private readonly AppDbContext _context;

        public CarrinhoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Carrinho carrinho)
        {
            await _context.Carrinhos.AddAsync(carrinho);
            await _context.SaveChangesAsync();
        }

        public async Task<Carrinho?> ObterPorIdAsync(Guid id)
        {
            return await _context.Carrinhos
                .Include(c => c.Itens)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Carrinho?> ObterPorUsuarioIdAsync(Guid usuarioId)
        {
            return await _context.Carrinhos
                .FirstOrDefaultAsync(c => c.UsuarioId == usuarioId);
        }

        public async Task AtualizarAsync(Carrinho carrinho)
        {
            await _context.SaveChangesAsync();
        }
    }
}