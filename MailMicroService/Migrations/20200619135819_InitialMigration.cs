using Microsoft.EntityFrameworkCore.Migrations;

namespace MailMicroService.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailServer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerType = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Host = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailServer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailServer");
        }
    }
}
