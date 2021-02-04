﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZELF.SocialNetwork.EFData;

namespace ZELF.SocialNetwork.EFData.Migrations
{
    [DbContext(typeof(SocialNetworkContext))]
    partial class SocialNetworkContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ZELF.SocialNetwork.EFData.Models.SubscribeUserEntity", b =>
                {
                    b.Property<Guid>("FromUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ToUserId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CreateUser")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ModifiedUser")
                        .HasColumnType("TEXT");

                    b.HasKey("FromUserId", "ToUserId");

                    b.HasIndex("ToUserId");

                    b.HasIndex("FromUserId", "ToUserId");

                    b.ToTable("UserSubscribers");
                });

            modelBuilder.Entity("ZELF.SocialNetwork.EFData.Models.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Raiting")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Raiting");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ZELF.SocialNetwork.EFData.Models.SubscribeUserEntity", b =>
                {
                    b.HasOne("ZELF.SocialNetwork.EFData.Models.UserEntity", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZELF.SocialNetwork.EFData.Models.UserEntity", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromUser");

                    b.Navigation("ToUser");
                });
#pragma warning restore 612, 618
        }
    }
}
