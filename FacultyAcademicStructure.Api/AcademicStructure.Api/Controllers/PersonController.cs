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
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet("{PersonName}", Name = "GetPerson")]
        [ProducesResponseType(typeof(IEnumerable<TeacherVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<TeacherVm>>> GetTeacherByName(string teacherName)
        {
            var query = new GetTeacherListQuery(teacherName);
            var teachers = await _mediator.Send(query);
            return Ok(teachers);
        }


        [HttpPost(Name = "ReadPersons")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> ReadTeachers([FromBody] TeacherCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut(Name = "UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateTeacher([FromBody] UpdateTeacherCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeletePerson")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteTeacher(int id)
        {
            var command = new DeleteTeacherCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
