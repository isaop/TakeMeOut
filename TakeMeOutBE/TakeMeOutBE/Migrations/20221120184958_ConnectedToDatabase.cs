using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeMeOutBE.Migrations
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
                    description = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__79D361B6C333322B", x => x.idCategory);
                });

            migrationBuilder.CreateTable(
                name: "EventStatus",
                columns: table => new
                {
                    idEventStatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventSta__8BA84D2113D948A2", x => x.idEventStatus);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3717C982F140C6B3", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    idVenue = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    uniqueIden = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    contactNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    description = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venue__077D5E69C89A79A3", x => x.idVenue);
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
                    table.PrimaryKey("PK__Payment__F22D4A455175E55E", x => x.idPayment);
                    table.ForeignKey(
                        name: "FK__Payment__idUser__34C8D9D1",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "BusinessAccount",
                columns: table => new
                {
                    idBA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    contactNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    idVenue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Business__9DB8DE821DC1CC20", x => x.idBA);
                    table.ForeignKey(
                        name: "FK__BusinessA__idVen__29572725",
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
                    idEventStatus = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<TimeSpan>(type: "time", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idBA = table.Column<int>(type: "int", nullable: true),
                    idCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event__B7EA7D7610802020", x => x.idEvent);
                    table.ForeignKey(
                        name: "FK__Event__idBA__3B75D760",
                        column: x => x.idBA,
                        principalTable: "BusinessAccount",
                        principalColumn: "idBA");
                    table.ForeignKey(
                        name: "FK__Event__idCategor__3C69FB99",
                        column: x => x.idCategory,
                        principalTable: "Category",
                        principalColumn: "idCategory");
                    table.ForeignKey(
                        name: "FK__Event__idEventSt__398D8EEE",
                        column: x => x.idEventStatus,
                        principalTable: "EventStatus",
                        principalColumn: "idEventStatus");
                    table.ForeignKey(
                        name: "FK__Event__idUser__3A81B327",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser");
                    table.ForeignKey(
                        name: "FK__Event__idVenue__38996AB5",
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
                    table.PrimaryKey("PK__Order__C8AAF6FF94A636C9", x => x.idOrder);
                    table.ForeignKey(
                        name: "FK__Order__idEvent__48CFD27E",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__Order__idUser__47DBAE45",
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
                    comment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Review__04F7FE1049D2A0B7", x => x.idReview);
                    table.ForeignKey(
                        name: "FK__Review__idEvent__3F466844",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__Review__idPaymen__412EB0B6",
                        column: x => x.idPayment,
                        principalTable: "Payment",
                        principalColumn: "idPayment");
                    table.ForeignKey(
                        name: "FK__Review__idUser__403A8C7D",
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
                    description = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    idEvent = table.Column<int>(type: "int", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__userActi__7AE31280C8489D16", x => x.idUserAction);
                    table.ForeignKey(
                        name: "FK__userActio__idEve__440B1D61",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__userActio__idUse__44FF419A",
                        column: x => x.idUser,
                        principalTable: "User",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusinessAccount_idVenue",
                table: "BusinessAccount",
                column: "idVenue");

            migrationBuilder.CreateIndex(
                name: "UQ__Business__72E12F1B2D4BF3CD",
                table: "BusinessAccount",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Business__AB6E6164DDECB8BD",
                table: "BusinessAccount",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idBA",
                table: "Event",
                column: "idBA");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idCategory",
                table: "Event",
                column: "idCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idEventStatus",
                table: "Event",
                column: "idEventStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idUser",
                table: "Event",
                column: "idUser");

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
                name: "UQ__User__AB6E6164986D442F",
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
                name: "BusinessAccount");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "EventStatus");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Venue");
        }
    }
}
