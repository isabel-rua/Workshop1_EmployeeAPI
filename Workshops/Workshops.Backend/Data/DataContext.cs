using Microsoft.EntityFrameworkCore;
using Workshops.Shared.Entities;

namespace Workshops.Backend.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Employee> Employees { get; set; }
}

