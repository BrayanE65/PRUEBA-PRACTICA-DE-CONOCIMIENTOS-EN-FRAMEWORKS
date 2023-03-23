using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PRUEBA_PRACTICA_DE_CONOCIMIENTOS_EN_FRAMEWORKS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
          public DbSet<Estudiante> Estudiantes { get; set; }
    }
}