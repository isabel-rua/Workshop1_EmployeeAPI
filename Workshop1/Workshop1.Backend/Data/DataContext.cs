using Microsoft.EntityFrameworkCore;
using Workshop1.Shared.Entities;

namespace Workshop1.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}