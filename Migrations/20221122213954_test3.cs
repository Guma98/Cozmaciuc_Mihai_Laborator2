using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cozmaciuc_Mihai_Laborator2.Migrations
{
    public partial class test3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthorFirstName",
                table: "Author");

            migrationBuilder.RenameColumn(
                name: "AuthorLastName",
                table: "Author",
                newName: "AuthorName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Author",
                newName: "AuthorLastName");

            migrationBuilder.AddColumn<string>(
                name: "AuthorFirstName",
                table: "Author",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
