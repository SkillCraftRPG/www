using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class CompleteLanguageTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScriptId",
                schema: "Rules",
                table: "Languages",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ScriptUid",
                schema: "Rules",
                table: "Languages",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TypicalSpeakers",
                schema: "Rules",
                table: "Languages",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ScriptId",
                schema: "Rules",
                table: "Languages",
                column: "ScriptId");

            migrationBuilder.CreateIndex(
                name: "IX_Languages_ScriptUid",
                schema: "Rules",
                table: "Languages",
                column: "ScriptUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Languages_Scripts_ScriptId",
                schema: "Rules",
                table: "Languages",
                column: "ScriptId",
                principalSchema: "Rules",
                principalTable: "Scripts",
                principalColumn: "ScriptId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Languages_Scripts_ScriptId",
                schema: "Rules",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_ScriptId",
                schema: "Rules",
                table: "Languages");

            migrationBuilder.DropIndex(
                name: "IX_Languages_ScriptUid",
                schema: "Rules",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ScriptId",
                schema: "Rules",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "ScriptUid",
                schema: "Rules",
                table: "Languages");

            migrationBuilder.DropColumn(
                name: "TypicalSpeakers",
                schema: "Rules",
                table: "Languages");
        }
    }
}
