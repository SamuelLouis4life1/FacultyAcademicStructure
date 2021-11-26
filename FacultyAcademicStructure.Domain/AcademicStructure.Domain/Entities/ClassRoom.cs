using AcademicStructure.Domain.Common;
using System;
using System.Collections.Generic;


namespace AcademicStructure.Domain.Entities
{

    public class ClassRoom : EntityBase
    {
        //public int Id { get; set; }
        public string ClassName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishAt { get; set; }
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
