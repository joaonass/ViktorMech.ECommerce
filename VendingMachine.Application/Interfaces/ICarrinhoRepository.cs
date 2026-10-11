using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Interfaces;

public interface ICarrinhoRepository
{
    Task AdicionarAsync(Carrinho carrinho);

    Task<Carrinho?> ObterPorIdAsync(Guid id);

    Task<Carrinho?> ObterPorUsuarioIdAsync(Guid usuarioId);
    Task AtualizarAsync(Carrinho carrinho);


}