using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateLineageTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationDiscountedTalents_Talents_TalentId",
                schema: "Rules",
                table: "SpecializationDiscountedTalents");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationFeatures_Features_FeatureId",
                schema: "Rules",
                table: "SpecializationFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationOptionalTalents_Talents_TalentId",
                schema: "Rules",
                table: "SpecializationOptionalTalents");

            migrationBuilder.CreateTable(
                name: "Languages",
                schema: "Rules",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Lineages",
                schema: "Rules",
                columns: table => new
                {
                    LineageId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SlugNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    ParentUid = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraLanguages = table.Column<int>(type: "integer", nullable: false),
                    LanguagesText = table.Column<string>(type: "text", nullable: true),
                    Names = table.Column<string>(type: "text", nullable: true),
                    Walk = table.Column<int>(type: "integer", nullable: false),
                    Climb = table.Column<int>(type: "integer", nullable: false),
                    Swim = table.Column<int>(type: "integer", nullable: false),
                    Fly = table.Column<int>(type: "integer", nullable: false),
                    Hover = table.Column<bool>(type: "boolean", nullable: false),
                    Burrow = table.Column<int>(type: "integer", nullable: false),
                    SizeCategory = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SizeRoll = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    Malnutrition = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    Skinny = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    NormalWeight = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    Overweight = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    Obese = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true),
                    Adolescent = table.Column<int>(type: "integer", nullable: false),
                    Adult = table.Column<int>(type: "integer", nullable: false),
                    Mature = table.Column<int>(type: "integer", nullable: false),
                    Venerable = table.Column<int>(type: "integer", nullable: false),
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
                    table.PrimaryKey("PK_Lineages", x => x.LineageId);
                    table.ForeignKey(
                        name: "FK_Lineages_Lineages_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Rules",
                        principalTable: "Lineages",
                        principalColumn: "LineageId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineageFeatures",
                schema: "Rules",
                columns: table => new
                {
                    LineageId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: false),
                    LineageUid = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureUid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineageFeatures", x => new { x.LineageId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_LineageFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "Rules",
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineageFeatures_Lineages_LineageId",
                        column: x => x.LineageId,
                        principalSchema: "Rules",
                        principalTable: "Lineages",
                        principalColumn: "LineageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LineageLanguages",
                schema: "Rules",
                columns: table => new
                {
                    LineageId = table.Column<int>(type: "integer", nullable: false),
                    LanguageId = table.Column<int>(type: "integer", nullable: false),
                    LineageUid = table.Column<Guid>(type: "uuid", nullable: false),
                    LanguageUid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineageLanguages", x => new { x.LineageId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_LineageLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalSchema: "Rules",
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LineageLanguages_Lineages_LineageId",
                        column: x => x.LineageId,
                        principalSchema: "Rules",
                        principalTable: "Lineages",
                        principalColumn: "LineageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CreatedBy",
                schema: "Rules",
                table: "Languages",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_CreatedOn",
                schema: "Rules",
                table: "Languages",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Id",
                schema: "Rules",
                table: "Languages",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_IsPublished",
                schema: "Rules",
                table: "Languages",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Name",
                schema: "Rules",
                table: "Languages",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Slug",
                schema: "Rules",
                table: "Languages",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_SlugNormalized",
                schema: "Rules",
                table: "Languages",
                column: "SlugNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_StreamId",
                schema: "Rules",
                table: "Languages",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Summary",
                schema: "Rules",
                table: "Languages",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_UpdatedBy",
                schema: "Rules",
                table: "Languages",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_UpdatedOn",
                schema: "Rules",
                table: "Languages",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_Version",
                schema: "Rules",
                table: "Languages",
                column: "Version");

            migrationBuilder.CreateIndex(
                name: "IX_LineageFeatures_FeatureId",
                schema: "Rules",
                table: "LineageFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_LineageFeatures_FeatureUid",
                schema: "Rules",
                table: "LineageFeatures",
                column: "FeatureUid");

            migrationBuilder.CreateIndex(
                name: "IX_LineageFeatures_LineageId",
                schema: "Rules",
                table: "LineageFeatures",
                column: "LineageId");

            migrationBuilder.CreateIndex(
                name: "IX_LineageFeatures_LineageUid",
                schema: "Rules",
                table: "LineageFeatures",
                column: "LineageUid");

            migrationBuilder.CreateIndex(
                name: "IX_LineageLanguages_LanguageId",
                schema: "Rules",
                table: "LineageLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LineageLanguages_LanguageUid",
                schema: "Rules",
                table: "LineageLanguages",
                column: "LanguageUid");

            migrationBuilder.CreateIndex(
                name: "IX_LineageLanguages_LineageId",
                schema: "Rules",
                table: "LineageLanguages",
                column: "LineageId");

            migrationBuilder.CreateIndex(
                name: "IX_LineageLanguages_LineageUid",
                schema: "Rules",
                table: "LineageLanguages",
                column: "LineageUid");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_CreatedBy",
                schema: "Rules",
                table: "Lineages",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_CreatedOn",
                schema: "Rules",
                table: "Lineages",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_Id",
                schema: "Rules",
                table: "Lineages",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_IsPublished",
                schema: "Rules",
                table: "Lineages",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_Name",
                schema: "Rules",
                table: "Lineages",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_ParentId",
                schema: "Rules",
                table: "Lineages",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_ParentUid",
                schema: "Rules",
                table: "Lineages",
                column: "ParentUid");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_SizeCategory",
                schema: "Rules",
                table: "Lineages",
                column: "SizeCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_Slug",
                schema: "Rules",
                table: "Lineages",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_SlugNormalized",
                schema: "Rules",
                table: "Lineages",
                column: "SlugNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_StreamId",
                schema: "Rules",
                table: "Lineages",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_Summary",
                schema: "Rules",
                table: "Lineages",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_UpdatedBy",
                schema: "Rules",
                table: "Lineages",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_UpdatedOn",
                schema: "Rules",
                table: "Lineages",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Lineages_Version",
                schema: "Rules",
                table: "Lineages",
                column: "Version");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationDiscountedTalents_Talents_TalentId",
                schema: "Rules",
                table: "SpecializationDiscountedTalents",
                column: "TalentId",
                principalSchema: "Rules",
                principalTable: "Talents",
                principalColumn: "TalentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationFeatures_Features_FeatureId",
                schema: "Rules",
                table: "SpecializationFeatures",
                column: "FeatureId",
                principalSchema: "Rules",
                principalTable: "Features",
                principalColumn: "FeatureId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationOptionalTalents_Talents_TalentId",
                schema: "Rules",
                table: "SpecializationOptionalTalents",
                column: "TalentId",
                principalSchema: "Rules",
                principalTable: "Talents",
                principalColumn: "TalentId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationDiscountedTalents_Talents_TalentId",
                schema: "Rules",
                table: "SpecializationDiscountedTalents");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationFeatures_Features_FeatureId",
                schema: "Rules",
                table: "SpecializationFeatures");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecializationOptionalTalents_Talents_TalentId",
                schema: "Rules",
                table: "SpecializationOptionalTalents");

            migrationBuilder.DropTable(
                name: "LineageFeatures",
                schema: "Rules");

            migrationBuilder.DropTable(
                name: "LineageLanguages",
                schema: "Rules");

            migrationBuilder.DropTable(
                name: "Languages",
                schema: "Rules");

            migrationBuilder.DropTable(
                name: "Lineages",
                schema: "Rules");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationDiscountedTalents_Talents_TalentId",
                schema: "Rules",
                table: "SpecializationDiscountedTalents",
                column: "TalentId",
                principalSchema: "Rules",
                principalTable: "Talents",
                principalColumn: "TalentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationFeatures_Features_FeatureId",
                schema: "Rules",
                table: "SpecializationFeatures",
                column: "FeatureId",
                principalSchema: "Rules",
                principalTable: "Features",
                principalColumn: "FeatureId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpecializationOptionalTalents_Talents_TalentId",
                schema: "Rules",
                table: "SpecializationOptionalTalents",
                column: "TalentId",
                principalSchema: "Rules",
                principalTable: "Talents",
                principalColumn: "TalentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
