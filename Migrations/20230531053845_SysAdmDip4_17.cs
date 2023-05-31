using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysAdmDip4.Migrations
{
    /// <inheritdoc />
    public partial class SysAdmDip4_17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Knowlege_ViewCount",
                table: "Knowlege",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Link_CreateDate",
                table: "ExternalLink",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Knowlege_ViewCount",
                table: "Knowlege");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Link_CreateDate",
                table: "ExternalLink",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
