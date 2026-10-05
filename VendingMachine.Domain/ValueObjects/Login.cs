using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class Login : ValueObject
    {
        public string Value { get; }

        private Login() { }
        public Login(string login)
        {
            Validar(login);
            Value = login;
        }

        private static void Validar(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new DomainException("Não pode estar vazio!");
            }
        }


        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
