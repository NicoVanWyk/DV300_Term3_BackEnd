﻿// <auto-generated />
using System;
using Du_Fang;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Du_Fang.Migrations
{
    [DbContext(typeof(AppDBContext))]
    partial class AppDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Du_Fang.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("AccountId"));

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<int>("CoinBalance")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("AccountId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Du_Fang.Authentication_Log", b =>
                {
                    b.Property<int>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LogId"));

                    b.Property<string>("DeviceInfo")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("IP_Address")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("character varying(45)");

                    b.Property<DateTime?>("LogOutTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("LoginTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LogId");

                    b.HasIndex("UserId");

                    b.ToTable("AuthenticationLogs");
                });

            modelBuilder.Entity("Du_Fang.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StatusId"));

                    b.Property<double>("AnnualInterestRate")
                        .HasColumnType("double precision");

                    b.Property<string>("StatusName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("TotalAmountCriteria")
                        .HasColumnType("numeric");

                    b.Property<decimal>("TransactionFee")
                        .HasColumnType("numeric");

                    b.Property<int>("TransactionsCriteria")
                        .HasColumnType("integer");

                    b.HasKey("StatusId");

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            StatusId = 1,
                            AnnualInterestRate = 0.01,
                            StatusName = "Active",
                            TotalAmountCriteria = 0m,
                            TransactionFee = 1m,
                            TransactionsCriteria = 0
                        },
                        new
                        {
                            StatusId = 2,
                            AnnualInterestRate = 0.02,
                            StatusName = "Silver",
                            TotalAmountCriteria = 1000m,
                            TransactionFee = 0.5m,
                            TransactionsCriteria = 10
                        },
                        new
                        {
                            StatusId = 3,
                            AnnualInterestRate = 0.029999999999999999,
                            StatusName = "Gold",
                            TotalAmountCriteria = 10000m,
                            TransactionFee = 0m,
                            TransactionsCriteria = 100
                        });
                });

            modelBuilder.Entity("Du_Fang.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TransactionId"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ToAccountId")
                        .HasColumnType("integer");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TransactionId");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("ToAccountId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Du_Fang.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<string>("Otp")
                        .HasColumnType("text");

                    b.Property<DateTime?>("OtpExpiry")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Du_Fang.User_Security", b =>
                {
                    b.Property<int>("SecurityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SecurityId"));

                    b.Property<string>("LatestOTPSecret")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("SecurityId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserSecurities");
                });

            modelBuilder.Entity("Du_Fang.Account", b =>
                {
                    b.HasOne("Du_Fang.Status", "Status")
                        .WithMany("Accounts")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Du_Fang.User", "User")
                        .WithOne("Account")
                        .HasForeignKey("Du_Fang.Account", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Du_Fang.Authentication_Log", b =>
                {
                    b.HasOne("Du_Fang.User", "User")
                        .WithMany("AuthenticationLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Du_Fang.Transaction", b =>
                {
                    b.HasOne("Du_Fang.Account", "FromAccount")
                        .WithMany("TransactionsFrom")
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Du_Fang.Account", "ToAccount")
                        .WithMany("TransactionsTo")
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");
                });

            modelBuilder.Entity("Du_Fang.User_Security", b =>
                {
                    b.HasOne("Du_Fang.User", "User")
                        .WithOne("UserSecurity")
                        .HasForeignKey("Du_Fang.User_Security", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Du_Fang.Account", b =>
                {
                    b.Navigation("TransactionsFrom");

                    b.Navigation("TransactionsTo");
                });

            modelBuilder.Entity("Du_Fang.Status", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("Du_Fang.User", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("AuthenticationLogs");

                    b.Navigation("UserSecurity");
                });
#pragma warning restore 612, 618
        }
    }
}
