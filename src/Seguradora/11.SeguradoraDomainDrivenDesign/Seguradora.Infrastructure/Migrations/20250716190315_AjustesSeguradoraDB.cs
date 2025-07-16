using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Seguradora.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustesSeguradoraDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apolices_Segurados_SeguradoId",
                table: "Apolices");

            migrationBuilder.DropForeignKey(
                name: "FK_Artefatos_Apolices_ApoliceId",
                table: "Artefatos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApoliceId",
                table: "Artefatos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "SeguradoId",
                table: "Apolices",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Apolices_Segurados_SeguradoId",
                table: "Apolices",
                column: "SeguradoId",
                principalTable: "Segurados",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Artefatos_Apolices_ApoliceId",
                table: "Artefatos",
                column: "ApoliceId",
                principalTable: "Apolices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apolices_Segurados_SeguradoId",
                table: "Apolices");

            migrationBuilder.DropForeignKey(
                name: "FK_Artefatos_Apolices_ApoliceId",
                table: "Artefatos");

            migrationBuilder.AlterColumn<Guid>(
                name: "ApoliceId",
                table: "Artefatos",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "SeguradoId",
                table: "Apolices",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Apolices_Segurados_SeguradoId",
                table: "Apolices",
                column: "SeguradoId",
                principalTable: "Segurados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Artefatos_Apolices_ApoliceId",
                table: "Artefatos",
                column: "ApoliceId",
                principalTable: "Apolices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
