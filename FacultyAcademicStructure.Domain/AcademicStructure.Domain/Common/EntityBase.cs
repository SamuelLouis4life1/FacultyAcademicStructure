using System;


namespace AcademicStructure.Domain.Common
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            CreatedAt = DateTime.Now;
        }
        public int Id { get; protected set; }
        public bool Ativo { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
