using Microsoft.AspNetCore.Mvc;
using Workshop1.Backend.UnitsOfWork.Interfaces;
using Workshop1.Shared.Entities;

namespace Workshop1.Backend.Controllers;

[ApiController] //Indica que es un controlador de API
[Route("api/[controller]")] //Define la ruta base para las solicitudes HTTP
public class EmployeesController : GenericController<Employee>
{
    public EmployeesController(IGenericUnitOfWork<Employee> unitOfWork) : base(unitOfWork)
    {
    }
}