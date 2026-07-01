using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirTrack.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddSquawkResolutionFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectiveActions");

            migrationBuilder.DropTable(
                name: "MechanicSignoffs");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Squawks");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Aircraft");

            migrationBuilder.AddColumn<string>(
                name: "MechanicSignoff",
                table: "Squawks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResolutionNotes",
                table: "Squawks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResolvedAt",
                table: "Squawks",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MechanicSignoff",
                table: "Squawks");

            migrationBuilder.DropColumn(
                name: "ResolutionNotes",
                table: "Squawks");

            migrationBuilder.DropColumn(
                name: "ResolvedAt",
                table: "Squawks");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Squawks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Aircraft",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssignedMechanicId = table.Column<int>(type: "INTEGER", nullable: true),
                    SquawkId = table.Column<int>(type: "INTEGER", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Mechanics_AssignedMechanicId",
                        column: x => x.AssignedMechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrders_Squawks_SquawkId",
                        column: x => x.SquawkId,
                        principalTable: "Squawks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MechanicId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecurringADId = table.Column<int>(type: "INTEGER", nullable: true),
                    WorkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionDescription = table.Column<string>(type: "TEXT", nullable: false),
                    LaborHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    PartsUsed = table.Column<string>(type: "TEXT", nullable: false),
                    PerformedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorrectiveActions_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorrectiveActions_RecurringADs_RecurringADId",
                        column: x => x.RecurringADId,
                        principalTable: "RecurringADs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CorrectiveActions_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MechanicSignoffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MechanicId = table.Column<int>(type: "INTEGER", nullable: false),
                    WorkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    CertificateNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SignedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SignoffText = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MechanicSignoffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MechanicSignoffs_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MechanicSignoffs_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_MechanicId",
                table: "CorrectiveActions",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_RecurringADId",
                table: "CorrectiveActions",
                column: "RecurringADId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectiveActions_WorkOrderId",
                table: "CorrectiveActions",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicSignoffs_MechanicId",
                table: "MechanicSignoffs",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_MechanicSignoffs_WorkOrderId",
                table: "MechanicSignoffs",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AssignedMechanicId",
                table: "WorkOrders",
                column: "AssignedMechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_SquawkId",
                table: "WorkOrders",
                column: "SquawkId",
                unique: true);
        }
    }
}
