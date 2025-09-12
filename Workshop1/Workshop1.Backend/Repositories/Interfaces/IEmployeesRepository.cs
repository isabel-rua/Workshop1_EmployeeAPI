using Workshop1.Shared.Entities;
using Workshop1.Shared.Responses;

namespace Workshop1.Backend.Repositories.Interfaces;

public interface IEmployeesRepository
{
    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string filter);
}