using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seguradora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustesApoliceDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativa",
                table: "Apolices",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativa",
                table: "Apolices");
        }
    }
}
