using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using examen.Models;

namespace examen.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Profession>? Profession { get; set; }
        public DbSet<Instructor>? Instructor { get; set; }
        public DbSet<Envrioment>? Envrioment { get; set; }
        public DbSet<Torre>? Torre { get; set; }
        public DbSet<Student>? Student { get; set; }
        public DbSet<Programa>? Programa { get; set; }
    }
}