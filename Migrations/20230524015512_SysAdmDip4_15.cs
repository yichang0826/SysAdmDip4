using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysAdmDip4.Migrations
{
    /// <inheritdoc />
    public partial class SysAdmDip4_15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MemberKnowlege",
                columns: table => new
                {
                    MemberKnowlege_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    KnowlegeId = table.Column<int>(type: "int", nullable: true),
                    MemberKnowlege_Characteristic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberKnowlege", x => x.MemberKnowlege_Id);
                    table.ForeignKey(
                        name: "FK_MemberKnowlege_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "Member_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MemberKnowlege_MemberId",
                table: "MemberKnowlege",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MemberKnowlege");
        }
    }
}
