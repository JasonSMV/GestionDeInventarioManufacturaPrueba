using System.ComponentModel.DataAnnotations;

namespace API.Dtos.Estados;

public class EstadoCrearDto
{
    [Required]
    public string Nombre { get; set; }
}