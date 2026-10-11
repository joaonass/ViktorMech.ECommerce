using VendingMachine.Domain.Exceptions;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Domain.Entities
{
    public class ItemCarrinho
    {
        public Guid Id { get; private set; }

        public Guid CarrinhoId { get; private set; }

        public Guid ProdutoId { get; private set; }

        public Quantidade Quantidade { get; private set; } = null!;
        private ItemCarrinho() { }

        public ItemCarrinho(Guid produtoId, Guid carrinhoId, int quantidade)
        {
            if (produtoId == Guid.Empty)
            {
                throw new DomainException("O ID do produto é inválido.");
            }

            if (carrinhoId == Guid.Empty)
            {
                throw new DomainException("O ID do carrinho é inválido.");
            }

            ProdutoId = produtoId;
            CarrinhoId = carrinhoId;
            Quantidade = new Quantidade(quantidade);
        }
        public void AlterarQuantidade(int quantidade)
        {
            Quantidade = new Quantidade(quantidade);
        }
    }
}