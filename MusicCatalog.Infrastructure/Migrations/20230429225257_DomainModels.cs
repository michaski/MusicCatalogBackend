using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicCatalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DomainModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlbumTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Artist = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false),
                    TypeId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProviderId1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Albums_AlbumTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AlbumTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Albums_AspNetUsers_ProviderId1",
                        column: x => x.ProviderId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tracks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Artist = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    ReleaseYear = table.Column<int>(type: "integer", nullable: false),
                    DurationMinutes = table.Column<int>(type: "integer", nullable: false),
                    DurationSeconds = table.Column<int>(type: "integer", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tracks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tracks_Albums_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "Albums",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AlbumTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1057aa4e-0df2-461b-bbba-60e8f89b32fc"), "LP" },
                    { new Guid("28504f78-b082-4707-bbf2-8672ea4eb804"), "Medley" },
                    { new Guid("52313e19-3a1e-4a4f-97b4-61f7ae1d54ba"), "Studio" },
                    { new Guid("613d74a9-0bf7-400a-9311-1957478761e9"), "EP" },
                    { new Guid("73c89b72-e3f4-4189-b026-1a4836d41f14"), "Live" },
                    { new Guid("7fe8237b-01b9-4ac7-8572-2badccaa28d1"), "Soundtrack" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ProviderId1",
                table: "Albums",
                column: "ProviderId1");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_TypeId",
                table: "Albums",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_AlbumId",
                table: "Tracks",
                column: "AlbumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tracks");

            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "AlbumTypes");
        }
    }
}
