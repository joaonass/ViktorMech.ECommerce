using Microsoft.EntityFrameworkCore;
using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Infrastructure.Data;

namespace VendingMachine.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAyinc(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task<Usuario?> ObterPorAsync(Guid id)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u=> u.Id == id);
        }
    }
}
