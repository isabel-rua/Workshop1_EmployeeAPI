using Workshop1.Shared.Entities;

namespace Workshop1.Backend.Data;

public class SeedDb
{
    //Esta clase es un alimentador de datos (seeder).
    //Esta clase se encarga de inicializar y poblar la base de datos con datos predeterminados.

    //Inyectar la conexión a la base de datos
    //Para que la inyección permanezca durante todo el ciclo de vida de la app se crea propiedad
    private readonly DataContext _context; //_context es un campo de la clase estandar

    public SeedDb(DataContext context) //Con lo que esta () se inyecta el contexto de la bd
    {
        _context = context;
    }

    //Método SeedAsync para garantizar que la BD exista y cree registros
    public async Task SeedAsync()
    {
        await _context.Database.EnsureCreatedAsync(); //Asegura que la BD exista, si no existe, se crea la BD.

        //Estos 2 métodos son para garantizar que existan los países y las categorías en la BD.
        await CheckEmployeeAsync();
    }

    //Métodos privados para verificar y agregar categorías y países

    private async Task CheckEmployeeAsync()
    {
        if (!_context.Employees.Any()) //Método Any = alguna, se niega condición (!) "Si no hay empleados"
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
            await _context.SaveChangesAsync(); //Guardar los cambios
        }
    }
}