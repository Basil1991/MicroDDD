using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WebApp.Repos.Migrations
{
    public partial class _201803011645 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "m_ArticleComment",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreateOn",
                table: "m_ArticleComment",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
