using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace brunsker_api.Migrations
{
    public partial class CreatedCorretorModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorretorCode",
                table: "imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorretorCode",
                table: "imoveis");
        }
    }
}
