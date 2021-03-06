﻿// <auto-generated />
using Basil.User.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Basil.User.Repository.Migrations
{
    [DbContext(typeof(UserDbContext))]
    partial class UserDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Basil.User.Core.Model.m_Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AllowedGrantTypes")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Description");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("m_Client");
                });

            modelBuilder.Entity("Basil.User.Core.Model.m_ClientScopes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<int?>("m_ClientId");

                    b.HasKey("Id");

                    b.HasIndex("m_ClientId");

                    b.ToTable("m_ClientScopes");
                });

            modelBuilder.Entity("Basil.User.Core.Model.m_Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreateOn");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("m_Role");
                });

            modelBuilder.Entity("Basil.User.Core.Model.m_User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreateOn");

                    b.Property<bool>("Enabled");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("WorkNumber")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("m_User");
                });

            modelBuilder.Entity("Basil.User.Core.Model.m_User_Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<DateTime>("CreateOn");

                    b.Property<int?>("m_RoleId");

                    b.Property<int?>("m_UserId");

                    b.HasKey("Id");

                    b.HasIndex("m_RoleId");

                    b.HasIndex("m_UserId");

                    b.ToTable("m_User_Role");
                });

            modelBuilder.Entity("Basil.User.Core.Model.m_ClientScopes", b =>
                {
                    b.HasOne("Basil.User.Core.Model.m_Client")
                        .WithMany("m_ClientScopes")
                        .HasForeignKey("m_ClientId");
                });

            modelBuilder.Entity("Basil.User.Core.Model.m_User_Role", b =>
                {
                    b.HasOne("Basil.User.Core.Model.m_Role", "m_Role")
                        .WithMany()
                        .HasForeignKey("m_RoleId");

                    b.HasOne("Basil.User.Core.Model.m_User", "m_User")
                        .WithMany()
                        .HasForeignKey("m_UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
