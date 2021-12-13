using AcademicStructure.Domain.Entities;
using AcademicStructure.Domain.Enums;
using MediatR;


namespace AcademicStructure.Application.Features.ClassRooms.Commands.UpdateClassRoom
{
    public class UpdateClassRoomCommand : IRequest
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int DayOfTheWeek { get; set; }
        public DayPeriodEnum DayPeriod { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual SchoolClass SchoolClass { get; set; }
        public virtual SchoolSubject SchoolSubject { get; set; }
    }
}
