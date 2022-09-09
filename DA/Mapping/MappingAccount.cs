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
    public class MappingAccount:IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnType("serial").ValueGeneratedOnAdd();
            builder.Property(x => x.Name);

            builder.HasMany(ac => ac.Contacts)
                .WithOne(c => c.Account);
                
        }
    }
}
