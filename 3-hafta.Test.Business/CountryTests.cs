using _3_hafta.Business.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using Core.Utilities.Result;
using Moq;

namespace _3_hafta.Test.Business
{
    public class CountryTests
    {
        Mock<ICountryService> _mockCountryService;
        List<CountryDto> _dbCountryDto;
        List<Country> _dbCountry;
        public CountryTests()
        {
            _mockCountryService = new Mock<ICountryService>();
            _dbCountryDto = getCountryDtoList();
            _dbCountry = getCountryList();

            _mockCountryService.Setup(x => x.GetListAsync()).ReturnsAsync(new SuccessDataResult<List<CountryDto>>(_dbCountryDto));
            _mockCountryService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int countryId) => new SuccessDataResult<CountryDto>(getCountryById(countryId)));

            _mockCountryService.Setup(x => x.AddAsync(It.IsAny<CountryDto>())).ReturnsAsync((CountryDto dto) => new SuccessResult());
            _mockCountryService.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<CountryDto>())).ReturnsAsync((int countryId, CountryDto dto) => new SuccessResult());
            _mockCountryService.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int countryId) => new SuccessResult());
        }
        [Fact]
        public async void Get_all_country()
        {
            var result = await _mockCountryService.Object.GetListAsync();
            Assert.Equal(3, result.Data.Count);
        }
        [Theory]
        [InlineData(1)]
        public async void Get_by_id_country(int id)
        {
            var result = await _mockCountryService.Object.GetByIdAsync(id);
            Assert.NotEqual(null, result.Data);
        }
        [Fact]
        public async void Add_country()
        {
            var result = await _mockCountryService.Object.AddAsync(new CountryDto());
            Assert.Equal(true, result.Success);
        }
        [Theory]
        [InlineData(1)]
        public async void Update_country(int id)
        {
            var result = await _mockCountryService.Object.UpdateAsync(id, new CountryDto());
            Assert.Equal(true, result.Success);
        }
        [Theory]
        [InlineData(1)]
        public async void Delete_country(int id)
        {
            var result = await _mockCountryService.Object.DeleteAsync(id);
            Assert.Equal(true, result.Success);
        }

        private List<Country> getCountryList()
        {
            return new List<Country>
            {
                new Country{CountryId=1,CountryName="Turkey",Continent="Asia",Currency="TRY"},
                new Country{CountryId=2,CountryName="Germany",Continent="Europe",Currency="EURO"},
                new Country{CountryId=3,CountryName="France",Continent="Europe",Currency="EURO"},
            };
        }
        private List<CountryDto> getCountryDtoList()
        {
            return new List<CountryDto>
            {
                new CountryDto{CountryName="Turkey",Continent="Asia",Currency="TRY"},
                new CountryDto{CountryName="Germany",Continent="Europe",Currency="EURO"},
                new CountryDto{CountryName="France",Continent="Europe",Currency="EURO"},
            };
        }
        private CountryDto getCountryById(int id)
        {
            var country = getCountryList().SingleOrDefault(c => c.CountryId == id);
            return new CountryDto
            {
                CountryName = country.CountryName,
                Continent = country.Continent,
                Currency = country.Currency
            };
        }
    }
}
