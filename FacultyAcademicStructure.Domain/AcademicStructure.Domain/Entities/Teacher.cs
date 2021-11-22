using AcademicStructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicStructure.Domain.Entities
{
    public class Teacher : EntityBase
    {
        //public int TeacherId { get; set; }
        List<Student> StudentList { get; set; }
        public IEnumerable<ClassRoom> ClassRooms { get; set; }

    }
}
