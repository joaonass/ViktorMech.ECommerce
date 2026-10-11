using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class TipoImplante : ValueObject
    {
        public string Tipo { get; } = null!;

        private TipoImplante()
        {
        }

        public TipoImplante(string tipo)
        {
            tipo = tipo?.Trim() ?? "";

            Validar(tipo);

            Tipo = tipo;
        }

        private static void Validar(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo))
            {
                throw new DomainException("Tipo do implante não pode ser vazio.");
            }

            if (tipo.Length < 3)
            {
                throw new DomainException(
                    "Tipo do implante deve possuir pelo menos 3 caracteres.");
            }
        }

        protected override IEnumerable<object> GetEqualityComponents()
            => [Tipo];
    }
}
