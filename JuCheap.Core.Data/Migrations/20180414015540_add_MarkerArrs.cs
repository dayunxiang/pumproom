using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JuCheap.Core.Data.Migrations
{
    public partial class add_MarkerArrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarkerArrs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    air = table.Column<string>(maxLength: 50, nullable: false),
                    airname = table.Column<string>(maxLength: 50, nullable: false),
                    alarm = table.Column<string>(maxLength: 50, nullable: false),
                    alarmname = table.Column<string>(maxLength: 50, nullable: false),
                    elecname = table.Column<string>(maxLength: 50, nullable: false),
                    electricity = table.Column<string>(maxLength: 50, nullable: false),
                    isOnline = table.Column<int>(nullable: false),
                    point = table.Column<string>(maxLength: 50, nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: false),
                    water = table.Column<string>(maxLength: 50, nullable: false),
                    watername = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarkerArrs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarkerArrs");
        }
    }
}
