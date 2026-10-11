using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachine.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarMapeamentoEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantidade_Estoque",
                table: "Produtos",
                newName: "Estoque_Valor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Estoque_Valor",
                table: "Produtos",
                newName: "Quantidade_Estoque");
        }
    }
}
