using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class Quantidade : ValueObject
    {
        public int Valor { get; }
        
        private Quantidade() { }

        public Quantidade(int quantidade)
        {
            Validar(quantidade);

            Valor = quantidade;
        }


        private static void Validar(int quantidade)
        {
            if(quantidade <= 0)
            {
                throw new DomainException("A quantidade deve ser maior que zero.");
            }
        }


        protected override IEnumerable<object> GetEqualityComponents()
            => [Valor];
    }
}
