
using VendingMachine.Domain.Entities;
namespace VendingMachine.Application.Interfaces
{
    public interface IProdutoRepository
    {
        Task AdicionarAsync(Produto produto);
        Task<Produto?> ObterPorIdAsync(Guid id);
        Task DeletarAsync(Produto produto);
        Task AtualizarAsync(Produto produto);
    }
}

    