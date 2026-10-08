using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Produtos.ObterProduto
{
    public class ObterProdutoHandler
    {
        private readonly IProdutoRepository _produtoRepository;

        public ObterProdutoHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Produto?> Handle(ObterProdutoQuery query)
        {
            return await _produtoRepository.ObterPorIdAsync(query.Id);
        }
    
    }
}