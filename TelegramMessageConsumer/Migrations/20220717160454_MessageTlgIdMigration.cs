using Microsoft.EntityFrameworkCore.Migrations;

namespace TelegramMessageConsumer.Migrations
{
    public partial class MessageTlgIdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TlgId",
                table: "Messages",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TlgId",
                table: "Messages");
        }
    }
}
