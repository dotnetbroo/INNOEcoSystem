using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Applications;
using INNOEcoSystem.Service.Interfaces.Applications;
using Microsoft.AspNetCore.Mvc;

namespace INNOEcoSystem.Api.Controllers.Applications;

public class ApplicationsController : BaseController
{
    private readonly IApplicationService _applicationService;

    public ApplicationsController(IApplicationService applicationService)
    {
        _applicationService = applicationService;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync([FromForm] ApplicationForCreationDto dto)
        => Ok(await _applicationService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _applicationService.RetrieveAllAsync(@params));

    [HttpGet("retrieve-all-deleted-applications")]
    public async Task<IActionResult> GetAllDeletedUsersAsync([FromQuery] PaginationParams @params)
            => Ok(await _applicationService.RetrieveAllDeletedApplicationAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long id)
        => Ok(await _applicationService.RetrieveByIdAsync(id));

    [HttpGet("search-by-application-number")]
    public async Task<IActionResult> GetApplicationByNumberAsync([FromRoute(Name = "number")] int num)
        => Ok(await _applicationService.SearchApplicationByNumberAsync(num));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute(Name = "id")] long id)
        => Ok(await _applicationService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] long id, [FromForm] ApplicationForUpdateDto dto)
        => Ok(await _applicationService.ModifyAsync(id, dto));


}
