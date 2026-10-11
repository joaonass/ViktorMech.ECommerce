using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;


namespace VendingMachine.Domain.ValueObjects
{
    public class NomeDoProduto : ValueObject
    {
        public string NomeProd { get; } = null!;
        private NomeDoProduto() { }
        public NomeDoProduto(string nome)
        {
            nome = nome?.Trim() ?? "";

            Validar(nome);

            NomeProd = nome;
        }

        private static void Validar(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new DomainException("Nome não pode ser vazio!");
            }
            if(nome.Length <= 3)
            {
                throw new DomainException("Nome precisa ter pelo menos 3 caracteres!");
            }
        }
        protected override IEnumerable<object> GetEqualityComponents()
           => [NomeProd];
    }
}
