
namespace VendingMachine.Application.Produtos.AtualizarProduto
{
    public class AtualizarProdutoCommand
    {
        public Guid Id { get; set; }

        public string? Nome { get; set; }

        public string? Tipo { get; set; }

        public decimal? Preco { get; set; }

        public int? Quantidade { get; set; }
    }
}
