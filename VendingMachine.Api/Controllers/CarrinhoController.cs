using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Carrinhos.AdicionarItem;
using VendingMachine.Application.Carrinhos.CriarCarrinho;
using VendingMachine.Application.Carrinhos.ObterCarrinho;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly CriarCarrinhoHandler _criarHandler;
    private readonly ObterCarrinhoHandler _obterHandler;
    private readonly AdicionarItemCarrinhoHandler _adicionarItemHandler;

    public CarrinhoController(
        CriarCarrinhoHandler criarHandler,
        ObterCarrinhoHandler obterHandler,
        AdicionarItemCarrinhoHandler adicionarItemHandler)
    {
        _criarHandler = criarHandler;
        _obterHandler = obterHandler;
        _adicionarItemHandler = adicionarItemHandler;
    }

    [HttpPost]
    public async Task<ActionResult<Carrinho>> CriarCarrinho(
        [FromBody] CriarCarrinhoCommand command)
    {
        var novoCarrinho = await _criarHandler.Handle(command);

        return CreatedAtAction(
            nameof(ObterCarrinhoPorId),
            new { id = novoCarrinho.Id },
            novoCarrinho);
    }

    [HttpPost("anonimo")]
    public async Task<ActionResult> CriarCarrinhoAnonimo()
    {
        var carrinho = await _criarHandler.CriarAnonimo();

        return CreatedAtAction(
            nameof(ObterCarrinhoPorId),
            new { id = carrinho.Id },
            new { id = carrinho.Id });
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Carrinho>> ObterCarrinhoPorId(Guid id)
    {
        var query = new ObterCarrinhoQuery(id);
        var carrinho = await _obterHandler.Handle(query);

        if (carrinho is null)
        {
            return NotFound();
        }

        return Ok(carrinho);
    }

    [HttpPost("{id:guid}/itens")]
    public async Task<IActionResult> AdicionarItem(
        Guid id,
        [FromBody] AdicionarItemCarrinhoCommand command)
    {
        if (id != command.CarrinhoId)
        {
            return BadRequest(
                "O ID do carrinho na URL não corresponde ao ID informado no comando.");
        }

        await _adicionarItemHandler.Handle(command);

        return NoContent();
    }
}