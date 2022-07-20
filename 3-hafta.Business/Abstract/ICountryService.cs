using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_hafta.Business.Abstract
{
    public interface ICountryService : IBaseService<Country, CountryDto>
    {
    }
}
