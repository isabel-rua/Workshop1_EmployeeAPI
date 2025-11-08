using Workshops.Backend.Repositories.Implementations;
using Workshops.Backend.Repositories.Interfaces;
using Workshops.Backend.UnitsOfWork.Interfaces;
using Workshops.Shared.DTOs;
using Workshops.Shared.Entities;
using Workshops.Shared.Responses;

namespace Workshops.Backend.UnitsOfWork.Implementations;

public class CountriesUnitOfWork : GenericUnitOfWork<Country>, ICountriesUnitOfWork
{
    private readonly ICountriesRepository _countriesRepository;

    public CountriesUnitOfWork(IGenericRepository<Country> repository, ICountriesRepository
        countriesRepository) : base(repository)
    {
        _countriesRepository = countriesRepository;
    }

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await
        _countriesRepository.GetTotalRecordsAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync(PaginationDTO pagination) => await
        _countriesRepository.GetAsync(pagination);

    public override async Task<ActionResponse<IEnumerable<Country>>> GetAsync() => await
        _countriesRepository.GetAsync();

    public override async Task<ActionResponse<Country>> GetAsync(int id) => await
        _countriesRepository.GetAsync(id);
}