
using System.Net.Mail;
using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public string Endereco{ get; }

        // EF Core
        private Email() { }

        public Email(string endereco)
        {
            endereco = endereco?.Trim() ?? "";

            ValidarEmail(endereco);

            Endereco = endereco;

            
        }

        private static void ValidarEmail(string endereco)
        {
            if (string.IsNullOrWhiteSpace(endereco))
                throw new DomainException("E-mail não pode ser vazio.");

            if (endereco.Length > 254)
                throw new DomainException("E-mail não pode exceder 254 caracteres.");

            if (endereco.Contains(".."))
                throw new DomainException("E-mail inválido.");

            try
            {
                var email = new MailAddress(endereco);

                if (email.Address != endereco)
                    throw new DomainException("E-mail inválido.");
            }
            catch (FormatException)
            {
                throw new DomainException("E-mail inválido.");
            }

        }

        protected override IEnumerable<object> GetEqualityComponents()
            => [Endereco];

        public override string ToString() => Endereco;
    }
}