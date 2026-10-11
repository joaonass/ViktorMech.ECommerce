
using VendingMachine.Domain.ValueObjects;


namespace VendingMachine.Domain.Entities
{
    public class Produto
    {
        public Guid Id { get; private set; }
        public NomeDoProduto NomeDoProduto { get; private set; } = null!;
        public TipoImplante Tipo { get; private set; } = null!;
        public Preco Preco { get; private set; } = null!;
        public Estoque Estoque { get; private set; } = null!;

        private Produto() { }

        public Produto(string nome, string tipo, decimal preco, int quantidade)
        {
            NomeDoProduto = new NomeDoProduto(nome);
            Tipo = new TipoImplante(tipo);
            Preco = new Preco(preco);
            Estoque = new Estoque(quantidade);

        }

        public void AlterarNome(string nome)
        {
            NomeDoProduto = new NomeDoProduto(nome);
        }

        public void AlterarTipo(string tipo)
        {
            Tipo = new TipoImplante(tipo);
        }

        public void AlterarPreco(decimal preco)
        {
            Preco = new Preco(preco);
        }

        public void AlterarQuantidade(int quantidade)
        {
            Estoque = new Estoque(quantidade);
        }

    }
}
