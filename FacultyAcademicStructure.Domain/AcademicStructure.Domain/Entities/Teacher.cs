using AcademicStructure.Domain.Common;
using System.Collections.Generic;


namespace AcademicStructure.Domain.Entities
{
    public class Teacher : EntityBase
    {
        public int PersonId { get; set; }

        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }
        public virtual Person Person { get; set; }
    }
}
