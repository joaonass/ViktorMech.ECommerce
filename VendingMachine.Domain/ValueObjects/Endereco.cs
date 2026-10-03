using VendingMachine.Domain.Common;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public string Rua { get; }
        public int NumeroDoImovel { get; }
        public string Bairro { get; }
        public string Cidade { get; }
        public string Cep { get; }

        // EF Core
        private Endereco() { }

        public Endereco(string rua, int numeroImovel, string bairro, string cidade, string cep)
        {
            rua = rua?.Trim() ?? "";
            bairro = bairro?.Trim() ?? "";
            cidade = cidade?.Trim() ?? "";
            cep = (cep?.Trim() ?? "").Replace("-", "");

            ValidarRua(rua);
            ValidarNumero(numeroImovel);
            ValidarTexto(bairro, "Bairro");
            ValidarTexto(cidade, "Cidade");
            ValidarCep(cep);

            Rua = rua;
            NumeroDoImovel = numeroImovel;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
        }

        private static void ValidarRua(string rua)
        {
            if (string.IsNullOrWhiteSpace(rua))
                throw new DomainException("Rua não pode ser vazia.");

            if (rua.Length < 2)
                throw new DomainException("Rua deve ter pelo menos 2 caracteres.");
        }

        private static void ValidarNumero(int numero)
        {
            if (numero < 1)
                throw new DomainException("Número do imóvel deve ser maior que zero.");
        }

        private static void ValidarTexto(string valor, string campo)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new DomainException($"{campo} não pode ser vazio.");
        }

        private static void ValidarCep(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep))
                throw new DomainException("CEP não pode ser vazio.");

            if (cep.Length != 8 || !cep.All(char.IsDigit))
                throw new DomainException("CEP deve conter exatamente 8 dígitos.");
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Rua;
            yield return NumeroDoImovel;
            yield return Bairro;
            yield return Cidade;
            yield return Cep;
        }

        public override string ToString()
            => $"{Rua}, {NumeroDoImovel} - {Bairro}, {Cidade} - {Cep}";
    }
}   
