﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mclog_API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER PROCEDURE [dbo].[sp_GetUserStatus] AS SET NOCOUNT ON; SELECT ActivityLogs.Id, Users.Gender, Symptoms.SymptomName, ActivityLogs.Status, ActivityLogs.ActivityDate, Buildings.BuildingName, Buildings.Address FROM ActivityLogs INNER JOIN BuildingLogs ON BuildingLogs.ActivityLogId = ActivityLogs.Id INNER JOIN Buildings ON BuildingLogs.BuildingId = Buildings.id INNER JOIN Users ON Users.Id = ActivityLogs.UserId INNER JOIN UserHealthStatus ON UserHealthStatus.UserId = Users.Id INNER JOIN Symptoms ON UserHealthStatus.Id = Symptoms.UserId");
    
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BirthDate = table.Column<int>(type: "int", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Region = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Baranggay = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHealthStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHealthStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ActivityDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "Symptoms",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   SymptomName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                   UserId = table.Column<int>(type: "int", nullable: false),
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Symptoms", x => x.Id);
               });

            migrationBuilder.CreateTable(
              name: "BuildingLogs",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  ActivityLogId = table.Column<int>(type: "int", nullable: false),
                  BuildingId = table.Column<int>(type: "int", nullable: false),
                  TimeIn = table.Column<DateTime>(type: "datetime", nullable: true),
                  TimeOut = table.Column<DateTime>(type: "datetime", nullable: true)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_BuildingLogs", x => x.Id);
              });

            migrationBuilder.CreateTable(
              name: "Buildings",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false)
                      .Annotation("SqlServer:Identity", "1, 1"),
                  BuildingName = table.Column<string>(type: "nvarchar(255)", nullable: false),
                  Address = table.Column<string>(type: "nvarchar(255)", nullable: false),
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Buildings", x => x.Id);
              });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
            migrationBuilder.DropTable(
                name: "ActivityLogs");
            migrationBuilder.DropTable(
                name: "UserHealthStatus");
            migrationBuilder.DropTable(
                name: "Symptoms");
            migrationBuilder.DropTable(
                name: "Buildings");
            migrationBuilder.DropTable(
                name: "BuildingLogs");
        }
    }
}
