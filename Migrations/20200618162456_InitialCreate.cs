using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServices.Migrations.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(10)", nullable: false),
                    Code = table.Column<string>(type: "varchar(4)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModiDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(10)", nullable: false),
                    Type = table.Column<string>(type: "varchar(2)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModiDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Confirmations",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SystemVersion = table.Column<string>(type: "varchar(10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModiDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmations", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Confirmations_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CRMProgram",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(10)", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "varchar(10)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModiDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRMProgram", x => new { x.Code, x.ConfirmationCode });
                    table.ForeignKey(
                        name: "FK_CRMProgram_Confirmations_ConfirmationCode",
                        column: x => x.ConfirmationCode,
                        principalTable: "Confirmations",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CRMProgram_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tag = table.Column<string>(type: "varchar(20)", nullable: true),
                    Priority = table.Column<string>(type: "varchar(1)", nullable: false),
                    Status = table.Column<string>(type: "varchar(1)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    StarDate = table.Column<string>(type: "varchar(8)", nullable: false),
                    EndDate = table.Column<string>(type: "varchar(8)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModiDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CRMProgramCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CRMProgramCode1 = table.Column<string>(type: "varchar(10)", nullable: true),
                    CRMProgramConfirmationCode = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Confirmations_ConfirmationCode",
                        column: x => x.ConfirmationCode,
                        principalTable: "Confirmations",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_CRMProgram_CRMProgramCode1_CRMProgramConfirmationCode",
                        columns: x => new { x.CRMProgramCode1, x.CRMProgramConfirmationCode },
                        principalTable: "CRMProgram",
                        principalColumns: new[] { "Code", "ConfirmationCode" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confirmations_CompanyId",
                table: "Confirmations",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CRMProgram_ConfirmationCode",
                table: "CRMProgram",
                column: "ConfirmationCode");

            migrationBuilder.CreateIndex(
                name: "IX_CRMProgram_EmployeeId",
                table: "CRMProgram",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_ConfirmationCode",
                table: "Task",
                column: "ConfirmationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Task_CRMProgramCode1_CRMProgramConfirmationCode",
                table: "Task",
                columns: new[] { "CRMProgramCode1", "CRMProgramConfirmationCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Task_EmployeeId",
                table: "Task",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "CRMProgram");

            migrationBuilder.DropTable(
                name: "Confirmations");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
