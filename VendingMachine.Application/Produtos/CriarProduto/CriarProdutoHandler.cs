using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.ValueObjects;

namespace VendingMachine.Application.Produtos.CriarProduto;

public class CriarProdutoHandler
{
    private readonly IProdutoRepository _produtoRepository;

    public CriarProdutoHandler(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<Produto> Handle(CriarProdutoCommand command)
    {
        var produto = new Produto(
            command.Nome,
            command.Tipo,
            command.Preco,
            command.Quantidade
        );

        await _produtoRepository.AdicionarAsync(produto);

        return produto;
    }
}