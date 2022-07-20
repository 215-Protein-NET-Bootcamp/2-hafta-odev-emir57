using _3_hafta.Business.Abstract;
using _3_hafta.DataAccess.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace _3_hafta.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : BaseController<Country, CountryDto>
    {
        public CountriesController(ICountryService service) : base(service)
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryDto countryDto)
        {
            return await base.AddAsync(countryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] CountryDto countryDto)
        {
            return await base.UpdateAsync(id, countryDto);
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
        public async Task<IActionResult> Get(int id)
        {
            return await base.GetByIdAsync(id);
        }

    }
}
