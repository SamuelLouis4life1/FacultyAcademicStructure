using AcademicStructure.Application.Features.ClassRooms.Commands.CRClassRoom;
using AcademicStructure.Application.Features.ClassRooms.Commands.DeleteClassRoom;
using AcademicStructure.Application.Features.ClassRooms.Commands.UpdateClassRoom;
using AcademicStructure.Application.Features.ClassRooms.Queries.GetClassRoomList;
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
    public class ClassRoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClassRoomController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }


        [HttpGet("{classRoomName}", Name = "GetClassRoom")]
        [ProducesResponseType(typeof(IEnumerable<ClassRoomVm>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClassRoomVm>>> GetClassRoomByName(string classRoomName)
        {
            var query = new GetStudentListQuery(classRoomName);
            var classRooms = await _mediator.Send(query);
            return Ok(classRooms);
        }


        [HttpPost(Name = "Class Rooms")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> ClassRooms ([FromBody] ClassRoomCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut(Name = "UpdateClassRoom")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateClassRoom([FromBody] UpdateClassRoomCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }


        [HttpDelete("{id}", Name = "Delete Class Room")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteClassRoom(Guid id)
        {
            var command = new DeleteClassRoomCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }

    }
}
