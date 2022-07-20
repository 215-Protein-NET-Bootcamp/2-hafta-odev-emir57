using _3_hafta.Dto.Concrete;
using FluentValidation;

namespace _3_hafta.Business.Validation.FluentValidation
{
    public class EmployeeValidator : AbstractValidator<EmployeeDto>
    {
        public EmployeeValidator()
        {
            RuleFor(e => e.EmpName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Çalışan adı boş olamaz");
            RuleFor(e => e.EmpName)
                .MaximumLength(50)
                .WithMessage("Çalışan adı maksimum 50 karakter olabilir");

            RuleFor(f => f.DeptId)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("Departman id boş olamaz");
        }
    }
}
