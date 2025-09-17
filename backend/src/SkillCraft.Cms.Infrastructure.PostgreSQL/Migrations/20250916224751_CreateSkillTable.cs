using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateSkillTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "Rules",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SlugNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AttributeId = table.Column<int>(type: "integer", nullable: true),
                    AttributeUid = table.Column<Guid>(type: "uuid", nullable: true),
                    Summary = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
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
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                    table.ForeignKey(
                        name: "FK_Skills_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Rules",
                        principalTable: "Attributes",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AttributeId",
                schema: "Rules",
                table: "Skills",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AttributeUid",
                schema: "Rules",
                table: "Skills",
                column: "AttributeUid");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CreatedBy",
                schema: "Rules",
                table: "Skills",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CreatedOn",
                schema: "Rules",
                table: "Skills",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Id",
                schema: "Rules",
                table: "Skills",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_IsPublished",
                schema: "Rules",
                table: "Skills",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Name",
                schema: "Rules",
                table: "Skills",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Slug",
                schema: "Rules",
                table: "Skills",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SlugNormalized",
                schema: "Rules",
                table: "Skills",
                column: "SlugNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_StreamId",
                schema: "Rules",
                table: "Skills",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Summary",
                schema: "Rules",
                table: "Skills",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UpdatedBy",
                schema: "Rules",
                table: "Skills",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_UpdatedOn",
                schema: "Rules",
                table: "Skills",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Value",
                schema: "Rules",
                table: "Skills",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_Version",
                schema: "Rules",
                table: "Skills",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Skills",
                schema: "Rules");
        }
    }
}
