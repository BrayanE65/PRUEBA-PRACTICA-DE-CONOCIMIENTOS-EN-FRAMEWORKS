using System.ComponentModel.DataAnnotations;

namespace PRUEBA_PRACTICA_DE_CONOCIMIENTOS_EN_FRAMEWORKS.Data
{
    

public class Estudiante {

    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Nota1 { get; set; }
    public int Nota2 { get; set; }
    public int Nota3 { get; set; }
    public float Promedio { get; set; }
}
}