using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bot.AdminPanel.Migrations.DataDB
{
    /// <inheritdoc />
    public partial class Edit_TelegramUpdates_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TelegramUpdateId",
                table: "TelegramUpdates");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "TelegramUpdates");

            migrationBuilder.RenameColumn(
                name: "MessageContent",
                table: "TelegramUpdates",
                newName: "Update");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Update",
                table: "TelegramUpdates",
                newName: "MessageContent");

            migrationBuilder.AddColumn<int>(
                name: "TelegramUpdateId",
                table: "TelegramUpdates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "TelegramUpdates",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
