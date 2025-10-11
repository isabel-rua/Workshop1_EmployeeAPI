using Workshops.Shared.DTOs;
using Workshops.Shared.Entities;
using Workshops.Shared.Responses;

namespace Workshops.Backend.Repositories.Interfaces;

public interface IEmployeesRepository
{
    Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination);

    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination);

    Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string filter);
}