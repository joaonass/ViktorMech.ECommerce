using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Common;

namespace VendingMachine.Domain.ValueObjects
{
    public class Preco : ValueObject
    {

        public decimal Valor { get; }
        private Preco() { }
        public Preco(decimal preco)
        {
            Validar(preco);

            Valor = preco;
            
        }
        private static void Validar(decimal preco)
        {
            if (preco <= 0)
            {
                throw new DomainException("O preço deve ser maior que zero.");
            }
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Valor;
        }
    }

    
}