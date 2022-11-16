using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TakeMeOut.Migrations
{
    /// <inheritdoc />
    public partial class AddPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    idCat = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__398E4045C9ECC572", x => x.idCat);
                });

            migrationBuilder.CreateTable(
                name: "Event_Status",
                columns: table => new
                {
                    idEstat = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event_St__6214BC210DE7C9D3", x => x.idEstat);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    idUser = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    phoneNo = table.Column<float>(name: "phone_No", type: "real", nullable: true),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Users__3717C9824B671996", x => x.idUser);
                });

            migrationBuilder.CreateTable(
                name: "Venue",
                columns: table => new
                {
                    idVenue = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    address = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    uniqueiden = table.Column<string>(name: "unique_iden", type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    contactNo = table.Column<float>(name: "contact_No", type: "real", nullable: true),
                    description = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Venue__077D5E693F07C0A4", x => x.idVenue);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    idPayment = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Payments__F22D4A45104198F7", x => x.idPayment);
                    table.ForeignKey(
                        name: "FK__Payments__idUser__34C8D9D1",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Business_Account",
                columns: table => new
                {
                    idBA = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    description = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    contactNo = table.Column<float>(name: "contact_No", type: "real", nullable: true),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    country = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    idVenue = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Business__9DB8DE827480C09C", x => x.idBA);
                    table.ForeignKey(
                        name: "FK__Business___idVen__29572725",
                        column: x => x.idVenue,
                        principalTable: "Venue",
                        principalColumn: "idVenue");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    idEvent = table.Column<int>(type: "int", nullable: false),
                    eventname = table.Column<string>(name: "event_name", type: "varchar(75)", unicode: false, maxLength: 75, nullable: true),
                    idVenue = table.Column<int>(type: "int", nullable: false),
                    idEstat = table.Column<int>(type: "int", nullable: true),
                    time = table.Column<TimeSpan>(type: "time", nullable: true),
                    date = table.Column<DateTime>(type: "date", nullable: true),
                    description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idBA = table.Column<int>(type: "int", nullable: true),
                    idCat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event__B7EA7D76B3559F2E", x => x.idEvent);
                    table.ForeignKey(
                        name: "FK__Event__idBA__3B75D760",
                        column: x => x.idBA,
                        principalTable: "Business_Account",
                        principalColumn: "idBA");
                    table.ForeignKey(
                        name: "FK__Event__idCat__3C69FB99",
                        column: x => x.idCat,
                        principalTable: "Category",
                        principalColumn: "idCat");
                    table.ForeignKey(
                        name: "FK__Event__idEstat__398D8EEE",
                        column: x => x.idEstat,
                        principalTable: "Event_Status",
                        principalColumn: "idEstat");
                    table.ForeignKey(
                        name: "FK__Event__idUser__3A81B327",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                    table.ForeignKey(
                        name: "FK__Event__idVenue__38996AB5",
                        column: x => x.idVenue,
                        principalTable: "Venue",
                        principalColumn: "idVenue");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    idOrder = table.Column<int>(type: "int", nullable: false),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idEvent = table.Column<int>(type: "int", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__C8AAF6FF2034C34B", x => x.idOrder);
                    table.ForeignKey(
                        name: "FK__Orders__idEvent__48CFD27E",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__Orders__idUser__47DBAE45",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    idReview = table.Column<int>(type: "int", nullable: false),
                    idEvent = table.Column<int>(type: "int", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true),
                    idPayment = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Reviews__04F7FE10A1EC1D3C", x => x.idReview);
                    table.ForeignKey(
                        name: "FK__Reviews__idEvent__3F466844",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__Reviews__idPayme__412EB0B6",
                        column: x => x.idPayment,
                        principalTable: "Payments",
                        principalColumn: "idPayment");
                    table.ForeignKey(
                        name: "FK__Reviews__idUser__403A8C7D",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateTable(
                name: "user_action",
                columns: table => new
                {
                    idUserAction = table.Column<int>(type: "int", nullable: false),
                    actionName = table.Column<string>(name: "action_Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    description = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: true),
                    idEvent = table.Column<int>(type: "int", nullable: true),
                    idUser = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__user_act__7AE31280D64B2F5E", x => x.idUserAction);
                    table.ForeignKey(
                        name: "FK__user_acti__idEve__440B1D61",
                        column: x => x.idEvent,
                        principalTable: "Event",
                        principalColumn: "idEvent");
                    table.ForeignKey(
                        name: "FK__user_acti__idUse__44FF419A",
                        column: x => x.idUser,
                        principalTable: "Users",
                        principalColumn: "idUser");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_Account_idVenue",
                table: "Business_Account",
                column: "idVenue");

            migrationBuilder.CreateIndex(
                name: "UQ__Business__72E12F1B1F6650F8",
                table: "Business_Account",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Business__AB6E6164FDCFEFBA",
                table: "Business_Account",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idBA",
                table: "Event",
                column: "idBA");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idCat",
                table: "Event",
                column: "idCat");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idEstat",
                table: "Event",
                column: "idEstat");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idUser",
                table: "Event",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Event_idVenue",
                table: "Event",
                column: "idVenue");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_idEvent",
                table: "Orders",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_idUser",
                table: "Orders",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_idUser",
                table: "Payments",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_idEvent",
                table: "Reviews",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_idPayment",
                table: "Reviews",
                column: "idPayment");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_idUser",
                table: "Reviews",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "IX_user_action_idEvent",
                table: "user_action",
                column: "idEvent");

            migrationBuilder.CreateIndex(
                name: "IX_user_action_idUser",
                table: "user_action",
                column: "idUser");

            migrationBuilder.CreateIndex(
                name: "UQ__Users__AB6E61644354BEF8",
                table: "Users",
                column: "email",
                unique: true,
                filter: "[email] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "user_action");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Business_Account");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Event_Status");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Venue");
        }
    }
}
