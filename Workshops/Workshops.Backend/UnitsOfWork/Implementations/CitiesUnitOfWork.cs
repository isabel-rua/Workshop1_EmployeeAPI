using System.Security.Cryptography;
using Workshops.Backend.Repositories.Implementations;
using Workshops.Backend.Repositories.Interfaces;
using Workshops.Backend.UnitsOfWork.Interfaces;
using Workshops.Shared.DTOs;
using Workshops.Shared.Entities;
using Workshops.Shared.Responses;

namespace Workshops.Backend.UnitsOfWork.Implementations;

public class CitiesUnitOfWork : GenericUnitOfWork<City>, ICitiesUnitOfWork
{
    private readonly ICitiesRepository _citiesRepository;

    public CitiesUnitOfWork(IGenericRepository<City> repository, ICitiesRepository citiesRepository) : base(repository)
    {
        _citiesRepository = citiesRepository;
    }

    public override async Task<ActionResponse<IEnumerable<City>>> GetAsync(PaginationDTO pagination) => await
        _citiesRepository.GetAsync(pagination);

    public override async Task<ActionResponse<int>> GetTotalRecordsAsync(PaginationDTO pagination) => await
        _citiesRepository.GetTotalRecordsAsync(pagination);
}