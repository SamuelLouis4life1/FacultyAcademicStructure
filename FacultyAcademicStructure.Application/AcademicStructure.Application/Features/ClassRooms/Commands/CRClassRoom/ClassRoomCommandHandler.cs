using AcademicStructure.Application.Contracts.Infrastructure;
using AcademicStructure.Application.Contracts.Persistence;
using AcademicStructure.Application.Models;
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

namespace AcademicStructure.Application.Features.ClassRooms.Commands.CRClassRoom
{
    public class ClassRoomCommandHandler : IRequestHandler<ClassRoomCommand, Guid>
    {
        private readonly IClassRoomRepository _classRoomRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<ClassRoomCommandHandler> _logger;

        public ClassRoomCommandHandler(IClassRoomRepository classRoomRepository, IMapper mapper, IEmailService emailService, ILogger<ClassRoomCommandHandler> logger)
        {
            _classRoomRepository = classRoomRepository;
            _mapper = mapper;
            _emailService = emailService;
            _logger = logger;
        }

        public async Task<Guid> Handle(ClassRoomCommand request, CancellationToken cancellationToken)
        {
            var classEntity = _mapper.Map<ClassRoom>(request);
            var newclass = await _classRoomRepository.AddAsync(classEntity);

            _logger.LogInformation($"ClassRoom {newclass.Id} is successfully created.");

            await SendMail(newclass);

            return newclass.Id;
        }

        private async Task SendMail(ClassRoom classRoom)
        {
            var email = new Email() { To = "samuel.louis@al.infnet.edu.br", Body = $"classRoom was created.", Subject = "Student was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                _logger.LogError($"ClassRoom {classRoom.Id} failed due to an error with the mail service: {ex.Message}");
            }
        }
    }
}
