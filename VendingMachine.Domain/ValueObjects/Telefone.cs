using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class Telefone : ValueObject
    {
        public string Tel { get; }

        private Telefone() { }
        public Telefone(string tel)
        {
            Tel = NormalizarEValidarTelefone(tel);
        }

        private static string NormalizarEValidarTelefone(string tel)
        {
            if (string.IsNullOrWhiteSpace(tel))
                throw new DomainException("Telefone não pode ser vazio.");

            tel = tel.Replace("(", "")
                     .Replace(")", "")
                     .Replace("-", "")
                     .Replace(" ", "")
                     .Trim();

            if (!tel.All(char.IsDigit))
                throw new DomainException("Telefone deve conter apenas números.");

            if (tel.Length != 10 && tel.Length != 11)
                throw new DomainException("Telefone deve possuir 10 ou 11 dígitos.");

            return tel;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Tel;
        }
    }
}
