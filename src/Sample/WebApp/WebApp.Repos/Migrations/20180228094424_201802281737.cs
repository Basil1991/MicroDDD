using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApp.Repos.Migrations
{
    public partial class _201802281737 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "m_Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    IsEnable = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Url = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "m_ArticleComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(maxLength: 2000, nullable: false),
                    CreateOn = table.Column<string>(nullable: false),
                    m_ArticleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_ArticleComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_m_ArticleComment_m_Article_m_ArticleId",
                        column: x => x.m_ArticleId,
                        principalTable: "m_Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_m_ArticleComment_m_ArticleId",
                table: "m_ArticleComment",
                column: "m_ArticleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "m_ArticleComment");

            migrationBuilder.DropTable(
                name: "m_Article");
        }
    }
}
