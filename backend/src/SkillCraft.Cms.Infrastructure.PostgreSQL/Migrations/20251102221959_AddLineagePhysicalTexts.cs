using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddLineagePhysicalTexts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgeText",
                schema: "Rules",
                table: "Lineages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SizeText",
                schema: "Rules",
                table: "Lineages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WeightText",
                schema: "Rules",
                table: "Lineages",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeText",
                schema: "Rules",
                table: "Lineages");

            migrationBuilder.DropColumn(
                name: "SizeText",
                schema: "Rules",
                table: "Lineages");

            migrationBuilder.DropColumn(
                name: "WeightText",
                schema: "Rules",
                table: "Lineages");
        }
    }
}
