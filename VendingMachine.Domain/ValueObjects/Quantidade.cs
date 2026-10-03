using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class Quantidade : ValueObject
    {
        public int Estoque { get; }
        
        private Quantidade() { }

        public Quantidade(int quantidade)
        {
            Validar(quantidade);

            Estoque = quantidade;
        }


        private static void Validar(int quantidade)
        {
            if(quantidade <= 0)
            {
                throw new DomainException("A quantidade de produto no estoque não pode ser zero");
            }
        }


        protected override IEnumerable<object> GetEqualityComponents()
            => [Estoque];
    }
}
