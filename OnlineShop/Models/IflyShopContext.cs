using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Models;

public partial class IflyShopContext : DbContext
{
    public IflyShopContext()
    {
    }

    public IflyShopContext(DbContextOptions<IflyShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountCustomer> AccountCustomers { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<VwOrder> VwOrders { get; set; }

    public virtual DbSet<VwOrderWrapper> VwOrderWrappers { get; set; }

    public virtual DbSet<VwReportOrder> VwReportOrders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=ADMIN;uid=sa;password=1;database=IFlyShop;Encrypt=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountCustomer>(entity =>
        {
            entity.HasKey(e => e.Phone);

            entity.ToTable("AccountCustomer");

            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("ct_pk");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CategoryName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Description).HasMaxLength(100);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.IdCustomer).HasName("PK_idCustomer");

            entity.ToTable("Customer");

            entity.Property(e => e.IdCustomer)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idCustomer");
            entity.Property(e => e.Address).HasColumnName("address");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.NameCustomer)
                .HasMaxLength(50)
                .HasColumnName("nameCustomer");
            entity.Property(e => e.Phone)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.ToTable("Order");

            entity.Property(e => e.IdOrder)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idOrder");
            entity.Property(e => e.IdCustomer)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idCustomer");
            entity.Property(e => e.OrderName)
                .HasMaxLength(50)
                .HasColumnName("orderName");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("productId");
            entity.Property(e => e.Totalmoney)
                .HasColumnType("money")
                .HasColumnName("totalmoney");

            entity.HasOne(d => d.IdCustomerNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdCustomer)
                .HasConstraintName("FK_Order_Customer");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.IdOrder, e.IdProduct }).HasName("z_key");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.IdOrder)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("idOrder");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("idProduct");
            entity.Property(e => e.ProductCost).HasColumnType("money");

            entity.HasOne(d => d.IdOrderNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdOrder)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Order");

            entity.HasOne(d => d.IdProductNavigation).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.IdProduct)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetail_Product");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK_SanPham");

            entity.ToTable("Product");

            entity.Property(e => e.IdProduct)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("idProduct");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.ImgProduct).HasColumnName("imgProduct");
            entity.Property(e => e.Likes).HasColumnName("likes");
            entity.Property(e => e.ProductAmount).HasColumnName("productAmount");
            entity.Property(e => e.ProductInformation)
                .HasMaxLength(100)
                .HasColumnName("productInformation");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .HasColumnName("productName");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ViewProduct1)
                .HasMaxLength(50)
                .HasColumnName("viewProduct1");
            entity.Property(e => e.ViewProduct2)
                .HasMaxLength(50)
                .HasColumnName("viewProduct2");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Product_Category");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.IdRating);

            entity.ToTable("Rating");

            entity.Property(e => e.IdRating)
                .ValueGeneratedNever()
                .HasColumnName("idRating");
            entity.Property(e => e.ProductId)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("productId");
            entity.Property(e => e.Rating1).HasColumnName("rating");
            entity.Property(e => e.UserId).HasColumnName("userId");

            entity.HasOne(d => d.Product).WithMany(p => p.Ratings)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Rating_SanPham");
        });

        modelBuilder.Entity<VwOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_orders");

            entity.Property(e => e.CMode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cMode");
            entity.Property(e => e.COrderNo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cOrderNo");
            entity.Property(e => e.CToyId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cToyId");
            entity.Property(e => e.DOrderDate)
                .HasColumnType("datetime")
                .HasColumnName("dOrderDate");
            entity.Property(e => e.MToyRate)
                .HasColumnType("money")
                .HasColumnName("mToyRate");
            entity.Property(e => e.SiQty).HasColumnName("siQty");
            entity.Property(e => e.VAddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("vAddress");
            entity.Property(e => e.VFirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vFirstName");
            entity.Property(e => e.VLastName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vLastName");
            entity.Property(e => e.VToyName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vToyName");
        });

        modelBuilder.Entity<VwOrderWrapper>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vwOrderWrapper");

            entity.Property(e => e.COrderNo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cOrderNo");
            entity.Property(e => e.CToyId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cToyId");
            entity.Property(e => e.MWrapperRate)
                .HasColumnType("money")
                .HasColumnName("mWrapperRate");
            entity.Property(e => e.SiQty).HasColumnName("siQty");
            entity.Property(e => e.VDescription)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vDescription");
        });

        modelBuilder.Entity<VwReportOrder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ReportOrder");

            entity.Property(e => e.COrderNo)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cOrderNo");
            entity.Property(e => e.CToyId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("cToyId");
            entity.Property(e => e.DOrderDate)
                .HasColumnType("datetime")
                .HasColumnName("dOrderDate");
            entity.Property(e => e.MTotalCost)
                .HasColumnType("money")
                .HasColumnName("mTotalCost");
            entity.Property(e => e.MToyRate)
                .HasColumnType("money")
                .HasColumnName("mToyRate");
            entity.Property(e => e.SiQty).HasColumnName("siQty");
            entity.Property(e => e.VAddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("vAddress");
            entity.Property(e => e.VEmailId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("vEmailId");
            entity.Property(e => e.VFirstName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vFirstName");
            entity.Property(e => e.VToyName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vToyName");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
