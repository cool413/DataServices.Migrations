using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataServices.Migrations.Migrations
{
    public partial class Test : Migration
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
                name: "Job",
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
                    table.PrimaryKey("PK_Job", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Job_Confirmation_ConfirmationCode",
                        column: x => x.ConfirmationCode,
                        principalTable: "Confirmation",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Job_CRMProgram_CRMProgramCode_ConfirmationCode",
                        columns: x => new { x.CRMProgramCode, x.ConfirmationCode },
                        principalTable: "CRMProgram",
                        principalColumns: new[] { "Code", "ConfirmationCode" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Job_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Company",
                columns: new[] { "Id", "Code", "CreatedDate", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "0340", new DateTime(2020, 7, 7, 1, 54, 38, 262, DateTimeKind.Local).AddTicks(9248), new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(458), "東洋" },
                    { 2, "0322", new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(1145), new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(1164), "訊聯" },
                    { 3, "0217", new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(1173), new DateTime(2020, 7, 7, 1, 54, 38, 264, DateTimeKind.Local).AddTicks(1175), "雲門" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "CreatedDate", "ModifiedDate", "Name", "Type" },
                values: new object[,]
                {
                    { "09846", new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8700), new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8708), "Derek", "PR" },
                    { "07056", new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8759), new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8760), "Young", "PR" },
                    { "05438", new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8763), new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(8764), "Carter", "SD" }
                });

            migrationBuilder.InsertData(
                table: "Confirmation",
                columns: new[] { "Code", "CompanyId", "CreatedDate", "ModifiedDate", "SystemVersion" },
                values: new object[] { "0000128773_CRM_0001", 1, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3750), new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3761), "91" });

            migrationBuilder.InsertData(
                table: "Confirmation",
                columns: new[] { "Code", "CompanyId", "CreatedDate", "ModifiedDate", "SystemVersion" },
                values: new object[] { "0000670228_CRM_0002", 2, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3861), new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3866), "91" });

            migrationBuilder.InsertData(
                table: "Confirmation",
                columns: new[] { "Code", "CompanyId", "CreatedDate", "ModifiedDate", "SystemVersion" },
                values: new object[] { "0000129312_CRM_0003", 3, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3868), new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(3869), "91" });

            migrationBuilder.InsertData(
                table: "CRMProgram",
                columns: new[] { "Code", "ConfirmationCode", "CompanyId", "CreatedDate", "EmployeeId", "Hours", "ModifiedDate", "Name" },
                values: new object[] { "SALMI21", "0000128773_CRM_0001", 1, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(6892), "09846", 10m, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(6903), "工作紀錄" });

            migrationBuilder.InsertData(
                table: "CRMProgram",
                columns: new[] { "Code", "ConfirmationCode", "CompanyId", "CreatedDate", "EmployeeId", "Hours", "ModifiedDate", "Name" },
                values: new object[] { "SALMI30", "0000670228_CRM_0002", 2, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(7041), "05438", 20m, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(7044), "報價單" });

            migrationBuilder.InsertData(
                table: "CRMProgram",
                columns: new[] { "Code", "ConfirmationCode", "CompanyId", "CreatedDate", "EmployeeId", "Hours", "ModifiedDate", "Name" },
                values: new object[] { "REPMI13", "0000129312_CRM_0003", 3, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(7049), "07056", 30m, new DateTime(2020, 7, 7, 1, 54, 38, 265, DateTimeKind.Local).AddTicks(7051), "維修單" });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "CRMProgramCode", "ConfirmationCode", "CreatedDate", "EmployeeId", "EndDate", "Hours", "ModifiedDate", "Priority", "StarDate", "Status", "Tag" },
                values: new object[] { 1, "SALMI21", "0000128773_CRM_0001", new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2008), "09846", "20200630", 10m, new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2016), "2", "20200621", "0", "" });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "CRMProgramCode", "ConfirmationCode", "CreatedDate", "EmployeeId", "EndDate", "Hours", "ModifiedDate", "Priority", "StarDate", "Status", "Tag" },
                values: new object[] { 2, "SALMI30", "0000670228_CRM_0002", new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2096), "05438", "20200830", 20m, new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2097), "2", "20200721", "0", "" });

            migrationBuilder.InsertData(
                table: "Job",
                columns: new[] { "Id", "CRMProgramCode", "ConfirmationCode", "CreatedDate", "EmployeeId", "EndDate", "Hours", "ModifiedDate", "Priority", "StarDate", "Status", "Tag" },
                values: new object[] { 3, "REPMI13", "0000129312_CRM_0003", new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2100), "07056", "20201030", 30m, new DateTime(2020, 7, 7, 1, 54, 38, 266, DateTimeKind.Local).AddTicks(2101), "2", "20200921", "0", "" });

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
                name: "IX_Job_ConfirmationCode",
                table: "Job",
                column: "ConfirmationCode");

            migrationBuilder.CreateIndex(
                name: "IX_Job_CRMProgramCode_ConfirmationCode",
                table: "Job",
                columns: new[] { "CRMProgramCode", "ConfirmationCode" });

            migrationBuilder.CreateIndex(
                name: "IX_Job_EmployeeId",
                table: "Job",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Job");

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
