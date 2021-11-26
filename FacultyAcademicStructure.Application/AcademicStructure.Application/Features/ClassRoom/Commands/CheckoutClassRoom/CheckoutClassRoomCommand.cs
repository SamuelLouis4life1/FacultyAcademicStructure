using MediatR;
using System;


namespace AcademicStructure.Application.Features.ClassRoom.Commands.CheckoutClassRoom
{
    public class CheckoutClassRoomCommand : IRequest<int>
    {
        public string ClassName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishAt { get; set; }
    }
}
