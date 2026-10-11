
using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Administradores.CriarAdministrador
{
    public class CriarAdministradorHandler
    {
        private readonly IAdministradorRepository _administradorRepository;

        public CriarAdministradorHandler(IAdministradorRepository administradorRepository)
        {
            _administradorRepository = administradorRepository;
        }

        public async Task<Administrador> Handle(CriarAdministradorCommand command)
        {
            var administrador = new Administrador(
               command.Login
           );

            await _administradorRepository.AdicionarAsync(administrador);

            return administrador;
        }
    }
}
