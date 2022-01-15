using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace tasinmaz_backend.Migrations
{
    public partial class migration0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cities",
                columns: table => new
                {
                    cityid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cityname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cities", x => x.cityid);
                });

            migrationBuilder.CreateTable(
                name: "kullanicilar",
                columns: table => new
                {
                    kullaniciid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ad = table.Column<string>(type: "text", nullable: true),
                    soyad = table.Column<string>(type: "text", nullable: true),
                    sifre = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    rol = table.Column<bool>(type: "boolean", nullable: false),
                    adres = table.Column<string>(type: "text", nullable: true),
                    silindimi = table.Column<bool>(type: "boolean", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kullanicilar", x => x.kullaniciid);
                });

            migrationBuilder.CreateTable(
                name: "loglar",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    durum = table.Column<string>(type: "text", nullable: true),
                    islemtipi = table.Column<string>(type: "text", nullable: true),
                    tarihsaat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Ip = table.Column<string>(type: "text", nullable: true),
                    Acikklama = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loglar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "counties",
                columns: table => new
                {
                    countyid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cityid = table.Column<int>(type: "integer", nullable: false),
                    countyname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_counties", x => x.countyid);
                    table.ForeignKey(
                        name: "FK_counties_cities_cityid",
                        column: x => x.cityid,
                        principalTable: "cities",
                        principalColumn: "cityid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "neighborhoods",
                columns: table => new
                {
                    neighborhoodid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    countyid = table.Column<int>(type: "integer", nullable: false),
                    neighborhoodname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_neighborhoods", x => x.neighborhoodid);
                    table.ForeignKey(
                        name: "FK_neighborhoods_counties_countyid",
                        column: x => x.countyid,
                        principalTable: "counties",
                        principalColumn: "countyid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tasinmazlar",
                columns: table => new
                {
                    tasinmazid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    neighborhoodid = table.Column<int>(type: "integer", nullable: true),
                    cityid = table.Column<int>(type: "integer", nullable: true),
                    countyid = table.Column<int>(type: "integer", nullable: true),
                    ada = table.Column<int>(type: "integer", nullable: false),
                    parsel = table.Column<int>(type: "integer", nullable: false),
                    nitelik = table.Column<string>(type: "text", nullable: true),
                    adres = table.Column<string>(type: "text", nullable: true),
                    silindimi = table.Column<bool>(type: "boolean", nullable: true),
                    cityname = table.Column<string>(type: "text", nullable: true),
                    countyname = table.Column<string>(type: "text", nullable: true),
                    neighborhoodname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tasinmazlar", x => x.tasinmazid);
                    table.ForeignKey(
                        name: "FK_tasinmazlar_neighborhoods_neighborhoodid",
                        column: x => x.neighborhoodid,
                        principalTable: "neighborhoods",
                        principalColumn: "neighborhoodid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_counties_cityid",
                table: "counties",
                column: "cityid");

            migrationBuilder.CreateIndex(
                name: "IX_neighborhoods_countyid",
                table: "neighborhoods",
                column: "countyid");

            migrationBuilder.CreateIndex(
                name: "IX_tasinmazlar_neighborhoodid",
                table: "tasinmazlar",
                column: "neighborhoodid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "kullanicilar");

            migrationBuilder.DropTable(
                name: "loglar");

            migrationBuilder.DropTable(
                name: "tasinmazlar");

            migrationBuilder.DropTable(
                name: "neighborhoods");

            migrationBuilder.DropTable(
                name: "counties");

            migrationBuilder.DropTable(
                name: "cities");
        }
    }
}
