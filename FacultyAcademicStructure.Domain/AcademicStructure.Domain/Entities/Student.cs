using AcademicStructure.Domain.Common;
using System.Collections.Generic;


namespace AcademicStructure.Domain.Entities
{
    public class Student : EntityBase
    {
        public int PersonId { get; set; }

        public virtual ICollection<SchoolClassStudent> SchoolClassStudents { get; set; }
        public virtual Person Person { get; set; }
    }
}
