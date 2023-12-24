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
    public async Task<IActionResult> InsertAsync([FromBody] ApplicationForCreationDto dto)
        => Ok(await _applicationService.AddAsync(dto));

    [HttpGet]
    public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
        => Ok(await _applicationService.RetrieveAllAsync(@params));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] long id)
        => Ok(await _applicationService.RetrieveByIdAsync(id));

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveAsync([FromRoute] long id)
        => Ok(await _applicationService.RemoveAsync(id));

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] short id, [FromBody] ApplicationForUpdateDto dto)
        => Ok(await _applicationService.ModifyAsync(id, dto));
}
