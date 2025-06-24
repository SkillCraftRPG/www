using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SkillCraft.EntityFrameworkCore.PostgreSQL.Migrations.Rules
{
    /// <inheritdoc />
    public partial class CreateStatisticTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statistics",
                schema: "Rules",
                columns: table => new
                {
                    StatisticId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Summary = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AttributeId = table.Column<int>(type: "integer", nullable: true),
                    AttributeUid = table.Column<Guid>(type: "uuid", nullable: true),
                    StreamId = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Version = table.Column<long>(type: "bigint", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedBy = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.StatisticId);
                    table.ForeignKey(
                        name: "FK_Statistics_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalSchema: "Rules",
                        principalTable: "Attributes",
                        principalColumn: "AttributeId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_AttributeId",
                schema: "Rules",
                table: "Statistics",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_AttributeUid",
                schema: "Rules",
                table: "Statistics",
                column: "AttributeUid");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_CreatedBy",
                schema: "Rules",
                table: "Statistics",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_CreatedOn",
                schema: "Rules",
                table: "Statistics",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Id",
                schema: "Rules",
                table: "Statistics",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Slug",
                schema: "Rules",
                table: "Statistics",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_StreamId",
                schema: "Rules",
                table: "Statistics",
                column: "StreamId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UpdatedBy",
                schema: "Rules",
                table: "Statistics",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_UpdatedOn",
                schema: "Rules",
                table: "Statistics",
                column: "UpdatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Value",
                schema: "Rules",
                table: "Statistics",
                column: "Value",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_Version",
                schema: "Rules",
                table: "Statistics",
                column: "Version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics",
                schema: "Rules");
        }
    }
}
