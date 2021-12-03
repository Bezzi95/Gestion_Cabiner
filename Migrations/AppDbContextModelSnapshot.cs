﻿// <auto-generated />
using System;
using CabinetWebAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CabinetWebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CabinetWebAPI.Model.Consultation", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_Consult")
                        .HasColumnType("datetime2");

                    b.Property<int>("Medecinid")
                        .HasColumnType("int");

                    b.Property<int>("Patientid")
                        .HasColumnType("int");

                    b.Property<string>("resultat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Medecinid");

                    b.HasIndex("Patientid");

                    b.ToTable("Consultations");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Medcine", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sexeid")
                        .HasColumnType("int");

                    b.Property<int>("Specialiteid")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Villeid")
                        .HasColumnType("int");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("Sexeid");

                    b.HasIndex("Specialiteid");

                    b.HasIndex("Villeid");

                    b.ToTable("Medcines");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Patient", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date_naiss")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("prenom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Rendez_vous", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date_rendez_vous")
                        .HasColumnType("datetime2");

                    b.Property<int>("Medcineid")
                        .HasColumnType("int");

                    b.Property<int>("Patientid")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Medcineid");

                    b.HasIndex("Patientid");

                    b.ToTable("Rendez_Vous");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Sexe", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Sexes");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Specialite", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Specialites");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Ville", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Villes");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Consultation", b =>
                {
                    b.HasOne("CabinetWebAPI.Model.Medcine", "Medecin")
                        .WithMany("Consultations")
                        .HasForeignKey("Medecinid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CabinetWebAPI.Model.Patient", "Patient")
                        .WithMany("Consultations")
                        .HasForeignKey("Patientid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medecin");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Medcine", b =>
                {
                    b.HasOne("CabinetWebAPI.Model.Sexe", "Sexe")
                        .WithMany("Medcines")
                        .HasForeignKey("Sexeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CabinetWebAPI.Model.Specialite", "Specialite")
                        .WithMany("Medcines")
                        .HasForeignKey("Specialiteid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CabinetWebAPI.Model.Ville", "Ville")
                        .WithMany("Medcines")
                        .HasForeignKey("Villeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sexe");

                    b.Navigation("Specialite");

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Rendez_vous", b =>
                {
                    b.HasOne("CabinetWebAPI.Model.Medcine", "Medcine")
                        .WithMany()
                        .HasForeignKey("Medcineid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CabinetWebAPI.Model.Patient", "Patient")
                        .WithMany("Rendez_vouss")
                        .HasForeignKey("Patientid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medcine");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Medcine", b =>
                {
                    b.Navigation("Consultations");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Patient", b =>
                {
                    b.Navigation("Consultations");

                    b.Navigation("Rendez_vouss");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Sexe", b =>
                {
                    b.Navigation("Medcines");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Specialite", b =>
                {
                    b.Navigation("Medcines");
                });

            modelBuilder.Entity("CabinetWebAPI.Model.Ville", b =>
                {
                    b.Navigation("Medcines");
                });
#pragma warning restore 612, 618
        }
    }
}
