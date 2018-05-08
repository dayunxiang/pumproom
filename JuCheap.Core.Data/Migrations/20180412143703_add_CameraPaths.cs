using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace JuCheap.Core.Data.Migrations
{
    public partial class add_CameraPaths : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CameraPaths",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    CreateDateTime = table.Column<DateTime>(nullable: false),
                    Ip = table.Column<string>(maxLength: 20, nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false),
                    LoginName = table.Column<string>(maxLength: 20, nullable: false),
                    Port = table.Column<string>(maxLength: 10, nullable: false),
                    PumpRoomId = table.Column<string>(maxLength: 36, nullable: true),
                    PumpRoomName = table.Column<string>(maxLength: 20, nullable: false),
                    Pwd = table.Column<string>(maxLength: 20, nullable: false),
                    info = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraPaths", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CameraPaths");
        }
    }
}
