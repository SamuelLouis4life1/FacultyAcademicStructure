using AcademicStructure.Domain.Entities;
using AcademicStructure.Domain.Enums;
using MediatR;
using System;


namespace AcademicStructure.Application.Features.ClassRooms.Commands.CRClassRoom
{
    public class ClassRoomCommand : IRequest<int>
    {
        //public int Id { get; set; }
        public int DayOfTheWeek { get; set; }
        public DayPeriodEnum DayPeriod { get; set; }
        public Teacher Teacher { get; set; }
        public SchoolClass SchoolClass { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
    }
}
