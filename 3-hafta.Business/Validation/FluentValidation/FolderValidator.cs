using _3_hafta.Dto.Concrete;
using FluentValidation;

namespace _3_hafta.Business.Validation.FluentValidation
{
    public class FolderValidator : AbstractValidator<FolderDto>
    {
        public FolderValidator()
        {
            RuleFor(f => f.AccessType)
                .NotNull()
                .NotEmpty()
                .WithMessage("Erişim tipi boş olamaz");

            RuleFor(f => f.AccessType)
                .MaximumLength(5)
                .WithMessage("Erişim tipi maksimum 5 karakter olabilir");

            RuleFor(f => f.EmpId)
                .NotNull()
                .NotEmpty()
                .NotEqual(0)
                .WithMessage("Çalışan id boş olamaz");
        }
    }
}
