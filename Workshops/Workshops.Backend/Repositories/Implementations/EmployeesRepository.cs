using Microsoft.EntityFrameworkCore;
using Workshop1.Backend.Data;
using Workshop1.Backend.Repositories.Interfaces;
using Workshop1.Shared.Entities;
using Workshop1.Shared.Responses;

namespace Workshop1.Backend.Repositories.Implementations;

public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
{
    private readonly DataContext _context;

    public EmployeesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string filter)
    {
        filter = (filter ?? string.Empty).Trim();

        var search = $"%{filter}%";

        var result = await _context.Employees
            .Where(e =>
                EF.Functions.Like(EF.Functions.Collate(e.FirstName, "Latin1_General_CI_AI"), search) ||
                EF.Functions.Like(EF.Functions.Collate(e.LastName, "Latin1_General_CI_AI"), search))
            .ToListAsync();

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = result
        };
    }
}