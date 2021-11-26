using AcademicStructure.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.Teachers.Queries.GetTeachersList
{
    public class GetTeacherListQueryHandler : IRequestHandler<GetTeacherListQuery, List<TeacherVm>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public GetTeacherListQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<TeacherVm>> Handle(GetTeacherListQuery request, CancellationToken cancellationToken)
        {
            var teacherList = await _teacherRepository.GetTeacherByName(request.TeacherName);
            return _mapper.Map<List<TeacherVm>>(teacherList);
        }
    }
}
