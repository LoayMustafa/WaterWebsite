using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addSpecificTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Specifics",
                columns: table => new
                {
                    SpecificsCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecificsNameE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    SpecificsNameA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecificsBriefE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificsBriefA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificsOverviewE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificsOverviewA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificsEndE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecificsEndA = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceDetailCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specifics", x => x.SpecificsCode);
                    table.ForeignKey(
                        name: "FK_Specifics_ServiceDetails",
                        column: x => x.ServiceDetailCode,
                        principalTable: "ServiceDetail",
                        principalColumn: "ServiceDetailCode");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Specifics_ServiceDetailCode",
                table: "Specifics",
                column: "ServiceDetailCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Specifics");
        }
    }
}
