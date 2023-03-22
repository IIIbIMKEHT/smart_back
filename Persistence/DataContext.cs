using Domain.Entities;
using Domain.Entities.Systems;
using Domain.EntityConfigurations;
using Domain.EntityConfigurations.System;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public virtual async Task<int> SaveChangesAsync(string username = "SYSTEM")
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.UpdatedAt = DateTime.Now;
                

                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.Now;
                }
            }

            var result = await base.SaveChangesAsync();

            return result;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new GvszConfiguration());
            modelBuilder.ApplyConfiguration(new WorkloadConfiguration());
        }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AcademicYear> AcademicYears { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<RolesUsers> RolesUsers { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Week> Weeks { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Gvsz> Gvszs { get; set; }
        public DbSet<Workload> Workloads { get; set; }
    }
}
