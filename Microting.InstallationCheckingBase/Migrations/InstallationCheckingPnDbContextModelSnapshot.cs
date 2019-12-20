﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microting.InstallationCheckingBase.Infrastructure.Data;

namespace Microting.InstallationCheckingBase.Migrations
{
    [DbContext(typeof(InstallationCheckingPnDbContext))]
    partial class InstallationCheckingPnDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            string autoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object autoIdGenStrategyValue = SqlServerValueGenerationStrategy.IdentityColumn;
            if (DbConfig.IsMySQL)
            {
                autoIdGenStrategy = "MySql:ValueGenerationStrategy";
                autoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.Installation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("CadastralNumber");

                    b.Property<string>("CadastralType");

                    b.Property<string>("CityName");

                    b.Property<string>("CompanyAddress");

                    b.Property<string>("CompanyAddress2");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CountryCode");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime?>("DateActRemove");

                    b.Property<DateTime?>("DateInstall");

                    b.Property<DateTime?>("DateRemove");

                    b.Property<int?>("InstallationEmployeeId");

                    b.Property<string>("InstallationImageName");

                    b.Property<int?>("InstallationSdkCaseId");

                    b.Property<int?>("LivingFloorsNumber");

                    b.Property<string>("PropertyNumber");

                    b.Property<int?>("RemovalEmployeeId");

                    b.Property<int?>("RemovalFormId");

                    b.Property<int?>("RemovalSdkCaseId");

                    b.Property<int>("State");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.Property<int?>("YearBuilt");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.ToTable("Installations");
                });

            modelBuilder.Entity("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.InstallationVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("ApartmentNumber");

                    b.Property<string>("CadastralNumber");

                    b.Property<string>("CadastralType");

                    b.Property<string>("CityName");

                    b.Property<string>("CompanyAddress");

                    b.Property<string>("CompanyAddress2");

                    b.Property<string>("CompanyName");

                    b.Property<string>("CountryCode");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("CustomerId");

                    b.Property<DateTime?>("DateActRemove");

                    b.Property<DateTime?>("DateInstall");

                    b.Property<DateTime?>("DateRemove");

                    b.Property<int?>("InstallationEmployeeId");

                    b.Property<int>("InstallationId");

                    b.Property<string>("InstallationImageName");

                    b.Property<int?>("InstallationSdkCaseId");

                    b.Property<int?>("LivingFloorsNumber");

                    b.Property<string>("PropertyNumber");

                    b.Property<int?>("RemovalEmployeeId");

                    b.Property<int?>("RemovalFormId");

                    b.Property<int?>("RemovalSdkCaseId");

                    b.Property<int>("State");

                    b.Property<int>("Type");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.Property<int?>("YearBuilt");

                    b.Property<string>("ZipCode");

                    b.HasKey("Id");

                    b.HasIndex("InstallationId");

                    b.ToTable("InstallationVersions");
                });

            modelBuilder.Entity("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.Meter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("Floor");

                    b.Property<int>("InstallationId");

                    b.Property<int>("Num");

                    b.Property<string>("QR");

                    b.Property<string>("RoomName");

                    b.Property<string>("RoomType");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("InstallationId");

                    b.ToTable("Meters");
                });

            modelBuilder.Entity("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.MeterVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("Floor");

                    b.Property<int>("InstallationId");

                    b.Property<int>("MeterId");

                    b.Property<int>("Num");

                    b.Property<string>("QR");

                    b.Property<string>("RoomName");

                    b.Property<string>("RoomType");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("InstallationId");

                    b.ToTable("MeterVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValues");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginConfigurationValueVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("Name");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<string>("Value");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginConfigurationValueVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("PluginGroupPermissions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<int?>("FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

                    b.Property<int>("GroupId");

                    b.Property<bool>("IsEnabled");

                    b.Property<int>("PermissionId");

                    b.Property<int>("PluginGroupPermissionId");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("FK_PluginGroupPermissionVersions_PluginGroupPermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("PluginGroupPermissionVersions");
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation(autoIdGenStrategy, autoIdGenStrategyValue);

                    b.Property<string>("ClaimName");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("CreatedByUserId");

                    b.Property<string>("PermissionName");

                    b.Property<DateTime?>("UpdatedAt");

                    b.Property<int>("UpdatedByUserId");

                    b.Property<int>("Version");

                    b.Property<string>("WorkflowState")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("PluginPermissions");
                });

            modelBuilder.Entity("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.InstallationVersion", b =>
                {
                    b.HasOne("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.Installation", "Installation")
                        .WithMany()
                        .HasForeignKey("InstallationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.Meter", b =>
                {
                    b.HasOne("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.Installation", "Installation")
                        .WithMany("Meters")
                        .HasForeignKey("InstallationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.MeterVersion", b =>
                {
                    b.HasOne("Microting.InstallationCheckingBase.Infrastructure.Data.Entities.Installation", "Installation")
                        .WithMany()
                        .HasForeignKey("InstallationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermissionVersion", b =>
                {
                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginGroupPermission", "PluginGroupPermission")
                        .WithMany()
                        .HasForeignKey("FK_PluginGroupPermissionVersions_PluginGroupPermissionId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Microting.eFormApi.BasePn.Infrastructure.Database.Entities.PluginPermission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
