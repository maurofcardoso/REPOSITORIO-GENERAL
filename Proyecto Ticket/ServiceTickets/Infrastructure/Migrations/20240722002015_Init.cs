using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Add-Migration Init en infraestructura y Update-Database 
            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    idArea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    activeArea = table.Column<bool>(type: "bit", nullable: false),
                    nameArea = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    createUser = table.Column<int>(type: "int", nullable: false),
                    dateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updateUser = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.idArea);
                });

            migrationBuilder.CreateTable(
                name: "TicketBody",
                columns: table => new
                {
                    idTicketBody = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketBody", x => x.idTicketBody);
                });

            migrationBuilder.CreateTable(
                name: "TicketCount",
                columns: table => new
                {
                    idTicketCount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    countOpen = table.Column<int>(type: "int", nullable: false),
                    countApproved = table.Column<int>(type: "int", nullable: false),
                    countDisapproved = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCount", x => x.idTicketCount);
                });

            migrationBuilder.CreateTable(
                name: "TicketPriority",
                columns: table => new
                {
                    idPriority = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketPriority", x => x.idPriority);
                });

            migrationBuilder.CreateTable(
                name: "TicketStatus",
                columns: table => new
                {
                    idTicketStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketStatus", x => x.idTicketStatus);
                });

            migrationBuilder.CreateTable(
                name: "TicketCategory",
                columns: table => new
                {
                    idTicketCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    reqApproval = table.Column<bool>(type: "bit", nullable: false),
                    minApprovers = table.Column<int>(type: "int", nullable: false),
                    idAreadestino = table.Column<int>(type: "int", nullable: false),
                    active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketCategory", x => x.idTicketCategory);
                    table.ForeignKey(
                        name: "FK_TicketCategory_Area_idAreadestino",
                        column: x => x.idAreadestino,
                        principalTable: "Area",
                        principalColumn: "idArea",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    idTicket = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    idStatus = table.Column<int>(type: "int", nullable: false),
                    idPriority = table.Column<int>(type: "int", nullable: false),
                    idPTicketCount = table.Column<int>(type: "int", nullable: false),
                    idTicketCategory = table.Column<int>(type: "int", nullable: false),
                    idTicketBody = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.idTicket);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketBody_idTicketBody",
                        column: x => x.idTicketBody,
                        principalTable: "TicketBody",
                        principalColumn: "idTicketBody",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketCategory_idTicketCategory",
                        column: x => x.idTicketCategory,
                        principalTable: "TicketCategory",
                        principalColumn: "idTicketCategory",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketCount_idPTicketCount",
                        column: x => x.idPTicketCount,
                        principalTable: "TicketCount",
                        principalColumn: "idTicketCount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketPriority_idPriority",
                        column: x => x.idPriority,
                        principalTable: "TicketPriority",
                        principalColumn: "idPriority",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_TicketStatus_idStatus",
                        column: x => x.idStatus,
                        principalTable: "TicketStatus",
                        principalColumn: "idTicketStatus",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketComment",
                columns: table => new
                {
                    idComment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTicket = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    file = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateComment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    edited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketComment", x => x.idComment);
                    table.ForeignKey(
                        name: "FK_TicketComment_Ticket_idTicket",
                        column: x => x.idTicket,
                        principalTable: "Ticket",
                        principalColumn: "idTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TicketLog",
                columns: table => new
                {
                    idTicketLog = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idTicket = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: false),
                    dateAction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    action = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketLog", x => x.idTicketLog);
                    table.ForeignKey(
                        name: "FK_TicketLog_Ticket_idTicket",
                        column: x => x.idTicket,
                        principalTable: "Ticket",
                        principalColumn: "idTicket",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Area",
                columns: new[] { "idArea", "activeArea", "createUser", "dateCreate", "dateUpdate", "description", "nameArea", "updateUser" },
                values: new object[,]
                {
                    { 1, true, 1, new DateTime(2024, 7, 21, 21, 20, 14, 866, DateTimeKind.Local).AddTicks(2599), new DateTime(2024, 7, 21, 21, 20, 14, 866, DateTimeKind.Local).AddTicks(2699), "Area encargada de la administracion total del sistema", "Admin", 1 },
                    { 2, true, 1, new DateTime(2024, 7, 21, 21, 20, 14, 866, DateTimeKind.Local).AddTicks(2701), new DateTime(2024, 7, 21, 21, 20, 14, 866, DateTimeKind.Local).AddTicks(2702), "Area encargada de registrar y ejecutar las compras/ventas de la organización", "CompraVenta", 1 },
                    { 3, true, 1, new DateTime(2024, 7, 21, 21, 20, 14, 866, DateTimeKind.Local).AddTicks(2703), new DateTime(2024, 7, 21, 21, 20, 14, 866, DateTimeKind.Local).AddTicks(2704), "Area encargada del soporte tecnico de la organización", "Soporte", 1 }
                });

            migrationBuilder.InsertData(
                table: "TicketPriority",
                columns: new[] { "idPriority", "description" },
                values: new object[,]
                {
                    { 1, "Baja" },
                    { 2, "Media" },
                    { 3, "Alta" }
                });

            migrationBuilder.InsertData(
                table: "TicketStatus",
                columns: new[] { "idTicketStatus", "description" },
                values: new object[,]
                {
                    { 1, "Pendiente" },
                    { 2, "En curso" },
                    { 3, "Finalizado" }
                });

            migrationBuilder.InsertData(
                table: "TicketCategory",
                columns: new[] { "idTicketCategory", "active", "description", "idAreadestino", "minApprovers", "name", "reqApproval" },
                values: new object[] { 1, true, "Categoria responsable de gestionar los tickets de ventas", 2, 1, "Ventas", true });

            migrationBuilder.InsertData(
                table: "TicketCategory",
                columns: new[] { "idTicketCategory", "active", "description", "idAreadestino", "minApprovers", "name", "reqApproval" },
                values: new object[] { 2, true, "Categoria responsable de gestionar los tickets de compras", 2, 1, "Compras", true });

            migrationBuilder.InsertData(
                table: "TicketCategory",
                columns: new[] { "idTicketCategory", "active", "description", "idAreadestino", "minApprovers", "name", "reqApproval" },
                values: new object[] { 3, true, "Categoria responsable de gestionar las reparaciones de Hardware", 3, 1, "Reparacion Hardware", true });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idPriority",
                table: "Ticket",
                column: "idPriority");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idPTicketCount",
                table: "Ticket",
                column: "idPTicketCount",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idStatus",
                table: "Ticket",
                column: "idStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idTicketBody",
                table: "Ticket",
                column: "idTicketBody",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_idTicketCategory",
                table: "Ticket",
                column: "idTicketCategory");

            migrationBuilder.CreateIndex(
                name: "IX_TicketCategory_idAreadestino",
                table: "TicketCategory",
                column: "idAreadestino");

            migrationBuilder.CreateIndex(
                name: "IX_TicketComment_idTicket",
                table: "TicketComment",
                column: "idTicket");

            migrationBuilder.CreateIndex(
                name: "IX_TicketLog_idTicket",
                table: "TicketLog",
                column: "idTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TicketComment");

            migrationBuilder.DropTable(
                name: "TicketLog");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketBody");

            migrationBuilder.DropTable(
                name: "TicketCategory");

            migrationBuilder.DropTable(
                name: "TicketCount");

            migrationBuilder.DropTable(
                name: "TicketPriority");

            migrationBuilder.DropTable(
                name: "TicketStatus");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
