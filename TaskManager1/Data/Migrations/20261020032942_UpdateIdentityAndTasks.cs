using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskManager1.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateIdentityAndTasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Task",
                newName: "SKUs");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Task",
                newName: "EmployeeAssigned");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Task",
                newName: "TaskId");

            migrationBuilder.AddColumn<string>(
                name: "Bin",
                table: "Task",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Task",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bin",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Task");

            migrationBuilder.RenameColumn(
                name: "SKUs",
                table: "Task",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "EmployeeAssigned",
                table: "Task",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "TaskId",
                table: "Task",
                newName: "Id");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "Task",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Task",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
