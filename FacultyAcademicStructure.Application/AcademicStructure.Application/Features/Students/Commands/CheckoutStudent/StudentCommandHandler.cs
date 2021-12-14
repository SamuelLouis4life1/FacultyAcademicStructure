using AcademicStructure.Application.Contracts.Infrastructure;
using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Application.Models;
using AcademicStructure.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AcademicStructure.Application.Features.Students.Commands.CheckoutStudent
{
    public class StudentCommandHandler : IRequestHandler<StudentCommand, Guid>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<StudentCommandHandler> _logger;

        public StudentCommandHandler(IStudentRepository studentRepository, IMapper mapper, IEmailService emailService, ILogger<StudentCommandHandler> logger)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(StudentCommand request, CancellationToken cancellationToken)
        {
            var studentEntity = _mapper.Map<Student>(request);
            var newStudent = await _studentRepository.AddAsync(studentEntity);

            _logger.LogInformation($"Student {newStudent.Id} is successfully created.");

            await SendMail(newStudent);

            return newStudent.Id;
        }

        private async Task SendMail(Student student)
        {
            var email = new Email() { To = "assessment@gmail.com", Body = $"Student was created.", Subject = "Student was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Student {student.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}
