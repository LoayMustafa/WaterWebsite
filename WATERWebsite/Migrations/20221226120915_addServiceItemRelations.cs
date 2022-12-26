using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addServiceItemRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceItemSpecializedService");

            migrationBuilder.AddColumn<string>(
                name: "ServiceItemDescriptionA",
                table: "ServiceItem",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceItemDescriptionE",
                table: "ServiceItem",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProjectsServiceItems",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ServiceItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectsServiceItems", x => new { x.ProjectId, x.ServiceItemId });
                    table.ForeignKey(
                        name: "FK_ProjectsServiceItems_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectsServiceItems_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItem",
                        principalColumn: "ServiceItemCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecializedServicesItems",
                columns: table => new
                {
                    SpecializedServiceId = table.Column<int>(type: "int", nullable: false),
                    ServiceItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializedServicesItems", x => new { x.ServiceItemId, x.SpecializedServiceId });
                    table.ForeignKey(
                        name: "FK_SpecializedServicesItems_ServiceItem_ServiceItemId",
                        column: x => x.ServiceItemId,
                        principalTable: "ServiceItem",
                        principalColumn: "ServiceItemCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializedServicesItems_SpecializedService_SpecializedServiceId",
                        column: x => x.SpecializedServiceId,
                        principalTable: "SpecializedService",
                        principalColumn: "SpecializedServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsServiceItems_ServiceItemId",
                table: "ProjectsServiceItems",
                column: "ServiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializedServicesItems_SpecializedServiceId",
                table: "SpecializedServicesItems",
                column: "SpecializedServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectsServiceItems");

            migrationBuilder.DropTable(
                name: "SpecializedServicesItems");

            migrationBuilder.DropColumn(
                name: "ServiceItemDescriptionA",
                table: "ServiceItem");

            migrationBuilder.DropColumn(
                name: "ServiceItemDescriptionE",
                table: "ServiceItem");

            migrationBuilder.CreateTable(
                name: "ServiceItemSpecializedService",
                columns: table => new
                {
                    ServiceItemsServiceItemCode = table.Column<int>(type: "int", nullable: false),
                    SpecializedServicesSpecializedServiceCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItemSpecializedService", x => new { x.ServiceItemsServiceItemCode, x.SpecializedServicesSpecializedServiceCode });
                    table.ForeignKey(
                        name: "FK_ServiceItemSpecializedService_ServiceItem_ServiceItemsServiceItemCode",
                        column: x => x.ServiceItemsServiceItemCode,
                        principalTable: "ServiceItem",
                        principalColumn: "ServiceItemCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceItemSpecializedService_SpecializedService_SpecializedServicesSpecializedServiceCode",
                        column: x => x.SpecializedServicesSpecializedServiceCode,
                        principalTable: "SpecializedService",
                        principalColumn: "SpecializedServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItemSpecializedService_SpecializedServicesSpecializedServiceCode",
                table: "ServiceItemSpecializedService",
                column: "SpecializedServicesSpecializedServiceCode");
        }
    }
}
