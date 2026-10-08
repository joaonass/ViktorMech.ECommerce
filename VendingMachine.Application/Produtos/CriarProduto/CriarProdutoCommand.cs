

namespace VendingMachine.Application.Produtos.CriarProduto
{
    public class CriarProdutoCommand
    {
        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
