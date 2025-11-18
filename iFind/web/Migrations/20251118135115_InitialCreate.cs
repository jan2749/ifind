using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace web.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uporabniki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priimek = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Spol = table.Column<int>(type: "int", nullable: true),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Geslo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatumRegistracije = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JeAdministrator = table.Column<bool>(type: "bit", nullable: false),
                    JeOrganizator = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uporabniki", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dogodki",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumCas = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrganizatorId = table.Column<int>(type: "int", nullable: false),
                    KategorijaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogodki", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogodki_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogodki_Uporabniki_OrganizatorId",
                        column: x => x.OrganizatorId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lokacije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogodekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lokacije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lokacije_Dogodki_DogodekId",
                        column: x => x.DogodekId,
                        principalTable: "Dogodki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Udelezbe",
                columns: table => new
                {
                    UporabnikId = table.Column<int>(type: "int", nullable: false),
                    DogodekId = table.Column<int>(type: "int", nullable: false),
                    DatumPrijave = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Udelezbe", x => new { x.UporabnikId, x.DogodekId });
                    table.ForeignKey(
                        name: "FK_Udelezbe_Dogodki_DogodekId",
                        column: x => x.DogodekId,
                        principalTable: "Dogodki",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Udelezbe_Uporabniki_UporabnikId",
                        column: x => x.UporabnikId,
                        principalTable: "Uporabniki",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogodki_KategorijaId",
                table: "Dogodki",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogodki_OrganizatorId",
                table: "Dogodki",
                column: "OrganizatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Lokacije_DogodekId",
                table: "Lokacije",
                column: "DogodekId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Udelezbe_DogodekId",
                table: "Udelezbe",
                column: "DogodekId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lokacije");

            migrationBuilder.DropTable(
                name: "Udelezbe");

            migrationBuilder.DropTable(
                name: "Dogodki");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Uporabniki");
        }
    }
}
