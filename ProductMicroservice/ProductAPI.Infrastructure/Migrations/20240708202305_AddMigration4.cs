using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductAPI.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariationvalues_Variation_VariationValueId",
                table: "ProductVariationvalues");

            migrationBuilder.DropForeignKey(
                name: "FK_Variation_CatergoryVariation_CategoryVariationId",
                table: "Variation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Variation",
                table: "Variation");

            migrationBuilder.RenameTable(
                name: "Variation",
                newName: "VariationValue");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "VariationValue",
                newName: "Value");

            migrationBuilder.RenameIndex(
                name: "IX_Variation_CategoryVariationId",
                table: "VariationValue",
                newName: "IX_VariationValue_CategoryVariationId");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "VariationValue",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VariationValue",
                table: "VariationValue",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariationvalues_VariationValue_VariationValueId",
                table: "ProductVariationvalues",
                column: "VariationValueId",
                principalTable: "VariationValue",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VariationValue_CatergoryVariation_CategoryVariationId",
                table: "VariationValue",
                column: "CategoryVariationId",
                principalTable: "CatergoryVariation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductVariationvalues_VariationValue_VariationValueId",
                table: "ProductVariationvalues");

            migrationBuilder.DropForeignKey(
                name: "FK_VariationValue_CatergoryVariation_CategoryVariationId",
                table: "VariationValue");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VariationValue",
                table: "VariationValue");

            migrationBuilder.RenameTable(
                name: "VariationValue",
                newName: "Variation");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Variation",
                newName: "value");

            migrationBuilder.RenameIndex(
                name: "IX_VariationValue_CategoryVariationId",
                table: "Variation",
                newName: "IX_Variation_CategoryVariationId");

            migrationBuilder.AlterColumn<int>(
                name: "value",
                table: "Variation",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Variation",
                table: "Variation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVariationvalues_Variation_VariationValueId",
                table: "ProductVariationvalues",
                column: "VariationValueId",
                principalTable: "Variation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Variation_CatergoryVariation_CategoryVariationId",
                table: "Variation",
                column: "CategoryVariationId",
                principalTable: "CatergoryVariation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
