namespace AcademicStructure.Domain.Entities
{
    public class SchoolClassStudent
    {
        public int SchoolClassId { get; set; }
        public int StudentId { get; set; }

        public virtual SchoolClass SchoolClass { get; set; }
        public virtual Student Student { get; set; }
    }
}
