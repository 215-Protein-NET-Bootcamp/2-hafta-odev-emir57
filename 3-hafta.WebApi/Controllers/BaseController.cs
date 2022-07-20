using _3_hafta.Business.Abstract;
using Core.Entity;
using Microsoft.AspNetCore.Mvc;

namespace _3_hafta.WebApi.Controllers
{
    public class BaseController<TEntity, TDto> : ControllerBase
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        protected readonly IBaseService<TEntity, TDto> Service;
        public BaseController(IBaseService<TEntity, TDto> service)
        {
            Service = service;
        }

        [NonAction]
        public async Task<IActionResult> AddAsync(TDto dto)
        {
            var result = await Service.AddAsync(dto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [NonAction]
        public async Task<IActionResult> UpdateAsync(int id, TDto dto)
        {
            var result = await Service.UpdateAsync(id, dto);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
        [NonAction]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await Service.DeleteAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [NonAction]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await Service.GetByIdAsync(id);
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }

        [NonAction]
        public async Task<IActionResult> GetListAsync()
        {
            var result = await Service.GetListAsync();
            if (result.Success)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
