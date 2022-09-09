using DA.Entities;
using DA.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DA
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
            modelBuilder.ApplyConfiguration(new MappingIncident());
            modelBuilder.ApplyConfiguration(new MappingContact());
            modelBuilder.ApplyConfiguration(new MappingAccount());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}