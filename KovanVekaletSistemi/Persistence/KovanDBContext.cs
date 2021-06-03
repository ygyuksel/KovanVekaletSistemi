using KovanVekaletSistemi.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KovanVekaletSistemi.Persistence
{
    public class KovanDBContext : DbContext
    {
        public KovanDBContext() : base("name=KovanDBContext")
        {
            //this.Configuration.LazyLoadingEnabled = true;
        }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<AuthorityRole> AuthorityRole { get; set; }
        public virtual DbSet<AuthorityAssignment> AuthorityAssignment { get; set; }

        public virtual DbSet<AuthorityRoleAuthorityAssignment> AuthorityRoleAuthorityAssignment { get; set; }

        public virtual DbSet<JobTitleAuthorityRole> JobTitleAuthorityRole { get; set; }

        public virtual DbSet<TimeOffRequest> TimeOffRequest { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Entity<JobTitle>()
            //            .HasMany<AuthorityRole>(s => s.AuthorityRoles)
            //            .WithMany(c => c.JobTitles)
            //            .Map(cs =>
            //            {
            //                cs.MapLeftKey("JobTitle_Id");
            //                cs.MapRightKey("AuthorityRole_Id");
            //                cs.ToTable("JobTitleAuthorityRoles");
            //            });


            modelBuilder.Entity<JobTitleAuthorityRole>()
       .HasKey(c => new { c.JobTitle_Id, c.AuthorityRole_Id });


            modelBuilder.Entity<AuthorityRole>()
               .HasMany(c => c.JobTitleAuthorityRoles)
               .WithRequired()
               .HasForeignKey(c => c.AuthorityRole_Id);

            modelBuilder.Entity<JobTitle>()
                .HasMany(c => c.JobTitleAuthorityRoles)
                .WithRequired()
                .HasForeignKey(c => c.JobTitle_Id);


            modelBuilder.Entity<AuthorityRoleAuthorityAssignment>()
     .HasKey(c => new { c.AuthorityRole_Id, c.AuthorityAssignment_Id });


            modelBuilder.Entity<AuthorityRole>()
               .HasMany(c => c.AuthorityRoleAuthorityAssignments)
               .WithRequired()
               .HasForeignKey(c => c.AuthorityRole_Id);

            modelBuilder.Entity<AuthorityAssignment>()
                .HasMany(c => c.AuthorityRoleAuthorityAssignments)
                .WithRequired()
                .HasForeignKey(c => c.AuthorityAssignment_Id);
        }
    }
}
