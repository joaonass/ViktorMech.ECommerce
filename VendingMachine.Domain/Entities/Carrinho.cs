using VendingMachine.Domain.Entities;

public class Carrinho
{
    public Guid Id { get; private set; }

    public Guid UsuarioId { get; private set; }

    private readonly List<ItemCarrinho> _itens = new();

    public IReadOnlyCollection<ItemCarrinho> Itens
        => _itens.AsReadOnly();

    private Carrinho() { }

    public Carrinho(Guid usuarioId)
    {
        UsuarioId = usuarioId;
    }
}