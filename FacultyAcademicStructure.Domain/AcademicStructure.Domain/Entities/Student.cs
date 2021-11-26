using AcademicStructure.Domain.Common;
using System;
using System.Collections.Generic;


namespace AcademicStructure.Domain.Entities
{
    public class Student : EntityBase
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool StudentOrTeacher { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public Address Address { get; set; }
        public int Matricula { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<ClassRoom> ClassRooms { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
