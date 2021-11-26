using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.Students.Commands.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateStudentCommandHandler> _logger;

        public UpdateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, ILogger<UpdateStudentCommandHandler> logger)
        {
            _studentRepository = studentRepository ?? throw new ArgumentNullException(nameof(studentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Unit> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var studentToUpdate = await _studentRepository.GetByIdAsync(request.Id);
            if (studentToUpdate == null)
            {
               // throw new NotFoundException(nameof(Student), request.Id);
            }

            _mapper.Map(request, studentToUpdate, typeof(UpdateStudentCommand), typeof(Student));

            await _studentRepository.UpdateAsync(studentToUpdate);

            _logger.LogInformation($"Student {studentToUpdate.Id} is successfully updated.");

            return Unit.Value;
        }
    }
}
