
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Interfaces
{
    public interface IAdministradorRepository
    {

        Task AdicionarAsync(Administrador administrador);
    }
}
