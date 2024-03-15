using Microsoft.EntityFrameworkCore;
using System;
using WebTechnique.Models.DBModel;

namespace WebTechnique.DBase
{
    public class DataBase : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<PersonToRole> PeopleToRoles { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Specialty> Specialties { get; set; }



        public DataBase(DbContextOptions<DataBase> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
           .HasOne(a => a.PersonToRole)
           .WithMany()
           .HasForeignKey(a => a.PersonToRoleId); // Внешний ключ в Account

            modelBuilder.Entity<PersonToRole>()
                .HasOne(ptr => ptr.Person)
                .WithMany(p => p.PersonToRoles)
                .HasForeignKey(ptr => ptr.PersonId);

            modelBuilder.Entity<PersonToRole>()
                .HasOne(ptr => ptr.Role)
                .WithMany(r => r.PersonToRoles)
                .HasForeignKey(ptr => ptr.RoleId);

            modelBuilder.Entity<Lesson>()
            .HasOne(l => l.Teacher)
            .WithMany(t => t.Lessons)
            .HasForeignKey(l => l.TeacherId);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Group)
                .WithMany(g => g.Lessons)
                .HasForeignKey(l => l.GroupId);

            modelBuilder.Entity<Lesson>()
                .HasOne(l => l.Subject)
                .WithMany(s => s.Lessons)
                .HasForeignKey(l => l.SubjectId);

            modelBuilder.Entity<Student>()
             .HasOne(s => s.Specialty)         // У каждого студента есть одна специальность
            .WithMany(sp => sp.Students)       // Одна специальность может иметь много студентов
             .HasForeignKey(s => s.SpecialtyId); // Внешний ключ в таблице студентов

            modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)        
            .WithMany(sp => sp.Students)      
               .HasForeignKey(s => s.GroupId); 

        }
    }
}
