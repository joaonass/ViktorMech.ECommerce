using System.Text.RegularExpressions;
using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class NomeCompleto : ValueObject
    {
        public string Nome { get; } = null!;

        private NomeCompleto() { }
        public NomeCompleto(string nome)
        {
            nome = nome?.Trim() ?? "";

            if (nome.Length < 2)
                throw new DomainException("Nome deve ter pelo menos 2 caracteres.");

            if (nome.Length > 100)
                throw new DomainException("Nome não pode exceder 100 caracteres.");

            if (!Regex.IsMatch(nome, @"^[a-zA-ZÀ-ÿ' ]+$"))
                throw new DomainException("Nome contém caracteres inválidos.");

            Nome = nome;
        }

        protected override IEnumerable<object> GetEqualityComponents()
            => [Nome];
    }
}