using Workshops.Backend.Repositories.Interfaces;
using Workshops.Backend.UnitsOfWork.Interfaces;
using Workshops.Shared.DTOs;
using Workshops.Shared.Entities;
using Workshops.Shared.Responses;

namespace Workshops.Backend.UnitsOfWork.Implementations;

public class EmployeesUnitOfWork : GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesUnitOfWork(IGenericRepository<Employee> repository,
        IEmployeesRepository employeesRepository) : base(repository)
    {
        _employeesRepository = employeesRepository;
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await
        _employeesRepository.GetTotalRecordsAsync(pagination);

    //Sobreescribir método GetAsync con paginación
    public override async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(PaginationDTO pagination) => await
        _employeesRepository.GetAsync(pagination);

    public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string filter)
        => await _employeesRepository.GetAsync(filter);
}