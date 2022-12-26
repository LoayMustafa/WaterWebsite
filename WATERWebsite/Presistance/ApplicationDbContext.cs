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
        public virtual DbSet<SpecializedService> SpecializedService { get; set; } = null!;
        public virtual DbSet<ServiceItem> ServiceItem { get; set; } = null!;
        public virtual DbSet<ServiceProject> ServiceProject { get; set; } = null!;
        public virtual DbSet<ServiceSpecializedService> ServiceSpecializedService { get; set; } = null!;

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

                entity.Property(c => c.ProjectCapacityE).HasMaxLength(25);

                entity.Property(c => c.ProjectOwnerE).HasMaxLength(255);

                entity.Property(c => c.ProjectOperatorE).HasMaxLength(255);

                entity.Property(c => c.ProjectDeveloperE).HasMaxLength(255);

                entity.Property(c => c.ProjectNameA).HasMaxLength(255);

                entity.Property(c => c.ProjectCapacityA).HasMaxLength(25);

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

                entity.HasMany(s => s.Projects)
                    .WithMany(p => p.Services)
                    .UsingEntity<ServiceProject>(
                        j => j
                            .HasOne(sp => sp.Project)
                            .WithMany(p => p.ServiceProjects)
                            .HasForeignKey(sp => sp.ProjectId),
                        j => j
                            .HasOne(sp => sp.Service)
                            .WithMany(s => s.ServiceProjects)
                            .HasForeignKey(sp => sp.ServiceId),
                        j =>
                        {
                            j.HasKey(p => new { p.ServiceId, p.ProjectId });
                        }
                    );

                entity.HasMany(s => s.SpecializedServices)
                    .WithMany(p => p.Services)
                    .UsingEntity<ServiceSpecializedService>(
                        j => j
                            .HasOne(sps => sps.SpecializedService)
                            .WithMany(ss => ss.ServiceSpecializedServices)
                            .HasForeignKey(sp => sp.SpecializedServiceId),
                        j => j
                            .HasOne(sps => sps.Service)
                            .WithMany(s => s.ServiceSpecializedServices)
                            .HasForeignKey(sp => sp.ServiceId),
                        j =>
                        {
                            j.HasKey(p => new { p.ServiceId, p.SpecializedServiceId });
                        }
                    );
            });

            modelBuilder.Entity<SpecializedService>(entity =>
            {
                entity.HasKey(c => c.SpecializedServiceCode);

                entity.Property(c => c.SpecializedServiceNameE).HasMaxLength(255);

                entity.Property(c => c.SpecializedServiceBriefE).HasMaxLength(255);

                entity.Property(c => c.SpecializedServiceNameA).HasMaxLength(255);

                entity.Property(c => c.SpecializedServiceBriefA).HasMaxLength(255);
            });

            modelBuilder.Entity<ServiceItem>(entity =>
            {
                entity.HasKey(c => c.ServiceItemCode);

                entity.Property(c => c.ServiceItemNameE).HasMaxLength(255);

                entity.Property(c => c.ServiceItemNameA).HasMaxLength(255);

                entity.Property(c => c.ServiceItemDescriptionE).HasMaxLength(255);

                entity.Property(c => c.ServiceItemDescriptionA).HasMaxLength(255);

                entity.HasMany(s => s.SpecializedServices)
                    .WithMany(p => p.ServiceItems)
                    .UsingEntity<SpecializedServicesItems>(
                        j => j
                            .HasOne(s => s.SpecializedServices)
                            .WithMany(i => i.SpecializedServicesItems)
                            .HasForeignKey(sp => sp.SpecializedServiceId),
                        j => j
                            .HasOne(i => i.ServiceItems)
                            .WithMany(s => s.SpecializedServicesItems)
                            .HasForeignKey(sp => sp.ServiceItemId),
                        j =>
                        {
                            j.HasKey(p => new { p.ServiceItemId, p.SpecializedServiceId });
                        }
                    );

                entity.HasMany(s => s.Projects)
                    .WithMany(p => p.ServiceItems)
                    .UsingEntity<ProjectsServiceItems>(
                        j => j
                            .HasOne(s => s.Projects)
                            .WithMany(i => i.ProjectsServiceItems)
                            .HasForeignKey(sp => sp.ProjectId),
                        j => j
                            .HasOne(i => i.ServiceItems)
                            .WithMany(s => s.ProjectsServiceItems)
                            .HasForeignKey(sp => sp.ServiceItemId),
                        j =>
                        {
                            j.HasKey(p => new { p.ProjectId, p.ServiceItemId });
                        }
                    );

            });
        }
    }
}
