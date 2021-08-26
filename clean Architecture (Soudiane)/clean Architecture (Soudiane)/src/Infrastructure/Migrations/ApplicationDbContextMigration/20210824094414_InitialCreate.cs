using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clean_Architecture_Soufiane.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "venteitemseq",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "venteseq",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "orderstatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderstatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vte_vente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    VenteStatusId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VenteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vte_vente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vte_vente_orderstatus_VenteStatusId",
                        column: x => x.VenteStatusId,
                        principalTable: "orderstatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "venteItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    VenteId = table.Column<int>(type: "int", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Units = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_venteItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_venteItems_Vte_vente_VenteId",
                        column: x => x.VenteId,
                        principalTable: "Vte_vente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_venteItems_VenteId",
                table: "venteItems",
                column: "VenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vte_vente_VenteStatusId",
                table: "Vte_vente",
                column: "VenteStatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "venteItems");

            migrationBuilder.DropTable(
                name: "Vte_vente");

            migrationBuilder.DropTable(
                name: "orderstatus");

            migrationBuilder.DropSequence(
                name: "venteitemseq");

            migrationBuilder.DropSequence(
                name: "venteseq");
        }
    }
}
