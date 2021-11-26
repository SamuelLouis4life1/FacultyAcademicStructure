using FluentValidation;


namespace AcademicStructure.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{FullName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{FullName} must not exceed 50 characters.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{Email} is required.");

            RuleFor(p => p.CPF)
                .NotEmpty().WithMessage("{CPF} is required.")
                .MaximumLength(16).WithMessage("{CPF} must not exceed 16 characters.");
        }
    }
}
