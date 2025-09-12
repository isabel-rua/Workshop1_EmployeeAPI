using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Workshop1.Shared.Entities;

public class Employee
{
    public int Id { get; set; }

    //Display para mostrar al usuario el nombre como uno quiere "decorado"
    [Display(Name = "Nombre")]

    //MaxLength para limitar la cantidad de caractéres que puede tener el campo
    [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres.")]

    // Required para que el campo sea obligatorio
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string FirstName { get; set; } = null!; //Condición null! es para no permitir null en ese campo

    [Display(Name = "Apellido")]
    [MaxLength(30, ErrorMessage = "El campo {0} no puede tener más de {1} caractéres.")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    public string LastName { get; set; } = null!;

    [Display(Name = "¿Esta activo?")]
    public bool IsActive { get; set; }

    [Display(Name = "Fecha de Contratación")]
    [DataType(DataType.DateTime)] // Indica que el campo debe mostrar fecha y hora
    public DateTime HireDate { get; set; }

    [Display(Name = "Salario")]
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [Range(1_000_000, double.MaxValue, ErrorMessage = "El salario debe ser mínimo {1}.")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }
}