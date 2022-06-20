﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TtrpgApi.Domain;

#nullable disable

namespace TtrpgApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220616104002_OwnerCorrected")]
    partial class OwnerCorrected
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RoomUser", b =>
                {
                    b.Property<string>("RoomsName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UsersUsername")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("RoomsName", "UsersUsername");

                    b.HasIndex("UsersUsername");

                    b.ToTable("RoomUser");
                });

            modelBuilder.Entity("TtrpgApi.Models.Connection", b =>
                {
                    b.Property<string>("ConnectionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsConnected")
                        .HasColumnType("bit");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ConnectionId");

                    b.HasIndex("Username");

                    b.ToTable("Connections");
                });

            modelBuilder.Entity("TtrpgApi.Models.Room", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TtrpgApi.Models.Text", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Room")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Sender")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Room");

                    b.HasIndex("Sender");

                    b.ToTable("Texts");
                });

            modelBuilder.Entity("TtrpgApi.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Username");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RoomUser", b =>
                {
                    b.HasOne("TtrpgApi.Models.Room", null)
                        .WithMany()
                        .HasForeignKey("RoomsName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TtrpgApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TtrpgApi.Models.Connection", b =>
                {
                    b.HasOne("TtrpgApi.Models.User", null)
                        .WithMany("Connections")
                        .HasForeignKey("Username");
                });

            modelBuilder.Entity("TtrpgApi.Models.Text", b =>
                {
                    b.HasOne("TtrpgApi.Models.Room", null)
                        .WithMany("Texts")
                        .HasForeignKey("Room");

                    b.HasOne("TtrpgApi.Models.User", null)
                        .WithMany("Texts")
                        .HasForeignKey("Sender");
                });

            modelBuilder.Entity("TtrpgApi.Models.Room", b =>
                {
                    b.Navigation("Texts");
                });

            modelBuilder.Entity("TtrpgApi.Models.User", b =>
                {
                    b.Navigation("Connections");

                    b.Navigation("Texts");
                });
#pragma warning restore 612, 618
        }
    }
}
