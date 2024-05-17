﻿// <auto-generated />
using System;
using Crm.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Crm.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240517122450_CreatedAtNotNull")]
    partial class CreatedAtNotNull
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Crm.Domain.Entities.Atendimento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MotivoId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("SubstatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MotivoId");

                    b.HasIndex("StatusId");

                    b.HasIndex("SubstatusId");

                    b.ToTable("Atendimentos");
                });

            modelBuilder.Entity("Crm.Domain.Entities.Motivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motivos");
                });

            modelBuilder.Entity("Crm.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFinisher")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("Crm.Domain.Entities.StatusSubstatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("SubstatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.HasIndex("SubstatusId");

                    b.ToTable("StatusSubstatus");
                });

            modelBuilder.Entity("Crm.Domain.Entities.Substatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Substatus");
                });

            modelBuilder.Entity("Crm.Domain.Entities.Atendimento", b =>
                {
                    b.HasOne("Crm.Domain.Entities.Motivo", "Motivo")
                        .WithMany("Atendimentos")
                        .HasForeignKey("MotivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Entities.Status", "Status")
                        .WithMany("Atendimentos")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Entities.Substatus", "Substatus")
                        .WithMany("Atendimentos")
                        .HasForeignKey("SubstatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Motivo");

                    b.Navigation("Status");

                    b.Navigation("Substatus");
                });

            modelBuilder.Entity("Crm.Domain.Entities.StatusSubstatus", b =>
                {
                    b.HasOne("Crm.Domain.Entities.Status", "Status")
                        .WithMany("StatusSubstatuses")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Crm.Domain.Entities.Substatus", "Substatus")
                        .WithMany("StatusSubstatuses")
                        .HasForeignKey("SubstatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("Substatus");
                });

            modelBuilder.Entity("Crm.Domain.Entities.Motivo", b =>
                {
                    b.Navigation("Atendimentos");
                });

            modelBuilder.Entity("Crm.Domain.Entities.Status", b =>
                {
                    b.Navigation("Atendimentos");

                    b.Navigation("StatusSubstatuses");
                });

            modelBuilder.Entity("Crm.Domain.Entities.Substatus", b =>
                {
                    b.Navigation("Atendimentos");

                    b.Navigation("StatusSubstatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
