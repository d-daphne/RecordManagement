using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodPressureMeasurementApplication.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionId);
                });

            migrationBuilder.CreateTable(
                name: "BloodPressures",
                columns: table => new
                {
                    BPId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodPressures", x => x.BPId);
                    table.ForeignKey(
                        name: "FK_BloodPressures_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "PositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "PositionId", "PositionName" },
                values: new object[,]
                {
                    { 1, "Standing" },
                    { 2, "Sitting" },
                    { 3, "Lying down" }
                });

            migrationBuilder.InsertData(
                table: "BloodPressures",
                columns: new[] { "BPId", "Date", "Diastolic", "PositionId", "Systolic" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 1, 120 },
                    { 2, new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 2, 110 },
                    { 3, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 3, 100 },
                    { 4, new DateTime(2024, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 2, 90 },
                    { 5, new DateTime(2024, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 1, 95 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodPressures_PositionId",
                table: "BloodPressures",
                column: "PositionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodPressures");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
