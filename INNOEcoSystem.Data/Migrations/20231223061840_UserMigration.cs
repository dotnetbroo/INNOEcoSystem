using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INNOEcoSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleed",
                table: "Users",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleed",
                table: "Lacations",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleed",
                table: "LacationAssets",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleed",
                table: "Departments",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleed",
                table: "DepartmentCategories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsDeleed",
                table: "Applications",
                newName: "IsDeleted");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Users",
                newName: "IsDeleed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Lacations",
                newName: "IsDeleed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "LacationAssets",
                newName: "IsDeleed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Departments",
                newName: "IsDeleed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "DepartmentCategories",
                newName: "IsDeleed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Applications",
                newName: "IsDeleed");
        }
    }
}
