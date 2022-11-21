using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeMeOutBE.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordBA : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "BusinessAccount",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "BusinessAccount");
        }
    }
}
