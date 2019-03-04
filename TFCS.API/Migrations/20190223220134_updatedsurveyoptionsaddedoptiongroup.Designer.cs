﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TFCS.API.DomainModels.Entities;

namespace TFCS.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190223220134_updatedsurveyoptionsaddedoptiongroup")]
    partial class updatedsurveyoptionsaddedoptiongroup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<string>("LogoImagePath")
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(100)")
                        .HasMaxLength(100);

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.CompanyEmployee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<int>("Id");

                    b.HasKey("EmployeeId");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.ToTable("CompanyEmployee");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.CompanySurveyCatItem", b =>
                {
                    b.Property<int>("SurveyCatId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SurveyId");

                    b.HasKey("SurveyCatId");

                    b.ToTable("CompanySurveyCatItems");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.StandardMenuItem", b =>
                {
                    b.Property<int>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("MenuItemId");

                    b.ToTable("StandardMenuItems");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.Survey", b =>
                {
                    b.Property<int>("SurveyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Active");

                    b.Property<int>("CompanyId");

                    b.Property<string>("SurveyFooterText")
                        .HasColumnType("VARCHAR(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("SurveyIntro")
                        .HasColumnType("VARCHAR(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("SurveyTypeId");

                    b.HasKey("SurveyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("SurveyTypeId");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyMenuItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuItemId");

                    b.Property<string>("Name");

                    b.Property<int>("SurveyId");

                    b.HasKey("ItemId");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyMenuItems");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyOption", b =>
                {
                    b.Property<int>("OptionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OptionGroup");

                    b.Property<string>("OptionName")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<int>("OptionOrder");

                    b.Property<int>("OptionTypeId");

                    b.Property<int>("QuestionId");

                    b.HasKey("OptionId");

                    b.HasIndex("OptionTypeId");

                    b.HasIndex("QuestionId");

                    b.ToTable("SurveyOptions");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyOptionType", b =>
                {
                    b.Property<int>("OptionTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("OptionTypeId");

                    b.ToTable("SurveyOptionTypes");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyQuestion", b =>
                {
                    b.Property<int>("QuestionId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("QuestionName")
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<int>("QuestionOrder");

                    b.Property<string>("QuestionType")
                        .HasColumnType("VARCHAR(25)")
                        .HasMaxLength(25);

                    b.Property<bool>("Required");

                    b.Property<string>("ShortQuestionName")
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<int>("SurveyId");

                    b.Property<int>("SurveyTypeId");

                    b.HasKey("QuestionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyQuestions");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyResponse", b =>
                {
                    b.Property<int>("ResponseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateEntered")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<int>("OptionId");

                    b.Property<string>("SavedValue")
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<int>("SurveyId");

                    b.HasKey("ResponseId");

                    b.HasIndex("OptionId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyResponses");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyType", b =>
                {
                    b.Property<int>("SurveyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("SurveyTypeId");

                    b.ToTable("SurveyTypes");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<bool>("Active");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("Lastactive");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.UserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId");

                    b.Property<string>("CustCellPhone")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CustHomePhone")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerEmail")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("CustomerName")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<int>("MakeId");

                    b.Property<int>("ModelId");

                    b.Property<string>("Vin")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Year");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.VehicleMake", b =>
                {
                    b.Property<int>("MakeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("MakeId");

                    b.ToTable("VehicleMakes");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.VehicleModel", b =>
                {
                    b.Property<int>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("ModelId");

                    b.ToTable("VehicleModels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.CompanyEmployee", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.User")
                        .WithOne("CompanyEmployee")
                        .HasForeignKey("TFCS.API.DomainModels.Entities.CompanyEmployee", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.Survey", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.Company", "Company")
                        .WithMany("Surveys")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TFCS.API.DomainModels.Entities.SurveyType", "SurveyTypes")
                        .WithMany("Surveys")
                        .HasForeignKey("SurveyTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyMenuItem", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.StandardMenuItem", "StandardMenuItems")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TFCS.API.DomainModels.Entities.Survey")
                        .WithMany("SurveyMenuItems")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyOption", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.SurveyOptionType", "SurveyOptionType")
                        .WithMany()
                        .HasForeignKey("OptionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TFCS.API.DomainModels.Entities.SurveyQuestion", "SurveyQuestion")
                        .WithMany("SurveyOptions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyQuestion", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.Survey", "Survey")
                        .WithMany("SurveyQuestions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.SurveyResponse", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.SurveyOption", "SurveyOption")
                        .WithMany("SurveyResponse")
                        .HasForeignKey("OptionId");

                    b.HasOne("TFCS.API.DomainModels.Entities.Survey", "Survey")
                        .WithMany("SurveyResponse")
                        .HasForeignKey("SurveyId");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.User", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("TFCS.API.DomainModels.Entities.UserRole", b =>
                {
                    b.HasOne("TFCS.API.DomainModels.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TFCS.API.DomainModels.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
