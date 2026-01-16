using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateSpellTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spells",
                schema: "Rules",
                columns: table => new
                {
                    SpellId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SlugNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    MetaDescription = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StreamId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spells", x => x.SpellId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Spells_CreatedBy",
                schema: "Rules",
                table: "Spells",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_CreatedOn",
                schema: "Rules",
                table: "Spells",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Id",
                schema: "Rules",
                table: "Spells",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spells_IsPublished",
                schema: "Rules",
                table: "Spells",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Name",
                schema: "Rules",
                table: "Spells",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Slug",
                schema: "Rules",
                table: "Spells",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_SlugNormalized",
                schema: "Rules",
                table: "Spells",
                column: "SlugNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spells_StreamId",
                schema: "Rules",
                table: "Spells",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Summary",
                schema: "Rules",
                table: "Spells",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Tier",
                schema: "Rules",
                table: "Spells",
                column: "Tier");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_UpdatedBy",
                schema: "Rules",
                table: "Spells",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_UpdatedOn",
                schema: "Rules",
                table: "Spells",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Spells_Version",
                schema: "Rules",
                table: "Spells",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spells",
                schema: "Rules");
        }
    }
}
