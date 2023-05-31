using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSubscriptionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SubscriptionStatus",
                table: "Subscriptions",
                newName: "SubscriptionAmount");

            migrationBuilder.AddColumn<string>(
                name: "SubscribeStatus",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionEndDate",
                table: "Subscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SubscriptionStartDate",
                table: "Subscriptions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubscribeStatus",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionEndDate",
                table: "Subscriptions");

            migrationBuilder.DropColumn(
                name: "SubscriptionStartDate",
                table: "Subscriptions");

            migrationBuilder.RenameColumn(
                name: "SubscriptionAmount",
                table: "Subscriptions",
                newName: "SubscriptionStatus");
        }
    }
}
