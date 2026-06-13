using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirTrack.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aircraft",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TailNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Hobbs = table.Column<decimal>(type: "TEXT", nullable: false),
                    Tach = table.Column<decimal>(type: "TEXT", nullable: false),
                    AnnualDueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SquawkCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentStudent = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentInstructor = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentFlightStart = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NextBookingStart = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NextBookingEnd = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aircraft", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Instructors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Certifications = table.Column<string>(type: "TEXT", nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    CertificationNumber = table.Column<string>(type: "TEXT", nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CessnaSkyhawks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HoursSinceLastOilChange = table.Column<decimal>(type: "TEXT", nullable: false),
                    HoursSinceLast50Hr = table.Column<decimal>(type: "TEXT", nullable: false),
                    HoursSinceLast100Hr = table.Column<decimal>(type: "TEXT", nullable: false),
                    ELTInspectionDue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TransponderDue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PitotStaticDue = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CessnaSkyhawks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CessnaSkyhawks_Aircraft_Id",
                        column: x => x.Id,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PiperArrows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HoursSinceLastOilChange = table.Column<decimal>(type: "TEXT", nullable: false),
                    HoursSinceLast100Hr = table.Column<decimal>(type: "TEXT", nullable: false),
                    GearCyclesSinceInspection = table.Column<int>(type: "INTEGER", nullable: false),
                    PropOverhaulDue = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiperArrows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PiperArrows_Aircraft_Id",
                        column: x => x.Id,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PiperSeminoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LeftEngineHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    RightEngineHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    LeftPropOverhaulDue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RightPropOverhaulDue = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GearCyclesSinceInspection = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PiperSeminoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PiperSeminoles_Aircraft_Id",
                        column: x => x.Id,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RobinsonR44s",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HoursSince2200HrOverhaul = table.Column<decimal>(type: "TEXT", nullable: false),
                    BladeLifeRemaining = table.Column<decimal>(type: "TEXT", nullable: false),
                    ClutchActuationCount = table.Column<int>(type: "INTEGER", nullable: false),
                    GovernorInspectionDue = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RobinsonR44s", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RobinsonR44s_Aircraft_Id",
                        column: x => x.Id,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Squawks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AircraftId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ReportedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsGrounding = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Squawks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Squawks_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedInstructorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Instructors_AssignedInstructorId",
                        column: x => x.AssignedInstructorId,
                        principalTable: "Instructors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RecurringADs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ADNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IntervalHours = table.Column<decimal>(type: "TEXT", nullable: false),
                    LastCompliedWith = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AircraftId = table.Column<int>(type: "INTEGER", nullable: false),
                    CessnaSkyhawkId = table.Column<int>(type: "INTEGER", nullable: true),
                    PiperArrowId = table.Column<int>(type: "INTEGER", nullable: true),
                    PiperSeminoleId = table.Column<int>(type: "INTEGER", nullable: true),
                    RobinsonR44Id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecurringADs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecurringADs_Aircraft_AircraftId",
                        column: x => x.AircraftId,
                        principalTable: "Aircraft",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecurringADs_CessnaSkyhawks_CessnaSkyhawkId",
                        column: x => x.CessnaSkyhawkId,
                        principalTable: "CessnaSkyhawks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringADs_PiperArrows_PiperArrowId",
                        column: x => x.PiperArrowId,
                        principalTable: "PiperArrows",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringADs_PiperSeminoles_PiperSeminoleId",
                        column: x => x.PiperSeminoleId,
                        principalTable: "PiperSeminoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RecurringADs_RobinsonR44s_RobinsonR44Id",
                        column: x => x.RobinsonR44Id,
                        principalTable: "RobinsonR44s",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SquawkId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedMechanicId = table.Column<int>(type: "INTEGER", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
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
                    WorkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    MechanicId = table.Column<int>(type: "INTEGER", nullable: false),
                    ActionDescription = table.Column<string>(type: "TEXT", nullable: false),
                    PartsUsed = table.Column<string>(type: "TEXT", nullable: false),
                    RecurringADId = table.Column<int>(type: "INTEGER", nullable: true),
                    LaborHours = table.Column<decimal>(type: "TEXT", nullable: false),
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
                    WorkOrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    MechanicId = table.Column<int>(type: "INTEGER", nullable: false),
                    SignoffText = table.Column<string>(type: "TEXT", nullable: false),
                    SignedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CertificateNumber = table.Column<string>(type: "TEXT", nullable: false)
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
                name: "IX_RecurringADs_AircraftId",
                table: "RecurringADs",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringADs_CessnaSkyhawkId",
                table: "RecurringADs",
                column: "CessnaSkyhawkId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringADs_PiperArrowId",
                table: "RecurringADs",
                column: "PiperArrowId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringADs_PiperSeminoleId",
                table: "RecurringADs",
                column: "PiperSeminoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RecurringADs_RobinsonR44Id",
                table: "RecurringADs",
                column: "RobinsonR44Id");

            migrationBuilder.CreateIndex(
                name: "IX_Squawks_AircraftId",
                table: "Squawks",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AssignedInstructorId",
                table: "Students",
                column: "AssignedInstructorId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorrectiveActions");

            migrationBuilder.DropTable(
                name: "MechanicSignoffs");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "RecurringADs");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Instructors");

            migrationBuilder.DropTable(
                name: "CessnaSkyhawks");

            migrationBuilder.DropTable(
                name: "PiperArrows");

            migrationBuilder.DropTable(
                name: "PiperSeminoles");

            migrationBuilder.DropTable(
                name: "RobinsonR44s");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "Squawks");

            migrationBuilder.DropTable(
                name: "Aircraft");
        }
    }
}
