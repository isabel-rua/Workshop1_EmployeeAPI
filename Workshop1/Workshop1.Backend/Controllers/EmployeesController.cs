using Microsoft.AspNetCore.Mvc;
using Workshop1.Backend.UnitsOfWork.Interfaces;
using Workshop1.Shared.Entities;

namespace Workshop1.Backend.Controllers;

[ApiController] //Indica que es un controlador de API
[Route("api/[controller]")] //Define la ruta base para las solicitudes HTTP
public class EmployeesController : GenericController<Employee>
{
    private readonly IEmployeesUnitOfWork _employeesUnitOfWork;

    public EmployeesController(IGenericUnitOfWork<Employee> unitOfWork,
        IEmployeesUnitOfWork employeesUnitOfWork) : base(unitOfWork)
    {
        _employeesUnitOfWork = employeesUnitOfWork;
    }

    // GET /api/employees/search/ju
    [HttpGet("search/{filter}")]
    public async Task<IActionResult> SearchAsync(string filter)
    {
        var action = await _employeesUnitOfWork.GetAsync(filter);

        if (!action.WasSuccess)
        {
            return BadRequest(action.Message);
        }
        else if (action.Result == null || !action.Result.Any())
        {
            return NotFound("No se encontraron empleados que coincidan con el filtro.");
        }
        else
        {
            return Ok(action.Result);
        }
    }
}