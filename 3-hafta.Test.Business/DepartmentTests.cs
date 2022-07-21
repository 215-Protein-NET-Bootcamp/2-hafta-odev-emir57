﻿using _3_hafta.Business.Abstract;
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
    public class DepartmentTests
    {
        Mock<IDepartmentService> _mockDepartmentService;
        List<Department> _dbDepartment;
        List<DepartmentDto> _dbDepartmentDto;
        public DepartmentTests()
        {
            _mockDepartmentService = new Mock<IDepartmentService>();
            _dbDepartmentDto = getDepartmentDtoList();
            _dbDepartment = getDepartmentList();

            _mockDepartmentService.Setup(x => x.GetListAsync()).ReturnsAsync(new SuccessDataResult<List<DepartmentDto>>(_dbDepartmentDto));
            _mockDepartmentService.Setup(x => x.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((int departmentId) => new SuccessDataResult<DepartmentDto>(getDepartmentById(departmentId)));

            _mockDepartmentService.Setup(x => x.AddAsync(It.IsAny<DepartmentDto>())).ReturnsAsync((DepartmentDto dto) => new SuccessResult());
            _mockDepartmentService.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<DepartmentDto>())).ReturnsAsync((int departmentId, DepartmentDto dto) => new SuccessResult());
            _mockDepartmentService.Setup(x => x.DeleteAsync(It.IsAny<int>())).ReturnsAsync((int departmentId) => new SuccessResult());

        }

        [Fact]
        public async void Get_all_departments()
        {
            var result = await _mockDepartmentService.Object.GetListAsync();
            Assert.Equal(result.Data.Count, 2);
        }
        [Theory]
        [InlineData(1)]
        public async void Get_by_id_department(int id)
        {
            var result = await _mockDepartmentService.Object.GetByIdAsync(id);
            Assert.NotEqual(result.Data, null);
        }
        [Fact]
        public async void Add_department()
        {
            var result = await _mockDepartmentService.Object.AddAsync(new DepartmentDto());
            Assert.Equal(result.Success, true);
        }
        [Theory]
        [InlineData(1)]
        public async void Update_department(int id)
        {
            var result = await _mockDepartmentService.Object.UpdateAsync(id, new DepartmentDto());
            Assert.Equal(result.Success, true);
        }
        [Theory]
        [InlineData(1)]
        public async void Delete_department(int id)
        {
            var result = await _mockDepartmentService.Object.DeleteAsync(id);
            Assert.Equal(result.Success, true);
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

        private DepartmentDto getDepartmentById(int id)
        {
            var department = getDepartmentList().SingleOrDefault(d => d.DepartmentId == id);
            return new DepartmentDto
            {
                CountryId = department.CountryId,
                DeptName = department.DeptName
            };
        }
    }
}
