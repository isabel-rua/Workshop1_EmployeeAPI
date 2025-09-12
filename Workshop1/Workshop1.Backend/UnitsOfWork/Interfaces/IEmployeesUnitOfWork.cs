using Workshop1.Shared.Entities;
using Workshop1.Shared.Responses;

namespace Workshop1.Backend.UnitsOfWork.Interfaces;

public interface IEmployeesUnitOfWork
{
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string filter);
}