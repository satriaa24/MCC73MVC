using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCC73MVC.Migrations
{
    /// <inheritdoc />
    public partial class erd1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_m_division",
                columns: table => new
                {
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_division", x => x.DivisionId);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_department", x => x.DepartmentId);
                    table.ForeignKey(
                        name: "FK_tb_m_department_tb_m_division_DivisionId",
                        column: x => x.DivisionId,
                        principalTable: "tb_m_division",
                        principalColumn: "DivisionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_employee",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_employee", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_employee_tb_m_department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "tb_m_department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_m_account",
                columns: table => new
                {
                    NIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_m_account", x => x.NIK);
                    table.ForeignKey(
                        name: "FK_tb_m_account_tb_m_employee_NIK",
                        column: x => x.NIK,
                        principalTable: "tb_m_employee",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_r_account_role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNIK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_r_account_role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tb_r_account_role_tb_m_account_AccountNIK",
                        column: x => x.AccountNIK,
                        principalTable: "tb_m_account",
                        principalColumn: "NIK",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_r_account_role_tb_m_role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "tb_m_role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_department_DivisionId",
                table: "tb_m_department",
                column: "DivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_employee_DepartmentId",
                table: "tb_m_employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_r_account_role_AccountNIK",
                table: "tb_r_account_role",
                column: "AccountNIK");

            migrationBuilder.CreateIndex(
                name: "IX_tb_r_account_role_RoleId",
                table: "tb_r_account_role",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_r_account_role");

            migrationBuilder.DropTable(
                name: "tb_m_account");

            migrationBuilder.DropTable(
                name: "tb_m_role");

            migrationBuilder.DropTable(
                name: "tb_m_employee");

            migrationBuilder.DropTable(
                name: "tb_m_department");

            migrationBuilder.DropTable(
                name: "tb_m_division");
        }
    }
}
