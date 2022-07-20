using _3_hafta.DataAccess.Abstract;
using _3_hafta.DataAccess.Concrete.Contexts;
using _3_hafta.Entity.Concrete;
using Core.DataAccess.EntityFramework;

namespace _3_hafta.DataAccess.Concrete.EntityFramework
{
    public class EfFolderDal : EfEntityRepositoryBase<Folder, EfPatikaDbContext>, IFolderDal
    {
    }
}
