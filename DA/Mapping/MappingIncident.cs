using DA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA.Mapping
{
    public class MappingIncident:IEntityTypeConfiguration<Incident>
    {
        public void Configure(EntityTypeBuilder<Incident> builder)
        {
            builder.ToTable("Incidents");
            builder.HasKey(x => x.Title);

            builder.Property(x => x.Title).IsRequired();

            builder.HasMany(i => i.Accounts)
                .WithOne(i => i.Incident);
        }
    }
}
