using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicCatalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProviderIdType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_ProviderId1",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ProviderId1",
                table: "Albums");

            migrationBuilder.DropColumn(
                name: "ProviderId1",
                table: "Albums");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderId",
                table: "Albums",
                type: "text",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ProviderId",
                table: "Albums",
                column: "ProviderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_ProviderId",
                table: "Albums",
                column: "ProviderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_AspNetUsers_ProviderId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Albums_ProviderId",
                table: "Albums");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProviderId",
                table: "Albums",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "ProviderId1",
                table: "Albums",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Albums_ProviderId1",
                table: "Albums",
                column: "ProviderId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_AspNetUsers_ProviderId1",
                table: "Albums",
                column: "ProviderId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
