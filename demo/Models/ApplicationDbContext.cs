using demo.DataConfiguration;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace demo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public virtual DbSet<Visit> visits { get; set; }

        public virtual DbSet<VisitType> VisitTypes { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new VisitConfiguration());
            modelBuilder.Configurations.Add(new VisitTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}