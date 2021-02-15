﻿// <auto-generated />
using System;
using AgroControl.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgroControl.Migrations
{
    [DbContext(typeof(GospodarstwoContext))]
    [Migration("20210214092907_EventDezynfekcja_upd")]
    partial class EventDezynfekcja_upd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AgroControl.Models.AppRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("AgroControl.Models.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasColumnType("character varying(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AgroControl.Models.EventDezynfekcja", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataZabiegu")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<int>("GospodarstwoID")
                        .HasColumnType("integer");

                    b.Property<double>("IloscPrzyrzadzonegoRoztworu")
                        .HasColumnType("double precision");

                    b.Property<double>("IloscUzytegoRoztworu")
                        .HasColumnType("double precision");

                    b.Property<int>("ObiektGospodarczyID")
                        .HasColumnType("integer");

                    b.Property<string>("SrodekDezynfekujacy")
                        .HasColumnType("text");

                    b.Property<int>("ZabiegDlaObiektGospodarczy")
                        .HasColumnType("integer");

                    b.Property<int>("ZabiegDlaSprzetNarzędzia")
                        .HasColumnType("integer");

                    b.Property<int>("ZabiegDlaWejscWyjsc")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ObiektGospodarczyID");

                    b.ToTable("EventsDezynfekcja");
                });

            modelBuilder.Entity("AgroControl.Models.EventPrzegladZabezpieczen", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataPrzegladu")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<int>("GospodarstwoID")
                        .HasColumnType("integer");

                    b.Property<int>("ObiektGospodarczyID")
                        .HasColumnType("integer");

                    b.Property<string>("PodjeteNaprawyBudynek")
                        .HasColumnType("text");

                    b.Property<string>("PodjeteNaprawyMagazynPasz")
                        .HasColumnType("text");

                    b.Property<int>("SzczelnoscBudynku")
                        .HasColumnType("integer");

                    b.Property<int>("SzczelnoscDrzwiWewnętrznychMagazynuPasz")
                        .HasColumnType("integer");

                    b.Property<int>("SzczelnoscDrzwiWewnętrzychBudynku")
                        .HasColumnType("integer");

                    b.Property<int>("SzczelnoscDrzwiZewnetrzychBudynku")
                        .HasColumnType("integer");

                    b.Property<int>("SzczelnoscDrzwiZewnetrzychMagazynuPasz")
                        .HasColumnType("integer");

                    b.Property<int>("SzczelnoscMagazynuPasz")
                        .HasColumnType("integer");

                    b.Property<int>("SzczelnoscOkienBudynku")
                        .HasColumnType("integer");

                    b.Property<int>("SzczelnoscOkienMagazynuPasz")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("EventsPrzegladZabezpieczen");
                });

            modelBuilder.Entity("AgroControl.Models.EventRejestrTransportu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CelWjazdu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataIGodzinaWjazdu")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<int>("GospodarstwoID")
                        .HasColumnType("integer");

                    b.Property<string>("NazwaLubNrRejestracji")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OstatniPobytPojazdu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("EventsRejestrTransportu");
                });

            modelBuilder.Entity("AgroControl.Models.EventRejestrWejscWyjsc", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CelWejscia")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("CzyZastosowanoOchrone")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("DataIGodzinaWejścia")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataOstatniegoPobytu")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<int>("GospodarstwoID")
                        .HasColumnType("integer");

                    b.Property<string>("MiejsceOstatniegoPobytu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NazwaFirmy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NazwaOsobyWchodzacej")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ObiektGospodarczyID")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.HasIndex("ObiektGospodarczyID");

                    b.ToTable("EventsRejestrWejscWyjsc");
                });

            modelBuilder.Entity("AgroControl.Models.EventSpisZwierzat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DataSpisu")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("EventType")
                        .HasColumnType("integer");

                    b.Property<int>("GospodarstwoID")
                        .HasColumnType("integer");

                    b.Property<int>("LiczbaKnurkow")
                        .HasColumnType("integer");

                    b.Property<int>("LiczbaKnurow")
                        .HasColumnType("integer");

                    b.Property<int>("LiczbaLoch")
                        .HasColumnType("integer");

                    b.Property<int>("LiczbaLoszek")
                        .HasColumnType("integer");

                    b.Property<int>("LiczbaProsiat")
                        .HasColumnType("integer");

                    b.Property<int>("LiczbaTucznikow")
                        .HasColumnType("integer");

                    b.Property<int>("LiczbaWarchlakow")
                        .HasColumnType("integer");

                    b.HasKey("ID");

                    b.ToTable("EventsSpisZwierzat");
                });

            modelBuilder.Entity("AgroControl.Models.Gospodarstwo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("UserID")
                        .HasColumnType("integer");

                    b.Property<string>("Wlasciciel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.ToTable("Gospodarstwo");
                });

            modelBuilder.Entity("AgroControl.Models.ObiektGospodarczy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("GospodarstwoID")
                        .HasColumnType("integer");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("GospodarstwoID");

                    b.ToTable("ObiektyGospodarcze");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AgroControl.Models.EventDezynfekcja", b =>
                {
                    b.HasOne("AgroControl.Models.ObiektGospodarczy", "ObiektGospodarczy")
                        .WithMany()
                        .HasForeignKey("ObiektGospodarczyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgroControl.Models.EventRejestrWejscWyjsc", b =>
                {
                    b.HasOne("AgroControl.Models.ObiektGospodarczy", "ObiektGospodarczy")
                        .WithMany()
                        .HasForeignKey("ObiektGospodarczyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgroControl.Models.ObiektGospodarczy", b =>
                {
                    b.HasOne("AgroControl.Models.Gospodarstwo", "Gospodarstwo")
                        .WithMany("ObiektyGospodarcze")
                        .HasForeignKey("GospodarstwoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("AgroControl.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("AgroControl.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("AgroControl.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("AgroControl.Models.AppRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroControl.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("AgroControl.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
