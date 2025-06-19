using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.EntityFrameworkCore.PostgreSQL.Migrations.Rules
{
    /// <inheritdoc />
    public partial class CreateTalentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Talents",
                schema: "Rules",
                columns: table => new
                {
                    TalentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Tier = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Summary = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AllowMultiplePurchases = table.Column<bool>(type: "boolean", nullable: false),
                    SkillId = table.Column<int>(type: "integer", nullable: true),
                    SkillUid = table.Column<Guid>(type: "uuid", nullable: true),
                    RequiredTalentId = table.Column<int>(type: "integer", nullable: true),
                    RequiredTalentUid = table.Column<Guid>(type: "uuid", nullable: true),
                    StreamId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talents", x => x.TalentId);
                    table.ForeignKey(
                        name: "FK_Talents_Skills_SkillId",
                        column: x => x.SkillId,
                        principalSchema: "Rules",
                        principalTable: "Skills",
                        principalColumn: "SkillId",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Talents_Talents_RequiredTalentId",
                        column: x => x.RequiredTalentId,
                        principalSchema: "Rules",
                        principalTable: "Talents",
                        principalColumn: "TalentId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talents_AllowMultiplePurchases",
                schema: "Rules",
                table: "Talents",
                column: "AllowMultiplePurchases");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_CreatedBy",
                schema: "Rules",
                table: "Talents",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_CreatedOn",
                schema: "Rules",
                table: "Talents",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Id",
                schema: "Rules",
                table: "Talents",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talents_RequiredTalentId",
                schema: "Rules",
                table: "Talents",
                column: "RequiredTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_RequiredTalentUid",
                schema: "Rules",
                table: "Talents",
                column: "RequiredTalentUid");

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

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Slug",
                schema: "Rules",
                table: "Talents",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talents_StreamId",
                schema: "Rules",
                table: "Talents",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Tier",
                schema: "Rules",
                table: "Talents",
                column: "Tier");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_UpdatedBy",
                schema: "Rules",
                table: "Talents",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_UpdatedOn",
                schema: "Rules",
                table: "Talents",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Version",
                schema: "Rules",
                table: "Talents",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Talents",
                schema: "Rules");
        }
    }
}
