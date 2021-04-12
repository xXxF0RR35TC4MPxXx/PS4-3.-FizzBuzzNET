﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FizzBuzzNET.Migrations
{
    public partial class InitSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FizzBuzz",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberStr = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Wynik = table.Column<string>(nullable: false),
                    Czas = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FizzBuzz", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FizzBuzz");
        }
    }
}
