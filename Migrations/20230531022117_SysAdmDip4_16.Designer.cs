﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SysAdmDip4.Data;

#nullable disable

namespace SysAdmDip4.Migrations
{
    [DbContext(typeof(SysAdmDip4Context))]
    [Migration("20230531022117_SysAdmDip4_16")]
    partial class SysAdmDip4_16
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SysAdmDip4.Models.Article.Classify", b =>
                {
                    b.Property<int>("Classify_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Classify_Id"));

                    b.Property<string>("Classify_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Knowlege_Id")
                        .HasColumnType("int");

                    b.HasKey("Classify_Id");

                    b.HasIndex("Knowlege_Id");

                    b.ToTable("Classify");
                });

            modelBuilder.Entity("SysAdmDip4.Models.Article.Comment", b =>
                {
                    b.Property<int>("Comment_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Comment_Id"));

                    b.Property<string>("Comment_AuthorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment_Characteristic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment_Text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Knowlege_Id")
                        .HasColumnType("int");

                    b.HasKey("Comment_Id");

                    b.HasIndex("Knowlege_Id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("SysAdmDip4.Models.Article.Knowlege", b =>
                {
                    b.Property<int>("Knowlege_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Knowlege_Id"));

                    b.Property<string>("Knowlege_Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Knowlege_Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Knowlege_CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Knowlege_CreaterId")
                        .HasColumnType("int");

                    b.Property<string>("Knowlege_FileSrc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Knowlege_Introduction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Knowlege_Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Knowlege_Transparency")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Knowlege_Id");

                    b.ToTable("Knowlege");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.ExternalLink", b =>
                {
                    b.Property<int>("Link_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Link_Id"));

                    b.Property<DateTime?>("Link_CreateDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<bool?>("Link_IsActive")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Link_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link_Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Link_Id");

                    b.ToTable("ExternalLink");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.Function", b =>
                {
                    b.Property<int>("Function_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Function_Id"));

                    b.Property<int?>("Function_Active")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Function_Controller")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Function_CreateDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<int?>("Function_CreaterId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Function_Describe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Function_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Function_Page")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Function_Id");

                    b.ToTable("Function");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.Member", b =>
                {
                    b.Property<int>("Member_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Member_Id"));

                    b.Property<string>("Member_Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Member_Active")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<DateTime?>("Member_CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Member_CreaterId")
                        .HasColumnType("int");

                    b.Property<string>("Member_Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Member_Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Member_RoleId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Member_Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.MemberKnowlege", b =>
                {
                    b.Property<int>("MemberKnowlege_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberKnowlege_Id"));

                    b.Property<int?>("KnowlegeId")
                        .HasColumnType("int");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int");

                    b.Property<string>("MemberKnowlege_Characteristic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MemberKnowlege_Id");

                    b.HasIndex("MemberId");

                    b.ToTable("MemberKnowlege");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.Role", b =>
                {
                    b.Property<int>("Role_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Role_Id"));

                    b.Property<string>("Role_Describe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Role_FunctionIdCount")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Role_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Role_Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.RoleFunction", b =>
                {
                    b.Property<int>("RoleFunction_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleFunction_Id"));

                    b.Property<int>("FunctionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("RoleFunction_Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleFunction");
                });

            modelBuilder.Entity("SysAdmDip4.Models.Article.Classify", b =>
                {
                    b.HasOne("SysAdmDip4.Models.Article.Knowlege", "Knowlege")
                        .WithMany("Knowlege_Classify")
                        .HasForeignKey("Knowlege_Id");

                    b.Navigation("Knowlege");
                });

            modelBuilder.Entity("SysAdmDip4.Models.Article.Comment", b =>
                {
                    b.HasOne("SysAdmDip4.Models.Article.Knowlege", "Knowlege")
                        .WithMany("Knowlege_Comment")
                        .HasForeignKey("Knowlege_Id");

                    b.Navigation("Knowlege");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.MemberKnowlege", b =>
                {
                    b.HasOne("SysAdmDip4.Models.System.Member", "Member")
                        .WithMany("MemberKnowlege")
                        .HasForeignKey("MemberId");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.RoleFunction", b =>
                {
                    b.HasOne("SysAdmDip4.Models.System.Role", "Role")
                        .WithMany("RoleFunctions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("SysAdmDip4.Models.Article.Knowlege", b =>
                {
                    b.Navigation("Knowlege_Classify");

                    b.Navigation("Knowlege_Comment");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.Member", b =>
                {
                    b.Navigation("MemberKnowlege");
                });

            modelBuilder.Entity("SysAdmDip4.Models.System.Role", b =>
                {
                    b.Navigation("RoleFunctions");
                });
#pragma warning restore 612, 618
        }
    }
}
