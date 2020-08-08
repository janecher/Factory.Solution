using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class NullLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_Locations_LocationId",
                table: "Engineers");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Locations_LocationId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Machines",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Engineers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_Locations_LocationId",
                table: "Engineers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Locations_LocationId",
                table: "Machines",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engineers_Locations_LocationId",
                table: "Engineers");

            migrationBuilder.DropForeignKey(
                name: "FK_Machines_Locations_LocationId",
                table: "Machines");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Machines",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Engineers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Engineers_Locations_LocationId",
                table: "Engineers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Machines_Locations_LocationId",
                table: "Machines",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
