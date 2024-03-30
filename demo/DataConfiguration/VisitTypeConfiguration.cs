using demo.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace demo.DataConfiguration
{
    public class VisitTypeConfiguration : EntityTypeConfiguration<VisitType>
    {
        public VisitTypeConfiguration()
        {
            ToTable("VisitType");
            Property(x => x.Id).HasColumnName("Id").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasKey(x => x.Id);
            Property(x => x.Name).HasColumnName("Name");
        }
    }
}