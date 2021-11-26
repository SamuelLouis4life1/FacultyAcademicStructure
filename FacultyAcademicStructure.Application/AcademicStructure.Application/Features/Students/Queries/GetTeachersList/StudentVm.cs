using AcademicStructure.Domain.Common;
using System;


namespace AcademicStructure.Application.Features.Students.Queries.GetTeachersList
{
    public class StudentVm
    {
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
    }
}
