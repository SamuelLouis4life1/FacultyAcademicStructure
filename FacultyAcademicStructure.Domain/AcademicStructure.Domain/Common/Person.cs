using AcademicStructure.Domain.Entities;
using System;


namespace AcademicStructure.Domain.Common
{
    public class Person : EntityBase
    {
        public int AddressId { get; set; }
        //public int? StudentId { get; set; }
        //public int? TeacherId { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int RegistrationId { get; set; }

        public virtual Address Address { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Student Student { get; set; }
    }
}
