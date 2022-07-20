using _3_hafta.Dto.Concrete;
using FluentValidation;

namespace _3_hafta.Business.Validation.FluentValidation
{
    public class DepartmentValidator : AbstractValidator<DepartmentDto>
    {
        public DepartmentValidator()
        {
            RuleFor(x => x.DeptName)
                .NotEmpty()
                .NotNull()
                .WithMessage("Departman adı boş olamaz");

            RuleFor(d => d.DeptName)
                .MaximumLength(50)
                .WithMessage("Departman adı maksimum 50 karakter olabilir");

            RuleFor(d => d.CountryId)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("Şehir id boş olamaz");
        }
    }
}
