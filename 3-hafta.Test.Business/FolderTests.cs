using _3_hafta.Business.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using Core.Utilities.Result;
using Moq;

namespace _3_hafta.Test.Business
{
    public class FolderTests
    {
        Mock<IFolderService> _mockFolderService;
        List<FolderDto> _dbFolderDto;
        List<Folder> _dbFolder;
        public FolderTests()
        {
            _mockFolderService = new Mock<IFolderService>();
            _dbFolderDto = getFolderDtoList();
            _dbFolder = getFolderList();

            _mockFolderService.Setup(x => x.GetListAsync()).ReturnsAsync(new SuccessDataResult<List<FolderDto>>(_dbFolderDto));
            _mockFolderService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int x) => new SuccessDataResult<FolderDto>(getFolderById(x)));

            _mockFolderService.Setup(x => x.AddAsync(It.IsAny<FolderDto>())).ReturnsAsync((FolderDto dto) => new SuccessResult());
            _mockFolderService.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<FolderDto>())).ReturnsAsync((int x, FolderDto dto) => new SuccessResult());
            _mockFolderService.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int x) => new SuccessResult());

            _mockFolderService.Setup(x => x.GetFoldersByEmployeeIdAsync(It.IsAny<int>())).ReturnsAsync((int empId) => new SuccessDataResult<List<FolderDto>>(getFoldersByEmployeeId(empId)));
        }

        [Fact]
        public async void Get_all_folders()
        {
            var result = await _mockFolderService.Object.GetListAsync();
            Assert.Equal(4, result.Data.Count);
        }
        [Theory]
        [InlineData(1)]
        public async void Get_folders_by_employee_id(int empId)
        {
            var result = await _mockFolderService.Object.GetFoldersByEmployeeIdAsync(empId);
            Assert.Equal(3, result.Data.Count);
        }
        [Theory]
        [InlineData(1)]
        public async void Get_by_id_folder(int id)
        {
            var result = await _mockFolderService.Object.GetByIdAsync(id);
            Assert.NotEqual(result.Data, null);
        }
        [Fact]
        public async void Add_folder()
        {
            var result = await _mockFolderService.Object.AddAsync(new FolderDto());
            Assert.Equal(result.Success, true);
        }
        [Theory]
        [InlineData(1)]
        public async void Update_folder(int id)
        {
            var result = await _mockFolderService.Object.UpdateAsync(id, new FolderDto());
            Assert.Equal(result.Success, true);
        }
        [Theory]
        [InlineData(1)]
        public async void Delete_folder(int id)
        {
            var result = await _mockFolderService.Object.DeleteAsync(id);
            Assert.Equal(result.Success, true);
        }

        private List<FolderDto> getFolderDtoList()
        {
            return new List<FolderDto>
            {
                new FolderDto{EmpId=1,AccessType="Public"},
                new FolderDto{EmpId=1,AccessType="Private"},
                new FolderDto{EmpId=1,AccessType="Public"},
                new FolderDto{EmpId=2,AccessType="Private"},
            };
        }
        private List<Folder> getFolderList()
        {
            return new List<Folder>
            {
                new Folder{FolderId=1,EmpId=1,AccessType="Public"},
                new Folder{FolderId=2,EmpId=1,AccessType="Private"},
                new Folder{FolderId=3,EmpId=1,AccessType="Public"},
                new Folder{FolderId=4,EmpId=2,AccessType="Private"},
            };
        }

        private FolderDto getFolderById(int id)
        {
            var folder = getFolderList().SingleOrDefault(x => x.FolderId == id);
            return new FolderDto
            {
                EmpId = folder.EmpId,
                AccessType = folder.AccessType
            };
        }
        private List<FolderDto> getFoldersByEmployeeId(int empId)
        {
            return getFolderDtoList().Where(f => f.EmpId == empId).ToList();
        }
    }
}
