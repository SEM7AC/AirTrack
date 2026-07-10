using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirTrack.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMxFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentFlightStart",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "CurrentInstructor",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "CurrentStudent",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "NextBookingEnd",
                table: "Aircraft");

            migrationBuilder.DropColumn(
                name: "NextBookingStart",
                table: "Aircraft");

            migrationBuilder.RenameColumn(
                name: "HoursSince2200HrOverhaul",
                table: "RobinsonR44s",
                newName: "Last2200HrOverhaul");

            migrationBuilder.RenameColumn(
                name: "RightEngineHours",
                table: "PiperSeminoles",
                newName: "LastRightEngineHobbs");

            migrationBuilder.RenameColumn(
                name: "LeftEngineHours",
                table: "PiperSeminoles",
                newName: "LastLeftEngineHobbs");

            migrationBuilder.RenameColumn(
                name: "GearCyclesSinceInspection",
                table: "PiperSeminoles",
                newName: "LastGearCyclesInspection");

            migrationBuilder.RenameColumn(
                name: "HoursSinceLastOilChange",
                table: "PiperArrows",
                newName: "LastOilChange");

            migrationBuilder.RenameColumn(
                name: "HoursSinceLast100Hr",
                table: "PiperArrows",
                newName: "Last100Hr");

            migrationBuilder.RenameColumn(
                name: "GearCyclesSinceInspection",
                table: "PiperArrows",
                newName: "LastGearCyclesInspection");

            migrationBuilder.RenameColumn(
                name: "HoursSinceLastOilChange",
                table: "CessnaSkyhawks",
                newName: "LastOilChange");

            migrationBuilder.RenameColumn(
                name: "HoursSinceLast50Hr",
                table: "CessnaSkyhawks",
                newName: "Last50Hr");

            migrationBuilder.RenameColumn(
                name: "HoursSinceLast100Hr",
                table: "CessnaSkyhawks",
                newName: "Last100Hr");

            migrationBuilder.AddColumn<decimal>(
                name: "Last100Hr",
                table: "PiperSeminoles",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Last100Hr",
                table: "PiperSeminoles");

            migrationBuilder.RenameColumn(
                name: "Last2200HrOverhaul",
                table: "RobinsonR44s",
                newName: "HoursSince2200HrOverhaul");

            migrationBuilder.RenameColumn(
                name: "LastRightEngineHobbs",
                table: "PiperSeminoles",
                newName: "RightEngineHours");

            migrationBuilder.RenameColumn(
                name: "LastLeftEngineHobbs",
                table: "PiperSeminoles",
                newName: "LeftEngineHours");

            migrationBuilder.RenameColumn(
                name: "LastGearCyclesInspection",
                table: "PiperSeminoles",
                newName: "GearCyclesSinceInspection");

            migrationBuilder.RenameColumn(
                name: "LastOilChange",
                table: "PiperArrows",
                newName: "HoursSinceLastOilChange");

            migrationBuilder.RenameColumn(
                name: "LastGearCyclesInspection",
                table: "PiperArrows",
                newName: "GearCyclesSinceInspection");

            migrationBuilder.RenameColumn(
                name: "Last100Hr",
                table: "PiperArrows",
                newName: "HoursSinceLast100Hr");

            migrationBuilder.RenameColumn(
                name: "LastOilChange",
                table: "CessnaSkyhawks",
                newName: "HoursSinceLastOilChange");

            migrationBuilder.RenameColumn(
                name: "Last50Hr",
                table: "CessnaSkyhawks",
                newName: "HoursSinceLast50Hr");

            migrationBuilder.RenameColumn(
                name: "Last100Hr",
                table: "CessnaSkyhawks",
                newName: "HoursSinceLast100Hr");

            migrationBuilder.AddColumn<DateTime>(
                name: "CurrentFlightStart",
                table: "Aircraft",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentInstructor",
                table: "Aircraft",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CurrentStudent",
                table: "Aircraft",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "NextBookingEnd",
                table: "Aircraft",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextBookingStart",
                table: "Aircraft",
                type: "TEXT",
                nullable: true);
        }
    }
}
