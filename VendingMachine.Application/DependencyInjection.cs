using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Application.Produtos.CriarProduto;
using VendingMachine.Application.Produtos.DeletarProduto;
using VendingMachine.Application.Produtos.ObterProduto;
using VendingMachine.Application.Produtos.AtualizarProduto;
using VendingMachine.Application.Carrinhos.CriarCarrinho;
using VendingMachine.Application.Usuarios.CriarUsuario;
using VendingMachine.Application.Administradores.CriarAdministrador;
using VendingMachine.Application.Carrinhos.ObterCarrinho;
using System.Runtime.Serialization;
using VendingMachine.Application.Carrinhos.AdicionarItem;

namespace VendingMachine.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        //Produto
        services.AddScoped<CriarProdutoHandler>();
        services.AddScoped<ObterProdutoHandler>();
        services.AddScoped<DeletarProdutoHandler>();
        services.AddScoped<AtualizarProdutoHandler>();

        //Carrinho
        services.AddScoped<CriarCarrinhoHandler>();
        services.AddScoped<ObterCarrinhoHandler>();
        services.AddScoped<AdicionarItemCarrinhoHandler>();
        
        
        //Usuario
        services.AddScoped<CriarUsuarioHandler>();

        //Administrador
        services.AddScoped<CriarAdministradorHandler>();
        return services;
    }
}