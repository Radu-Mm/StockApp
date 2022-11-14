using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StockApp.Models.DBObjects;

namespace StockApp.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<District> Districts { get; set; } = null!;
        public virtual DbSet<Document> Documents { get; set; } = null!;
        public virtual DbSet<DocumentDetail> DocumentDetails { get; set; } = null!;
        public virtual DbSet<DocumentType> DocumentTypes { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Seller> Sellers { get; set; } = null!;
        public virtual DbSet<Usage> Usages { get; set; } = null!;
        public virtual DbSet<UsageType> UsageTypes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryID");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("categoryDescription");

                entity.Property(e => e.CategoyName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("categoyName");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.CountryId)
                    .ValueGeneratedNever()
                    .HasColumnName("countryID");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("countryName");
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.DistrictId)
                    .ValueGeneratedNever()
                    .HasColumnName("districtID");

                entity.Property(e => e.CountryId).HasColumnName("countryID");

                entity.Property(e => e.DistrictName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("districtName");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK__Districts__count__628FA481");
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasKey(e => e.DocId)
                    .HasName("PK__Document__0639C402312D5CBE");

                entity.Property(e => e.DocId)
                    .ValueGeneratedNever()
                    .HasColumnName("docID");

                entity.Property(e => e.DocDate)
                    .HasColumnType("date")
                    .HasColumnName("docDate");

                entity.Property(e => e.DocNumber)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("docNumber");

                entity.Property(e => e.DocTotalValue)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("docTotalValue");

                entity.Property(e => e.DocTotalValueVat)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("docTotalValueVAT");

                entity.Property(e => e.DocTotalValueWithoutVat)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("docTotalValueWithoutVat");

                entity.Property(e => e.DocTypeId).HasColumnName("docTypeId");

                entity.Property(e => e.IsValid).HasColumnName("isValid");

                entity.Property(e => e.SellerId).HasColumnName("sellerID");

                entity.Property(e => e.ValidatedBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("validatedBy");

                entity.Property(e => e.WhenValidated)
                    .HasColumnType("datetime")
                    .HasColumnName("whenValidated");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.DocTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documents__docTy__6FE99F9F");

                entity.HasOne(d => d.Seller)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.SellerId)
                    .HasConstraintName("FK__Documents__selle__70DDC3D8");
            });

            modelBuilder.Entity<DocumentDetail>(entity =>
            {
                entity.HasKey(e => e.DocDetId)
                    .HasName("PK__Document__40AB58823311C6A6");

                entity.Property(e => e.DocDetId)
                    .ValueGeneratedNever()
                    .HasColumnName("docDetID");

                entity.Property(e => e.DocId).HasColumnName("docID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.QuantityRemaining).HasColumnName("quantityRemaining");

                entity.Property(e => e.Unitprice)
                    .HasColumnType("numeric(18, 4)")
                    .HasColumnName("unitprice");

                entity.Property(e => e.Vat).HasColumnName("VAT");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.DocumentDetails)
                    .HasForeignKey(d => d.DocId)
                    .HasConstraintName("FK__DocumentD__docID__74AE54BC");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DocumentDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__DocumentD__produ__75A278F5");
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.HasKey(e => e.DocTypeId)
                    .HasName("PK__Document__288C0C4B31E87CE0");

                entity.ToTable("DocumentType");

                entity.Property(e => e.DocTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("docTypeID");

                entity.Property(e => e.DocType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("docType");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("productID");

                entity.Property(e => e.ProductInUse)
                    .IsRequired()
                    .HasColumnName("productInUse")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("productName");

                entity.Property(e => e.Productcategory).HasColumnName("productcategory");

                entity.HasOne(d => d.ProductcategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Productcategory)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("fk_prod_category");
            });

            modelBuilder.Entity<Seller>(entity =>
            {
                entity.Property(e => e.SellerId)
                    .ValueGeneratedNever()
                    .HasColumnName("sellerID");

                entity.Property(e => e.BlackListMotive)
                    .HasColumnType("ntext")
                    .HasColumnName("blackListMotive");

                entity.Property(e => e.BlackListTime)
                    .HasColumnType("datetime")
                    .HasColumnName("blackListTime");

                entity.Property(e => e.BlackListWho)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("blackListWho");

                entity.Property(e => e.BlackListed).HasColumnName("blackListed");

                entity.Property(e => e.SellerAddress)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("sellerAddress");

                entity.Property(e => e.SellerCountry).HasColumnName("sellerCountry");

                entity.Property(e => e.SellerDistrict).HasColumnName("sellerDistrict");

                entity.Property(e => e.SellerName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("sellerName");

                entity.Property(e => e.SellerPhone)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("sellerPhone");

                entity.Property(e => e.SellerUic)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sellerUIC");

                entity.HasOne(d => d.SellerCountryNavigation)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.SellerCountry)
                    .HasConstraintName("FK__Sellers__sellerC__656C112C");

                entity.HasOne(d => d.SellerDistrictNavigation)
                    .WithMany(p => p.Sellers)
                    .HasForeignKey(d => d.SellerDistrict)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sellers__sellerD__66603565");
            });

            modelBuilder.Entity<Usage>(entity =>
            {
                entity.ToTable("usage");

                entity.Property(e => e.UsageId)
                    .ValueGeneratedNever()
                    .HasColumnName("usageID");

                entity.Property(e => e.DocdetId).HasColumnName("docdetID");

                entity.Property(e => e.Docid).HasColumnName("docid");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.UsageTypeId).HasColumnName("usageTypeID");

                entity.HasOne(d => d.Docdet)
                    .WithMany(p => p.Usages)
                    .HasForeignKey(d => d.DocdetId)
                    .HasConstraintName("FK__usage__docdetID__1DB06A4F");

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.Usages)
                    .HasForeignKey(d => d.Docid)
                    .HasConstraintName("FK__usage__docid__1F98B2C1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Usages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__usage__productID__1EA48E88");

                entity.HasOne(d => d.UsageType)
                    .WithMany(p => p.Usages)
                    .HasForeignKey(d => d.UsageTypeId)
                    .HasConstraintName("FK__usage__usageType__1CBC4616");
            });

            modelBuilder.Entity<UsageType>(entity =>
            {
                entity.ToTable("UsageType");

                entity.Property(e => e.UsageTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("usageTypeID");

                entity.Property(e => e.UsageType1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UsageType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
