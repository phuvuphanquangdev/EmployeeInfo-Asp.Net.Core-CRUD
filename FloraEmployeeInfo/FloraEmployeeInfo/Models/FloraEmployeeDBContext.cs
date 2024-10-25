using System;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace FloraEmployeeInfo.Models
{
    public partial class FloraEmployeeDBContext : DbContext
    {
        public FloraEmployeeDBContext()
        {
        }

        public FloraEmployeeDBContext(DbContextOptions<FloraEmployeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Designation> Designation { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=FloraEmployeeDB;Trusted_Connection=True;");
            }
        }

       // Start

        public void InsertEmployee(Employee employee)
        {
            SqlParameter EmployeeName = new SqlParameter("@EmployeeName", employee.EmployeeName);
            SqlParameter DepartmentId = new SqlParameter("@DepartmentId", employee.DepartmentId);
            SqlParameter DesignationId = new SqlParameter("@DesignationId", employee.DesignationId);
            SqlParameter Email = new SqlParameter("@Email", employee.Email);
            SqlParameter Phone = new SqlParameter("@Phone", employee.Phone);
            SqlParameter JoinDate = new SqlParameter("@JoinDate", employee.JoinDate);
            this.Database.ExecuteSqlRaw("EXEC SpInsertEmployee @EmployeeName,@DepartmentId,@DesignationId,@Email,@Phone,@JoinDate ", EmployeeName, DepartmentId, DesignationId, Email, Phone, JoinDate);
        }

        public void UpdateEmployee(Employee employee)
        {
            SqlParameter EployeeId = new SqlParameter("@EployeeId", employee.EployeeId);
            SqlParameter EmployeeName = new SqlParameter("@EmployeeName", employee.EmployeeName);
            SqlParameter DepartmentId = new SqlParameter("@DepartmentId", employee.DepartmentId);
            SqlParameter DesignationId = new SqlParameter("@DesignationId", employee.DesignationId);
            SqlParameter Email = new SqlParameter("@Email", employee.Email);
            SqlParameter Phone = new SqlParameter("@Phone", employee.Phone);
            SqlParameter JoinDate = new SqlParameter("@JoinDate", employee.JoinDate);
            this.Database.ExecuteSqlRaw("EXEC SpUpdateEmployee @EployeeId, @EmployeeName ,@DepartmentId,@DesignationId,@Email, @Phone, @JoinDate ", EployeeId, EmployeeName, DepartmentId, DesignationId, Email, Phone, JoinDate);
        }


        public void DeleteCustomer(int id)
        {
            SqlParameter EployeeId = new SqlParameter("@EployeeId", id);
            this.Database.ExecuteSqlRaw("EXEC SpDeleteEmployee @EployeeId", EployeeId);
        }



        // End







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.DepartmentName)
                    .IsRequired()
                    .HasMaxLength(75);
            });

            modelBuilder.Entity<Designation>(entity =>
            {
                entity.Property(e => e.DesignationName)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Designation)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Designati__Depar__286302EC");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EployeeId)
                    .HasName("PK__Employee__E2D64AF51FA28759");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.JoinDate).HasColumnType("datetime");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__Depart__2B3F6F97");

                entity.HasOne(d => d.Designation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DesignationId)
                    .HasConstraintName("FK__Employee__Design__2C3393D0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
