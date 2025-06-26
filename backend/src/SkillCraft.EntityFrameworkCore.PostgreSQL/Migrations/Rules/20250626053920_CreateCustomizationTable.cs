using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.EntityFrameworkCore.PostgreSQL.Migrations.Rules
{
    /// <inheritdoc />
    public partial class CreateCustomizationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customizations",
                schema: "Rules",
                columns: table => new
                {
                    CustomizationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Kind = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Summary = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
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
                    table.PrimaryKey("PK_Customizations", x => x.CustomizationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_CreatedBy",
                schema: "Rules",
                table: "Customizations",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_CreatedOn",
                schema: "Rules",
                table: "Customizations",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_Id",
                schema: "Rules",
                table: "Customizations",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_Kind",
                schema: "Rules",
                table: "Customizations",
                column: "Kind");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_Slug",
                schema: "Rules",
                table: "Customizations",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_StreamId",
                schema: "Rules",
                table: "Customizations",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_UpdatedBy",
                schema: "Rules",
                table: "Customizations",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_UpdatedOn",
                schema: "Rules",
                table: "Customizations",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Customizations_Version",
                schema: "Rules",
                table: "Customizations",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customizations",
                schema: "Rules");
        }
    }
}
