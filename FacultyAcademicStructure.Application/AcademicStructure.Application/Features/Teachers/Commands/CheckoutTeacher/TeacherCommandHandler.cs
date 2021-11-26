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

namespace AcademicStructure.Application.Features.Teachers.Commands.CheckoutTeacher
{
    public class TeacherCommandHandler : IRequestHandler<TeacherCommand, int>
    {

        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<TeacherCommandHandler> _logger;

        public TeacherCommandHandler(ITeacherRepository teacherRepository, IMapper mapper, IEmailService emailService, ILogger<TeacherCommandHandler> logger)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<int> Handle(TeacherCommand request, CancellationToken cancellationToken)
        {
            var teacherEntity = _mapper.Map<Teacher>(request);
            var newTeacher = await _teacherRepository.AddAsync(teacherEntity);

            _logger.LogInformation($"Teacher {newTeacher.Id} is successfully created.");

            await SendMail(newTeacher);

            return newTeacher.Id;

        }

        private async Task SendMail(Teacher teacher)
        {
            var email = new Email() { To = "assessment@gmail.com", Body = $"teacher was created.", Subject = "teacher was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Teacher {teacher.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}
