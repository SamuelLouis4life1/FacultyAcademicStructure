using System;


namespace AcademicStructure.Domain.Common
{
    public abstract class EntityBase
    {
        //protected EntityBase()
        //{
        //    Id = Guid.NewGuid();
        //}
        public int Id { get; protected set; }
        public string FullName { get; set; }
        public bool Ativo { get; set; }

        //public string CreatedBy { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public string LastModifiedBy { get; set; }
        //public DateTime? LastModifiedDate { get; set; }
    }
}
