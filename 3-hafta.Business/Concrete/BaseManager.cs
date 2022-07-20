using _3_hafta.Business.Abstract;
using _3_hafta.Business.Constants;
using _3_hafta.Business.Validation.FluentValidation;
using AutoMapper;
using Core.Aspects.Autofac.Validation;
using Core.DataAccess;
using Core.Entity;
using Core.Utilities.Result;
using FluentValidation;

namespace _3_hafta.Business.Concrete
{
    public class BaseManager<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class, IEntity, new()
        where TDto : class, IDto, new()
    {
        protected readonly IEntityRepository<TEntity> _entityRepository;
        protected readonly IMapper Mapper;
        public BaseManager(IEntityRepository<TEntity> entityRepository, IMapper mapper)
        {
            _entityRepository = entityRepository;
            Mapper = mapper;
        }
        [ValidationAspect(typeof(EmployeeValidator))]
        public virtual async Task<IResult> AddAsync(TDto entity)
        {
            TEntity addedEntity = Mapper.Map<TEntity>(entity);
            bool result = await _entityRepository.AddAsync(addedEntity);
            if (result)
                return new SuccessResult(BusinessMessages.SuccessAdd);
            return new ErrorResult(BusinessMessages.UnSuccessAdd);
        }

        public virtual async Task<IResult> UpdateAsync(int id, TDto entity)
        {
            TEntity updatedEntity = await _entityRepository.GetByIdAsync(id);
            if (updatedEntity is null)
                return new ErrorResult(BusinessMessages.NotFoundEntity);
            Mapper.Map(entity, updatedEntity);
            bool result = await _entityRepository.UpdateAsync(updatedEntity);
            if (result)
                return new SuccessResult(BusinessMessages.SuccessUpdate);
            return new ErrorResult(BusinessMessages.UnSuccessUpdate);

        }

        public async Task<IResult> DeleteAsync(int id)
        {
            TEntity deletedEntity = await _entityRepository.GetByIdAsync(id);
            if (deletedEntity is null)
                return new ErrorResult(BusinessMessages.NotFoundEntity);
            bool result = await _entityRepository.DeleteAsync(deletedEntity);
            if (result)
                return new SuccessResult(BusinessMessages.SuccessDelete);
            return new ErrorResult(BusinessMessages.UnSuccessDelete);
        }

        public async Task AddRangeAsync(IEnumerable<TDto> entities)
        {
            var addedEntities = Mapper.Map<IEnumerable<TEntity>>(entities);
            await _entityRepository.AddRangeAsync(addedEntities);
        }

        public async Task<IDataResult<List<TDto>>> GetListAsync()
        {
            var result = await _entityRepository.GetAllAsync();
            var resultDtos = Mapper.Map<List<TDto>>(result);
            return new SuccessDataResult<List<TDto>>(resultDtos, BusinessMessages.SuccessList);
        }

        public async Task<IDataResult<TDto>> GetByIdAsync(int id)
        {
            var result = await _entityRepository.GetByIdAsync(id);
            if (result is null)
                return new ErrorDataResult<TDto>(BusinessMessages.NotFoundEntity);
            var resultDto = Mapper.Map<TDto>(result);
            return new SuccessDataResult<TDto>(resultDto, BusinessMessages.SuccessGet);
        }
    }
}
