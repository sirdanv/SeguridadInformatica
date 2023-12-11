using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeguridadInformatica.Migrations
{
    public partial class Inicio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuariosId);
                });

            migrationBuilder.CreateTable(
                name: "Activos",
                columns: table => new
                {
                    ActivosId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Disponibilidad = table.Column<float>(type: "real", nullable: false),
                    Integridad = table.Column<float>(type: "real", nullable: false),
                    Confidencialidad = table.Column<float>(type: "real", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuariosId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuariosId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activos", x => x.ActivosId);
                    table.ForeignKey(
                        name: "FK_Activos_Usuarios_UsuariosId1",
                        column: x => x.UsuariosId1,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosId");
                });

            migrationBuilder.CreateTable(
                name: "Dimensiones",
                columns: table => new
                {
                    DimensionesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disponibilidad = table.Column<int>(type: "int", nullable: false),
                    Integridad = table.Column<int>(type: "int", nullable: false),
                    Confidencialidad = table.Column<int>(type: "int", nullable: false),
                    Evaluacion = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuariosId1 = table.Column<int>(type: "int", nullable: true),
                    ActivosId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivosId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensiones", x => x.DimensionesId);
                    table.ForeignKey(
                        name: "FK_Dimensiones_Activos_ActivosId1",
                        column: x => x.ActivosId1,
                        principalTable: "Activos",
                        principalColumn: "ActivosId");
                    table.ForeignKey(
                        name: "FK_Dimensiones_Usuarios_UsuariosId1",
                        column: x => x.UsuariosId1,
                        principalTable: "Usuarios",
                        principalColumn: "UsuariosId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activos_UsuariosId1",
                table: "Activos",
                column: "UsuariosId1");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensiones_ActivosId1",
                table: "Dimensiones",
                column: "ActivosId1");

            migrationBuilder.CreateIndex(
                name: "IX_Dimensiones_UsuariosId1",
                table: "Dimensiones",
                column: "UsuariosId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dimensiones");

            migrationBuilder.DropTable(
                name: "Activos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
