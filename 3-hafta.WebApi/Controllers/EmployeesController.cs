using _3_hafta.Business.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _3_hafta.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : BaseController<Employee, EmployeeDto>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IFolderService _folderService;
        public EmployeesController(IEmployeeService service, IDepartmentService departmentService, IFolderService folderService) : base(service)
        {
            _departmentService = departmentService;
            _folderService = folderService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employeeDto)
        {
            return await base.AddAsync(employeeDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EmployeeDto employeeDto)
        {
            return await base.UpdateAsync(id, employeeDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return await base.DeleteAsync(id);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await base.GetListAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            return await base.GetByIdAsync(id);
        }

        [HttpGet("{employeeId}/departments")]
        public async Task<IActionResult> GetDepartmends([FromRoute] int employeeId)
        {
            var result = await _departmentService.GetDepartmentsByEmployeeIdAsync(employeeId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("{employeeId}/folders")]
        public async Task<IActionResult> GetFolders([FromRoute] int employeeId)
        {
            var result = await _folderService.GetFoldersByEmployeeIdAsync(employeeId);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}