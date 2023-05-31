using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyToSubscriptionForBlog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "Subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_BlogId",
                table: "Subscriptions",
                column: "BlogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscriptions_BlogsTable_BlogId",
                table: "Subscriptions",
                column: "BlogId",
                principalTable: "BlogsTable",
                principalColumn: "BlogId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscriptions_BlogsTable_BlogId",
                table: "Subscriptions");

            migrationBuilder.DropIndex(
                name: "IX_Subscriptions_BlogId",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "Subscriptions");
        }
    }
}
