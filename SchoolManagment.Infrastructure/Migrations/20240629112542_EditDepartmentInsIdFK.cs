using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditDepartmentInsIdFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructor_InsId",
                table: "Departments");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructor_InsId",
                table: "Departments",
                column: "InsId",
                principalTable: "Instructor",
                principalColumn: "InstId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructor_InsId",
                table: "Departments");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructor_InsId",
                table: "Departments",
                column: "InsId",
                principalTable: "Instructor",
                principalColumn: "InstId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
