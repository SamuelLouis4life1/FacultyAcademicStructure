using AcademicStructure.Domain.Enums;


namespace AcademicStructure.Domain.Entities
{
    public class SchoolClassDate
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
