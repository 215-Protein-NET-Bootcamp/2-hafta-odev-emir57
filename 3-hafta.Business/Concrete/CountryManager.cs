using _3_hafta.Business.Abstract;
using _3_hafta.Business.Validation.FluentValidation;
using _3_hafta.DataAccess.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using AutoMapper;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Result;

namespace _3_hafta.Business.Concrete
{
    public class CountryManager : BaseManager<Country, CountryDto>, ICountryService
    {
        public CountryManager(ICountryDal entityRepository, IMapper mapper) : base(entityRepository, mapper)
        {
        }
        [ValidationAspect(typeof(CountryValidator))]
        public override Task<IResult> AddAsync(CountryDto entity)
        {
            return base.AddAsync(entity);
        }
        [ValidationAspect(typeof(CountryValidator))]
        public override Task<IResult> UpdateAsync(int id, CountryDto entity)
        {
            return base.UpdateAsync(id, entity);
        }
    }
}
