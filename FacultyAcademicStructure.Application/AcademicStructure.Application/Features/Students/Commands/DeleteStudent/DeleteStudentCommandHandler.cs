using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Application.Exceptions;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.Students.Commands.DeleteStudent
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand>
    {

        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteStudentCommandHandler> _logger;

        public DeleteStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, ILogger<DeleteStudentCommandHandler> logger)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToDelete = await _studentRepository.GetByIdAsync(request.Id);
            if (studentToDelete == null)
            {
                throw new NotFoundException(nameof(Student), request.Id);
            }

            await _studentRepository.DeleteAsync(studentToDelete);

            _logger.LogInformation($"Student {studentToDelete.Id} is successfully deleted.");

            return Unit.Value;
        }
    }
}
