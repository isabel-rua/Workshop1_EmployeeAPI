using Microsoft.EntityFrameworkCore;
using Workshops.Backend.Data;
using Workshops.Backend.Helpers;
using Workshops.Backend.Repositories.Interfaces;
using Workshops.Shared.DTOs;
using Workshops.Shared.Entities;
using Workshops.Shared.Responses;

namespace Workshops.Backend.Repositories.Implementations;

public class EmployeesRepository : GenericRepository<Employee>, IEmployeesRepository
{
    private readonly DataContext _context;

    public EmployeesRepository(DataContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination)
    {
        var queryable = _context.Employees
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            var filter = pagination.Filter;
            var search = $"%{filter}%";
            queryable = queryable.Where(x =>
             EF.Functions.Like(EF.Functions.Collate(x.FirstName, "Latin1_General_CI_AI"), search) ||
             EF.Functions.Like(EF.Functions.Collate(x.LastName, "Latin1_General_CI_AI"), search)); ;
        }

        return new ActionResponse<IEnumerable<Employee>>
        {
            WasSuccess = true,
            Result = await queryable
                .OrderBy(x => x.FirstName)
                .Paginate(pagination)
                .ToListAsync()
        };
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination)
    {
        var queryable = _context.Employees.AsQueryable();

        if (!string.IsNullOrWhiteSpace(pagination.Filter))
        {
            var filter = pagination.Filter;
            var search = $"%{filter}%";
            queryable = queryable.Where(x =>
             EF.Functions.Like(EF.Functions.Collate(x.FirstName, "Latin1_General_CI_AI"), search) ||
             EF.Functions.Like(EF.Functions.Collate(x.LastName, "Latin1_General_CI_AI"), search)); ;
        }

        try
        {
            double count = await queryable.CountAsync();
            return new ActionResponse<int>
            {
                WasSuccess = true,
                Result = (int)count
            };
        }
        catch (Exception ex)
        {
            throw;
        }
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