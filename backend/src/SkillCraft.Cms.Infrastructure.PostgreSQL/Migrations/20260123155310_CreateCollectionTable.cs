using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CreateCollectionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collections",
                schema: "Rules",
                columns: table => new
                {
                    CollectionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    Key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    KeyNormalized = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
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
                    table.PrimaryKey("PK_Collections", x => x.CollectionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CreatedBy",
                schema: "Rules",
                table: "Collections",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CreatedOn",
                schema: "Rules",
                table: "Collections",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Id",
                schema: "Rules",
                table: "Collections",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_IsPublished",
                schema: "Rules",
                table: "Collections",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Key",
                schema: "Rules",
                table: "Collections",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_KeyNormalized",
                schema: "Rules",
                table: "Collections",
                column: "KeyNormalized",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Name",
                schema: "Rules",
                table: "Collections",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_StreamId",
                schema: "Rules",
                table: "Collections",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UpdatedBy",
                schema: "Rules",
                table: "Collections",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UpdatedOn",
                schema: "Rules",
                table: "Collections",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_Version",
                schema: "Rules",
                table: "Collections",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collections",
                schema: "Rules");
        }
    }
}
