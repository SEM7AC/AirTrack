using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirTrack.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EngineType",
                table: "Aircraft",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Equipment",
                table: "Aircraft",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "FuelType",
                table: "Aircraft",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Aircraft",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Aircraft",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Aircraft",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EngineType",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "FuelType",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Aircraft");
        }
    }
}
