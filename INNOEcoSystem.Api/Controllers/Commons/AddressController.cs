using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Address;
using INNOEcoSystem.Service.Interfaces.Locations;
using Microsoft.AspNetCore.Mvc;

namespace INNOEcoSystem.Api.Controllers.Commons
{
    public class AddressController : BaseController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] AddressForCreationDto dto)
            => Ok(await _addressService.CreateAsync(dto));

        [HttpGet("retrieve-all-users-address")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _addressService.RetrieveAllAsync(@params));

        [HttpGet("deleted-users-address")]
        public async Task<IActionResult> GetAllDeletedUsersAddressAsync([FromQuery] PaginationParams @params)
            => Ok(await _addressService.RetrieveAllDeletedUsersAddressAsync(@params));

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute(Name = "id")] long id)
            => Ok(await _addressService.RetrieveByIdAsync(id));

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync([FromRoute(Name = "id")] long id, [FromForm] AddressForUpdateDto dto)
            => Ok(await _addressService.ModifyAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _addressService.RemoveAsync(id));
    }
}
