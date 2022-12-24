using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class AddSpecializedServiceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecializedServices",
                table: "Service");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceBriefE",
                table: "Service",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceItem",
                columns: table => new
                {
                    ServiceItemCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceItemNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceItemNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItem", x => x.ServiceItemCode);
                });

            migrationBuilder.CreateTable(
                name: "SpecializedService",
                columns: table => new
                {
                    SpecializedServiceCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializedServiceNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SpecializedServiceOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializedServiceBriefE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecializedServiceNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SpecializedServiceOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializedServiceBriefA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecializedServicePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializedServiceLogo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializedService", x => x.SpecializedServiceCode);
                });

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

            migrationBuilder.CreateTable(
                name: "ServiceSpecializedService",
                columns: table => new
                {
                    ServicesServiceCode = table.Column<int>(type: "int", nullable: false),
                    SpecializedServicesSpecializedServiceCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSpecializedService", x => new { x.ServicesServiceCode, x.SpecializedServicesSpecializedServiceCode });
                    table.ForeignKey(
                        name: "FK_ServiceSpecializedService_Service_ServicesServiceCode",
                        column: x => x.ServicesServiceCode,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSpecializedService_SpecializedService_SpecializedServicesSpecializedServiceCode",
                        column: x => x.SpecializedServicesSpecializedServiceCode,
                        principalTable: "SpecializedService",
                        principalColumn: "SpecializedServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceItemSpecializedService_SpecializedServicesSpecializedServiceCode",
                table: "ServiceItemSpecializedService",
                column: "SpecializedServicesSpecializedServiceCode");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSpecializedService_SpecializedServicesSpecializedServiceCode",
                table: "ServiceSpecializedService",
                column: "SpecializedServicesSpecializedServiceCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceItemSpecializedService");

            migrationBuilder.DropTable(
                name: "ServiceSpecializedService");

            migrationBuilder.DropTable(
                name: "ServiceItem");

            migrationBuilder.DropTable(
                name: "SpecializedService");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceBriefE",
                table: "Service",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SpecializedServices",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
