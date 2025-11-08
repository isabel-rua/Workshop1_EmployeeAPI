using Workshops.Backend.Repositories.Interfaces;
using Workshops.Backend.UnitsOfWork.Interfaces;
using Workshops.Shared.DTOs;
using Workshops.Shared.Entities;
using Workshops.Shared.Responses;

namespace Workshops.Backend.UnitsOfWork.Implementations;

public class StatesUnitOfWork : GenericUnitOfWork<State>, IStatesUnitOfWork
{
    private readonly IStatesRepository _statesRepository;

    public StatesUnitOfWork(IGenericRepository<State> repository, IStatesRepository statesRepository) : base(repository)
    {
        _statesRepository = statesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync(PaginationDTO pagination) => await
        _statesRepository.GetAsync(pagination);

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await
        _statesRepository.GetTotalRecordsAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<State>>> GetAsync() => await
        _statesRepository.GetAsync();

    public override async Task<ActionResponse<State>> GetAsync(int id) => await _statesRepository.GetAsync(id);
}