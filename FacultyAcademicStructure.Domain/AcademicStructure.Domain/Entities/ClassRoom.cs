using AcademicStructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicStructure.Domain.Entities
{

    public class ClassRoom : EntityBase
    {
        //public int Id { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }

    public enum ClassEnum
    {
        Morning,
        Afternoon,
        Night
    }
}
