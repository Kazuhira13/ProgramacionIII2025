using Clase11.Entities;
using Microsoft.EntityFrameworkCore;
using Clase11.Models;

namespace Clase11.Data
{
    public class ClaseDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Profesor> Profesores { get; set; }
    }
}
