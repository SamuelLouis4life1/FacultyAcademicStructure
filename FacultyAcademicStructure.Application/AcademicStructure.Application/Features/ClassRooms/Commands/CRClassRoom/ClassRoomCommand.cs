using AcademicStructure.Domain.Entities;
using AcademicStructure.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;


namespace AcademicStructure.Application.Features.ClassRooms.Commands.CRClassRoom
{
    public class ClassRoomCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string ClassName { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishAt { get; set; }
        public DayPeriodEnum DayPeriod { get; set; }
        public DateTime DateOfClass { get; set; }
        public DateTime FirstDateOfClass { get; set; }
        public DateTime LastDateOfClass { get; set; }
        public IEnumerable<Teacher> Teachers { get; set; }
        public IEnumerable<Student> Students { get; set; }
    }
}
