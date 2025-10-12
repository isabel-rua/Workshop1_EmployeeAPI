using Microsoft.EntityFrameworkCore;
using Workshops.Shared.Entities;

namespace Workshops.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;

    public SeedDb(DataContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();

        await CheckEmployeesFullAsync();
        await CheckEmployeeAsync();
    }

    private async Task CheckEmployeesFullAsync()
    {
        if (!_context.Employees.Any())
        {
            var employeesSQLScript = File.ReadAllText("Data\\Employees.sql");
            await _context.Database.ExecuteSqlRawAsync(employeesSQLScript);
        }
    }

    private async Task CheckEmployeeAsync()
    {
        if (!_context.Employees.Any())
        {
            _context.Employees.Add(new Employee
            {
                FirstName = "Julian",
                LastName = "Gómez",
                IsActive = true,
                HireDate = new DateTime(2022, 05, 20, 14, 15, 0),
                Salary = 2_000_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "Pedro",
                LastName = "Gallego",
                IsActive = true,
                HireDate = new DateTime(2024, 01, 12, 10, 0, 0),
                Salary = 1_600_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "Luisa",
                LastName = "Martínez",
                IsActive = false,
                HireDate = new DateTime(2023, 06, 25, 15, 30, 0),
                Salary = 1_400_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "Andrés",
                LastName = "Juárez",
                IsActive = false,
                HireDate = new DateTime(2023, 07, 03, 9, 0, 0),
                Salary = 1_300_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "María",
                LastName = "Monsalve",
                IsActive = true,
                HireDate = new DateTime(2023, 03, 05, 11, 45, 0),
                Salary = 1_800_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "Sofía",
                LastName = "Hernández",
                IsActive = true,
                HireDate = new DateTime(2024, 02, 28, 16, 20, 0),
                Salary = 1_750_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "Juan",
                LastName = "Pérez",
                IsActive = true,
                HireDate = new DateTime(2023, 01, 15, 9, 30, 0),
                Salary = 1_500_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "Carolina",
                LastName = "San Martín",
                IsActive = true,
                HireDate = new DateTime(2025, 04, 10, 8, 30, 0),
                Salary = 2_200_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "Julián",
                LastName = "Vargas",
                IsActive = true,
                HireDate = new DateTime(2022, 09, 17, 13, 0, 0),
                Salary = 2_100_000
            });

            _context.Employees.Add(new Employee
            {
                FirstName = "Ana Julia",
                LastName = "Ramírez",
                IsActive = false,
                HireDate = new DateTime(2022, 08, 10, 8, 0, 0),
                Salary = 1_200_000
            });
            await _context.SaveChangesAsync();
        }
    }
}