using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Domain.Configurations;
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

        [HttpGet("{location-id}/{id}")]
        public async Task<IActionResult> GetById([FromRoute(Name = "location-id")]long locationId ,long id)
            =>Ok(await _locationAssetService.RetrieveByIdAsync(locationId, id));

        [HttpGet]
        public async Task<IActionResult>GetAllAsync([FromQuery] PaginationParams @params)
            =>Ok(await _locationAssetService.RetrieveAllAsync(@params));

        [HttpDelete("{location-id}/{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "location-id")] long locationId, long id)
            => Ok(await _locationAssetService.RemoveAsync(locationId, id));



        [HttpPost("{location-id}")]
        public async Task<IActionResult> CreateAsync([FromRoute(Name = "location-id")] long id,[Required]IFormFile formFile)
            =>Ok(await _locationAssetService.CreateAsync(id,formFile));

    }
}
