﻿// <auto-generated />
using AgroControl.DBContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace AgroControl.Migrations
{
    [DbContext(typeof(GospodarstwoContext))]
    partial class GospodarstwoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("AgroControl.Models.Gospodarstwo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("text");

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

            modelBuilder.Entity("AgroControl.Models.ObiektGospodarczy", b =>
                {
                    b.HasOne("AgroControl.Models.Gospodarstwo", "Gospodarstwo")
                        .WithMany("ObiektyGospodarcze")
                        .HasForeignKey("GospodarstwoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}