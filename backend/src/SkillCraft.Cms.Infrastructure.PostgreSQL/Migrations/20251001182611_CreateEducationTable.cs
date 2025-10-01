using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateEducationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Educations",
                schema: "Rules",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SlugNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    WealthMultiplier = table.Column<int>(type: "integer", nullable: true),
                    SkillId = table.Column<int>(type: "integer", nullable: true),
                    SkillUid = table.Column<Guid>(type: "uuid", nullable: true),
                    FeatureId = table.Column<int>(type: "integer", nullable: true),
                    FeatureUid = table.Column<Guid>(type: "uuid", nullable: true),
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
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Educations_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "Rules",
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Educations_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Rules",
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CreatedBy",
                schema: "Rules",
                table: "Educations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_CreatedOn",
                schema: "Rules",
                table: "Educations",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FeatureId",
                schema: "Rules",
                table: "Educations",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_FeatureUid",
                schema: "Rules",
                table: "Educations",
                column: "FeatureUid");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_Id",
                schema: "Rules",
                table: "Educations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_IsPublished",
                schema: "Rules",
                table: "Educations",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_Name",
                schema: "Rules",
                table: "Educations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_SkillId",
                schema: "Rules",
                table: "Educations",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_SkillUid",
                schema: "Rules",
                table: "Educations",
                column: "SkillUid");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_Slug",
                schema: "Rules",
                table: "Educations",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_SlugNormalized",
                schema: "Rules",
                table: "Educations",
                column: "SlugNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_StreamId",
                schema: "Rules",
                table: "Educations",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_Summary",
                schema: "Rules",
                table: "Educations",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UpdatedBy",
                schema: "Rules",
                table: "Educations",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UpdatedOn",
                schema: "Rules",
                table: "Educations",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_Version",
                schema: "Rules",
                table: "Educations",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations",
                schema: "Rules");
        }
    }
}
