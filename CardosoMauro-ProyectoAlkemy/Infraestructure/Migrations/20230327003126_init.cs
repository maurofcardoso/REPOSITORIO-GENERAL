using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal (15,2)", precision: 15, scale: 2, nullable: false),
                    History = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.CharacterId);
                });

            migrationBuilder.CreateTable(
                name: "Genders",
                columns: table => new
                {
                    GenderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genders", x => x.GenderId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Movies or Series",
                columns: table => new
                {
                    MovieOrSerieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Qualification = table.Column<int>(type: "int", nullable: false),
                    GenderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies or Series", x => x.MovieOrSerieId);
                    table.ForeignKey(
                        name: "FK_Movies or Series_Genders_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Genders",
                        principalColumn: "GenderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Characters Movies or Series",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    MovieOrSerieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters Movies or Series", x => new { x.CharacterId, x.MovieOrSerieId });
                    table.ForeignKey(
                        name: "FK_Characters Movies or Series_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "CharacterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Characters Movies or Series_Movies or Series_MovieOrSerieId",
                        column: x => x.MovieOrSerieId,
                        principalTable: "Movies or Series",
                        principalColumn: "MovieOrSerieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "CharacterId", "Age", "History", "Image", "Name", "Weight" },
                values: new object[] { 1, 37, "una historia", "https://i.imgur.com/ii8kB2g.jpg", "mauro", 85.2m });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "Image", "Name" },
                values: new object[] { 1, "https://i.imgur.com/4M7bD2X.jpg", "terror" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UserId", "Email", "LastName", "Name", "Password" },
                values: new object[] { 1, "mauro@mauro.com", "Cardoso", "Mauro", "0cf9698501df07b21305bfded3a6b3660123095f1375b3ab32f739c0c37f0096" });

            migrationBuilder.InsertData(
                table: "Movies or Series",
                columns: new[] { "MovieOrSerieId", "CreationDate", "GenderId", "Image", "Qualification", "Title" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "https://i.imgur.com/q4tQeeH.jpg", 5, "algun titulo" });

            migrationBuilder.InsertData(
                table: "Characters Movies or Series",
                columns: new[] { "CharacterId", "MovieOrSerieId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Characters Movies or Series_MovieOrSerieId",
                table: "Characters Movies or Series",
                column: "MovieOrSerieId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies or Series_GenderId",
                table: "Movies or Series",
                column: "GenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters Movies or Series");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropTable(
                name: "Movies or Series");

            migrationBuilder.DropTable(
                name: "Genders");
        }
    }
}
