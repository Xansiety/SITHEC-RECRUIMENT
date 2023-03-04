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
                name: "Humanos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Altura = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Peso = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Humanos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Humanos",
                columns: new[] { "Id", "Altura", "Edad", "Nombre", "Peso", "Sexo" },
                values: new object[,]
                {
                    { 1, 1.80m, 20, "Juan Perez", 80.00m, 2 },
                    { 2, 1.70m, 25, "Pedro Hernandez", 70.00m, 2 },
                    { 3, 1.60m, 30, "Maria Santiago", 60.00m, 1 },
                    { 4, 1.60m, 35, "Jose Perez", 50.00m, 2 },
                    { 5, 1.80m, 40, "Luis Jimenez", 50.00m, 2 },
                    { 6, 1.60m, 45, "Ana Alvarado", 80.00m, 1 },
                    { 7, 1.70m, 50, "Luisa Salazar", 60.00m, 1 },
                    { 8, 1.70m, 55, "Luis Perez", 78.00m, 2 },
                    { 9, 1.80m, 60, "Luisa Sanchez", 56.00m, 2 },
                    { 10, 1.60m, 65, "Maria Salazar", 45.00m, 1 },
                    { 11, 1.70m, 70, "Maria Lino", 45.00m, 1 },
                    { 12, 1.60m, 75, "Luisa Perez", 45.00m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Humanos");
        }
    }
}
