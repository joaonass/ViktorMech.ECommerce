
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarAyinc(Usuario usuario);
        Task<Usuario?> ObterPorAsync(Guid id);
    }
}
