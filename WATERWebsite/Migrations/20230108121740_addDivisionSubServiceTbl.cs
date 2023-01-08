using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addDivisionSubServiceTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DivisionSubServices",
                columns: table => new
                {
                    DivisionCode = table.Column<int>(type: "int", nullable: false),
                    SubServiceCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DivisionSubServices", x => new { x.DivisionCode, x.SubServiceCode });
                    table.ForeignKey(
                        name: "Fk_DivisionSubServices_Division",
                        column: x => x.DivisionCode,
                        principalTable: "Division",
                        principalColumn: "DivisionCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "Fk_DivisionSubServices_SubService",
                        column: x => x.SubServiceCode,
                        principalTable: "SubService",
                        principalColumn: "SubServiceCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DivisionSubServices_SubServiceCode",
                table: "DivisionSubServices",
                column: "SubServiceCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DivisionSubServices");
        }
    }
}
