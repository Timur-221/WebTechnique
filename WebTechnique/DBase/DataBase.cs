using Microsoft.EntityFrameworkCore;
using System;
using WebTechnique.Models.DBModel;

namespace WebTechnique.DBase
{
    public class DataBase : DbContext
    {
        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
         .HasOne(a => a.PersonToRole) 
         .WithOne() 
         .HasForeignKey<Account>(a => a.PersonToRoleId);

            modelBuilder.Entity<PersonToRole>()
                .HasKey(pt => pt.Id);

            modelBuilder.Entity<PersonToRole>()
                .HasOne(pt => pt.Person)
                .WithMany(p => p.PersonToRoles)
                .HasForeignKey(pt => pt.PersonId);

            modelBuilder.Entity<PersonToRole>()
                .HasOne(pt => pt.Role)
                .WithMany(r => r.PersonToRoles)
                .HasForeignKey(pt => pt.RoleId);

          
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PersonToRole> PersonsToRoles { get; set; }
    }
}
