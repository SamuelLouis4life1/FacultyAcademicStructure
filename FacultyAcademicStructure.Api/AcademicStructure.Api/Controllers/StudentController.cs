using AcademicStructure.Application.Features.Students.Commands.CheckoutStudent;
using AcademicStructure.Application.Features.Students.Commands.DeleteStudent;
using AcademicStructure.Application.Features.Students.Commands.UpdateStudent;
using AcademicStructure.Application.Features.Students.Queries.GetTeachersList;
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
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet("{studentName}", Name = "GetStudent")]
        [ProducesResponseType(typeof(IEnumerable<StudentVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<StudentVm>>> GetStudentsByName(string studentName)
        {
            var query = new GetStudentListQuery(studentName);
            var students = await _mediator.Send(query);
            return Ok(students);
        }


        [HttpPost(Name = "Students")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Students ([FromBody] StudentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut(Name = "UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            var command = new DeleteStudentCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
