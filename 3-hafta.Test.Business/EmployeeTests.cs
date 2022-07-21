using _3_hafta.Business.Abstract;
using _3_hafta.Dto.Concrete;
using _3_hafta.Entity.Concrete;
using Core.Utilities.Result;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_hafta.Test.Business
{
    public class EmployeeTests
    {
        Mock<IEmployeeService> _mockEmployeeService;
        List<EmployeeDto> _dbEmployeeDto;
        List<Employee> _dbEmployee;
        public EmployeeTests()
        {
            _mockEmployeeService = new Mock<IEmployeeService>();
            _dbEmployeeDto = getEmployeeDtoList();
            _dbEmployee = getEmployeeList();

            _mockEmployeeService.Setup(m => m.GetListAsync()).ReturnsAsync(new SuccessDataResult<List<EmployeeDto>>(_dbEmployeeDto));
            _mockEmployeeService.Setup(m => m.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int x) => new SuccessDataResult<EmployeeDto>(getEmployeeById(x)));

            _mockEmployeeService.Setup(m => m.AddAsync(It.IsAny<EmployeeDto>())).ReturnsAsync((EmployeeDto dto) => new SuccessResult());
            _mockEmployeeService.Setup(m => m.UpdateAsync(It.IsAny<int>(), It.IsAny<EmployeeDto>())).ReturnsAsync((int x, EmployeeDto dto) => new SuccessResult());
            _mockEmployeeService.Setup(m => m.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int x) => new SuccessResult());

        }
        [Fact]
        public async void Get_all_employees()
        {
            var result = await _mockEmployeeService.Object.GetListAsync();
            Assert.Equal(4, result.Data.Count);
        }
        [Theory]
        [InlineData(1)]
        public async void Get_by_id_employee(int id)
        {
            var result = await _mockEmployeeService.Object.GetByIdAsync(id);
            Assert.NotEqual(null, result.Data);
        }

        [Fact]
        public async void Add_employee()
        {
            var result = await _mockEmployeeService.Object.AddAsync(new EmployeeDto());
            Assert.Equal(result.Success, true);
        }
        [Theory]
        [InlineData(1)]
        public async void Update_employee(int id)
        {
            var result = await _mockEmployeeService.Object.UpdateAsync(id, new EmployeeDto());
            Assert.Equal(result.Success, true);
        }
        [Theory]
        [InlineData(1)]
        public async void Delete_employee(int id)
        {
            var result = await _mockEmployeeService.Object.DeleteAsync(id);
            Assert.Equal(result.Success, true);
        }

        private List<EmployeeDto> getEmployeeDtoList()
        {
            return new List<EmployeeDto>
            {
                new EmployeeDto{EmpName="Emir",DeptId=1},
                new EmployeeDto{EmpName="Yasin",DeptId=5},
                new EmployeeDto{EmpName="Enes",DeptId=4},
                new EmployeeDto{EmpName="Oğuzhan",DeptId=3},
            };
        }
        private List<Employee> getEmployeeList()
        {
            return new List<Employee>
            {
                new Employee{EmpID=1,EmpName="Emir",DeptId=1},
                new Employee{EmpID=2,EmpName="Yasin",DeptId=5},
                new Employee{EmpID=3,EmpName="Enes",DeptId=4},
                new Employee{EmpID=4,EmpName="Oğuzhan",DeptId=3},
            };
        }
        private List<DepartmentDto> getDepartmentDtoList()
        {
            return new List<DepartmentDto>
            {
                new DepartmentDto{CountryId=1,DeptName="Protein"},
                new DepartmentDto{CountryId=1,DeptName="Protel"},
            };
        }
        private List<Department> getDepartmentList()
        {
            return new List<Department>
            {
                new Department{DepartmentId=1,CountryId=1,DeptName="Protein"},
                new Department{DepartmentId=2,CountryId=1,DeptName="Protel"},
            };
        }

        private EmployeeDto getEmployeeById(int id)
        {
            var employee = getEmployeeList().SingleOrDefault(x => x.EmpID == id);
            return new EmployeeDto
            {
                EmpName = employee.EmpName,
                DeptId = employee.DeptId
            };
        }
    }
}
