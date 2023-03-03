using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentSITHEC.Migrations
{
    /// <inheritdoc />
    public partial class HumanTBL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Humano",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humano", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Humano",
                columns: new[] { "Id", "Altura", "Edad", "Nombre", "Peso", "Sexo" },
                values: new object[,]
                {
                    { 1, 1.80m, 20, "Juan", 80.00m, "H" },
                    { 2, 1.70m, 25, "Pedro", 70.00m, "H" },
                    { 3, 1.60m, 30, "Maria", 60.00m, "M" },
                    { 4, 1.50m, 35, "Jose", 50.00m, "H" },
                    { 5, 1.40m, 40, "Luis", 40.00m, "H" },
                    { 6, 1.30m, 45, "Ana", 30.00m, "M" },
                    { 7, 1.20m, 50, "Luisa", 20.00m, "M" },
                    { 8, 1.10m, 55, "Luis", 10.00m, "H" },
                    { 9, 1.00m, 60, "Luisa", 5.00m, "M" },
                    { 10, 0.90m, 65, "Luis", 4.00m, "H" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humano");
        }
    }
}
