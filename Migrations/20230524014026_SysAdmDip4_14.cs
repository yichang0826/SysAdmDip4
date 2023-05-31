using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysAdmDip4.Migrations
{
    /// <inheritdoc />
    public partial class SysAdmDip4_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Knowlege",
                columns: table => new
                {
                    Knowlege_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Knowlege_Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Knowlege_Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Knowlege_Introduction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Knowlege_Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Knowlege_FileSrc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Knowlege_Transparency = table.Column<int>(type: "int", nullable: false),
                    Knowlege_CreaterId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Knowlege_CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowlege", x => x.Knowlege_Id);
                });

            migrationBuilder.CreateTable(
                name: "Classify",
                columns: table => new
                {
                    Classify_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classify_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Knowlege_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classify", x => x.Classify_Id);
                    table.ForeignKey(
                        name: "FK_Classify_Knowlege_Knowlege_Id",
                        column: x => x.Knowlege_Id,
                        principalTable: "Knowlege",
                        principalColumn: "Knowlege_Id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Comment_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment_AuthorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment_Characteristic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comment_Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Knowlege_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Comment_Id);
                    table.ForeignKey(
                        name: "FK_Comment_Knowlege_Knowlege_Id",
                        column: x => x.Knowlege_Id,
                        principalTable: "Knowlege",
                        principalColumn: "Knowlege_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classify_Knowlege_Id",
                table: "Classify",
                column: "Knowlege_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Knowlege_Id",
                table: "Comment",
                column: "Knowlege_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Classify");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Knowlege");
        }
    }
}
