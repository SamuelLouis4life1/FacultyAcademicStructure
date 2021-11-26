using MediatR;
using System;
using System.Collections.Generic;


namespace AcademicStructure.Application.Features.Teachers.Queries.GetTeachersList
{
    public class GetTeacherListQuery : IRequest<List<TeacherVm>>
    {
        public string TeacherName { get; set; }

        public GetTeacherListQuery(string teacherName)
        {
            TeacherName = teacherName ?? throw new ArgumentNullException(nameof(teacherName));
        }
    }
}
