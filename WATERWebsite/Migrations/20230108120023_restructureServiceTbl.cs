using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class restructureServiceTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Project_ProjectCode",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "ProjectsServiceItems");

            migrationBuilder.DropTable(
                name: "ServiceProject");

            migrationBuilder.DropTable(
                name: "ServiceSpecializedService");

            migrationBuilder.DropTable(
                name: "SpecializedServicesItems");

            migrationBuilder.DropTable(
                name: "ServiceItem");

            migrationBuilder.DropTable(
                name: "SpecializedService");

            migrationBuilder.DropIndex(
                name: "IX_Employee_ProjectCode",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "Employee");

            migrationBuilder.CreateTable(
                name: "Division",
                columns: table => new
                {
                    DivisionCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DivisionNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DivisionBriefE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionBriefA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Division", x => x.DivisionCode);
                });

            migrationBuilder.CreateTable(
                name: "SubService",
                columns: table => new
                {
                    SubServiceCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubServiceNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubServiceNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubServiceBriefE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SubServiceBriefA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubService", x => x.SubServiceCode);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDivisons",
                columns: table => new
                {
                    ServiceCode = table.Column<int>(type: "int", nullable: false),
                    DivisionCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDivisons", x => new { x.ServiceCode, x.DivisionCode });
                    table.ForeignKey(
                        name: "Fk_ServiceDivisions_Division",
                        column: x => x.DivisionCode,
                        principalTable: "Division",
                        principalColumn: "DivisionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_ServiceDivisions_Service",
                        column: x => x.ServiceCode,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDivisons_DivisionCode",
                table: "ServiceDivisons",
                column: "DivisionCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceDivisons");

            migrationBuilder.DropTable(
                name: "SubService");

            migrationBuilder.DropTable(
                name: "Division");

            migrationBuilder.AddColumn<int>(
                name: "ProjectCode",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceItem",
                columns: table => new
                {
                    ServiceItemCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceItemDescriptionA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServiceItemDescriptionE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServiceItemNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceItemNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceItem", x => x.ServiceItemCode);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProject",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProject", x => new { x.ServiceId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ServiceProject_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceProject_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecializedService",
                columns: table => new
                {
                    SpecializedServiceCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecializedServiceBriefA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecializedServiceBriefE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SpecializedServiceLogo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecializedServiceNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SpecializedServiceNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SpecializedServiceOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializedServiceOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecializedServicePhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializedService", x => x.SpecializedServiceCode);
                });

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
                name: "ServiceSpecializedService",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    SpecializedServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSpecializedService", x => new { x.ServiceId, x.SpecializedServiceId });
                    table.ForeignKey(
                        name: "FK_ServiceSpecializedService_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceSpecializedService_SpecializedService_SpecializedServiceId",
                        column: x => x.SpecializedServiceId,
                        principalTable: "SpecializedService",
                        principalColumn: "SpecializedServiceCode",
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
                    table.PrimaryKey("PK_SpecializedServicesItems", x => new { x.SpecializedServiceId, x.ServiceItemId });
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
                name: "IX_Employee_ProjectCode",
                table: "Employee",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectsServiceItems_ServiceItemId",
                table: "ProjectsServiceItems",
                column: "ServiceItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProject_ProjectId",
                table: "ServiceProject",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSpecializedService_SpecializedServiceId",
                table: "ServiceSpecializedService",
                column: "SpecializedServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializedServicesItems_ServiceItemId",
                table: "SpecializedServicesItems",
                column: "ServiceItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Project_ProjectCode",
                table: "Employee",
                column: "ProjectCode",
                principalTable: "Project",
                principalColumn: "ProjectCode");
        }
    }
}
