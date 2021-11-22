using AcademicStructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicStructure.Domain.Entities
{
    public class Student : EntityBase
    {
        //public int StudentId { get; set; }

        public int Matricula { get; set; }

        public bool Ativo { get; set; }
        List<Teacher> TeacherList { get; set; }
        public IEnumerable<ClassRoom> ClassRooms { get; set; }

    }
}
