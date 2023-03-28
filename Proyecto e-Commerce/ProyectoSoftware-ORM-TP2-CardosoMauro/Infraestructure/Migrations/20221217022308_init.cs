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
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DNI = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(13)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(25)", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal (15,2)", precision: 15, scale: 2, nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Carritos",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carritos", x => x.CarritoId);
                    table.ForeignKey(
                        name: "FK_Carritos_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrito / Producto",
                columns: table => new
                {
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID", x => new { x.CarritoId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_Carrito / Producto_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Carrito / Producto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordenes",
                columns: table => new
                {
                    OrdenId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "decimal (15,2)", precision: 15, scale: 2, nullable: false),
                    CarritoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenes", x => x.OrdenId);
                    table.ForeignKey(
                        name: "FK_Ordenes_Carritos_CarritoId",
                        column: x => x.CarritoId,
                        principalTable: "Carritos",
                        principalColumn: "CarritoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "ClienteId", "Apellido", "DNI", "Direccion", "Nombre", "Telefono" },
                values: new object[] { 1, "Cardoso", "31282983", "Calle 421", "Mauro", "1158594841" });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Codigo", "Descripcion", "Image", "Marca", "Nombre", "Precio" },
                values: new object[,]
                {
                    { 1, "Cod 1", "Cuidado Corporal", "https://i.imgur.com/ii8kB2g.jpg", "Nivea", "Bronceador", 1693m },
                    { 2, "cod 2", "Espumante", "https://i.imgur.com/4M7bD2X.jpg", "Nieto Senetiner", "Champagne", 1940m },
                    { 3, "cod 3", "Ciruela", "https://i.imgur.com/q4tQeeH.jpg", "Emeth", "Mermelada", 231m },
                    { 4, "Cod 4", "Mineral", "https://i.imgur.com/Jdz22SZ.jpg", "King", "Agua", 160m },
                    { 5, "Cod 5", "Organica", "https://i.imgur.com/nE1TQaW.jpg", "Chango", "Azucar", 429m },
                    { 6, "Cod 6", "Descartables", "https://i.imgur.com/NwWXjUW.jpg", "Elite", "Pañuelos", 178m },
                    { 7, "Cod 7", "Pollo", "https://i.imgur.com/wbIl0jU.jpg", "Well", "Medallon", 119m },
                    { 8, "Cod 8", "Goma", "https://i.imgur.com/zgOx8TG.jpg", "Dia", "Secador", 425m },
                    { 9, "Cod 9", "Rellenas", "https://i.imgur.com/KJAyrFa.jpg", "Frutigram", "Galletitas", 165m },
                    { 10, "Cod 10", "Tostado", "https://i.imgur.com/RYgyvxE.jpg", "Martinez", "Cafe", 1391m }
                });

            migrationBuilder.InsertData(
                table: "Carritos",
                columns: new[] { "CarritoId", "ClienteId", "Estado" },
                values: new object[] { new Guid("5ee604af-6677-4606-aaf1-544fe610e1c1"), 1, true });

            migrationBuilder.CreateIndex(
                name: "IX_Carrito / Producto_ProductoId",
                table: "Carrito / Producto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Carritos_ClienteId",
                table: "Carritos",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordenes_CarritoId",
                table: "Ordenes",
                column: "CarritoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carrito / Producto");

            migrationBuilder.DropTable(
                name: "Ordenes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Carritos");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
