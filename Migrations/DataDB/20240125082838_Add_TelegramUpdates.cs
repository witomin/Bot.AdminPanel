using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bot.AdminPanel.Migrations.DataDB
{
    /// <inheritdoc />
    public partial class Add_TelegramUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TelegramUpdates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ReceivedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TelegramUpdateId = table.Column<int>(type: "int", nullable: false),
                    MessageContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramUpdates", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TelegramUpdates");
        }
    }
}
