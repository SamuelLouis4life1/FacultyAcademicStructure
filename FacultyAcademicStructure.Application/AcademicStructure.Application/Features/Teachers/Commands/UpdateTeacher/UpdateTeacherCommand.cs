using AcademicStructure.Domain.Common;
using MediatR;
using System;


namespace AcademicStructure.Application.Features.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommand : IRequest
    {
        public Guid Id { get; set; }
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
