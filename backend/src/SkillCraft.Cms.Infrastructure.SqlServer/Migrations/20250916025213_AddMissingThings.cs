using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingThings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Rules");

            migrationBuilder.RenameTable(
                name: "Talents",
                schema: "Cms",
                newName: "Talents",
                newSchema: "Rules");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Rules",
                table: "Talents",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SlugNormalized",
                schema: "Rules",
                table: "Talents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_SlugNormalized",
                schema: "Rules",
                table: "Talents",
                column: "SlugNormalized",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Talents_SlugNormalized",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "SlugNormalized",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.EnsureSchema(
                name: "Cms");

            migrationBuilder.RenameTable(
                name: "Talents",
                schema: "Rules",
                newName: "Talents",
                newSchema: "Cms");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "Cms",
                table: "Talents",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);
        }
    }
}
