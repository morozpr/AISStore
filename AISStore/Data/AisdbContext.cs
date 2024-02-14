using System;
using System.Collections.Generic;
using AISStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AISStore.Data;

public partial class AisdbContext : IdentityDbContext
{
    public AisdbContext()
    {
    }

    public AisdbContext(DbContextOptions<AisdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemType> ItemTypes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Supply> Supplies { get; set; }

    public virtual DbSet<SupplyItem> SupplyItems { get; set; }

    public virtual DbSet<SupplySupplyItem> SupplySupplyItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432;Database=aisdb;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.ClientId).HasName("Client_pkey");

            entity.ToTable("Client");

            entity.Property(e => e.ClientId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ClientID");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("Employee_pkey");

            entity.ToTable("Employee");

            entity.HasIndex(e => e.EmployeeTypeId, "IX_Employee_EmployeeTypeID");

            entity.Property(e => e.EmployeeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("EmployeeID");
            entity.Property(e => e.EmployeeTypeId).HasColumnName("EmployeeTypeID");

            entity.HasOne(d => d.EmployeeType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.EmployeeTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("empTypeID");
        });

        modelBuilder.Entity<EmployeeType>(entity =>
        {
            entity.HasKey(e => e.EmployeeTypeId).HasName("EmployeeType_pkey");

            entity.ToTable("EmployeeType");

            entity.Property(e => e.EmployeeTypeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("EmployeeTypeID");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("Item_pkey");

            entity.ToTable("Item");

            entity.HasIndex(e => e.PriceId, "IX_Item_PriceID");

            entity.Property(e => e.ItemId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ItemID");
            entity.Property(e => e.PriceId).HasColumnName("PriceID");
            entity.Property(e => e.StockId).HasColumnName("StockID");

            entity.HasOne(d => d.Price).WithMany(p => p.Items)
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PriceID");

            entity.HasOne(d => d.Stock).WithMany(p => p.Items)
                .HasForeignKey(d => d.StockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("StockID");
        });

        modelBuilder.Entity<ItemType>(entity =>
        {
            entity.HasKey(e => e.ItemTypeId).HasName("ItemType_pkey");

            entity.ToTable("ItemType");

            entity.Property(e => e.ItemTypeId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ItemTypeID");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("Order_pkey");

            entity.ToTable("Order");

            entity.HasIndex(e => e.ClientId, "IX_Order_ClientID");

            entity.HasIndex(e => e.EmployeeId, "IX_Order_EmployeeID");

            entity.HasIndex(e => e.OrderItemsId, "IX_Order_OrderItemsID");

            entity.Property(e => e.OrderId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("OrderID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.OrderItemsId).HasColumnName("OrderItemsID");
            entity.Property(e => e.Timestamp).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ClientID");

            entity.HasOne(d => d.Employee).WithMany(p => p.Orders)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("EmployeeID");

            entity.HasOne(d => d.OrderItems).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderItemsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("OrderItemsID");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.OrderItemsId).HasName("OrderItems_pkey");

            entity.HasIndex(e => e.ItemId, "IX_OrderItems_ItemID");

            entity.Property(e => e.OrderItemsId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("OrderItemsID");
            entity.Property(e => e.ItemId).HasColumnName("ItemID");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ItemID");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("Price_pkey");

            entity.ToTable("Price");

            entity.Property(e => e.PriceId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("PriceID");
            entity.Property(e => e.DataSet).HasColumnType("timestamp without time zone");
            entity.Property(e => e.DataUnSet).HasColumnType("timestamp without time zone");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.ProviderId).HasName("Provider_pkey");

            entity.ToTable("Provider");

            entity.Property(e => e.ProviderId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("ProviderID");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("Stock_pkey");

            entity.ToTable("Stock");

            entity.HasIndex(e => e.ItemTypeId, "IX_Stock_ItemTypeID");

            entity.Property(e => e.StockId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("StockID");
            entity.Property(e => e.ItemTypeId).HasColumnName("ItemTypeID");
            entity.Property(e => e.SupplyItemsId).HasColumnName("SupplyItemsID");

            entity.HasOne(d => d.ItemType).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ItemTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ItemTypeID");
        });

        modelBuilder.Entity<Supply>(entity =>
        {
            entity.HasKey(e => e.SupplyId).HasName("Supply_pkey");

            entity.ToTable("Supply");

            entity.HasIndex(e => e.ProviderId, "IX_Supply_ProviderID");

            entity.Property(e => e.SupplyId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("SupplyID");
            entity.Property(e => e.ProviderId).HasColumnName("ProviderID");
            entity.Property(e => e.Timestamp).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Provider).WithMany(p => p.Supplies)
                .HasForeignKey(d => d.ProviderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("ProviderID");
        });

        modelBuilder.Entity<SupplyItem>(entity =>
        {
            entity.HasKey(e => e.SupplyItemId).HasName("SupplyItem_pkey");

            entity.ToTable("SupplyItem");

            entity.Property(e => e.SupplyItemId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("SupplyItemID");
        });

        modelBuilder.Entity<SupplySupplyItem>(entity =>
        {
            entity.HasKey(e => e.SupplyItemsId).HasName("SupplyItems_pkey");

            entity.ToTable("SupplySupplyItem");

            entity.HasIndex(e => e.SupplyId, "IX_SupplySupplyItem_SupplyID");

            entity.HasIndex(e => e.SupplyItemId, "IX_SupplySupplyItem_SupplyItemID");

            entity.Property(e => e.SupplyItemsId)
                .UseIdentityAlwaysColumn()
                .HasColumnName("SupplyItemsID");
            entity.Property(e => e.SupplyId).HasColumnName("SupplyID");
            entity.Property(e => e.SupplyItemId).HasColumnName("SupplyItemID");

            entity.HasOne(d => d.Supply).WithMany(p => p.SupplySupplyItems)
                .HasForeignKey(d => d.SupplyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SupplyID");

            entity.HasOne(d => d.SupplyItem).WithMany(p => p.SupplySupplyItems)
                .HasForeignKey(d => d.SupplyItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("SupplyItemID");
        });

        OnModelCreatingPartial(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
