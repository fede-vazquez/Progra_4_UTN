using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PancheriaJP.Migrations
{
    /// <inheritdoc />
    public partial class DbCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Panchos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVegano = table.Column<bool>(type: "bit", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Aderezos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panchos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Panchos",
                columns: new[] { "Id", "Aderezos", "IsVegano", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "[\"Mayonesa\",\"Mostaza\"]", false, "Normal", 12.5 },
                    { 2, "[\"Mayonesa\",\"Mostaza\",\"Papitas\"]", false, "Super Pancho", 20.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Panchos");
        }
    }
}
