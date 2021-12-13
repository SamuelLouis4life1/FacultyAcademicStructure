using AcademicStructure.Domain.Common;
using AcademicStructure.Domain.Enums;


namespace AcademicStructure.Domain.Entities
{
    public class SchoolClassDate : EntityBase
    {
        public int SchoolClassId { get; set; }
        public int DayOfTheWeek { get; set; }
        public DayPeriodEnum DayPeriod { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
    }

}
