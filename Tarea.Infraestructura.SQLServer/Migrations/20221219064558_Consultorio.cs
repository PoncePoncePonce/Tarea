using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tarea.Infraestructura.SQLServer.Migrations
{
    public partial class Consultorio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "cat");

            migrationBuilder.CreateTable(
                name: "Clientes",
                schema: "cat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DireccionCliente = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoCliente = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("codigoCliente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctores",
                schema: "cat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CedulaDoctor = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    NumeroDeTelefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreDoctor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ApellidoDoctor = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("codigoDoctor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                schema: "cat",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Doctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaDeConsulta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clienteId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    doctorId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("codigoCita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Clientes_clienteId",
                        column: x => x.clienteId,
                        principalSchema: "cat",
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Doctores_doctorId",
                        column: x => x.doctorId,
                        principalSchema: "cat",
                        principalTable: "Doctores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_clienteId",
                schema: "cat",
                table: "Citas",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_doctorId",
                schema: "cat",
                table: "Citas",
                column: "doctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Clientes",
                schema: "cat");

            migrationBuilder.DropTable(
                name: "Doctores",
                schema: "cat");
        }
    }
}
