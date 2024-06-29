using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditSubIdFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Subjects_StudId",
                table: "DepartmentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_DepartmentSubjects_StudId",
                table: "DepartmentSubjects");

            migrationBuilder.DropColumn(
                name: "StudId",
                table: "DepartmentSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubId",
                table: "DepartmentSubjects",
                column: "SubId",
                principalTable: "Subjects",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentSubjects_Subjects_SubId",
                table: "DepartmentSubjects");

            migrationBuilder.AddColumn<int>(
                name: "StudId",
                table: "DepartmentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentSubjects_StudId",
                table: "DepartmentSubjects",
                column: "StudId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentSubjects_Subjects_StudId",
                table: "DepartmentSubjects",
                column: "StudId",
                principalTable: "Subjects",
                principalColumn: "SubId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
