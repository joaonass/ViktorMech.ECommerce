

using VendingMachine.Application.Interfaces;

using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;

namespace VendingMachine.Application.Produtos.AtualizarProduto
{
    public class AtualizarProdutoHandler
    {

        private readonly IProdutoRepository _produtoRepository;

        public AtualizarProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(AtualizarProdutoCommand command)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(command.Id);

            if (produto is null)
                throw new NotFoundException("Produto não encontrado.");

            if (command.Nome is not null)
                produto.AlterarNome(command.Nome);

            if (command.Tipo is not null)
                produto.AlterarTipo(command.Tipo);

            if (command.Preco is not null)
                produto.AlterarPreco(command.Preco.Value);

            if (command.Quantidade is not null)
                produto.AlterarQuantidade(command.Quantidade.Value);

            await _produtoRepository.AtualizarAsync(produto);
            return produto;



        }

        
    }
}
