using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Application.Carrinhos.AdicionarItem;

public class AdicionarItemCarrinhoHandler
{
    private readonly ICarrinhoRepository _carrinhoRepository;
    private readonly IProdutoRepository _produtoRepository;

    public AdicionarItemCarrinhoHandler(
        ICarrinhoRepository carrinhoRepository,
        IProdutoRepository produtoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
        _produtoRepository = produtoRepository;
    }

    public async Task Handle(AdicionarItemCarrinhoCommand command)
    {
        var carrinho = await _carrinhoRepository
            .ObterPorIdAsync(command.CarrinhoId);

        if (carrinho is null)
        {
            throw new NotFoundException("Carrinho não encontrado");
        }

        var produto = await _produtoRepository
            .ObterPorIdAsync(command.ProdutoId);

        if (produto is null)
        {
            throw new NotFoundException("Produto não encontrado.");
        }

        var itemExistente = carrinho.Itens.FirstOrDefault(
            item => item.ProdutoId == command.ProdutoId);

        var quantidadeNoCarrinho = itemExistente?.Quantidade.Valor ?? 0;

        var quantidadeTotal = quantidadeNoCarrinho + command.Quantidade;

        if (produto.Estoque.Valor < quantidadeTotal)
        {
            throw new DomainException(
                "Estoque insuficiente para a quantidade solicitada.");
        }

        carrinho.AdicionarItem(
            command.ProdutoId,
            command.Quantidade);

        await _carrinhoRepository.AtualizarAsync(carrinho);
    }
}