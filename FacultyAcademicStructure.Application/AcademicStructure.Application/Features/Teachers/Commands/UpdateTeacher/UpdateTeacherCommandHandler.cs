using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.Teachers.Commands.UpdateTeacher
{
    public class UpdateTeacherCommandHandler : IRequestHandler<UpdateTeacherCommand>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateTeacherCommandHandler> _logger;

        public UpdateTeacherCommandHandler(ITeacherRepository teacherRepository, IMapper mapper, ILogger<UpdateTeacherCommandHandler> logger)
        {
            _teacherRepository = teacherRepository ?? throw new ArgumentNullException(nameof(teacherRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherToUpdate = await _teacherRepository.GetByIdAsync(request.Id);
            if (teacherToUpdate == null)
            {
                //throw new NotFoundException(nameof(Teacher), request.Id);
            }

            _mapper.Map(request, teacherToUpdate, typeof(UpdateTeacherCommand), typeof(Teacher));

            await _teacherRepository.UpdateAsync(teacherToUpdate);

            _logger.LogInformation($"Teacher {teacherToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
