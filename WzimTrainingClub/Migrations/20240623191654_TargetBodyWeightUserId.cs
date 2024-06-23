using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WzimTrainingClub.Migrations
{
    /// <inheritdoc />
    public partial class TargetBodyWeightUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TargetBodyweights_AspNetUsers_UserId",
                table: "TargetBodyweights");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TargetBodyweights",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TargetBodyweights_AspNetUsers_UserId",
                table: "TargetBodyweights",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TargetBodyweights_AspNetUsers_UserId",
                table: "TargetBodyweights");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "TargetBodyweights",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_TargetBodyweights_AspNetUsers_UserId",
                table: "TargetBodyweights",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
