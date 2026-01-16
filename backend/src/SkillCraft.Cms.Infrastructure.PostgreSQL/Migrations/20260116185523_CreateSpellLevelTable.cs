using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateSpellLevelTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SpellLevels",
                schema: "Rules",
                columns: table => new
                {
                    SpellLevelId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    SpellId = table.Column<int>(type: "integer", nullable: false),
                    SpellUid = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CastingTime = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    IsRitual = table.Column<bool>(type: "boolean", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    DurationUnit = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    IsConcentration = table.Column<bool>(type: "boolean", nullable: false),
                    Range = table.Column<int>(type: "integer", nullable: false),
                    IsSomatic = table.Column<bool>(type: "boolean", nullable: false),
                    IsVerbal = table.Column<bool>(type: "boolean", nullable: false),
                    Focus = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    Material = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
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
                    table.PrimaryKey("PK_SpellLevels", x => x.SpellLevelId);
                    table.ForeignKey(
                        name: "FK_SpellLevels_Spells_SpellId",
                        column: x => x.SpellId,
                        principalSchema: "Rules",
                        principalTable: "Spells",
                        principalColumn: "SpellId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_CreatedBy",
                schema: "Rules",
                table: "SpellLevels",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_CreatedOn",
                schema: "Rules",
                table: "SpellLevels",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_Id",
                schema: "Rules",
                table: "SpellLevels",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_IsPublished",
                schema: "Rules",
                table: "SpellLevels",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_SpellId",
                schema: "Rules",
                table: "SpellLevels",
                column: "SpellId");

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_SpellUid",
                schema: "Rules",
                table: "SpellLevels",
                column: "SpellUid");

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_StreamId",
                schema: "Rules",
                table: "SpellLevels",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_UpdatedBy",
                schema: "Rules",
                table: "SpellLevels",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_UpdatedOn",
                schema: "Rules",
                table: "SpellLevels",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_SpellLevels_Version",
                schema: "Rules",
                table: "SpellLevels",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpellLevels",
                schema: "Rules");
        }
    }
}
