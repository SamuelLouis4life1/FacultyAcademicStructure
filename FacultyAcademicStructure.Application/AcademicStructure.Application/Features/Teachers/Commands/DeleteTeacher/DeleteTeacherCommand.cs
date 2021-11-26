using MediatR;


namespace AcademicStructure.Application.Features.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand : IRequest
    {
        public int Id { get; set; }
    }
}
