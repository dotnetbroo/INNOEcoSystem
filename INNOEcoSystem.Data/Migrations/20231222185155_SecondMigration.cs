using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INNOEcoSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryAsset",
                table: "DepartmentCategories",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "DepartmentCategories",
                newName: "CategoryAsset");
        }
    }
}
