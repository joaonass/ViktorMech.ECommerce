using Microsoft.EntityFrameworkCore;
using VendingMachine.Application.Interfaces;
using VendingMachine.Application.Produtos.CriarProduto;
using VendingMachine.Application.Produtos.ObterProduto;
using VendingMachine.Application.Produtos.DeletarProduto;
using VendingMachine.Infrastructure.Data;
using VendingMachine.Infrastructure.Repositories;
using VendingMachine.Application.Produtos.AtualizarProduto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CriarProdutoHandler>();
builder.Services.AddScoped<ObterProdutoHandler>();
builder.Services.AddScoped<DeletarProdutoHandler>();
builder.Services.AddScoped<AtualizarProdutoHandler>();

builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();