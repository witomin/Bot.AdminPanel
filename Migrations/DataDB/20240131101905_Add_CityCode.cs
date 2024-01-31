using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bot.AdminPanel.Migrations.DataDB
{
    /// <inheritdoc />
    public partial class Add_CityCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CityCode",
                table: "Subscribers",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityCode",
                table: "Subscribers");
        }
    }
}
