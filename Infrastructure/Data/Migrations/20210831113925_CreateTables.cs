using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domain.Entities.Guest",
                columns: table => new
                {
                    Id_Guest = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain.Entities.Guest", x => x.Id_Guest);
                });

            migrationBuilder.CreateTable(
                name: "Domain.Entities.Reservation",
                columns: table => new
                {
                    Id_Reservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Booking_Code = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 40, nullable: false),
                    Check_in_Date = table.Column<DateTime>(type: "datetime2", maxLength: 40, nullable: false),
                    Check_out_Date = table.Column<DateTime>(type: "datetime2", maxLength: 40, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain.Entities.Reservation", x => x.Id_Reservation);
                });

            migrationBuilder.CreateTable(
                name: "Domain.Entities.ReservationsGuests",
                columns: table => new
                {
                    Id_Reservation = table.Column<int>(type: "int", nullable: false),
                    Id_Guest = table.Column<int>(type: "int", nullable: false),
                    Id_Reservation_Guest = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain.Entities.ReservationsGuests", x => new { x.Id_Guest, x.Id_Reservation });
                    table.ForeignKey(
                        name: "FK_Domain.Entities.ReservationsGuests_Domain.Entities.Guest_Id_Guest",
                        column: x => x.Id_Guest,
                        principalTable: "Domain.Entities.Guest",
                        principalColumn: "Id_Guest",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Domain.Entities.ReservationsGuests_Domain.Entities.Reservation_Id_Reservation",
                        column: x => x.Id_Reservation,
                        principalTable: "Domain.Entities.Reservation",
                        principalColumn: "Id_Reservation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Domain.Entities.ReservationsGuests_Id_Reservation",
                table: "Domain.Entities.ReservationsGuests",
                column: "Id_Reservation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Domain.Entities.ReservationsGuests");

            migrationBuilder.DropTable(
                name: "Domain.Entities.Guest");

            migrationBuilder.DropTable(
                name: "Domain.Entities.Reservation");
        }
    }
}
