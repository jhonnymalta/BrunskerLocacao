﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using brunsker_api.data;

#nullable disable

namespace brunsker_api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220715132055_CreatedCorretorModels")]
    partial class CreatedCorretorModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("brunsker_api.models.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Banheiros")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("CorretorCode")
                        .HasColumnType("int");

                    b.Property<int>("Garagem")
                        .HasColumnType("int");

                    b.Property<double>("ValorImovel")
                        .HasColumnType("double");

                    b.Property<int>("quartos")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("imoveis");
                });
#pragma warning restore 612, 618
        }
    }
}
