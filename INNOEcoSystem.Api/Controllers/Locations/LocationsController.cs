using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Locations;
using INNOEcoSystem.Service.Interfaces.Location;
using Microsoft.AspNetCore.Mvc;

namespace INNOEcoSystem.Api.Controllers.Locations
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationsController : BaseController
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] LocationForCreationDto dto)
       => Ok(await this._locationService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await this._locationService.RetrieveAllAsync(@params));


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await this._locationService.RetrieveByIdAsync(id));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await this._locationService.RemoveAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromBody] LocationForUpdateDto dto)
            => Ok(await this._locationService.ModifyAsync(id, dto));
    }
}
