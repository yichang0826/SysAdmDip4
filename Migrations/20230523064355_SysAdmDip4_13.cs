using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysAdmDip4.Migrations
{
    /// <inheritdoc />
    public partial class SysAdmDip4_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    Function_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Function_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function_Controller = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function_Page = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function_Describe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Function_Active = table.Column<int>(type: "int", nullable: false),
                    Function_CreaterId = table.Column<int>(type: "int", nullable: false),
                    Function_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.Function_Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Member_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Member_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Member_Account = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Member_Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Member_Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Member_RoleId = table.Column<int>(type: "int", nullable: false),
                    Member_Active = table.Column<int>(type: "int", nullable: false),
                    Member_CreaterId = table.Column<int>(type: "int", nullable: false),
                    Member_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.Member_Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Role_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_Describe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role_FunctionIdCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleFunction",
                columns: table => new
                {
                    RoleFunction_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FunctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleFunction", x => x.RoleFunction_Id);
                    table.ForeignKey(
                        name: "FK_RoleFunction_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleFunction_RoleId",
                table: "RoleFunction",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "RoleFunction");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
