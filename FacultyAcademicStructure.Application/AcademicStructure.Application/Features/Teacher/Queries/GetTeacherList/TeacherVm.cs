using AcademicStructure.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.Teacher.Queries.GetTeacherList
{
    public class TeacherVm
    {
        public string FullName { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool StudentOrTeacher { get; set; }
        public long PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public Address Address { get; set; }
  
    }
}
