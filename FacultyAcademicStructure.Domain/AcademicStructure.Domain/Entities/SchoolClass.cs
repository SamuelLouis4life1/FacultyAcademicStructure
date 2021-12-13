using AcademicStructure.Domain.Common;
using System.Collections.Generic;


namespace AcademicStructure.Domain.Entities
{

    public class SchoolClass : EntityBase
    {
        public int TeacherId { get; set; }
        public int SchoolSubjectId { get; set; }
        public string Name { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual SchoolSubject SchoolSubject { get; set; }
        public virtual ICollection<SchoolClassStudent> SchoolClassStudents { get; set; }
        public virtual ICollection<SchoolClassDate> SchoolClassDates { get; set; }
    }
}