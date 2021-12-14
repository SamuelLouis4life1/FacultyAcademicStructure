using MediatR;
using System;


namespace AcademicStructure.Application.Features.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
