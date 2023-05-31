using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUsersAndBlogTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UsersTable",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BlogsTable",
                newName: "BlogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UsersTable",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "BlogsTable",
                newName: "Id");
        }
    }
}
