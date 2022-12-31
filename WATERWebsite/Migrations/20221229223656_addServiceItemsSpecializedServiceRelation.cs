using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addServiceItemsSpecializedServiceRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecializedServicesItems",
                table: "SpecializedServicesItems");

            migrationBuilder.DropIndex(
                name: "IX_SpecializedServicesItems_SpecializedServiceId",
                table: "SpecializedServicesItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecializedServicesItems",
                table: "SpecializedServicesItems",
                columns: new[] { "SpecializedServiceId", "ServiceItemId" });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializedServicesItems_ServiceItemId",
                table: "SpecializedServicesItems",
                column: "ServiceItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SpecializedServicesItems",
                table: "SpecializedServicesItems");

            migrationBuilder.DropIndex(
                name: "IX_SpecializedServicesItems_ServiceItemId",
                table: "SpecializedServicesItems");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SpecializedServicesItems",
                table: "SpecializedServicesItems",
                columns: new[] { "ServiceItemId", "SpecializedServiceId" });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializedServicesItems_SpecializedServiceId",
                table: "SpecializedServicesItems",
                column: "SpecializedServiceId");
        }
    }
}
