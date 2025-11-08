using Microsoft.EntityFrameworkCore;
using Workshops.Backend.UnitsOfWork.Implementations;
using Workshops.Backend.UnitsOfWork.Interfaces;
using Workshops.Shared.Entities;
using Workshops.Shared.Enums;

namespace Workshops.Backend.Data;

public class SeedDb
{
    private readonly DataContext _context;
    private readonly IUsersUnitOfWork _usersUnitOfWork;

    public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork)
    {
        _context = context;
        _usersUnitOfWork = usersUnitOfWork;
    }

    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync();

        await CheckCountriesFullAsync();
        await CheckCountriesAsync();
        await CheckEmployeesFullAsync();
        await CheckEmployeeAsync();
        await CheckRolesAsync();
        await CheckUserAsync("1010", "Isabel", "Rua", "IsabelRua@yopmail.com", "322 311 4620", "Calle Luna Calle Sol",
                             UserType.Admin);
    }

    private async Task CheckCountriesFullAsync()
    {
        if (!_context.Countries.Any())
        {
            var countriesSQLScript = File.ReadAllText("Data\\CountriesStatesCities.sql");
            await _context.Database.ExecuteSqlRawAsync(countriesSQLScript);
        }
    }

    private async Task CheckEmployeesFullAsync()
    {
        if (!_context.Employees.Any())
        {
            var employeesSQLScript = File.ReadAllText("Data\\Employees.sql");
            await _context.Database.ExecuteSqlRawAsync(employeesSQLScript);
        }
    }

    private async Task CheckCountriesAsync()
    {
        if (!_context.Countries.Any())
        {
            _context.Countries.Add(new Country
            {
                Name = "Colombia",
                States = [
               new State()
                {
                    Name = "Antioquia",
                    Cities = [
                        new City() { Name = "Medellín" },
                        new City() { Name = "Itagüí" },
                        new City() { Name = "Envigado" },
                        new City() { Name = "Bello" },
                        new City() { Name = "Rionegro" },
                    ]
                },
                new State()
                {
                    Name = "Bogotá",
                    Cities = [
                        new City() { Name = "Usaquen" },
                        new City() { Name = "Champinero" },
                        new City() { Name = "Santa fe" },
                        new City() { Name = "Useme" },
                        new City() { Name = "Bosa" },
                    ]
                },
            ]
            });
            _context.Countries.Add(new Country
            {
                Name = "Estados Unidos",
                States = [
                    new State()
                {
                    Name = "Florida",
                    Cities = [
                        new City() { Name = "Orlando" },
                        new City() { Name = "Miami" },
                        new City() { Name = "Tampa" },
                        new City() { Name = "Fort Lauderdale" },
                        new City() { Name = "Key West" },
                    ]
                },
                new State()
                    {
                        Name = "Texas",
                        Cities = [
                            new City() { Name = "Houston" },
                            new City() { Name = "San Antonio" },
                            new City() { Name = "Dallas" },
                            new City() { Name = "Austin" },
                            new City() { Name = "El Paso" },
                        ]
                    },
                ]
            });
        }
        await _context.SaveChangesAsync();
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

    private async Task CheckRolesAsync()
    {
        await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString());
        await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());
    }

    private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string
    phone, string address, UserType userType)
    {
        var user = await _usersUnitOfWork.GetUserAsync(email);
        if (user == null)
        {
            user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phone,
                Address = address,
                Document = document,
                City = _context.Cities.FirstOrDefault(),
                UserType = userType,
            };

            await _usersUnitOfWork.AddUserAsync(user, "123456");
            await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
        }

        return user;
    }
}