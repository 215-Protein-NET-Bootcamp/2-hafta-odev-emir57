using _3_hafta.Business.Abstract;
using _3_hafta.Business.Constants;
using _3_hafta.Business.Validation.FluentValidation;
using _3_hafta.DataAccess.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using AutoMapper;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using System.Linq;

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
            var result = BusinessRules.Run(
                checkCountryName(entity.CountryName));
            if (result != null)
                return Task.Run(() => result);
            return base.AddAsync(entity);
        }

        private IResult checkCountryName(string countryName)
        {
            List<string> countryNames = base.GetListAsync().Result.Data.Select(c => c.CountryName).ToList();
            if (countryNames.Any(x => x.ToLower() == countryName.ToLower()) == true)
                return new ErrorResult(BusinessMessages.CountryAlreadyExists);
            return new SuccessResult();
        }

        [ValidationAspect(typeof(CountryValidator))]
        public override Task<IResult> UpdateAsync(int id, CountryDto entity)
        {
            return base.UpdateAsync(id, entity);
        }
    }
}
