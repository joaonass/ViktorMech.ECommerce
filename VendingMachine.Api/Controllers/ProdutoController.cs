using Microsoft.AspNetCore.Mvc;
using VendingMachine.Application.Produtos.AtualizarProduto;
using VendingMachine.Application.Produtos.CriarProduto;
using VendingMachine.Application.Produtos.DeletarProduto;
using VendingMachine.Application.Produtos.ObterProduto;
using VendingMachine.Domain.Entities;

namespace VendingMachine.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly CriarProdutoHandler _handler;
    private readonly ObterProdutoHandler _query;
    private readonly DeletarProdutoHandler _remover;
    private readonly AtualizarProdutoHandler _atualizar;

    public ProdutoController(CriarProdutoHandler handler, ObterProdutoHandler query, DeletarProdutoHandler remover, AtualizarProdutoHandler atualizar)
    {
        _handler = handler;
        _query = query;
        _remover = remover;
        _atualizar = atualizar;
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> CriarProduto(
        CriarProdutoCommand command)
    {
        var novoProduto = await _handler.Handle(command);

        return Created($"/api/produto/{novoProduto.Id}", novoProduto);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Produto>> ObterProduto(Guid id)
    {
        var query = new ObterProdutoQuery
        {
            Id = id
        };

        var produto = await _query.Handle(query);

        if (produto is null)
        {
            return NotFound();
        }

        return Ok(produto);
    }
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<Produto>> DeletarProduto(Guid id)
    {
        var command = new DeletarProdutoCommand
        {
            Id = id
        };

        var produto = await _remover.Handle(command);

        if(produto is null)
        {
            return NotFound();
        }

        return Ok(produto);
    }
    [HttpPatch("{id:guid}")]
    public async Task<ActionResult<Produto>> AtualizarProduto(
    Guid id,
    AtualizarProdutoCommand command)
    {
        command.Id = id;

        var produto = await _atualizar.Handle(command);

        return Ok(produto);
    }
}