
using VendingMachine.Domain.ValueObjects;
namespace VendingMachine.Domain.Entities{
    
    public class Usuario
    {
        public Guid Id { get; private set; }
        public NomeCompleto NomeCompleto { get; private set; } = null!;
        public Cpf Cpf { get; private set; } = null!;
        public Email Email { get; private set; } = null!;
        public Telefone Telefone { get; private set; } = null!;
        public Endereco Endereco { get; private set; } = null!;

        private Usuario() { }
        
        public Usuario(string nomeCompleto,string cpf, string email, string telefone,
            string rua, int numeroImovel, string bairro, string cidade, string cep)
        {
            NomeCompleto = new NomeCompleto(nomeCompleto);
            Cpf = new Cpf(cpf);        // validação fica lá dentro
            Email = new Email(email);
            Telefone = new Telefone(telefone);
            Endereco = new Endereco(rua, numeroImovel, bairro, cidade, cep);
        }
    }
}
