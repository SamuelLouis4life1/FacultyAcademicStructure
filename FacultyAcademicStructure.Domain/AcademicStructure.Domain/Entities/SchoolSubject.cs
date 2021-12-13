using AcademicStructure.Domain.Common;
using System.Collections.Generic;


namespace AcademicStructure.Domain.Entities
{
    public class SchoolSubject : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }
    }
}
