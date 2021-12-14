using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Application.Exceptions;
using AcademicStructure.Application.Features.Students.Commands.DeleteStudent;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.ClassRooms.Commands.DeleteClassRoom
{
    public class DeleteClassRoomCommandHandler : IRequestHandler<DeleteClassRoomCommand>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteClassRoomCommandHandler> _logger;

        public DeleteClassRoomCommandHandler(IClassRoomRepository classRoomRepository, IMapper mapper, ILogger<DeleteClassRoomCommandHandler> logger)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteClassRoomCommand request, CancellationToken cancellationToken)
        {
            var studentToDelete = await _classRoomRepository.GetByIdAsync(request.Id);
            if (studentToDelete == null)
            {
                throw new NotFoundException(nameof(ClassRoom), request.Id);
            }

            await _classRoomRepository.DeleteAsync(studentToDelete);

            _logger.LogInformation($"ClassRoom {studentToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
