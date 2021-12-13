using AcademicStructure.Domain.Common;
using AcademicStructure.Domain.Entities;
using AcademicStructure.Domain.Enums;


namespace AcademicStructure.Application.Features.Students.Queries.GetTeachersList
{
    public class StudentVm
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public int DayOfTheWeek { get; set; }
        public DayPeriodEnum DayPeriod { get; set; }
        public Teacher Teacher { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
    }
}
