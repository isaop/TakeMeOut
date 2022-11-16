using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeMeOut.Migrations
{
    /// <inheritdoc />
    public partial class AddPassword2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Business_Account",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Business_Account");
        }
    }
}
