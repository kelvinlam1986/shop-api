using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShopApi.Models;

namespace ShopApi.Data
{
    public class ShopContext : IdentityDbContext<ApplicationUser>
    {
        public ShopContext(DbContextOptions<ShopContext> options) : base(options) { }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
        public DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }
        public DbSet<ExportType> ExportTypes { get; set; }
        public DbSet<ImportType> ImportTypes { get; set; }
        public DbSet<AutomaticValue> AutomaticValues { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<PurchaseInvoiceType> PurchaseInvoiceTypes { get; set; }
        public DbSet<ReceiptType> ReceiptTypes { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<SalesInvoiceType> SalesInvoiceTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Manufacture> Manufactures { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.Id)
               .HasMaxLength(255));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedEmail)
               .HasMaxLength(255));
            builder.Entity<ApplicationUser>(entity => entity.Property(m => m.NormalizedUserName)
               .HasMaxLength(255));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.Id)
               .HasMaxLength(255));
            builder.Entity<IdentityRole>(entity => entity.Property(m => m.NormalizedName)
               .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.LoginProvider)
               .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.ProviderKey)
               .HasMaxLength(255));
            builder.Entity<IdentityUserLogin<string>>(entity => entity.Property(m => m.UserId)
               .HasMaxLength(255));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.UserId)
               .HasMaxLength(255));
            builder.Entity<IdentityUserRole<string>>(entity => entity.Property(m => m.RoleId)
               .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.UserId)
               .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.LoginProvider)
               .HasMaxLength(255));
            builder.Entity<IdentityUserToken<string>>(entity => entity.Property(m => m.Name)
               .HasMaxLength(255));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.Id)
               .HasMaxLength(255));
            builder.Entity<IdentityUserClaim<string>>(entity => entity.Property(m => m.UserId)
               .HasMaxLength(255));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.Id)
               .HasMaxLength(255));
            builder.Entity<IdentityRoleClaim<string>>(entity => entity.Property(m => m.RoleId)
               .HasMaxLength(255));
            builder.Entity<PurchaseInvoice>().HasIndex(x => x.InvoiceId).IsUnique();
            builder.Entity<PurchaseInvoiceDetail>().HasIndex(x => new { x.InvoiceId, x.OrdinalNumber }).IsUnique();
        }

    }
}