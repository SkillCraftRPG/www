using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkillCraft.Cms.Infrastructure.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class CreateTalentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cms");

            migrationBuilder.CreateTable(
                name: "Talents",
                schema: "Cms",
                columns: table => new
                {
                    TalentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    AllowMultiplePurchases = table.Column<bool>(type: "bit", nullable: false),
                    Skill = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    RequiredTalentId = table.Column<int>(type: "int", nullable: true),
                    RequiredTalentUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreamId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Talents", x => x.TalentId);
                    table.ForeignKey(
                        name: "FK_Talents_Talents_RequiredTalentId",
                        column: x => x.RequiredTalentId,
                        principalSchema: "Cms",
                        principalTable: "Talents",
                        principalColumn: "TalentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Talents_AllowMultiplePurchases",
                schema: "Cms",
                table: "Talents",
                column: "AllowMultiplePurchases");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_CreatedBy",
                schema: "Cms",
                table: "Talents",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_CreatedOn",
                schema: "Cms",
                table: "Talents",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Id",
                schema: "Cms",
                table: "Talents",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talents_IsPublished",
                schema: "Cms",
                table: "Talents",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Name",
                schema: "Cms",
                table: "Talents",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_RequiredTalentId",
                schema: "Cms",
                table: "Talents",
                column: "RequiredTalentId");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_RequiredTalentUid",
                schema: "Cms",
                table: "Talents",
                column: "RequiredTalentUid");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Skill",
                schema: "Cms",
                table: "Talents",
                column: "Skill");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Slug",
                schema: "Cms",
                table: "Talents",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_StreamId",
                schema: "Cms",
                table: "Talents",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Summary",
                schema: "Cms",
                table: "Talents",
                column: "Summary");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Tier",
                schema: "Cms",
                table: "Talents",
                column: "Tier");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_UpdatedBy",
                schema: "Cms",
                table: "Talents",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_UpdatedOn",
                schema: "Cms",
                table: "Talents",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Talents_Version",
                schema: "Cms",
                table: "Talents",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Talents",
                schema: "Cms");
        }
    }
}
