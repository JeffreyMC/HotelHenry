using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelHenry.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitacions",
                columns: table => new
                {
                    IdHabitacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitacions", x => x.IdHabitacion);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    IdPais = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.IdPais);
                });

            migrationBuilder.CreateTable(
                name: "Rols",
                columns: table => new
                {
                    IdRol = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoRol = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rols", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Correo = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    PaisIdPais = table.Column<int>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RolIdRol = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Correo);
                    table.ForeignKey(
                        name: "FK_Usuarios_Paises_PaisIdPais",
                        column: x => x.PaisIdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Rols_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Rols",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservacions",
                columns: table => new
                {
                    IdReserva = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Correo1 = table.Column<string>(nullable: true),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    FechaSalida = table.Column<DateTime>(nullable: false),
                    TipoHabitacionIdHabitacion = table.Column<int>(nullable: true),
                    CantHabitaciones = table.Column<int>(nullable: false),
                    PaisIdPais = table.Column<int>(nullable: true),
                    RolIdRol = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservacions", x => x.IdReserva);
                    table.ForeignKey(
                        name: "FK_Reservacions_Usuarios_Correo1",
                        column: x => x.Correo1,
                        principalTable: "Usuarios",
                        principalColumn: "Correo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservacions_Paises_PaisIdPais",
                        column: x => x.PaisIdPais,
                        principalTable: "Paises",
                        principalColumn: "IdPais",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservacions_Rols_RolIdRol",
                        column: x => x.RolIdRol,
                        principalTable: "Rols",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservacions_Habitacions_TipoHabitacionIdHabitacion",
                        column: x => x.TipoHabitacionIdHabitacion,
                        principalTable: "Habitacions",
                        principalColumn: "IdHabitacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservacions_Correo1",
                table: "Reservacions",
                column: "Correo1");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacions_PaisIdPais",
                table: "Reservacions",
                column: "PaisIdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacions_RolIdRol",
                table: "Reservacions",
                column: "RolIdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Reservacions_TipoHabitacionIdHabitacion",
                table: "Reservacions",
                column: "TipoHabitacionIdHabitacion");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_PaisIdPais",
                table: "Usuarios",
                column: "PaisIdPais");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolIdRol",
                table: "Usuarios",
                column: "RolIdRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservacions");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Habitacions");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Rols");
        }
    }
}
