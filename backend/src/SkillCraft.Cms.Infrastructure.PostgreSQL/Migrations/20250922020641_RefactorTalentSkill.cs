using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.PostgreSQL.Migrations
{
    /// <inheritdoc />
    public partial class RefactorTalentSkill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Talents_Skill",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "Skill",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.AddColumn<int>(
                name: "SkillId",
                schema: "Rules",
                table: "Talents",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SkillUid",
                schema: "Rules",
                table: "Talents",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talents_SkillId",
                schema: "Rules",
                table: "Talents",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_SkillUid",
                schema: "Rules",
                table: "Talents",
                column: "SkillUid");

            migrationBuilder.AddForeignKey(
                name: "FK_Talents_Skills_SkillId",
                schema: "Rules",
                table: "Talents",
                column: "SkillId",
                principalSchema: "Rules",
                principalTable: "Skills",
                principalColumn: "SkillId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Talents_Skills_SkillId",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.DropIndex(
                name: "IX_Talents_SkillId",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.DropIndex(
                name: "IX_Talents_SkillUid",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "SkillId",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.DropColumn(
                name: "SkillUid",
                schema: "Rules",
                table: "Talents");

            migrationBuilder.AddColumn<string>(
                name: "Skill",
                schema: "Rules",
                table: "Talents",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Skill",
                schema: "Rules",
                table: "Talents",
                column: "Skill");
        }
    }
}
