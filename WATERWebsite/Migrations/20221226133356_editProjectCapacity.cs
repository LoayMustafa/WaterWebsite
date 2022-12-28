using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class editProjectCapacity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectCapacityA",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectCapacityE",
                table: "Project");

            migrationBuilder.AddColumn<long>(
                name: "ProjectCapacity",
                table: "Project",
                type: "bigint",
                maxLength: 25,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectCapacity",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "ProjectCapacityA",
                table: "Project",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectCapacityE",
                table: "Project",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);
        }
    }
}
