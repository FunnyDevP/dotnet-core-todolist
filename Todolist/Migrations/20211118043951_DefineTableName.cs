using Microsoft.EntityFrameworkCore.Migrations;

namespace Todolist.Migrations
{
    public partial class DefineTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists");

            migrationBuilder.RenameTable(
                name: "TodoLists",
                newName: "todolists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_todolists",
                table: "todolists",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_todolists",
                table: "todolists");

            migrationBuilder.RenameTable(
                name: "todolists",
                newName: "TodoLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TodoLists",
                table: "TodoLists",
                column: "Id");
        }
    }
}
