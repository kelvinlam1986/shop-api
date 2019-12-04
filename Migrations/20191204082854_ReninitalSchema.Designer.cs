using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ShopApi.Data;

namespace ShopApi.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20191204082854_ReninitalSchema")]
    partial class ReninitalSchema
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(255);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(255);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(255);

                    b.Property<string>("RoleId")
                        .HasMaxLength(255);

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(255);

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(255);

                    b.Property<string>("Name")
                        .HasMaxLength(255);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ShopApi.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(255);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(255);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ShopApi.Models.AutomaticValue", b =>
                {
                    b.Property<string>("ObjectName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastValueOfColumnId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("LengthOfDefaultValueForId");

                    b.Property<string>("PrefixOfDefaultValueForId")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ObjectName");

                    b.ToTable("AutomaticValues");
                });

            modelBuilder.Entity("ShopApi.Models.Bank", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("Banks");
                });

            modelBuilder.Entity("ShopApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ShopApi.Models.Country", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("ShopApi.Models.Currency", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("ShopApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("BirthDate");

                    b.Property<bool>("Cedula");

                    b.Property<bool>("Cert");

                    b.Property<DateTime>("CiDate");

                    b.Property<string>("CiName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CiRemarks")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("CoMaker")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CoMakerDetails")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("CreditStatus")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("EmployerAddress")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployerName")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmployerNo")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("EmployerYear")
                        .HasColumnType("varchar(10)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HouseStatus")
                        .HasColumnType("varchar(30)");

                    b.Property<bool>("Income");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Occupation")
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("PaySlip");

                    b.Property<string>("Picture")
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Rent")
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("Salary")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Spouse")
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("SpouseDetails")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SpouseEmp")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SpouseIncome")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("SpouseNo")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<bool>("ValidId");

                    b.Property<string>("Years")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("ShopApi.Models.CustomerType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("CustomerTypes");
                });

            modelBuilder.Entity("ShopApi.Models.ExchangeRate", b =>
                {
                    b.Property<string>("CurrencyCode")
                        .HasColumnType("char(3)");

                    b.Property<DateTime>("DateOfRate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Discontinued");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("CurrencyCode", "DateOfRate");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("ShopApi.Models.ExportType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("ExportTypes");
                });

            modelBuilder.Entity("ShopApi.Models.ImportType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("ImportTypes");
                });

            modelBuilder.Entity("ShopApi.Models.Manufacture", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(5)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.HasIndex("CountryId");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("ShopApi.Models.PaymentType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("PaymentTypes");
                });

            modelBuilder.Entity("ShopApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("varchar(300)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("Quantity");

                    b.Property<int>("ReOrder");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("SupplierId");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ShopApi.Models.Province", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.HasIndex("CountryCode");

                    b.ToTable("Provinces");
                });

            modelBuilder.Entity("ShopApi.Models.PurchaseInvoiceBatch", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(3)");

                    b.Property<DateTime>("BatchDate");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("Status");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("PurchaseInvoiceBatches");
                });

            modelBuilder.Entity("ShopApi.Models.PurchaseInvoiceType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("PurchaseInvoiceTypes");
                });

            modelBuilder.Entity("ShopApi.Models.ReceiptType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("ReceiptTypes");
                });

            modelBuilder.Entity("ShopApi.Models.Report", b =>
                {
                    b.Property<string>("ReportName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DataSheet")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("RelationTables")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SingleForm")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ReportName");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("ShopApi.Models.SalesInvoiceType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("SalesInvoiceTypes");
                });

            modelBuilder.Entity("ShopApi.Models.Stock", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(5)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("ShopApi.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("char(5)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("Discontinued");

                    b.Property<DateTime>("DueDate");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FaxNumber")
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("MaxDebitAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OtherLanguageName")
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("ProvinceCode")
                        .HasColumnType("char(3)");

                    b.Property<string>("SupplierTypeCode")
                        .IsRequired()
                        .HasColumnType("char(3)");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.Property<string>("VietnameseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceCode");

                    b.HasIndex("SupplierTypeCode");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ShopApi.Models.SupplierType", b =>
                {
                    b.Property<string>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(3)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Code");

                    b.ToTable("SupplierTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ShopApi.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ShopApi.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopApi.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopApi.Models.ExchangeRate", b =>
                {
                    b.HasOne("ShopApi.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopApi.Models.Manufacture", b =>
                {
                    b.HasOne("ShopApi.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopApi.Models.Product", b =>
                {
                    b.HasOne("ShopApi.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ShopApi.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopApi.Models.Province", b =>
                {
                    b.HasOne("ShopApi.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ShopApi.Models.Supplier", b =>
                {
                    b.HasOne("ShopApi.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceCode");

                    b.HasOne("ShopApi.Models.SupplierType", "SupplierType")
                        .WithMany()
                        .HasForeignKey("SupplierTypeCode")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
