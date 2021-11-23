using MediatR;
using System;
using System.Collections.Generic;


namespace AcademicStructure.Application.Features.ClassRoom.Queries.GetClassRoomList
{
    public class GetClassRoomListQuery : IRequest<List<ClassRoomVm>>
    {
        public string ClassRoomName { get; set; }

        public GetClassRoomListQuery(string classRoomName)
        {
            ClassRoomName = classRoomName ?? throw new ArgumentNullException(nameof(classRoomName));
        }
    }
}
