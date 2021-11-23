using MediatR;
using System;
using System.Collections.Generic;


namespace AcademicStructure.Application.Features.Student.Queries.GetStudentList
{
    public class GetStudentListQuery : IRequest<List<StudentVm>>
    {
        public string StudentName { get; set; }

        public GetStudentListQuery(string studentName)
        {
            StudentName = studentName ?? throw new ArgumentNullException(nameof(studentName));
        }

    }
}
