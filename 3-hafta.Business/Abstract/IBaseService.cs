using Core.Entity;
using Core.Utilities.Result;
using FluentValidation;

namespace _3_hafta.Business.Abstract
{
    public interface IBaseService<TEntity, TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        Task<IResult> AddAsync(TDto entity);
        Task<IResult> UpdateAsync(int id, TDto entity);
        Task<IResult> DeleteAsync(int id);

        Task AddRangeAsync(IEnumerable<TDto> entities);

        Task<IDataResult<List<TDto>>> GetListAsync();
        Task<IDataResult<TDto>> GetByIdAsync(int id);
    }
}
