using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace futebol.Migrations
{
    /// <inheritdoc />
    public partial class team : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "team");

            migrationBuilder.AddPrimaryKey(
                name: "PK_team",
                table: "team",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_team",
                table: "team");

            migrationBuilder.RenameTable(
                name: "team",
                newName: "Teams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");
        }
    }
}
