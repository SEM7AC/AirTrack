using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirTrack.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueTailNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Aircraft_TailNumber",
                table: "Aircraft",
                column: "TailNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Aircraft_TailNumber",
                table: "Aircraft");
        }
    }
}
