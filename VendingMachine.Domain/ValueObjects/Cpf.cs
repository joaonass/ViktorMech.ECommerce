using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.Common;

namespace VendingMachine.Domain.ValueObjects
{


    public class Cpf : ValueObject
    {
        public string Valor { get; } = null!;
        private Cpf(){}

        public Cpf(string valor)
        {
            var limpo = valor?.Replace(".", "").Replace("-", "").Trim() ?? "";

            if (limpo.Length != 11 || !limpo.All(char.IsDigit))
                throw new DomainException("CPF inválido.");

            if (!ValidarDigitos(limpo))
                throw new DomainException("CPF com dígitos verificadores inválidos.");

            Valor = limpo;
        }

        protected override IEnumerable<object> GetEqualityComponents()
            => [Valor];



        private static bool ValidarDigitos(string cpf)
        {
            int[] numeros = cpf.Select(c => c - '0').ToArray();

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += numeros[i] * (10 - i);
            }

            int resto = soma % 11;
            int primeiroDigito = resto < 2 ? 0 : 11 - resto;

            if (primeiroDigito != numeros[9])
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += numeros[i] * (11 - i);
            }

            resto = soma % 11;
            int segundoDigito = resto < 2 ? 0 : 11 - resto;

            return segundoDigito == numeros[10];
        }
    }

}