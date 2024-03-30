using demo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace demo.DataConfiguration
{
    public class VisitConfiguration : EntityTypeConfiguration<Visit>
    {
        public VisitConfiguration()
        {
            ToTable("Visit");
            Property(x => x.VisitId).HasColumnName("VisitId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(x => x.VisitId);
            Property(x => x.Title).HasColumnName("Title");
            Property(x => x.From).HasColumnName("From");
            Property(x => x.To).HasColumnName("To");
            Property(x => x.NumberOfDays).HasColumnName("NumberOfDays");
            Property(x => x.VisitTypeId).HasColumnName("VisitTypeId");
            Property(x => x.Notes).HasColumnName("Notes");

            HasRequired(x => x.VisitType).WithMany().HasForeignKey(x => x.VisitTypeId);
         }
    }
}