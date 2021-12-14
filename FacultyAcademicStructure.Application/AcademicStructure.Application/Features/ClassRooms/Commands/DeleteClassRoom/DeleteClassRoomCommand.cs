using MediatR;
using System;

namespace AcademicStructure.Application.Features.ClassRooms.Commands.DeleteClassRoom
{
    public class DeleteClassRoomCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
