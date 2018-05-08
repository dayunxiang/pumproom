using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JuCheap.Core.Data.Migrations
{
    public partial class add_stations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stations",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    分区内排序 = table.Column<int>(nullable: false),
                    分区名称 = table.Column<string>(maxLength: 25, nullable: false),
                    分区类型 = table.Column<string>(maxLength: 20, nullable: false),
                    站点全名 = table.Column<string>(maxLength: 35, nullable: true),
                    站点名称 = table.Column<string>(maxLength: 35, nullable: false),
                    站点类型 = table.Column<string>(maxLength: 20, nullable: false),
                    站点编号 = table.Column<string>(maxLength: 20, nullable: false),
                    编号 = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stations");
        }
    }
}
