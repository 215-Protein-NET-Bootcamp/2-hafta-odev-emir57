using _3_hafta.Business.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _3_hafta.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : BaseController<Department, DepartmentDto>
    {
        public DepartmentsController(IDepartmentService service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DepartmentDto employeeDto)
        {
            return await base.AddAsync(employeeDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] DepartmentDto employeeDto)
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
    }
}
