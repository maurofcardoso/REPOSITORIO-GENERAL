using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.PermissionId);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.RolId);
                });

            migrationBuilder.CreateTable(
                name: "RolPermission",
                columns: table => new
                {
                    RolId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermission", x => new { x.RolId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermission_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    DNI = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActiveUser = table.Column<bool>(type: "bit", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUser = table.Column<int>(type: "int", nullable: false),
                    UpdateUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "RolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "PermissionId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Permiso que otorga la posibilidad de agregar, modificar y/o eliminar usuarios", "ABM Usuarios" },
                    { 2, "Permiso que otorga la posibilidad de crear y/o editar tickets", "AM Tickets" },
                    { 3, "Permiso que otorga la posibilidad de tomar, resolver y/o derivar tickets", "Resolucion Tickets" },
                    { 4, "Permiso que otorga la posibilidad de realizar un ABM de las areas del sistema", "ABM Areas" },
                    { 5, "Permiso que otorga la posibilidad de realizar un ABM de TicketCategory", "ABM TicketCategory" }
                });

            migrationBuilder.InsertData(
                table: "Rol",
                columns: new[] { "RolId", "Description", "Title" },
                values: new object[,]
                {
                    { 1, "Perfil administrador del portal", "Administrador" },
                    { 2, "Perfil de Usuario, permite generar y editar tickets", "Usuario" },
                    { 3, "Perfil de Agente, permite tomar, derivar y/o resolver un ticket", "Agente" }
                });

            migrationBuilder.InsertData(
                table: "RolPermission",
                columns: new[] { "PermissionId", "RolId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "ActiveUser", "AreaId", "CreateUser", "DNI", "DateCreate", "DateUpdate", "Email", "FirstName", "LastName", "Password", "Phone", "RolId", "UpdateUser", "UserName" },
                values: new object[,]
                {
                    { 1, true, 1, 0, "11845121", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "psgrupointer@gmail.com", "Cosme", "Fulanito", "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", "1561990876", 1, 0, "admin" },
                    { 2, true, 2, 0, "33678345", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "juanperez@gmail.com", "Juan", "Perez", "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", "1168374456", 2, 0, "juanperez" },
                    { 3, true, 2, 0, "23876498", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "francogomez@gmail.com", "Franco", "Gomez", "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", "1168374456", 3, 0, "francogomez" },
                    { 4, true, 3, 0, "29358567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "angelsola@gmail.com", "Angel", "Sosa", "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", "1168374456", 2, 0, "angelsosa" },
                    { 5, true, 3, 0, "39345567", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "candelagabriele@outlook.com", "Candela", "Gabriele", "/T/sAU1qDJH7ANJ9eRiZWDpNS+0pMxVEpx03KZO529E=", "1168374456", 3, 0, "candelagabriele" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolPermission_PermissionId",
                table: "RolPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RolId",
                table: "User",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolPermission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
