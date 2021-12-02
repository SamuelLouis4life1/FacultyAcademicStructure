using MediatR;


namespace AcademicStructure.Application.Features.ClassRooms.Commands.DeleteClassRoom
{
    public class DeleteClassRoomCommand : IRequest
    {
        public int Id { get; set; }
    }
}
