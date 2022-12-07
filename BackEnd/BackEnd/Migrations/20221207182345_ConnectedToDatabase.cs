using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class ConnectedToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    idCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__79D361B6D4F47176", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3717C9822D17B98F", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    idVenue = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    contactNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    description = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venue__077D5E69913A4F54", x => x.idVenue);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    idPayment = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payment__F22D4A4593E65ED4", x => x.idPayment);
                    table.ForeignKey(
                        name: "FK__Payment__idUser__68487DD7",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "BusinessAccount",
                columns: table => new
                {
                    idBusinessAccount = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    description = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    contactNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    idVenue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Business__56FB16FB1C8630AA", x => x.idBusinessAccount);
                    table.ForeignKey(
                        name: "FK__BusinessA__idVen__5FB337D6",
                        column: x => x.idVenue,
                        principalTable: "Venue",
                        principalColumn: "idVenue");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    idEvent = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    eventName = table.Column<string>(type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    idVenue = table.Column<int>(type: "int", nullable: false),
                    time = table.Column<TimeSpan>(type: "time", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    description = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true),
                    idBusinessAccount = table.Column<int>(type: "int", nullable: false),
                    idCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event__B7EA7D76162FB28D", x => x.idEvent);
                    table.ForeignKey(
                        name: "FK__Event__idBusines__6D0D32F4",
                        column: x => x.idBusinessAccount,
                        principalTable: "BusinessAccount",
                        principalColumn: "idBusinessAccount");
                    table.ForeignKey(
                        name: "FK__Event__idCategor__6E01572D",
                        column: x => x.idCategory,
                        principalTable: "Category",
                        principalColumn: "idCategory");
                    table.ForeignKey(
                        name: "FK__Event__idVenue__6C190EBB",
                        column: x => x.idVenue,
                        principalTable: "Venue",
                        principalColumn: "idVenue");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    idOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idEvent = table.Column<int>(type: "int", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Order__C8AAF6FF8AC0F47A", x => x.idOrder);
                    table.ForeignKey(
                        name: "FK__Order__idEvent__7A672E12",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__Order__idUser__797309D9",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    idReview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idEvent = table.Column<int>(type: "int", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idPayment = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "varchar(2500)", unicode: false, maxLength: 2500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review__04F7FE1095A9FA06", x => x.idReview);
                    table.ForeignKey(
                        name: "FK__Review__idEvent__70DDC3D8",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__Review__idPaymen__72C60C4A",
                        column: x => x.idPayment,
                        principalTable: "Payment",
                        principalColumn: "idPayment");
                    table.ForeignKey(
                        name: "FK__Review__idUser__71D1E811",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "userAction",
                columns: table => new
                {
                    idUserAction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    actionName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    idEvent = table.Column<int>(type: "int", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__userActi__7AE3128011D36028", x => x.idUserAction);
                    table.ForeignKey(
                        name: "FK__userActio__idEve__75A278F5",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__userActio__idUse__76969D2E",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAccount_idVenue",
                table: "BusinessAccount",
                column: "idVenue");

            migrationBuilder.CreateIndex(
                name: "UQ__Business__72E12F1B1A9C9650",
                table: "BusinessAccount",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Business__AB6E616401B4AC9E",
                table: "BusinessAccount",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idBusinessAccount",
                table: "Event",
                column: "idBusinessAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idCategory",
                table: "Event",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idVenue",
                table: "Event",
                column: "idVenue");

            migrationBuilder.CreateIndex(
                name: "IX_Order_idEvent",
                table: "Order",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Order_idUser",
                table: "Order",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_idUser",
                table: "Payment",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Review_idEvent",
                table: "Review",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Review_idPayment",
                table: "Review",
                column: "idPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Review_idUser",
                table: "Review",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "UQ__User__72E12F1B653C9BF8",
                table: "User",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__User__AB6E61649F9DA34A",
                table: "User",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_userAction_idEvent",
                table: "userAction",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_userAction_idUser",
                table: "userAction",
                column: "idUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "userAction");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "BusinessAccount");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Venue");
        }
    }
}
