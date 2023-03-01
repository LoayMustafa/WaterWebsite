using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class AddNewServicesStructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ServicePhotoPath",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceLogo",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentCode",
                table: "Service",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceEndA",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ServiceEndE",
                table: "Service",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DepartmentNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DepartmentBriefE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DepartmentBriefA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DepartmentOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentEndE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentEndA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentLogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentCode);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDetail",
                columns: table => new
                {
                    ServiceDetailCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceDetailNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceDetailNameA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ServiceDetailBriefE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDetailBriefA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ServiceDetailOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDetailOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDetailEndE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDetailEndA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDetail", x => x.ServiceDetailCode);
                    table.ForeignKey(
                        name: "FK_ServiceDetails_Services",
                        column: x => x.ServiceCode,
                        principalTable: "Service",
                        principalColumn: "ServiceCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Service_DepartmentCode",
                table: "Service",
                column: "DepartmentCode");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetail_ServiceCode",
                table: "ServiceDetail",
                column: "ServiceCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Departments",
                table: "Service",
                column: "DepartmentCode",
                principalTable: "Department",
                principalColumn: "DepartmentCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Departments",
                table: "Service");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "ServiceDetail");

            migrationBuilder.DropIndex(
                name: "IX_Service_DepartmentCode",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "DepartmentCode",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceEndA",
                table: "Service");

            migrationBuilder.DropColumn(
                name: "ServiceEndE",
                table: "Service");

            migrationBuilder.AlterColumn<string>(
                name: "ServicePhotoPath",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ServiceLogo",
                table: "Service",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
