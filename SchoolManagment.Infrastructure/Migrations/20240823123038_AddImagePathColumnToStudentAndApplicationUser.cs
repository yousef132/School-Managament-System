using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathColumnToStudentAndApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "AspNetUsers");


        }
    }
}
