using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.LocationsAsset;
using INNOEcoSystem.Service.DTOs.Users;
using INNOEcoSystem.Service.Interfaces.LocationAssets;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace INNOEcoSystem.Api.Controllers.LocationAssets
{
    public class LocationAssetController : BaseController
    {
        private readonly ILocationAssetService _locationAssetService;

        public LocationAssetController(ILocationAssetService locationAssetService)
        {
            _locationAssetService = locationAssetService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromForm] LocationAssetForCreationDto dto)
            => Ok(await _locationAssetService.CreateAsync(dto));

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _locationAssetService.RetrieveAllAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "id")] long id)
            => Ok(await _locationAssetService.RetrieveByIdAsync(id));


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _locationAssetService.RemoveAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] LocationAssetForUpdateDto dto)
            => Ok(await this._locationAssetService.ModifyAsync(id, dto));
    }
}
