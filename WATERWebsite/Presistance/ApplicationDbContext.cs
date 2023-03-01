using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WATERWebsite.Core.Models;

namespace WATERWebsite.Presistance
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Employee> Employee { get; set; } = null!;
        public virtual DbSet<Project> Project { get; set; } = null!;
        public virtual DbSet<Department> Department { get; set; } = null!;
        public virtual DbSet<Service> Service { get; set; } = null!;
        public virtual DbSet<ServiceDetail> ServiceDetail { get; set; } = null!;
        public virtual DbSet<Blog> Blog { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LOAY\\SQLEXPRESS;Initial Catalog=WATER_DB;Trusted_Connection=True;Encrypt=False;MultipleActiveResultSets=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(c => c.EmployeeCode);

                entity.Property(c => c.EmployeeNameE).HasMaxLength(255);

                entity.Property(c => c.EmployeeJobE).HasMaxLength(255);
                
                entity.Property(c => c.EmployeeNameA).HasMaxLength(255);
                
                entity.Property(c => c.EmployeeJobA).HasMaxLength(255);
                
                entity.Property(c => c.EmployeePhone).HasMaxLength(15);
                
                entity.Property(c => c.EmployeeEmail).HasMaxLength(255);
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasKey(c => c.ProjectCode);

                entity.Property(c => c.ProjectNameE).HasMaxLength(255);

                entity.Property(c => c.ProjectOwnerE).HasMaxLength(255);

                entity.Property(c => c.ProjectOperatorE).HasMaxLength(255);

                entity.Property(c => c.ProjectDeveloperE).HasMaxLength(255);

                entity.Property(c => c.ProjectNameA).HasMaxLength(255);

                entity.Property(c => c.ProjectCapacity).HasMaxLength(25);

                entity.Property(c => c.ProjectOwnerA).HasMaxLength(255);

                entity.Property(c => c.ProjectOperatorA).HasMaxLength(255);

                entity.Property(c => c.ProjectDeveloperA).HasMaxLength(255);

                entity.Property(c => c.ProjectDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(c => c.DepartmentCode);

                entity.Property(c => c.DepartmentCode).ValueGeneratedOnAdd();

                entity.Property(c => c.DepartmentNameE).HasMaxLength(255);

                entity.Property(c => c.DepartmentNameA).HasMaxLength(255);

                entity.Property(c => c.DepartmentBriefE).HasMaxLength(255);

                entity.Property(c => c.DepartmentBriefA).HasMaxLength(255);

            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(c => c.ServiceCode);

                entity.Property(c => c.ServiceNameE).HasMaxLength(255);

                entity.Property(c => c.ServiceBriefE).HasMaxLength(255);

                entity.Property(c => c.ServiceNameA).HasMaxLength(255);

                entity.Property(c => c.ServiceBriefA).HasMaxLength(255);

                entity.HasOne(p => p.DepartmentNavigationCode)
                    .WithMany(d => d.Services)
                    .HasForeignKey(p => p.DepartmentCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Services_Departments");
            });

            modelBuilder.Entity<ServiceDetail>(entity =>
            {
                entity.HasKey(c => c.ServiceDetailCode);

                entity.Property(c => c.ServiceDetailCode).ValueGeneratedOnAdd();

                entity.Property(c => c.ServiceDetailNameE).HasMaxLength(255);

                entity.Property(c => c.ServiceDetailNameA).HasMaxLength(255);

                entity.Property(c => c.ServiceDetailBriefA).HasMaxLength(255);

                entity.Property(c => c.ServiceDetailBriefA).HasMaxLength(255);

                entity.HasOne(p => p.ServiceNavigationCode)
                    .WithMany(d => d.ServiceDetails)
                    .HasForeignKey(p => p.ServiceCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServiceDetails_Services");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(c => c.BlogCode);

                entity.Property(c => c.BlogCode).ValueGeneratedOnAdd();

                entity.Property(c => c.BlogBriefA).HasMaxLength(255);

                entity.Property(c => c.BlogBriefE).HasMaxLength(255);

                entity.Property(c => c.BlogTitleA).HasMaxLength(255);

                entity.Property(c => c.BlogTitleE).HasMaxLength(255);

                entity.Property(c => c.BlogDate).HasColumnType("datetime");
                
                entity.Property(c => c.BlogPublisherE).HasMaxLength(25);
                
                entity.Property(c => c.BlogPublisherA).HasMaxLength(25);
            });
        }
    }
}
