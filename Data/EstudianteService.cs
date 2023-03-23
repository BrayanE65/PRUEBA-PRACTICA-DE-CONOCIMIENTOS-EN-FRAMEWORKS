using Microsoft.EntityFrameworkCore;

namespace PRUEBA_PRACTICA_DE_CONOCIMIENTOS_EN_FRAMEWORKS.Data
{
   public class EstudianteService
{
    private readonly ApplicationDbContext _dbContext;

    public EstudianteService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Estudiante>> ObtenerEstudiantesAsync()
    {
        return await _dbContext.Estudiantes.ToListAsync();
    }

    public async Task AgregarEstudianteAsync(Estudiante estudiante)
    {
        estudiante.Promedio = (float)(estudiante.Nota1 + estudiante.Nota2 + estudiante.Nota3) / 3;
        _dbContext.Estudiantes.Add(estudiante);
        await _dbContext.SaveChangesAsync();
    }
}
}