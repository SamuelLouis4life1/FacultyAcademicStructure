using AcademicStructure.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.Students.Queries.GetTeachersList
{
    public class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, List<StudentVm>>
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetStudentListQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<StudentVm>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentRepository.GetStudentsByName(request.StudentName);
            return _mapper.Map<List<StudentVm>>(studentList);
        }
    }
}
