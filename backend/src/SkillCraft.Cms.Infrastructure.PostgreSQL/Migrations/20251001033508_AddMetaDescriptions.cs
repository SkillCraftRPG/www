using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddMetaDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "Rules",
                table: "Talents",
                type: "character varying(160)",
                maxLength: 160,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "Rules",
                table: "Statistics",
                type: "character varying(160)",
                maxLength: 160,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "Rules",
                table: "Skills",
                type: "character varying(160)",
                maxLength: 160,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MetaDescription",
                schema: "Rules",
                table: "Attributes",
                type: "character varying(160)",
                maxLength: 160,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "Rules",
                table: "Statistics");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "Rules",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "MetaDescription",
                schema: "Rules",
                table: "Attributes");
        }
    }
}
