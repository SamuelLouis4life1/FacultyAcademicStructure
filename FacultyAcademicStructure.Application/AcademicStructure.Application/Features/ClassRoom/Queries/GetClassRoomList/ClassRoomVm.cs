using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.ClassRoom.Queries.GetClassRoomList
{
    public class ClassRoomVm
    {
        public string Name { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
