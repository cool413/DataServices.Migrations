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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "varchar(10)", nullable: false),
                    Code = table.Column<string>(type: "varchar(4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(5)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "varchar(10)", nullable: false),
                    Type = table.Column<string>(type: "char(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Confirmation",
                columns: table => new
                {
                    Code = table.Column<string>(type: "varchar(30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SystemVersion = table.Column<string>(type: "char(2)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmation", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Confirmation_Company_CompanyId",
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
                    ConfirmationCode = table.Column<string>(type: "varchar(30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "varchar(10)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "varchar(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CRMProgram", x => new { x.Code, x.ConfirmationCode });
                    table.ForeignKey(
                        name: "FK_CRMProgram_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CRMProgram_Confirmation_ConfirmationCode",
                        column: x => x.ConfirmationCode,
                        principalTable: "Confirmation",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
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
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tag = table.Column<string>(type: "varchar(20)", nullable: false),
                    Priority = table.Column<string>(type: "char(1)", nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: false),
                    Hours = table.Column<decimal>(type: "decimal(4,1)", nullable: false),
                    StarDate = table.Column<string>(type: "char(8)", nullable: false),
                    EndDate = table.Column<string>(type: "char(8)", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "varchar(30)", nullable: false),
                    CRMProgramCode = table.Column<string>(type: "varchar(10)", nullable: true),
                    EmployeeId = table.Column<string>(type: "varchar(5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Confirmation_ConfirmationCode",
                        column: x => x.ConfirmationCode,
                        principalTable: "Confirmation",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Task_CRMProgram_CRMProgramCode_ConfirmationCode",
                        columns: x => new { x.CRMProgramCode, x.ConfirmationCode },
                        principalTable: "CRMProgram",
                        principalColumns: new[] { "Code", "ConfirmationCode" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Task_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Confirmation_CompanyId",
                table: "Confirmation",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CRMProgram_CompanyId",
                table: "CRMProgram",
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
                name: "IX_Task_CRMProgramCode_ConfirmationCode",
                table: "Task",
                columns: new[] { "CRMProgramCode", "ConfirmationCode" });

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
                name: "Confirmation");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
