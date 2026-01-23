using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateArticleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                schema: "Rules",
                columns: table => new
                {
                    ArticleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CollectionId = table.Column<int>(type: "integer", nullable: true),
                    CollectionUid = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentId = table.Column<int>(type: "integer", nullable: true),
                    ParentUid = table.Column<Guid>(type: "uuid", nullable: true),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    SlugNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    MetaDescription = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    HtmlContent = table.Column<string>(type: "text", nullable: true),
                    StreamId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                    table.ForeignKey(
                        name: "FK_Articles_Articles_ParentId",
                        column: x => x.ParentId,
                        principalSchema: "Rules",
                        principalTable: "Articles",
                        principalColumn: "ArticleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Articles_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalSchema: "Rules",
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CollectionId",
                schema: "Rules",
                table: "Articles",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CollectionUid",
                schema: "Rules",
                table: "Articles",
                column: "CollectionUid");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatedBy",
                schema: "Rules",
                table: "Articles",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CreatedOn",
                schema: "Rules",
                table: "Articles",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Id",
                schema: "Rules",
                table: "Articles",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IsPublished",
                schema: "Rules",
                table: "Articles",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ParentId",
                schema: "Rules",
                table: "Articles",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_ParentUid",
                schema: "Rules",
                table: "Articles",
                column: "ParentUid");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Slug",
                schema: "Rules",
                table: "Articles",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_SlugNormalized",
                schema: "Rules",
                table: "Articles",
                column: "SlugNormalized");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_StreamId",
                schema: "Rules",
                table: "Articles",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Title",
                schema: "Rules",
                table: "Articles",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UpdatedBy",
                schema: "Rules",
                table: "Articles",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UpdatedOn",
                schema: "Rules",
                table: "Articles",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_Version",
                schema: "Rules",
                table: "Articles",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles",
                schema: "Rules");
        }
    }
}
