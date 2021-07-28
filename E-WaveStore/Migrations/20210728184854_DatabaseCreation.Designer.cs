﻿// <auto-generated />
using System;
using E_WaveStore.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_WaveStore.Migrations
{
    [DbContext(typeof(StoreDbContext))]
    [Migration("20210728184854_DatabaseCreation")]
    partial class DatabaseCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Keyboard", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("BackLight")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BrandName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ConnectionType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Dimension")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("KeysAmount")
                        .HasColumnType("int");

                    b.Property<string>("Layout")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Keyboards");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Laptop", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CoreAmount")
                        .HasColumnType("int");

                    b.Property<string>("Cpu")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("DisplayDiagonal")
                        .HasColumnType("real");

                    b.Property<string>("DisplayResolution")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Hdd")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OperationalSystem")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Ram")
                        .HasColumnType("int");

                    b.Property<string>("Ssd")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Laptops");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Monitor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Dimension")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("DisplayDiagonal")
                        .HasColumnType("real");

                    b.Property<string>("DisplayResolution")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MonitorcInterface")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("PowerConsumption")
                        .HasColumnType("float");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Monitors");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.MonoBlock", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cpu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Dimension")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("DisplayDiagonal")
                        .HasColumnType("real");

                    b.Property<string>("DisplayResolution")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Hdd")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MonoBlockInterface")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("OperationalSystem")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Ram")
                        .HasColumnType("int");

                    b.Property<string>("RamType")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("VideoCard")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("VideoMemorySize")
                        .HasColumnType("int");

                    b.Property<bool?>("WebCamera")
                        .HasColumnType("bit");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("MonoBlocks");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Mouse", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("BackLight")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BrandName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("ButtonAmount")
                        .HasColumnType("int");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Connection")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OpticalResolution")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Mice");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.SmartWatch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<bool>("Bluetooth")
                        .HasColumnType("bit");

                    b.Property<string>("BodyMaterial")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BraceletMaterial")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BrandName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Sensor")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<bool>("Wifi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SmartWatches");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Tv", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("DisplayDiagonal")
                        .HasColumnType("real");

                    b.Property<string>("DisplayResolution")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Platform")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<bool>("Smart")
                        .HasColumnType("bit");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.Property<bool>("Wifi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Tvs");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.UserDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserDbs");
                });

            modelBuilder.Entity("E_WaveStore.Entity.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("E_WaveStore.Entity.Phone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<int>("BatteryCapacity")
                        .HasColumnType("int");

                    b.Property<string>("BodyMaterial")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BrandName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("BuiltMemory")
                        .HasColumnType("int");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CoreAmount")
                        .HasColumnType("int");

                    b.Property<string>("Cpu")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("DisplayDiagonal")
                        .HasColumnType("real");

                    b.Property<string>("DisplayResolution")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("FaceRecognition")
                        .HasColumnType("bit");

                    b.Property<string>("FrontCamera")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainCamera")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ModelName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NavSystem")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Nfc")
                        .HasColumnType("bit");

                    b.Property<string>("OperatingSystem")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Ram")
                        .HasColumnType("int");

                    b.Property<int>("SimAmount")
                        .HasColumnType("int");

                    b.Property<string>("SimType")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UsbPort")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Phones");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Keyboard", b =>
                {
                    b.HasOne("E_WaveStore.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Laptop", b =>
                {
                    b.HasOne("E_WaveStore.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Monitor", b =>
                {
                    b.HasOne("E_WaveStore.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.MonoBlock", b =>
                {
                    b.HasOne("E_WaveStore.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Mouse", b =>
                {
                    b.HasOne("E_WaveStore.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.SmartWatch", b =>
                {
                    b.HasOne("E_WaveStore.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_WaveStore.DataLayer.Entity.Tv", b =>
                {
                    b.HasOne("E_WaveStore.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_WaveStore.Entity.Phone", b =>
                {
                    b.HasOne("E_WaveStore.Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}