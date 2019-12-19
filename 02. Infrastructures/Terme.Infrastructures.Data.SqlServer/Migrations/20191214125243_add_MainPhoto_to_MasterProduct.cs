using Microsoft.EntityFrameworkCore.Migrations;

namespace Terme.Infrastructures.Data.SqlServer.Migrations
{
    public partial class add_MainPhoto_to_MasterProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "MainPhotoId",
                table: "MasterProducts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MasterProducts_MainPhotoId",
                table: "MasterProducts",
                column: "MainPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_MasterProducts_Photos_MainPhotoId",
                table: "MasterProducts",
                column: "MainPhotoId",
                principalTable: "Photos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MasterProducts_Photos_MainPhotoId",
                table: "MasterProducts");

            migrationBuilder.DropIndex(
                name: "IX_MasterProducts_MainPhotoId",
                table: "MasterProducts");

            migrationBuilder.DropColumn(
                name: "MainPhotoId",
                table: "MasterProducts");
        }
    }
}
