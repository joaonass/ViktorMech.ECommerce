

namespace VendingMachine.Application.Usuarios.CriarUsuario
{
    public class EnderecoCommand
    {
        public string Rua { get; set; } = string.Empty;
        public int NumeroDoImovel { get; set; }
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Cep { get; set;  } = string.Empty;
    }
}
