namespace VendingMachine.Application.Carrinhos.AdicionarItem;

public record AdicionarItemCarrinhoCommand(
    Guid CarrinhoId,
    Guid ProdutoId,
    int Quantidade
);