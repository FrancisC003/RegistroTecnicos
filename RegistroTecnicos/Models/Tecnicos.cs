using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models;

public class Tecnicos
{
    [Key]

    public int TecnicosId { get; set; }
    [Required(ErrorMessage = "El campo Nombre es obligatorio")]
    public string? TecnicosName { get; set; }
    [Range(0.1, float.MaxValue, ErrorMessage = "Favor ingresar un numero mayor que 0")]
    [Required(ErrorMessage = "El campo SueldoHora es obligatorio")]
    public decimal SueldoHora { get; set; }
    
}
