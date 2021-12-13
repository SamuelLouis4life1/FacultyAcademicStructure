using AcademicStructure.Domain.Common;
using AcademicStructure.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;


namespace AcademicStructure.Application.Features.Teachers.Commands.CheckoutTeacher
{
    public class TeacherCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public int Matricula { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<SchoolClass> SchoolClasses { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
