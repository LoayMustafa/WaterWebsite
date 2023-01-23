using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class addBlogTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BlogTitleE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlogTitleA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlogBriefE = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlogBriefA = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BlogContentE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogContentA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BlogPhoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blog");
        }
    }
}
