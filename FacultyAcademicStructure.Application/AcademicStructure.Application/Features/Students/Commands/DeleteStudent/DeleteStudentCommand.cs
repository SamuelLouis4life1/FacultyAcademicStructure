using MediatR;
using System;


namespace AcademicStructure.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
