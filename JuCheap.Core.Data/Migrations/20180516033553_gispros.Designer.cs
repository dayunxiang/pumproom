﻿// <auto-generated />
using JuCheap.Core.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace JuCheap.Core.Data.Migrations
{
    [DbContext(typeof(JuCheapContext))]
    [Migration("20180516033553_gispros")]
    partial class gispros
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("JuCheap.Core.Data.Entity.AreaEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<int>("DisplaySequence");

                    b.Property<bool>("Enabled");

                    b.Property<string>("FullSpelling")
                        .HasMaxLength(100);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ParentId")
                        .HasMaxLength(20);

                    b.Property<string>("PathCode")
                        .HasMaxLength(20);

                    b.Property<string>("SimpleSpelling")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.CameraPathEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Port")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("PumpRoomId")
                        .HasMaxLength(36);

                    b.Property<string>("PumpRoomName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("info")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("CameraPaths");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.DepartmentEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("FullName")
                        .HasMaxLength(500);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("ParentId");

                    b.Property<string>("PathCode");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.GisProEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("分区名称")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("坐标")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("备用1")
                        .HasMaxLength(50);

                    b.Property<string>("备用2")
                        .HasMaxLength(50);

                    b.Property<string>("备用3")
                        .HasMaxLength(50);

                    b.Property<string>("备用4")
                        .HasMaxLength(50);

                    b.Property<string>("报警信息")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("报警信息name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("泵个数")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("泵个数name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("泵表编号")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("状态信息")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("状态信息name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("站点名称")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("GisPros");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.LoginLogEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LoginLogs");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.MarkerArrEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("air")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("airname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("alarm")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("alarmname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("elecname")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("electricity")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("isOnline");

                    b.Property<string>("point")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("water")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("watername")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("id");

                    b.ToTable("MarkerArrs");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.MenuEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(6);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("Icon")
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<int>("Order");

                    b.Property<string>("ParentId");

                    b.Property<string>("PathCode")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<byte>("Type");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.PageViewEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("IP")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("PageViews");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.PathCodeEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("Len");

                    b.HasKey("Id");

                    b.ToTable("PathCodes");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.RoleEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.RoleMenuEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("MenuId")
                        .IsRequired();

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleMenus");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.StationEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("分区内排序");

                    b.Property<string>("分区名称")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("分区类型")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("站点全名")
                        .HasMaxLength(35);

                    b.Property<string>("站点名称")
                        .IsRequired()
                        .HasMaxLength(35);

                    b.Property<string>("站点类型")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("站点编号")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("编号")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.SystemConfigEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<DateTime>("DataInitedDate");

                    b.Property<bool>("IsDataInited");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("SystemName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("SystemConfigs");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<string>("DepartmentId");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsSuperMan");

                    b.Property<string>("LoginName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("RealName")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.UserRoleEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36);

                    b.Property<DateTime>("CreateDateTime");

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.RoleMenuEntity", b =>
                {
                    b.HasOne("JuCheap.Core.Data.Entity.MenuEntity", "Menu")
                        .WithMany("RoleMenus")
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuCheap.Core.Data.Entity.RoleEntity", "Role")
                        .WithMany("RoleMenus")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.UserEntity", b =>
                {
                    b.HasOne("JuCheap.Core.Data.Entity.DepartmentEntity", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");
                });

            modelBuilder.Entity("JuCheap.Core.Data.Entity.UserRoleEntity", b =>
                {
                    b.HasOne("JuCheap.Core.Data.Entity.RoleEntity", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuCheap.Core.Data.Entity.UserEntity", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
