using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZPets.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddTutorCreatedPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "tutors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "tutors");
        }
    }
}
