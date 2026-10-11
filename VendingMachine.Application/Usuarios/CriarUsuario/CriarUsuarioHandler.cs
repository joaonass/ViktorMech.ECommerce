

using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Usuarios.CriarUsuario
{
    public class CriarUsuarioHandler
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CriarUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<Usuario> Handle(CriarUsuarioCommand command)
        {
            var usuario = new Usuario(
               command.NomeCompleto,
               command.Cpf,
               command.Email,
               command.Telefone,
               command.Endereco.Rua,
               command.Endereco.NumeroDoImovel,
               command.Endereco.Bairro,
               command.Endereco.Cidade,
               command.Endereco.Cep
           );

            await _usuarioRepository.AdicionarAyinc(usuario);

            return usuario;
        }
    }
}
