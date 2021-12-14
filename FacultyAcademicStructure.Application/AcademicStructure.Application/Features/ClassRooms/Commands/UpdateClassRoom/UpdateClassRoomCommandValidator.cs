using FluentValidation;


namespace AcademicStructure.Application.Features.ClassRooms.Commands.UpdateClassRoom
{
    public class UpdateClassRoomCommandValidator : AbstractValidator<UpdateClassRoomCommand>
    {
        public UpdateClassRoomCommandValidator()
        {
            RuleFor(p => p.ClassName)
                .NotEmpty().WithMessage("{ClassRoomName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{ClassRoomName} must not exceed 50 characters.");

            RuleFor(p => p.FirstDateOfClass)
                .NotEmpty().WithMessage("{FirstDateOfClass} is required.");
        }
    }
}
