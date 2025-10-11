using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshops.Shared.Entities;

public class Employee
{
    public int Id { get; set; }

    [Display(Name = "Nombre")]
    [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string FirstName { get; set; } = null!;

    [Display(Name = "Apellido")]
    [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string LastName { get; set; } = null!;

    [Display(Name = "¿Esta activo?")]
    public bool IsActive { get; set; }

    [Display(Name = "Fecha de Contratación")]
    [DataType(DataType.DateTime)]
    public DateTime HireDate { get; set; }

    [Display(Name = "Salario")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Range(1_000_000, double.MaxValue, ErrorMessage = "El salario debe ser mínimo {1}.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }
}

