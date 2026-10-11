using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class Estoque : ValueObject
    {
        public int Valor { get; } 

        private Estoque() { }

        public Estoque(int quantidade)
        {
            Validar(quantidade);

            Valor = quantidade;
        }


        private static void Validar(int quantidade)
        {
            if (quantidade <= 0)
            {
                throw new DomainException("O estoque não pode ser negativo nem zero.");
            }
        }


        protected override IEnumerable<object> GetEqualityComponents()
            => [Valor];
    }
}
