using AcademicStructure.Application.Features.ClassRoom.Queries.GetClassRoomList;
using AcademicStructure.Application.Features.Student.Queries.GetStudentList;
using AcademicStructure.Application.Features.Teacher.Queries.GetTeacherList;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Students
            CreateMap<Student, StudentVm>().ReverseMap();

            // Teacher
            CreateMap<Teacher, TeacherVm>().ReverseMap();


            // ClassRoom
            CreateMap<ClassRoom, ClassRoomVm>().ReverseMap();
        }
    }
}
