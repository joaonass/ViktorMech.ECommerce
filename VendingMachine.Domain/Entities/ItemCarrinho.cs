using VendingMachine.Domain.ValueObjects;

public class ItemCarrinho
{
    public Guid Id { get; private set; }

    public Guid CarrinhoId { get; private set; }

    public Guid ProdutoId { get; private set; }

    public Quantidade Quantidade { get; private set; }

    private ItemCarrinho() { }

    public ItemCarrinho(Guid produtoId, Guid carrinhoId, int quantidade)
    {
        ProdutoId = produtoId;
        CarrinhoId = carrinhoId;
        Quantidade = new Quantidade(quantidade);

    }
}