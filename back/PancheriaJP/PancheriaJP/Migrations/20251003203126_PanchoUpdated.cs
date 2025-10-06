using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PancheriaJP.Migrations
{
    /// <inheritdoc />
    public partial class PanchoUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Panchos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Panchos_CategoriaId",
                table: "Panchos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Panchos_Categorias_CategoriaId",
                table: "Panchos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panchos_Categorias_CategoriaId",
                table: "Panchos");

            migrationBuilder.DropIndex(
                name: "IX_Panchos_CategoriaId",
                table: "Panchos");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Panchos");
        }
    }
}
