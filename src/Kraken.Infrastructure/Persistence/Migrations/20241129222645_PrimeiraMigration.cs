using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kraken.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Criação da tabela Produto
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Id);
                });

            // Criação da tabela OrdemItem
            migrationBuilder.CreateTable(
                name: "OrdemItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdemItem_Produto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict); // Evita exclusão em cascata
                });

            // Criação do índice para IdProduto em OrdemItem
            migrationBuilder.CreateIndex(
                name: "IX_OrdemItem_IdProduto",
                table: "OrdemItem",
                column: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Exclusão da tabela OrdemItem
            migrationBuilder.DropTable(
                name: "OrdemItem");

            // Exclusão da tabela Produto
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}