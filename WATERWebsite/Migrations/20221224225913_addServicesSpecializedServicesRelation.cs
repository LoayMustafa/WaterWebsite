using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addServicesSpecializedServicesRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSpecializedService_Service_ServicesServiceCode",
                table: "ServiceSpecializedService");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSpecializedService_SpecializedService_SpecializedServicesSpecializedServiceCode",
                table: "ServiceSpecializedService");

            migrationBuilder.RenameColumn(
                name: "SpecializedServicesSpecializedServiceCode",
                table: "ServiceSpecializedService",
                newName: "SpecializedServiceId");

            migrationBuilder.RenameColumn(
                name: "ServicesServiceCode",
                table: "ServiceSpecializedService",
                newName: "ServiceId");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceSpecializedService_SpecializedServicesSpecializedServiceCode",
                table: "ServiceSpecializedService",
                newName: "IX_ServiceSpecializedService_SpecializedServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSpecializedService_Service_ServiceId",
                table: "ServiceSpecializedService",
                column: "ServiceId",
                principalTable: "Service",
                principalColumn: "ServiceCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSpecializedService_SpecializedService_SpecializedServiceId",
                table: "ServiceSpecializedService",
                column: "SpecializedServiceId",
                principalTable: "SpecializedService",
                principalColumn: "SpecializedServiceCode",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSpecializedService_Service_ServiceId",
                table: "ServiceSpecializedService");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceSpecializedService_SpecializedService_SpecializedServiceId",
                table: "ServiceSpecializedService");

            migrationBuilder.RenameColumn(
                name: "SpecializedServiceId",
                table: "ServiceSpecializedService",
                newName: "SpecializedServicesSpecializedServiceCode");

            migrationBuilder.RenameColumn(
                name: "ServiceId",
                table: "ServiceSpecializedService",
                newName: "ServicesServiceCode");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceSpecializedService_SpecializedServiceId",
                table: "ServiceSpecializedService",
                newName: "IX_ServiceSpecializedService_SpecializedServicesSpecializedServiceCode");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSpecializedService_Service_ServicesServiceCode",
                table: "ServiceSpecializedService",
                column: "ServicesServiceCode",
                principalTable: "Service",
                principalColumn: "ServiceCode",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceSpecializedService_SpecializedService_SpecializedServicesSpecializedServiceCode",
                table: "ServiceSpecializedService",
                column: "SpecializedServicesSpecializedServiceCode",
                principalTable: "SpecializedService",
                principalColumn: "SpecializedServiceCode",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
