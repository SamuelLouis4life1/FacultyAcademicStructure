using MediatR;
using System;


namespace AcademicStructure.Application.Features.ClassRoom.Commands.DeleteClassRoom
{
    public class DeleteClassRoomCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
