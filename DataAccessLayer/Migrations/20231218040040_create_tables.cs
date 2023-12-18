using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAccessLayer.Migrations
{
    public partial class create_tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuildingProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    building = table.Column<string>(type: "text", nullable: true),
                    geotype = table.Column<string>(type: "text", nullable: true),
                    index = table.Column<int>(type: "integer", nullable: true),
                    addrcity = table.Column<string>(type: "text", nullable: true),
                    addrhousenumber = table.Column<string>(type: "text", nullable: true),
                    addrstreet = table.Column<string>(type: "text", nullable: true),
                    buildinglevels = table.Column<string>(type: "text", nullable: true),
                    addrcountry = table.Column<string>(type: "text", nullable: true),
                    leisure = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    opening_hourscovid19 = table.Column<string>(type: "text", nullable: true),
                    addrpostcode = table.Column<string>(type: "text", nullable: true),
                    amenity = table.Column<string>(type: "text", nullable: true),
                    bathopen_air = table.Column<string>(type: "text", nullable: true),
                    bathsand_bath = table.Column<string>(type: "text", nullable: true),
                    charge = table.Column<string>(type: "text", nullable: true),
                    fee = table.Column<string>(type: "text", nullable: true),
                    opening_hours = table.Column<string>(type: "text", nullable: true),
                    paymentcash = table.Column<string>(type: "text", nullable: true),
                    paymentmastercard = table.Column<string>(type: "text", nullable: true),
                    paymentvisa = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PoiFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoiFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadFeatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoadProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    highway = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    nameaz = table.Column<string>(type: "text", nullable: true),
                    nameen = table.Column<string>(type: "text", nullable: true),
                    nameru = table.Column<string>(type: "text", nullable: true),
                    oneway = table.Column<string>(type: "text", nullable: true),
                    geotype = table.Column<string>(type: "text", nullable: true),
                    index = table.Column<int>(type: "integer", nullable: true),
                    alt_name = table.Column<string>(type: "text", nullable: true),
                    junction = table.Column<string>(type: "text", nullable: true),
                    maxwidth = table.Column<string>(type: "text", nullable: true),
                    int_ref = table.Column<string>(type: "text", nullable: true),
                    old_name = table.Column<string>(type: "text", nullable: true),
                    old_nameru = table.Column<string>(type: "text", nullable: true),
                    maxspeed = table.Column<string>(type: "text", nullable: true),
                    surface = table.Column<string>(type: "text", nullable: true),
                    covered = table.Column<string>(type: "text", nullable: true),
                    layer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadProperties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    BuildingFeatureId = table.Column<int>(type: "integer", nullable: true),
                    PropertiesId = table.Column<int>(type: "integer", nullable: true),
                    IdValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buildings_BuildingFeatures_BuildingFeatureId",
                        column: x => x.BuildingFeatureId,
                        principalTable: "BuildingFeatures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Poi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    PoiFeatureId = table.Column<int>(type: "integer", nullable: true),
                    PropertiesId = table.Column<int>(type: "integer", nullable: true),
                    IdValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Poi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Poi_PoiFeatures_PoiFeatureId",
                        column: x => x.PoiFeatureId,
                        principalTable: "PoiFeatures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Roads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(type: "text", nullable: true),
                    geometry = table.Column<Geometry>(type: "geometry", nullable: true),
                    RoadFeatureId = table.Column<int>(type: "integer", nullable: true),
                    PropertiesId = table.Column<int>(type: "integer", nullable: true),
                    IdValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Roads_RoadFeatures_RoadFeatureId",
                        column: x => x.RoadFeatureId,
                        principalTable: "RoadFeatures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buildings_BuildingFeatureId",
                table: "Buildings",
                column: "BuildingFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Poi_PoiFeatureId",
                table: "Poi",
                column: "PoiFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Roads_RoadFeatureId",
                table: "Roads",
                column: "RoadFeatureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingProperties");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "Poi");

            migrationBuilder.DropTable(
                name: "RoadProperties");

            migrationBuilder.DropTable(
                name: "Roads");

            migrationBuilder.DropTable(
                name: "BuildingFeatures");

            migrationBuilder.DropTable(
                name: "PoiFeatures");

            migrationBuilder.DropTable(
                name: "RoadFeatures");
        }
    }
}
