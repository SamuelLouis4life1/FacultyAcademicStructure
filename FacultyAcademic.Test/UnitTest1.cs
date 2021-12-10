using AcademicStructure.Api.Controllers;
using AcademicStructure.Application.Features.Teachers.Queries.GetTeachersList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace FacultyAcademic.Test
{
    [TestClass]
    public class UnitTest1
    {
        private readonly IMediator _mediator;

        public UnitTest1(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }



        [Fact]
        public async void TestMethod1()
        {
            string teacherName = "Samuel";
            var query = new GetTeacherListQuery(teacherName);
            var teachers = await _mediator.Send(query);

            var getTeacherName = new TeacherController(_mediator);
            var nameTeacher = await getTeacherName.GetTeacherByName(teacherName);

            //Assert.AreEqual(teacherName, nameTeacher);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(teacherName, nameTeacher);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(teachers, teachers);

            //return Ok(teachers);
        }

        [Fact]
        public async Task<ActionResult<IEnumerable<TeacherVm>>> TestMethod2()
        {
            string teacherName = "Samuel";
            var query = new GetTeacherListQuery(teacherName);
            var teachers = await _mediator.Send(query);

            var getTeacherName = new TeacherController(_mediator);
            var nameTeacher = await getTeacherName.GetTeacherByName(teacherName);

            //Assert.AreEqual(teacherName, nameTeacher);
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(teacherName, nameTeacher);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(teachers, teachers);

            return (teachers);
        }
    }
}
