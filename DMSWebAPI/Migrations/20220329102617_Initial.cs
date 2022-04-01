using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DMSWebAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllergicSymptoms",
                columns: table => new
                {
                    AllergicSymptomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AllergyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllergicSymptoms", x => x.AllergicSymptomId);
                });

            migrationBuilder.CreateTable(
                name: "AntiAllergicDrugs",
                columns: table => new
                {
                    AntiAllergicDrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntiAllergicDrugs", x => x.AntiAllergicDrugId);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Drugs",
                columns: table => new
                {
                    DrugId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChemicalAnalysis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drugs", x => x.DrugId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOJ = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Designation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    userName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    PatientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.PatientId);
                });

            migrationBuilder.CreateTable(
                name: "ReactionAgents",
                columns: table => new
                {
                    ReactionAgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LongName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReactionAgents", x => x.ReactionAgentId);
                });

            migrationBuilder.CreateTable(
                name: "ConditionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AllergicSymptomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionDetails_AllergicSymptoms_AllergicSymptomId",
                        column: x => x.AllergicSymptomId,
                        principalTable: "AllergicSymptoms",
                        principalColumn: "AllergicSymptomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AntiAllergicDrugSymptoms",
                columns: table => new
                {
                    AntiAllergicDrugSymptomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AntiAllergicDrugId = table.Column<int>(type: "int", nullable: false),
                    AllergyName = table.Column<int>(type: "int", nullable: false),
                    AllergicSymptomId = table.Column<int>(type: "int", nullable: false),
                    SpecialDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntiAllergicDrugSymptoms", x => x.AntiAllergicDrugSymptomId);
                    table.ForeignKey(
                        name: "FK_AntiAllergicDrugSymptoms_AllergicSymptoms_AllergicSymptomId",
                        column: x => x.AllergicSymptomId,
                        principalTable: "AllergicSymptoms",
                        principalColumn: "AllergicSymptomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AntiAllergicDrugSymptoms_AntiAllergicDrugs_AntiAllergicDrugId",
                        column: x => x.AntiAllergicDrugId,
                        principalTable: "AntiAllergicDrugs",
                        principalColumn: "AntiAllergicDrugId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsageConditions",
                columns: table => new
                {
                    ConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugId1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsageConditions", x => x.ConditionId);
                    table.ForeignKey(
                        name: "FK_UsageConditions_Drugs_DrugId1",
                        column: x => x.DrugId1,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewDrugTrials",
                columns: table => new
                {
                    TrialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurposeOfTrial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DrugId = table.Column<int>(type: "int", nullable: false),
                    TrialResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrialStatus = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewDrugTrials", x => x.TrialId);
                    table.ForeignKey(
                        name: "FK_NewDrugTrials_Drugs_DrugId",
                        column: x => x.DrugId,
                        principalTable: "Drugs",
                        principalColumn: "DrugId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewDrugTrials_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewDrugTrials_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AntiAllergicDrugSymptoms_AllergicSymptomId",
                table: "AntiAllergicDrugSymptoms",
                column: "AllergicSymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_AntiAllergicDrugSymptoms_AntiAllergicDrugId",
                table: "AntiAllergicDrugSymptoms",
                column: "AntiAllergicDrugId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionDetails_AllergicSymptomId",
                table: "ConditionDetails",
                column: "AllergicSymptomId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDrugTrials_DrugId",
                table: "NewDrugTrials",
                column: "DrugId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDrugTrials_EmployeeId",
                table: "NewDrugTrials",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_NewDrugTrials_PatientId",
                table: "NewDrugTrials",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_UsageConditions_DrugId1",
                table: "UsageConditions",
                column: "DrugId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AntiAllergicDrugSymptoms");

            migrationBuilder.DropTable(
                name: "ConditionDetails");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "NewDrugTrials");

            migrationBuilder.DropTable(
                name: "ReactionAgents");

            migrationBuilder.DropTable(
                name: "UsageConditions");

            migrationBuilder.DropTable(
                name: "AntiAllergicDrugs");

            migrationBuilder.DropTable(
                name: "AllergicSymptoms");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Drugs");
        }
    }
}
