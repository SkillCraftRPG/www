using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateScriptTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scripts",
                schema: "Rules",
                columns: table => new
                {
                    ScriptId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SlugNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
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
                    table.PrimaryKey("PK_Scripts", x => x.ScriptId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_CreatedBy",
                schema: "Rules",
                table: "Scripts",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_CreatedOn",
                schema: "Rules",
                table: "Scripts",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Id",
                schema: "Rules",
                table: "Scripts",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_IsPublished",
                schema: "Rules",
                table: "Scripts",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Name",
                schema: "Rules",
                table: "Scripts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Slug",
                schema: "Rules",
                table: "Scripts",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_SlugNormalized",
                schema: "Rules",
                table: "Scripts",
                column: "SlugNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_StreamId",
                schema: "Rules",
                table: "Scripts",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Summary",
                schema: "Rules",
                table: "Scripts",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_UpdatedBy",
                schema: "Rules",
                table: "Scripts",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_UpdatedOn",
                schema: "Rules",
                table: "Scripts",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Scripts_Version",
                schema: "Rules",
                table: "Scripts",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Scripts",
                schema: "Rules");
        }
    }
}
