using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace CakeShop.Model
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Aboutu> Aboutus { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Contatctu> Contatctus { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Home> Homes { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Testimoial> Testimoials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("USER ID=TAH10_USER195;PASSWORD=train2022;DATA SOURCE=94.56.229.181:3488/traindb");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TAH10_USER195")
                .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

            modelBuilder.Entity<Aboutu>(entity =>
            {
                entity.HasKey(e => e.AboutusId)
                    .HasName("ABOUTUS_PK");

                entity.ToTable("ABOUTUS");

                entity.Property(e => e.AboutusId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ABOUTUS_ID")
                    .HasDefaultValueSql("1 ");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("CART");

                entity.Property(e => e.CartId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CART_ID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("CUSTOMER3_FK");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_DESCRIPTION");

                entity.Property(e => e.CategoryImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_IMAGE");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CATEGORY_NAME");
            });

            modelBuilder.Entity<Contatctu>(entity =>
            {
                entity.HasKey(e => e.ContatcusId)
                    .HasName("CONTATCTUS_PK");

                entity.ToTable("CONTATCTUS");

                entity.Property(e => e.ContatcusId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CONTATCUS_ID")
                    .HasDefaultValueSql("1 ");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FIRST_NAME");

                entity.Property(e => e.Message)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.PhoneNumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONE_NUMBER");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("CUSTOMER");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CUSTOMER_NAME");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.PhoneNumber)
                    .HasPrecision(10)
                    .HasColumnName("PHONE_NUMBER");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("FULLNAME");

                entity.Property(e => e.HairedDate)
                    .HasColumnType("DATE")
                    .HasColumnName("HAIRED_DATE");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNumber)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PHONE_NUMBER");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Salary)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SALARY");
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.ToTable("HOME");

                entity.Property(e => e.HomeId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("HOME_ID")
                    .HasDefaultValueSql("1 ");

                entity.Property(e => e.AboutusId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ABOUTUS_ID");

                entity.Property(e => e.ContactusId)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CONTACTUS_ID");

                entity.Property(e => e.Logo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("LOGO");

                entity.Property(e => e.Slider)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("SLIDER");

                entity.HasOne(d => d.Aboutus)
                    .WithMany(p => p.Homes)
                    .HasForeignKey(d => d.AboutusId)
                    .HasConstraintName("HOME_FK1");

                entity.HasOne(d => d.Contactus)
                    .WithMany(p => p.Homes)
                    .HasForeignKey(d => d.ContactusId)
                    .HasConstraintName("HOME_FK2");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.LoginId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("LOGIN_ID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.RoleId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ROLE_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("CUSTOMER2_FK");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("EMPLOYEE2_FK");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ORDER_ID");

                entity.Property(e => e.CartId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CART_ID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("DATE")
                    .HasColumnName("ORDER_DATE");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("CART1_FK");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("PRODUCT1_FK");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.VisaId)
                    .HasName("SYS_C00130056");

                entity.ToTable("PAYMENT_METHOD");

                entity.Property(e => e.VisaId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("VISA_ID");

                entity.Property(e => e.Amount)
                    .HasColumnType("FLOAT")
                    .HasColumnName("AMOUNT");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CVV");

                entity.Property(e => e.OrderId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("ORDER_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.PaymentMethods)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("ORDER1_FK");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProductId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PRODUCT_ID");

                entity.Property(e => e.CategoryId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CATEGORY_ID");

                entity.Property(e => e.Price)
                    .HasColumnType("NUMBER")
                    .HasColumnName("PRICE");

                entity.Property(e => e.ProductImage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_IMAGE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.Quantity)
                    .HasColumnType("NUMBER")
                    .HasColumnName("QUANTITY");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("CATEGORY1_FK");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("REPORT");

                entity.Property(e => e.ReportId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("REPORT_ID");

                entity.Property(e => e.DateOut)
                    .HasColumnType("DATE")
                    .HasColumnName("DATE_OUT");

                entity.Property(e => e.EmployeeId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("EMPLOYEE_ID");

                entity.Property(e => e.ReportType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REPORT_TYPE");

                entity.Property(e => e.SalaryLosses)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SALARY_LOSSES");

                entity.Property(e => e.SalaryProfits)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SALARY_PROFITS");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("EMPLOYEE1_FK");
            });

            modelBuilder.Entity<Testimoial>(entity =>
            {
                entity.ToTable("TESTIMOIAL");

                entity.Property(e => e.TestimoialId)
                    .HasColumnType("NUMBER")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("TESTIMOIAL_ID");

                entity.Property(e => e.CustomerId)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CUSTOMER_ID");

                entity.Property(e => e.Message)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Ratting)
                    .HasColumnType("NUMBER")
                    .HasColumnName("RATTING");

                entity.Property(e => e.TestimoialDate)
                    .HasColumnType("DATE")
                    .HasColumnName("TESTIMOIAL_DATE");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Testimoials)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("CUSTOMER1_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
