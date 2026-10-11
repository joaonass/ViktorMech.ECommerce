using VendingMachine.Application.Interfaces;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Application.Carrinhos.CriarCarrinho;

public class CriarCarrinhoHandler
{
    private readonly ICarrinhoRepository _carrinhoRepository;

    public CriarCarrinhoHandler(ICarrinhoRepository carrinhoRepository)
    {
        _carrinhoRepository = carrinhoRepository;
    }
    public async Task<Carrinho> CriarAnonimo()
    {
        var carrinho = Carrinho.CriarAnonimo();

        await _carrinhoRepository.AdicionarAsync(carrinho);

        return carrinho;
    }
    public async Task<Carrinho> Handle(
        CriarCarrinhoCommand command)
    {
        var carrinhoExistente = await _carrinhoRepository
            .ObterPorUsuarioIdAsync(command.UsuarioId);

        if (carrinhoExistente is not null)
        {
            throw new InvalidOperationException(
                "Este usuário já possui um carrinho."
            );
        }

        var carrinho = new Carrinho(
            command.UsuarioId
        );

        await _carrinhoRepository.AdicionarAsync(carrinho);

        return carrinho;
    }
}

