using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZPets.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualWeight = table.Column<float>(type: "real", nullable: false),
                    Breed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tutors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tutors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vaccines",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_vaccines_pets_PetId",
                        column: x => x.PetId,
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "weights",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<float>(type: "real", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_weights_pets_PetId",
                        column: x => x.PetId,
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pet_ownership",
                columns: table => new
                {
                    TutorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PetId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pet_ownership", x => new { x.PetId, x.TutorId });
                    table.ForeignKey(
                        name: "FK_pet_ownership_pets_PetId",
                        column: x => x.PetId,
                        principalTable: "pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pet_ownership_tutors_TutorId",
                        column: x => x.TutorId,
                        principalTable: "tutors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_pet_ownership_TutorId",
                table: "pet_ownership",
                column: "TutorId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccines_PetId",
                table: "vaccines",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_weights_PetId",
                table: "weights",
                column: "PetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pet_ownership");

            migrationBuilder.DropTable(
                name: "vaccines");

            migrationBuilder.DropTable(
                name: "weights");

            migrationBuilder.DropTable(
                name: "tutors");

            migrationBuilder.DropTable(
                name: "pets");
        }
    }
}
