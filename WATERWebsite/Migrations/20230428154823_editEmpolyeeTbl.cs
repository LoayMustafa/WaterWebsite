using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WATERWebsite.Migrations
{
    public partial class editEmpolyeeTbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsKey",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "EmployeeDescriptionE",
                table: "Employee",
                newName: "EmployeeLinkedIn");

            migrationBuilder.RenameColumn(
                name: "EmployeeDescriptionA",
                table: "Employee",
                newName: "EmployeeBioE");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeJobE",
                table: "Employee",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeJobA",
                table: "Employee",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeBioA",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeLevel",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeBioA",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmployeeLevel",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "EmployeeLinkedIn",
                table: "Employee",
                newName: "EmployeeDescriptionE");

            migrationBuilder.RenameColumn(
                name: "EmployeeBioE",
                table: "Employee",
                newName: "EmployeeDescriptionA");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeJobE",
                table: "Employee",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeJobA",
                table: "Employee",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsKey",
                table: "Employee",
                type: "bit",
                nullable: true);
        }
    }
}
