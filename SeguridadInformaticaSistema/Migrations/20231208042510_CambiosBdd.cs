using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeguridadInformatica.Migrations
{
    public partial class CambiosBdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    ActivosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.ActivosId);
                });

            migrationBuilder.CreateTable(
                name: "Dimensiones",
                columns: table => new
                {
                    DimesionesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    ActivosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensiones", x => x.DimesionesId);
                    table.ForeignKey(
                        name: "FK_Dimensiones_Activos_ActivosId",
                        column: x => x.ActivosId,
                        principalTable: "Activos",
                        principalColumn: "ActivosId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dimensiones_ActivosId",
                table: "Dimensiones",
                column: "ActivosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dimensiones");

            migrationBuilder.DropTable(
                name: "Activos");
        }
    }
}
