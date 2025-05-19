using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentModule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GroupNumberFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
           name: "GroupNumberInt",
           table: "Groups",
           nullable: false,
           defaultValue: 0);

            migrationBuilder.Sql(@"
            UPDATE ""Groups""
            SET ""GroupNumberInt"" = CAST(""GroupNumber"" AS integer)
            WHERE ""GroupNumber"" ~ '^[0-9]+$'");

            migrationBuilder.DropColumn(
                name: "GroupNumber",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "GroupNumberInt",
                table: "Groups",
                newName: "GroupNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
            name: "GroupNumberStr",
            table: "Groups",
            type: "text",
            nullable: false,
            defaultValue: "0");

            migrationBuilder.Sql(@"
            UPDATE ""Groups""
            SET ""GroupNumberStr"" = CAST(""GroupNumber"" AS text)");

            migrationBuilder.DropColumn(
                name: "GroupNumber",
                table: "Groups");

            migrationBuilder.RenameColumn(
                name: "GroupNumberStr",
                table: "Groups",
                newName: "GroupNumber");

        }
    }
}
