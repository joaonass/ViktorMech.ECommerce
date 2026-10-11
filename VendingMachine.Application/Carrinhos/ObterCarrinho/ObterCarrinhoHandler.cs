
using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Carrinhos.ObterCarrinho
{
    public class ObterCarrinhoHandler
    {
        private readonly ICarrinhoRepository _carrinhoRepository;

        public ObterCarrinhoHandler(ICarrinhoRepository carrinhoRepository)
        {
            _carrinhoRepository = carrinhoRepository;
        }

        public async Task<Carrinho?> Handle(ObterCarrinhoQuery query)
        {
            return await _carrinhoRepository.ObterPorIdAsync(query.Id);
        }
    }
}
