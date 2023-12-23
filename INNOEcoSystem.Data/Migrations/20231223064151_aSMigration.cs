using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INNOEcoSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class aSMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Lacations_LocationId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Lacations_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Lacations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Lacations_LocationId",
                table: "Users");

            migrationBuilder.AlterColumn<long>(
                name: "LocationId",
                table: "Users",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Lacations_LocationId",
                table: "Users",
                column: "LocationId",
                principalTable: "Lacations",
                principalColumn: "Id");
        }
    }
}
