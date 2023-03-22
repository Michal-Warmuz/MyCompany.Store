﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCompany.Store.Infrastructure.Database;

#nullable disable

namespace MyCompany.Store.Infrastructure.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MyCompany.Store.Core.Domain.Orders.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("UniqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("_createDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyCompany.Store.Core.Domain.Orders.OrderLine", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<Guid>("UniqueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("_orderId")
                        .HasColumnType("bigint")
                        .HasColumnName("OrderId");

                    b.HasKey("Id");

                    b.HasIndex("_orderId");

                    b.ToTable("OrderLines");
                });

            modelBuilder.Entity("MyCompany.Store.Core.Domain.Orders.Order", b =>
                {
                    b.OwnsOne("MyCompany.Store.Core.Domain.Orders.Client", "_client", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("ClientName");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("MyCompany.Store.Core.Domain.Orders.Information", "_additionalInfo", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("AdditionalInfo");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsOne("MyCompany.Store.Core.Domain.Orders.OrderStatus", "_status", b1 =>
                        {
                            b1.Property<long>("OrderId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Status");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("_additionalInfo");

                    b.Navigation("_client");

                    b.Navigation("_status");
                });

            modelBuilder.Entity("MyCompany.Store.Core.Domain.Orders.OrderLine", b =>
                {
                    b.HasOne("MyCompany.Store.Core.Domain.Orders.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("_orderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("MyCompany.Store.Core.Domain.Orders.Amount", "_price", b1 =>
                        {
                            b1.Property<long>("OrderLineId")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(18,2)")
                                .HasColumnName("Price");

                            b1.HasKey("OrderLineId");

                            b1.ToTable("OrderLines");

                            b1.WithOwner()
                                .HasForeignKey("OrderLineId");
                        });

                    b.OwnsOne("MyCompany.Store.Core.Domain.Orders.Product", "_product", b1 =>
                        {
                            b1.Property<long>("OrderLineId")
                                .HasColumnType("bigint");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Product");

                            b1.HasKey("OrderLineId");

                            b1.ToTable("OrderLines");

                            b1.WithOwner()
                                .HasForeignKey("OrderLineId");
                        });

                    b.Navigation("Order");

                    b.Navigation("_price");

                    b.Navigation("_product");
                });

            modelBuilder.Entity("MyCompany.Store.Core.Domain.Orders.Order", b =>
                {
                    b.Navigation("OrderLines");
                });
#pragma warning restore 612, 618
        }
    }
}