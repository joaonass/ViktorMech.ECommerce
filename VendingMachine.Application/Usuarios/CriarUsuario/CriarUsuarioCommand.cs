using System.Security.Cryptography.X509Certificates;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Application.Usuarios.CriarUsuario
{
    public class CriarUsuarioCommand
    {
        public Guid Id { get; private set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public  string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public EnderecoCommand Endereco { get; set; } = new();
    }
}
