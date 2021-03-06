using Microsoft.EntityFrameworkCore.Migrations;

namespace xuyang.CabBookingShop.Infrastructure.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_CabTypes_CabTypeId",
                table: "BookingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_Places_FromPlaceId",
                table: "BookingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_Places_ToPlaceId",
                table: "BookingHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CabTypes",
                table: "CabTypes");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "Place");

            migrationBuilder.RenameTable(
                name: "CabTypes",
                newName: "CabType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Place",
                table: "Place",
                column: "PlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CabType",
                table: "CabType",
                column: "CabTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_CabType_CabTypeId",
                table: "BookingHistory",
                column: "CabTypeId",
                principalTable: "CabType",
                principalColumn: "CabTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_Place_FromPlaceId",
                table: "BookingHistory",
                column: "FromPlaceId",
                principalTable: "Place",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_Place_ToPlaceId",
                table: "BookingHistory",
                column: "ToPlaceId",
                principalTable: "Place",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_CabType_CabTypeId",
                table: "BookingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_Place_FromPlaceId",
                table: "BookingHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_BookingHistory_Place_ToPlaceId",
                table: "BookingHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Place",
                table: "Place");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CabType",
                table: "CabType");

            migrationBuilder.RenameTable(
                name: "Place",
                newName: "Places");

            migrationBuilder.RenameTable(
                name: "CabType",
                newName: "CabTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "PlaceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CabTypes",
                table: "CabTypes",
                column: "CabTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_CabTypes_CabTypeId",
                table: "BookingHistory",
                column: "CabTypeId",
                principalTable: "CabTypes",
                principalColumn: "CabTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_Places_FromPlaceId",
                table: "BookingHistory",
                column: "FromPlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BookingHistory_Places_ToPlaceId",
                table: "BookingHistory",
                column: "ToPlaceId",
                principalTable: "Places",
                principalColumn: "PlaceId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
