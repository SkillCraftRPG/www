using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateSpecializationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Features",
                schema: "Rules",
                columns: table => new
                {
                    FeatureId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
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
                    table.PrimaryKey("PK_Features", x => x.FeatureId);
                });

            migrationBuilder.CreateTable(
                name: "Specializations",
                schema: "Rules",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SlugNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: false),
                    Summary = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    MandatoryTalentId = table.Column<int>(type: "integer", nullable: true),
                    MandatoryTalentUid = table.Column<Guid>(type: "uuid", nullable: true),
                    OtherRequirements = table.Column<string>(type: "text", nullable: true),
                    OtherOptions = table.Column<string>(type: "text", nullable: true),
                    ReservedTalentName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    ReservedTalentDescription = table.Column<string>(type: "text", nullable: true),
                    StreamId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specializations", x => x.SpecializationId);
                    table.ForeignKey(
                        name: "FK_Specializations_Talents_MandatoryTalentId",
                        column: x => x.MandatoryTalentId,
                        principalSchema: "Rules",
                        principalTable: "Talents",
                        principalColumn: "TalentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecializationDiscountedTalents",
                schema: "Rules",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "integer", nullable: false),
                    TalentId = table.Column<int>(type: "integer", nullable: false),
                    SpecializationUid = table.Column<Guid>(type: "uuid", nullable: false),
                    TalentUid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationDiscountedTalents", x => new { x.SpecializationId, x.TalentId });
                    table.ForeignKey(
                        name: "FK_SpecializationDiscountedTalents_Specializations_Specializat~",
                        column: x => x.SpecializationId,
                        principalSchema: "Rules",
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializationDiscountedTalents_Talents_TalentId",
                        column: x => x.TalentId,
                        principalSchema: "Rules",
                        principalTable: "Talents",
                        principalColumn: "TalentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecializationFeatures",
                schema: "Rules",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "integer", nullable: false),
                    FeatureId = table.Column<int>(type: "integer", nullable: false),
                    SpecializationUid = table.Column<Guid>(type: "uuid", nullable: false),
                    FeatureUid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationFeatures", x => new { x.SpecializationId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_SpecializationFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalSchema: "Rules",
                        principalTable: "Features",
                        principalColumn: "FeatureId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializationFeatures_Specializations_SpecializationId",
                        column: x => x.SpecializationId,
                        principalSchema: "Rules",
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecializationOptionalTalents",
                schema: "Rules",
                columns: table => new
                {
                    SpecializationId = table.Column<int>(type: "integer", nullable: false),
                    TalentId = table.Column<int>(type: "integer", nullable: false),
                    SpecializationUid = table.Column<Guid>(type: "uuid", nullable: false),
                    TalentUid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationOptionalTalents", x => new { x.SpecializationId, x.TalentId });
                    table.ForeignKey(
                        name: "FK_SpecializationOptionalTalents_Specializations_Specializatio~",
                        column: x => x.SpecializationId,
                        principalSchema: "Rules",
                        principalTable: "Specializations",
                        principalColumn: "SpecializationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializationOptionalTalents_Talents_TalentId",
                        column: x => x.TalentId,
                        principalSchema: "Rules",
                        principalTable: "Talents",
                        principalColumn: "TalentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Features_CreatedBy",
                schema: "Rules",
                table: "Features",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Features_CreatedOn",
                schema: "Rules",
                table: "Features",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Features_Id",
                schema: "Rules",
                table: "Features",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_IsPublished",
                schema: "Rules",
                table: "Features",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Features_Name",
                schema: "Rules",
                table: "Features",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Features_StreamId",
                schema: "Rules",
                table: "Features",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_UpdatedBy",
                schema: "Rules",
                table: "Features",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Features_UpdatedOn",
                schema: "Rules",
                table: "Features",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Features_Version",
                schema: "Rules",
                table: "Features",
                column: "Version");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationDiscountedTalents_SpecializationId",
                schema: "Rules",
                table: "SpecializationDiscountedTalents",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationDiscountedTalents_SpecializationUid",
                schema: "Rules",
                table: "SpecializationDiscountedTalents",
                column: "SpecializationUid");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationDiscountedTalents_TalentId",
                schema: "Rules",
                table: "SpecializationDiscountedTalents",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationDiscountedTalents_TalentUid",
                schema: "Rules",
                table: "SpecializationDiscountedTalents",
                column: "TalentUid");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationFeatures_FeatureId",
                schema: "Rules",
                table: "SpecializationFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationFeatures_FeatureUid",
                schema: "Rules",
                table: "SpecializationFeatures",
                column: "FeatureUid");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationFeatures_SpecializationId",
                schema: "Rules",
                table: "SpecializationFeatures",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationFeatures_SpecializationUid",
                schema: "Rules",
                table: "SpecializationFeatures",
                column: "SpecializationUid");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationOptionalTalents_SpecializationId",
                schema: "Rules",
                table: "SpecializationOptionalTalents",
                column: "SpecializationId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationOptionalTalents_SpecializationUid",
                schema: "Rules",
                table: "SpecializationOptionalTalents",
                column: "SpecializationUid");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationOptionalTalents_TalentId",
                schema: "Rules",
                table: "SpecializationOptionalTalents",
                column: "TalentId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationOptionalTalents_TalentUid",
                schema: "Rules",
                table: "SpecializationOptionalTalents",
                column: "TalentUid");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_CreatedBy",
                schema: "Rules",
                table: "Specializations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_CreatedOn",
                schema: "Rules",
                table: "Specializations",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Id",
                schema: "Rules",
                table: "Specializations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_IsPublished",
                schema: "Rules",
                table: "Specializations",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_MandatoryTalentId",
                schema: "Rules",
                table: "Specializations",
                column: "MandatoryTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_MandatoryTalentUid",
                schema: "Rules",
                table: "Specializations",
                column: "MandatoryTalentUid");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Name",
                schema: "Rules",
                table: "Specializations",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_ReservedTalentName",
                schema: "Rules",
                table: "Specializations",
                column: "ReservedTalentName");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Slug",
                schema: "Rules",
                table: "Specializations",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_SlugNormalized",
                schema: "Rules",
                table: "Specializations",
                column: "SlugNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_StreamId",
                schema: "Rules",
                table: "Specializations",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Summary",
                schema: "Rules",
                table: "Specializations",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Tier",
                schema: "Rules",
                table: "Specializations",
                column: "Tier");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_UpdatedBy",
                schema: "Rules",
                table: "Specializations",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_UpdatedOn",
                schema: "Rules",
                table: "Specializations",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Specializations_Version",
                schema: "Rules",
                table: "Specializations",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializationDiscountedTalents",
                schema: "Rules");

            migrationBuilder.DropTable(
                name: "SpecializationFeatures",
                schema: "Rules");

            migrationBuilder.DropTable(
                name: "SpecializationOptionalTalents",
                schema: "Rules");

            migrationBuilder.DropTable(
                name: "Features",
                schema: "Rules");

            migrationBuilder.DropTable(
                name: "Specializations",
                schema: "Rules");
        }
    }
}
