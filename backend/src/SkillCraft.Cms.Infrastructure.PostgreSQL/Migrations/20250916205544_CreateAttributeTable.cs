using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateAttributeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SlugNormalized",
                schema: "Rules",
                table: "Talents",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "Attributes",
                schema: "Rules",
                columns: table => new
                {
                    AttributeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SlugNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Category = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
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
                    table.PrimaryKey("PK_Attributes", x => x.AttributeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Category",
                schema: "Rules",
                table: "Attributes",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_CreatedBy",
                schema: "Rules",
                table: "Attributes",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_CreatedOn",
                schema: "Rules",
                table: "Attributes",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Id",
                schema: "Rules",
                table: "Attributes",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_IsPublished",
                schema: "Rules",
                table: "Attributes",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Name",
                schema: "Rules",
                table: "Attributes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Slug",
                schema: "Rules",
                table: "Attributes",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_SlugNormalized",
                schema: "Rules",
                table: "Attributes",
                column: "SlugNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_StreamId",
                schema: "Rules",
                table: "Attributes",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Summary",
                schema: "Rules",
                table: "Attributes",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_UpdatedBy",
                schema: "Rules",
                table: "Attributes",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_UpdatedOn",
                schema: "Rules",
                table: "Attributes",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Value",
                schema: "Rules",
                table: "Attributes",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attributes_Version",
                schema: "Rules",
                table: "Attributes",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attributes",
                schema: "Rules");

            migrationBuilder.AlterColumn<string>(
                name: "SlugNormalized",
                schema: "Rules",
                table: "Talents",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);
        }
    }
}
