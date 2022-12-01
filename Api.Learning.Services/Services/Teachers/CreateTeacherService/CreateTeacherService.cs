using Api.Learning.DataAccess.Entities.Teacher;
using Api.Learning.DataAccess.Repository.Teacher;
using Api.Learning.Dtos.Dtos.Teacher;
using Api.Learning.Utils.Services.Crypto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Teachers.CreateTeacherService
{
    public class CreateTeacherService : ICreateTeacherService
    {
        private readonly ITeacherRepository teacherRepository;
        
        public CreateTeacherService(
            ITeacherRepository _teacherRepository
            )
        {
            teacherRepository = _teacherRepository;
        }
        public CreateTeacherDto execute(CreateTeacherDto dto)
        {
            string hash = CryptService.EncryptToPassword(dto.Password);
            TeacherEntity entity = new TeacherEntity()
            {
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                Email = dto.Email,
                Password =  hash,
                Description = dto.Description,
                BirthDate = dto.BirthDate
            };
            TeacherEntity result = teacherRepository.createTeacher(entity);
            dto.Id = result.Id;
            return dto;
        }
    }
}
