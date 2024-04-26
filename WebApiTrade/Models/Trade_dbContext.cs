using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApiTrade.Models
{
    public partial class Trade_dbContext : DbContext
    {
        public Trade_dbContext()
        {
        }

        public Trade_dbContext(DbContextOptions<Trade_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DProduct> DProducts { get; set; } = null!;
        public virtual DbSet<DProductImage> DProductImages { get; set; } = null!;
        public virtual DbSet<DProductType> DProductTypes { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS; DataBase=Trade_db; Trusted_Connection=true; TrustServerCertificate=true");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Включение связанных записей
            modelBuilder.Entity<DProduct>().Navigation(x => x.ProductType).AutoInclude();
            modelBuilder.Entity<DProduct>().Navigation(x => x.DProductImages).AutoInclude();
            modelBuilder.Entity<DProduct>(entity =>
            {
                entity.ToTable("D_Product");

                entity.Property(e => e.Price).HasColumnType("decimal(8, 2)");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.DProducts)
                    .HasForeignKey(d => d.ProductTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_Product_D_ProductType");
            });

            modelBuilder.Entity<DProductImage>(entity =>
            {
                entity.ToTable("D_ProductImage");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_D_ProductImage_D_Product");
            });

            modelBuilder.Entity<DProductType>(entity =>
            {
                entity.ToTable("D_ProductType");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
