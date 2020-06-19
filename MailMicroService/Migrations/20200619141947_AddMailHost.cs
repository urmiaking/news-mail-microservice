using Microsoft.EntityFrameworkCore.Migrations;

namespace MailMicroService.Migrations
{
    public partial class AddMailHost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MailServer",
                columns: new[] { "Id", "Email", "Host", "Password", "Port", "ServerType" },
                values: new object[] { 1, "masoud.xpress@gmail.com", "smtp.gmail.com", "MASOUD7559", 587, "gmail" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MailServer",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
