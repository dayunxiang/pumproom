using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JuCheap.Core.Data.Migrations
{
    public partial class gispros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GisPros",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    分区名称 = table.Column<string>(maxLength: 50, nullable: false),
                    坐标 = table.Column<string>(maxLength: 50, nullable: false),
                    备用1 = table.Column<string>(maxLength: 50, nullable: true),
                    备用2 = table.Column<string>(maxLength: 50, nullable: true),
                    备用3 = table.Column<string>(maxLength: 50, nullable: true),
                    备用4 = table.Column<string>(maxLength: 50, nullable: true),
                    报警信息 = table.Column<string>(maxLength: 50, nullable: false),
                    报警信息name = table.Column<string>(maxLength: 50, nullable: false),
                    泵个数 = table.Column<string>(maxLength: 50, nullable: false),
                    泵个数name = table.Column<string>(maxLength: 50, nullable: false),
                    泵表编号 = table.Column<string>(maxLength: 50, nullable: false),
                    状态信息 = table.Column<string>(maxLength: 50, nullable: false),
                    状态信息name = table.Column<string>(maxLength: 50, nullable: false),
                    站点名称 = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GisPros", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GisPros");
        }
    }
}
