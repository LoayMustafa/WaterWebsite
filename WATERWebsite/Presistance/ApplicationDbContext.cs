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
        public virtual DbSet<Service> Service { get; set; } = null!;
        public virtual DbSet<Division> Division { get; set; } = null!;
        public virtual DbSet<SubService> SubService { get; set; } = null!;
        public virtual DbSet<ServiceDivisons> ServiceDivisons { get; set; } = null!;
        public virtual DbSet<ProjectServices> ProjectServices { get; set; } = null!;
        public virtual DbSet<DivisionSubServices> DivisionSubServices { get; set; } = null!;

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

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(c => c.ServiceCode);

                entity.Property(c => c.ServiceNameE).HasMaxLength(255);

                entity.Property(c => c.ServiceBriefE).HasMaxLength(255);

                entity.Property(c => c.ServiceNameA).HasMaxLength(255);

                entity.Property(c => c.ServiceBriefA).HasMaxLength(255);
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(c => c.DivisionCode);

                entity.Property(c => c.DivisionNameE).HasMaxLength(255);

                entity.Property(c => c.DivisionNameA).HasMaxLength(255);

                entity.Property(c => c.DivisionNameA).HasMaxLength(255);

                entity.Property(c => c.DivisionNameA).HasMaxLength(255);
            });

            modelBuilder.Entity<ServiceDivisons>(entity =>
            {
                entity.HasKey(e => new { e.ServiceCode, e.DivisionCode });

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ServiceDivisons)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("Fk_ServiceDivisions_Service");

                entity.HasOne(d => d.DivisionCodeNavigation)
                    .WithMany(p => p.ServiceDivisons)
                    .HasForeignKey(d => d.DivisionCode)
                    .HasConstraintName("Fk_ServiceDivisions_Division");
            });

            modelBuilder.Entity<SubService>(entity =>
            {
                entity.HasKey(c => c.SubServiceCode);

                entity.Property(c => c.SubServiceNameE).HasMaxLength(255);

                entity.Property(c => c.SubServiceNameA).HasMaxLength(255);

                entity.Property(c => c.SubServiceBriefA).HasMaxLength(255);

                entity.Property(c => c.SubServiceBriefE).HasMaxLength(255);
            });

            modelBuilder.Entity<ProjectServices>(entity =>
            {
                entity.HasKey(e => new { e.ProjectCode, e.ServiceCode });

                entity.HasOne(d => d.ProjectCodeNavigation)
                    .WithMany(p => p.ProjectServices)
                    .HasForeignKey(d => d.ProjectCode)
                    .HasConstraintName("Fk_ProjectServices_Project");

                entity.HasOne(d => d.ServiceCodeNavigation)
                    .WithMany(p => p.ProjectServices)
                    .HasForeignKey(d => d.ServiceCode)
                    .HasConstraintName("Fk_ProjectServices_Service");
            });

            modelBuilder.Entity<DivisionSubServices>(entity =>
            {
                entity.HasKey(e => new { e.DivisionCode, e.SubServiceCode });

                entity.HasOne(d => d.DivisionCodeNavigation)
                    .WithMany(p => p.DivisionSubServices)
                    .HasForeignKey(d => d.DivisionCode)
                    .HasConstraintName("Fk_DivisionSubServices_Division");

                entity.HasOne(d => d.SubServiceCodeNavigation)
                    .WithMany(p => p.DivisionSubServices)
                    .HasForeignKey(d => d.SubServiceCode)
                    .HasConstraintName("Fk_DivisionSubServices_SubService");
            });
        }
    }
}
