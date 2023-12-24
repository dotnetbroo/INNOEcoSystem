using INNOEcoSystem.Api.Controllers.Commons;
using INNOEcoSystem.Domain.Configurations;
using INNOEcoSystem.Service.DTOs.Department;
using INNOEcoSystem.Service.DTOs.DepartmentAssets;
using INNOEcoSystem.Service.DTOs.Departments;
using INNOEcoSystem.Service.Interfaces.Department;
using Microsoft.AspNetCore.Mvc;

namespace INNOEcoSystem.Api.Controllers.Departments
{
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService communityService)
        {
            _departmentService = communityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute(Name = "id")] long Id)
            => Ok(await _departmentService.RetrieveByIdAsync(Id));

        [HttpGet]
        public async Task<IActionResult> GeAllAsync([FromQuery] PaginationParams @params)
            => Ok(await _departmentService.RetrieveAllAsync(@params));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute(Name = "id")] long id)
            => Ok(await _departmentService.RemoveAsync(id));

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentForCreationDto departmentForCreationDto)
            => Ok(await _departmentService.AddAsync(departmentForCreationDto));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute(Name = "id")] long id, [FromBody] DepartmentForUpdateDto departmentForUpdateDto)
            => Ok(await _departmentService.ModifyAsync(id, departmentForUpdateDto));


        [HttpPost("Department/License/{id}")]
        public async Task<IActionResult> CreateLicenseAsync([FromRoute(Name = "id")] long id, [FromForm] DepartmentAssetForCreationDto file)
            => Ok(await _departmentService.CreateLicenseAsync(id, file));


        [HttpPost("Department/Logo/{id}")]
        public async Task<IActionResult> CreateLogoAsync([FromRoute(Name = "id")] long id, [FromForm] DepartmentAssetForCreationDto file)
            => Ok(await _departmentService.CreateLogoAsync(id, file));

        [HttpPatch("Department/License/{id}")]
        public async Task<IActionResult> UpdateLicenseAsync([FromRoute(Name = "id")] long id, [FromForm] DepartmentAssetForCreationDto file)
           => Ok(await _departmentService.UpdateLicenseAsync(id, file));

        [HttpPatch("Department/Logo/{id}")]
        public async Task<IActionResult> UpdateLogoAsync([FromRoute(Name = "id")] long id, [FromForm] DepartmentAssetForCreationDto file)
            => Ok(await _departmentService.UpdateLogoAsync(id, file));

    }
}
