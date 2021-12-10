using AcademicStructure.Domain.Common;
using System.Collections.Generic;


namespace AcademicStructure.Domain.Entities
{

    public class SchoolClass : EntityBase
    {
        //public int Id { get; set; }
        public string ClassName { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
