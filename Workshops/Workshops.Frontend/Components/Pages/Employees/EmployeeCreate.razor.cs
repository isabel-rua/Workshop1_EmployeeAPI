using Microsoft.AspNetCore.Components;
using MudBlazor;
using Workshops.Frontend.Repositories;
using Workshops.Shared.Entities;

namespace Workshops.Frontend.Components.Pages.Employees;

public partial class EmployeeCreate
{
    private Employee employee = new()
    {
        IsActive = true,
        HireDate = DateTime.Today,
        Salary = 1_000_000m
    };

    [Inject] private IRepository Repository { get; set; } = null!;
    [Inject] private NavigationManager NavigationManager { get; set; } = null!;
    [Inject] private ISnackbar Snackbar { get; set; } = null!;

    private async Task CreateAsync()
    {
        var responseHttp = await Repository.PostAsync("/api/employees", employee);
        if (responseHttp.Error)
        {
            var message = await responseHttp.GetErrorMessageAsync();
            Snackbar.Add(message!, Severity.Error);
            return;
        }

        Return();
        Snackbar.Add("Registro creado", Severity.Success);
    }

    private void Return()
    {
        NavigationManager.NavigateTo("/employees");
    }
}