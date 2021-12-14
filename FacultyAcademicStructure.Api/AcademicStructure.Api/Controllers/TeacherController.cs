using AcademicStructure.Application.Features.Teachers.Commands.CheckoutTeacher;
using AcademicStructure.Application.Features.Teachers.Commands.DeleteTeacher;
using AcademicStructure.Application.Features.Teachers.Commands.UpdateTeacher;
using AcademicStructure.Application.Features.Teachers.Queries.GetTeachersList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AcademicStructure.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet("{teacherName}", Name = "GetTeacher")]
        [ProducesResponseType(typeof(IEnumerable<TeacherVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TeacherVm>>> GetTeacherByName(string teacherName)
        {
            var query = new GetTeacherListQuery(teacherName);
            var teachers = await _mediator.Send(query);
            return Ok(teachers);
        }


        [HttpPost(Name = "ReadTeachers")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> ReadTeachers([FromBody] TeacherCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut(Name = "UpdateTeacher")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTeacher([FromBody] UpdateTeacherCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteTeacher")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteTeacher(Guid id)
        {
            var command = new DeleteTeacherCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
