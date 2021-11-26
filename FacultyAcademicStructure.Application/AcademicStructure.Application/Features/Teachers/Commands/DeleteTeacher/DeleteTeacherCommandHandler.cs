using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.Teachers.Commands.DeleteTeacher
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteTeacherCommandHandler> _logger;

        public DeleteTeacherCommandHandler(ITeacherRepository teacherRepository, IMapper mapper, ILogger<DeleteTeacherCommandHandler> logger)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherToDelete = await _teacherRepository.GetByIdAsync(request.Id);
            if (teacherToDelete == null)
            {
                throw new NotFoundException(nameof(Teacher), request.Id);
            }

            await _teacherRepository.DeleteAsync(teacherToDelete);

            _logger.LogInformation($"Teacher {teacherToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
