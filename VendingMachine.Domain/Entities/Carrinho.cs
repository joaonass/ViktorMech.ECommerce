using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Domain.Entities
{
    public class Carrinho
    {
        public Guid Id { get; private set; }

        public Guid? UsuarioId { get; private set; }

        private readonly List<ItemCarrinho> _itens = new();

        public IReadOnlyCollection<ItemCarrinho> Itens => _itens.AsReadOnly();

        private Carrinho() { }

        public static Carrinho CriarAnonimo()
        {
            return new Carrinho();
        }

        public Carrinho(Guid usuarioId)
        {
            if (usuarioId == Guid.Empty)
            {
                throw new DomainException("O ID do usuário é inválido.");
            }

            UsuarioId = usuarioId;
        }
        public void AdicionarItem(Guid produtoId, int quantidade)
        {
            if (produtoId == Guid.Empty)
            {
                throw new DomainException("O ID do produto é inválido.");
            }

            var itemExistente = _itens.FirstOrDefault(
                item => item.ProdutoId == produtoId);

            if (itemExistente is not null)
            {
                var novaQuantidade =
                    itemExistente.Quantidade.Valor + quantidade;

                itemExistente.AlterarQuantidade(novaQuantidade);
                return;
            }

            var item = new ItemCarrinho(
                produtoId,
                Id,
                quantidade);

            _itens.Add(item);
        }
    }
}