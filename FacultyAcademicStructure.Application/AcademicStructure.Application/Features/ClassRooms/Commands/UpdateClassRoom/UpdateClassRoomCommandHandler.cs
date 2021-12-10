using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Application.Exceptions;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.ClassRooms.Commands.UpdateClassRoom
{
    public class UpdateClassRoomCommandHandler : IRequestHandler<UpdateClassRoomCommand>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClassRoomCommandHandler> _logger;

        public UpdateClassRoomCommandHandler(IClassRoomRepository classRoomRepository, IMapper mapper, ILogger<UpdateClassRoomCommandHandler> logger)
        {
            _classRoomRepository = classRoomRepository ?? throw new ArgumentNullException(nameof(classRoomRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateClassRoomCommand request, CancellationToken cancellationToken)
        {
            var classRoomToUpdate = await _classRoomRepository.GetByIdAsync(request.Id);
            if (classRoomToUpdate == null)
            {
                throw new NotFoundException(nameof(SchoolClass), request.Id);
            }

            _mapper.Map(request, classRoomToUpdate, typeof(UpdateClassRoomCommand), typeof(SchoolClass));

            await _classRoomRepository.UpdateAsync(classRoomToUpdate);

            _logger.LogInformation($"ClassRoom {classRoomToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
