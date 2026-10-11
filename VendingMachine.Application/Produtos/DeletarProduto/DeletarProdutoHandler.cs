
using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;
using VendingMachine.Domain.Exceptions;


namespace VendingMachine.Application.Produtos.DeletarProduto
{
    public class DeletarProdutoHandler
    {
        private readonly IProdutoRepository _produtoRepository;

        public DeletarProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto> Handle(DeletarProdutoCommand command)
        {
            var produto = await _produtoRepository.ObterPorIdAsync(command.Id);

            if (produto is null)
                throw new NotFoundException("Produto não encontrado.");

            await _produtoRepository.DeletarAsync(produto);

            return produto;

        }
    }
}
