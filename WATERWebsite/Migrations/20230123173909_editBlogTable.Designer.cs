﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WATERWebsite.Presistance;

#nullable disable

namespace WATERWebsite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230123173909_editBlogTable")]
    partial class editBlogTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.Blog", b =>
                {
                    b.Property<int>("BlogCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BlogCode"), 1L, 1);

                    b.Property<string>("BlogBriefA")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("BlogBriefE")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("BlogContentA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogContentE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BlogDate")
                        .HasColumnType("datetime");

                    b.Property<string>("BlogPhoto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BlogPublisherA")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("BlogPublisherE")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("BlogTitleA")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("BlogTitleE")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("BlogCode");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.Division", b =>
                {
                    b.Property<int>("DivisionCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DivisionCode"), 1L, 1);

                    b.Property<string>("DivisionBriefA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DivisionBriefE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DivisionNameA")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("DivisionNameE")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("DivisionCode");

                    b.ToTable("Division");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.DivisionSubServices", b =>
                {
                    b.Property<int>("DivisionCode")
                        .HasColumnType("int");

                    b.Property<int>("SubServiceCode")
                        .HasColumnType("int");

                    b.HasKey("DivisionCode", "SubServiceCode");

                    b.HasIndex("SubServiceCode");

                    b.ToTable("DivisionSubServices");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeCode"), 1L, 1);

                    b.Property<string>("EmployeeCV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeDescriptionA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeDescriptionE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeEmail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EmployeeJobA")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EmployeeJobE")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EmployeeNameA")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EmployeeNameE")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("EmployeePhone")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("EmployeePhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsKey")
                        .HasColumnType("bit");

                    b.HasKey("EmployeeCode");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.Project", b =>
                {
                    b.Property<int>("ProjectCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProjectCode"), 1L, 1);

                    b.Property<long?>("ProjectCapacity")
                        .HasMaxLength(25)
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ProjectDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ProjectDeveloperA")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectDeveloperE")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectLocationA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectLocationE")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectNameA")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectNameE")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectOperatorA")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectOperatorE")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectOverviewA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectOverviewE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectOwnerA")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectOwnerE")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ProjectPhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectCode");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.ProjectServices", b =>
                {
                    b.Property<int>("ProjectCode")
                        .HasColumnType("int");

                    b.Property<int>("ServiceCode")
                        .HasColumnType("int");

                    b.HasKey("ProjectCode", "ServiceCode");

                    b.HasIndex("ServiceCode");

                    b.ToTable("ProjectServices");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.Service", b =>
                {
                    b.Property<int>("ServiceCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ServiceCode"), 1L, 1);

                    b.Property<string>("ServiceBriefA")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ServiceBriefE")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ServiceLogo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceNameA")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ServiceNameE")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ServiceOverviewA")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceOverviewE")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServicePhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ServiceCode");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.ServiceDivisons", b =>
                {
                    b.Property<int>("ServiceCode")
                        .HasColumnType("int");

                    b.Property<int>("DivisionCode")
                        .HasColumnType("int");

                    b.HasKey("ServiceCode", "DivisionCode");

                    b.HasIndex("DivisionCode");

                    b.ToTable("ServiceDivisons");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.SubService", b =>
                {
                    b.Property<int>("SubServiceCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubServiceCode"), 1L, 1);

                    b.Property<string>("SubServiceBriefA")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SubServiceBriefE")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SubServiceNameA")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SubServiceNameE")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SubServiceCode");

                    b.ToTable("SubService");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.DivisionSubServices", b =>
                {
                    b.HasOne("WATERWebsite.Core.Models.Division", "DivisionCodeNavigation")
                        .WithMany("DivisionSubServices")
                        .HasForeignKey("DivisionCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_DivisionSubServices_Division");

                    b.HasOne("WATERWebsite.Core.Models.SubService", "SubServiceCodeNavigation")
                        .WithMany("DivisionSubServices")
                        .HasForeignKey("SubServiceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_DivisionSubServices_SubService");

                    b.Navigation("DivisionCodeNavigation");

                    b.Navigation("SubServiceCodeNavigation");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.ProjectServices", b =>
                {
                    b.HasOne("WATERWebsite.Core.Models.Project", "ProjectCodeNavigation")
                        .WithMany("ProjectServices")
                        .HasForeignKey("ProjectCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_ProjectServices_Project");

                    b.HasOne("WATERWebsite.Core.Models.Service", "ServiceCodeNavigation")
                        .WithMany("ProjectServices")
                        .HasForeignKey("ServiceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_ProjectServices_Service");

                    b.Navigation("ProjectCodeNavigation");

                    b.Navigation("ServiceCodeNavigation");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.ServiceDivisons", b =>
                {
                    b.HasOne("WATERWebsite.Core.Models.Division", "DivisionCodeNavigation")
                        .WithMany("ServiceDivisons")
                        .HasForeignKey("DivisionCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_ServiceDivisions_Division");

                    b.HasOne("WATERWebsite.Core.Models.Service", "ServiceCodeNavigation")
                        .WithMany("ServiceDivisons")
                        .HasForeignKey("ServiceCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("Fk_ServiceDivisions_Service");

                    b.Navigation("DivisionCodeNavigation");

                    b.Navigation("ServiceCodeNavigation");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.Division", b =>
                {
                    b.Navigation("DivisionSubServices");

                    b.Navigation("ServiceDivisons");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.Project", b =>
                {
                    b.Navigation("ProjectServices");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.Service", b =>
                {
                    b.Navigation("ProjectServices");

                    b.Navigation("ServiceDivisons");
                });

            modelBuilder.Entity("WATERWebsite.Core.Models.SubService", b =>
                {
                    b.Navigation("DivisionSubServices");
                });
#pragma warning restore 612, 618
        }
    }
}
