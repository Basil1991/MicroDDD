using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Basil.User.Repository.Migrations
{
    public partial class _1221723 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_User_Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreateBy = table.Column<string>(maxLength: 200, nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    m_RoleId = table.Column<int>(nullable: true),
                    m_UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_User_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK_m_User_Role_m_Role_m_RoleId",
                        column: x => x.m_RoleId,
                        principalTable: "m_Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_m_User_Role_m_User_m_UserId",
                        column: x => x.m_UserId,
                        principalTable: "m_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_User_Role_m_RoleId",
                table: "m_User_Role",
                column: "m_RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_m_User_Role_m_UserId",
                table: "m_User_Role",
                column: "m_UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_User_Role");
        }
    }
}
