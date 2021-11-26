using AcademicStructure.Application.Features.ClassRoom.Queries.GetClassRoomList;
using AcademicStructure.Application.Features.Teachers.Commands.CheckoutTeacher;
using AcademicStructure.Application.Features.Teachers.Commands.UpdateTeacher;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using AcademicStructure.Application.Features.Teachers.Queries.GetTeachersList;
using AcademicStructure.Application.Features.Students.Queries.GetTeachersList;
using AcademicStructure.Application.Features.Students.Commands.UpdateStudent;
using AcademicStructure.Application.Features.Students.Commands.CheckoutStudent;
using AcademicStructure.Application.Features.ClassRoom.Commands.CheckoutClassRoom;

namespace AcademicStructure.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Students
            CreateMap<Student, StudentVm>().ReverseMap();
            CreateMap<Student, StudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();

            // Teacher
            CreateMap<Teacher, TeacherVm>().ReverseMap();
            CreateMap<Teacher, TeacherCommand>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherCommand>().ReverseMap();


            // ClassRoom
            CreateMap<ClassRoom, ClassRoomVm>().ReverseMap();
            CreateMap<ClassRoom, CheckoutClassRoomCommand>().ReverseMap();
            //CreateMap<ClassRoom, UpdateClassRoomCommand>().ReverseMap();
        }
    }
}
