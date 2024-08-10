using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDepartmentDeleteBehaviors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructor_InsId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Departments_DeptId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DeptId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructor_InsId",
                table: "Departments",
                column: "InsId",
                principalTable: "Instructor",
                principalColumn: "InstId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Departments_DeptId",
                table: "Instructor",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DeptId",
                table: "Students",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructor_InsId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructor_Departments_DeptId",
                table: "Instructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DeptId",
                table: "Students");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructor_InsId",
                table: "Departments",
                column: "InsId",
                principalTable: "Instructor",
                principalColumn: "InstId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructor_Departments_DeptId",
                table: "Instructor",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DeptId",
                table: "Students",
                column: "DeptId",
                principalTable: "Departments",
                principalColumn: "DeptId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
