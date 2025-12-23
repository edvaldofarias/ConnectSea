using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectSea.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ManifestoEscala : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManifestoEscalas",
                columns: table => new
                {
                    ManifestoId = table.Column<int>(type: "int", nullable: false),
                    EscalaId = table.Column<int>(type: "int", nullable: false),
                    DataVinculacao = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManifestoEscalas", x => new { x.ManifestoId, x.EscalaId });
                    table.ForeignKey(
                        name: "FK_ManifestoEscalas_Escalas_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escalas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManifestoEscalas_Manifestos_ManifestoId",
                        column: x => x.ManifestoId,
                        principalTable: "Manifestos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManifestoEscalas_EscalaId",
                table: "ManifestoEscalas",
                column: "EscalaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManifestoEscalas");
        }
    }
}
