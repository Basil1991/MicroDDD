﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WebApp.Repos;

namespace WebApp.Repos.Migrations
{
    [DbContext(typeof(WikiDbContext))]
    [Migration("20180301084525_201803011645")]
    partial class _201803011645
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("WebApp.Core.Model.m_Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime>("CreateOn");

                    b.Property<bool>("IsEnable");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("m_Article");
                });

            modelBuilder.Entity("WebApp.Core.Model.m_ArticleComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.Property<DateTime>("CreateOn");

                    b.Property<int?>("m_ArticleId");

                    b.HasKey("Id");

                    b.HasIndex("m_ArticleId");

                    b.ToTable("m_ArticleComment");
                });

            modelBuilder.Entity("WebApp.Core.Model.m_ArticleComment", b =>
                {
                    b.HasOne("WebApp.Core.Model.m_Article")
                        .WithMany("Comments")
                        .HasForeignKey("m_ArticleId");
                });
#pragma warning restore 612, 618
        }
    }
}
