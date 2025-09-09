using Microsoft.EntityFrameworkCore;
using Workshop1.Shared.Entities;

namespace Workshop1.Backend.Data;

public class DataContext : DbContext
{
    //Constructor del contexto para la construcción de la BD (estructura lógica)
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    //Crea la tabla Employees a partir de la entidad Employee
    public DbSet<Employee> Employees { get; set; }
}