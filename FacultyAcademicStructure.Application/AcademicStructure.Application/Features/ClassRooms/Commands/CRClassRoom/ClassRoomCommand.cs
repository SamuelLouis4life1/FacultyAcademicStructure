using MediatR;
using System;


namespace AcademicStructure.Application.Features.ClassRooms.Commands.CRClassRoom
{
    public class ClassRoomCommand : IRequest<int>
    {
        public string ClassRoomName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishAt { get; set; }
        public DateTime DateOfClass { get; set; }
        public DateTime FirstDateOfClass { get; set; }
        public DateTime LastDateOfClass { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
