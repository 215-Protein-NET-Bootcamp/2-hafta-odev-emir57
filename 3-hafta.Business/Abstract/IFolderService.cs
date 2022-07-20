using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using Core.Utilities.Result;

namespace _3_hafta.Business.Abstract
{
    public interface IFolderService : IBaseService<Folder, FolderDto>
    {
        Task<IDataResult<List<FolderDto>>> GetFoldersByEmployeeIdAsync(int employeeId);
    }
}
