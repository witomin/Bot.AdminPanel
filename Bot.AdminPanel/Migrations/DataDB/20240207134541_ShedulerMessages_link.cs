using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bot.AdminPanel.Migrations.DataDB
{
    /// <inheritdoc />
    public partial class ShedulerMessages_link : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ScheduledMessages",
                newName: "SubscriberId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledMessages_SubscriberId",
                table: "ScheduledMessages",
                column: "SubscriberId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledMessages_Subscribers_SubscriberId",
                table: "ScheduledMessages",
                column: "SubscriberId",
                principalTable: "Subscribers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledMessages_Subscribers_SubscriberId",
                table: "ScheduledMessages");

            migrationBuilder.DropIndex(
                name: "IX_ScheduledMessages_SubscriberId",
                table: "ScheduledMessages");

            migrationBuilder.RenameColumn(
                name: "SubscriberId",
                table: "ScheduledMessages",
                newName: "UserId");
        }
    }
}
