using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddedBAToUserRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshToken");
            migrationBuilder.CreateTable(
                name: "UserRefreshToken",
                columns: table => new
                {
                    IDUserRefreshToken = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefreshToken = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    IDUser = table.Column<int>(type: "int", nullable: true),
                    IDBusinessAccount = table.Column<int>(type: "int", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshToken", x => x.IDUserRefreshToken);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_BusinessAccount_IDBusinessAccount",
                        column: x => x.IDBusinessAccount,
                        principalTable: "BusinessAccount",
                        principalColumn: "IdBusinessAccount",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_User_IDUser",
                        column: x => x.IDUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshToken_IDBusinessAccount",
                table: "UserRefreshToken",
                column: "IDBusinessAccount");

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshToken_IDUser",
                table: "UserRefreshToken",
                column: "IDUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshToken");
        }
    }
}
