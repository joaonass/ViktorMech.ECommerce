using VendingMachine.Domain.ValueObjects;

public class ItemCarrinho
{
    public Guid Id { get; private set; }

    public Guid ProdutoId { get; private set; }

    public Quantidade Quantidade { get; private set; }

    private ItemCarrinho() { }

    public ItemCarrinho(Guid produtoId, int quantidade)
    {
        ProdutoId = produtoId;
        Quantidade = new Quantidade(quantidade);
    }
}