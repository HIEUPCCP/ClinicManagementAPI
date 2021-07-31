using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ClinicAPI.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Certificate> Certificates { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DetailOrder> DetailOrders { get; set; }
        public virtual DbSet<DiscountEvent> DiscountEvents { get; set; }
        public virtual DbSet<MachineCategory> MachineCategories { get; set; }
        public virtual DbSet<Medicine> Medicines { get; set; }
        public virtual DbSet<Origin> Origins { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<ReceiptMedicine> ReceiptMedicines { get; set; }
        public virtual DbSet<ReceiptMedicineIdOrderdetail> ReceiptMedicineIdOrderdetails { get; set; }
        public virtual DbSet<ReceiptScientificEquipment> ReceiptScientificEquipments { get; set; }
        public virtual DbSet<ReceiptScientificEquipmentIdOrderDetail> ReceiptScientificEquipmentIdOrderDetails { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<ScientificEquipment> ScientificEquipments { get; set; }
        public virtual DbSet<StaffRole> StaffRoles { get; set; }
        public virtual DbSet<TypeOfMedicine> TypeOfMedicines { get; set; }
        public virtual DbSet<staff> staff { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Brand1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Brand");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.ToTable("Certificate");

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.Place)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.Certificates)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_Certificate_Staff");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Address).HasMaxLength(300);

                entity.Property(e => e.Email).HasMaxLength(300);

                entity.Property(e => e.FullName).HasMaxLength(300);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.Username).HasMaxLength(300);
            });

            modelBuilder.Entity<DetailOrder>(entity =>
            {
                entity.ToTable("DetailOrder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DetailOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_DetailOrder_Customer");

                entity.HasOne(d => d.DiscountEvent)
                    .WithMany(p => p.DetailOrders)
                    .HasForeignKey(d => d.DiscountEventId)
                    .HasConstraintName("FK_DetailOrder_DiscountEvent");
            });

            modelBuilder.Entity<DiscountEvent>(entity =>
            {
                entity.ToTable("DiscountEvent");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateEnd).HasColumnType("datetime");

                entity.Property(e => e.DateStart).HasColumnType("datetime");
            });

            modelBuilder.Entity<MachineCategory>(entity =>
            {
                entity.ToTable("MachineCategory");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Medicine>(entity =>
            {
                entity.ToTable("Medicine");

                entity.Property(e => e.DateOfManufacture).HasColumnType("datetime");

                entity.Property(e => e.Expiry).HasColumnType("datetime");

                entity.Property(e => e.Illustration)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("illustration");

                entity.Property(e => e.Ingredient).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Point).IsUnicode(false);

                entity.Property(e => e.PresentationFormat).IsUnicode(false);

                entity.Property(e => e.SpecialWarning).IsUnicode(false);

                entity.Property(e => e.Using).IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Medicine_Brand");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("FK_Medicine_Origin");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.Priceid)
                    .HasConstraintName("FK_Medicine_Price");

                entity.HasOne(d => d.TypeOf)
                    .WithMany(p => p.Medicines)
                    .HasForeignKey(d => d.TypeOfId)
                    .HasConstraintName("FK_Medicine_TypeOfMedicine");
            });

            modelBuilder.Entity<Origin>(entity =>
            {
                entity.ToTable("Origin");

                entity.Property(e => e.Origin1)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Origin");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Position");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Price1).HasColumnName("Price");
            });

            modelBuilder.Entity<ReceiptMedicine>(entity =>
            {
                entity.ToTable("ReceiptMedicine");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Medicine)
                    .WithMany(p => p.ReceiptMedicines)
                    .HasForeignKey(d => d.MedicineId)
                    .HasConstraintName("FK_ReceiptMedicine_Medicine");
            });

            modelBuilder.Entity<ReceiptMedicineIdOrderdetail>(entity =>
            {
                entity.HasKey(e => new { e.ReceiptMedicineId, e.OrderdetailId });

                entity.ToTable("ReceiptMedicineId_Orderdetail");

                entity.HasOne(d => d.Orderdetail)
                    .WithMany(p => p.ReceiptMedicineIdOrderdetails)
                    .HasForeignKey(d => d.OrderdetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptMedicineId_Orderdetail_DetailOrder");

                entity.HasOne(d => d.ReceiptMedicine)
                    .WithMany(p => p.ReceiptMedicineIdOrderdetails)
                    .HasForeignKey(d => d.ReceiptMedicineId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptMedicineId_Orderdetail_ReceiptMedicine");
            });

            modelBuilder.Entity<ReceiptScientificEquipment>(entity =>
            {
                entity.ToTable("ReceiptScientificEquipment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.ScientificEquipment)
                    .WithMany(p => p.ReceiptScientificEquipments)
                    .HasForeignKey(d => d.ScientificEquipmentId)
                    .HasConstraintName("FK_ReceiptScientificEquipment_ScientificEquipment");
            });

            modelBuilder.Entity<ReceiptScientificEquipmentIdOrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.ReceiptScientificEquipmentId, e.OrderDetailId });

                entity.ToTable("ReceiptScientificEquipmentId_OrderDetail");

                entity.HasOne(d => d.OrderDetail)
                    .WithMany(p => p.ReceiptScientificEquipmentIdOrderDetails)
                    .HasForeignKey(d => d.OrderDetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptScientificEquipmentId_OrderDetail_DetailOrder");

                entity.HasOne(d => d.ReceiptScientificEquipment)
                    .WithMany(p => p.ReceiptScientificEquipmentIdOrderDetails)
                    .HasForeignKey(d => d.ReceiptScientificEquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReceiptScientificEquipmentId_OrderDetail_ReceiptScientificEquipment");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ScientificEquipment>(entity =>
            {
                entity.ToTable("ScientificEquipment");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Illustration)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("illustration");

                entity.Property(e => e.InventedYear).HasColumnName("inventedYear");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ScientificEquipments)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_ScientificEquipment_Brand");

                entity.HasOne(d => d.MachineCategory)
                    .WithMany(p => p.ScientificEquipments)
                    .HasForeignKey(d => d.MachineCategoryId)
                    .HasConstraintName("FK_ScientificEquipment_MachineCategory");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.ScientificEquipments)
                    .HasForeignKey(d => d.OriginId)
                    .HasConstraintName("FK_ScientificEquipment_Origin");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.ScientificEquipments)
                    .HasForeignKey(d => d.Priceid)
                    .HasConstraintName("FK_ScientificEquipment_Price");
            });

            modelBuilder.Entity<StaffRole>(entity =>
            {
                entity.HasKey(e => new { e.StaffId, e.RoleId });

                entity.ToTable("StaffRole");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.StaffRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffRole_Role");

                entity.HasOne(d => d.Staff)
                    .WithMany(p => p.StaffRoles)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffRole_Staff");
            });

            modelBuilder.Entity<TypeOfMedicine>(entity =>
            {
                entity.ToTable("TypeOfMedicine");

                entity.Property(e => e.Category)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Dob).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Name).HasMaxLength(300);

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.WokingStart).HasColumnType("datetime");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK_Staff_Position");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
