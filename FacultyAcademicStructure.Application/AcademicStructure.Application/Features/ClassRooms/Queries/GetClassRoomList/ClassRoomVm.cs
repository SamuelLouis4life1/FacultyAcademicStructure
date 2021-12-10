using AcademicStructure.Domain.Entities;
using AcademicStructure.Domain.Enums;


namespace AcademicStructure.Application.Features.ClassRooms.Queries.GetClassRoomList
{
    public class ClassRoomVm
    {
        //public int Id { get; set; }
        public int DayOfTheWeek { get; set; }
        public DayPeriodEnum DayPeriod { get; set; }
        public Teacher Teacher { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
    }
}
