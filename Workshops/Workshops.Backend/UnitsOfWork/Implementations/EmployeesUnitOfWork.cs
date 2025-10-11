using Workshop1.Backend.Repositories.Interfaces;
using Workshop1.Backend.UnitsOfWork.Interfaces;
using Workshop1.Shared.Entities;
using Workshop1.Shared.Responses;

namespace Workshop1.Backend.UnitsOfWork.Implementations;

public class EmployeesUnitOfWork : GenericUnitOfWork<Employee>, IEmployeesUnitOfWork
{
    private readonly IEmployeesRepository _employeesRepository;

    public EmployeesUnitOfWork(IGenericRepository<Employee> repository,
        IEmployeesRepository employeesRepository) : base(repository)
    {
        _employeesRepository = employeesRepository;
    }

    public async Task<ActionResponse<IEnumerable<Employee>>> GetAsync(string filter)
            => await _employeesRepository.GetAsync(filter);
}