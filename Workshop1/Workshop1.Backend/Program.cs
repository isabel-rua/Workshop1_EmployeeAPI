using Microsoft.EntityFrameworkCore;
using Workshop1.Backend.Data;
using Workshop1.Backend.Repositories.Implementations;
using Workshop1.Backend.Repositories.Interfaces;
using Workshop1.Backend.UnitsOfWork.Implementations;
using Workshop1.Backend.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyectar conexión con la BD
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("name=LocalConnection"));

builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddScoped<IEmployeesUnitOfWork, EmployeesUnitOfWork>();

var app = builder.Build();

//Luego de crear la app, se inyecata llamando el método SeedData que recibe la app (WebApplication)
SeedData(app);

void SeedData(WebApplication app)
{
    //scopedFactory es la forma de llamar las direcciones de los servicios
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    //Con esto se garantiza que cada que se corra el programa se ejecute el método SeedAsync de la clase SeedDb
    using var scope = scopedFactory!.CreateScope();
    var service = scope.ServiceProvider.GetService<SeedDb>();
    service!.SeedAsync().Wait(); //Es .Wait porque se llama un método async desde un método que no es async

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}