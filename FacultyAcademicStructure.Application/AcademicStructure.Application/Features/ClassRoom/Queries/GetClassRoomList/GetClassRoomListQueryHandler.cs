using AcademicStructure.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.ClassRoom.Queries.GetClassRoomList
{
    public class GetClassRoomListQueryHandler : IRequestHandler<GetClassRoomListQuery, List<ClassRoomVm>>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;

        public GetClassRoomListQueryHandler(IClassRoomRepository classRoomRepository, IMapper mapper)
        {
            _classRoomRepository = classRoomRepository ?? throw new ArgumentNullException(nameof(classRoomRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<ClassRoomVm>> Handle(GetClassRoomListQuery request, CancellationToken cancellationToken)
        {
            var classRoomList = await _classRoomRepository.GetClassRoomByName(request.ClassRoomName);
            return _mapper.Map<List<ClassRoomVm>>(classRoomList);
        }
    }
}
