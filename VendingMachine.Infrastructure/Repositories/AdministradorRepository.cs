
using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Infrastructure.Data;

namespace VendingMachine.Infrastructure.Repositories
{
    public class AdministradorRepository : IAdministradorRepository
    {

        private readonly AppDbContext _context;

        public AdministradorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Administrador administrador)
        {
            await _context.Administradores.AddAsync(administrador);
            await _context.SaveChangesAsync();
        }
    }
}
