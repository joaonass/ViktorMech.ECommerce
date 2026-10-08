using Microsoft.Extensions.DependencyInjection;
using VendingMachine.Application.Produtos.CriarProduto;
using VendingMachine.Application.Produtos.DeletarProduto;
using VendingMachine.Application.Produtos.ObterProduto;
using VendingMachine.Application.Produtos.AtualizarProduto;

namespace VendingMachine.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<CriarProdutoHandler>();
        services.AddScoped<ObterProdutoHandler>();
        services.AddScoped<DeletarProdutoHandler>();
        services.AddScoped<AtualizarProdutoHandler>();

        return services;
    }
}