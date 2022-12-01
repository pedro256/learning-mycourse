using Api.Learning.DataAccess.Entities.Student;
using Api.Learning.DataAccess.Repository.Student;
using Api.Learning.Dtos.Dtos.Student;
using Api.Learning.Utils.Exceptions;
using Api.Learning.Utils.Services.Crypto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Students.CreateStudentService
{
    public class CreateStudentServices : ICreateStudentServices
    {
        private readonly IStudentRepository _studentRepository;

        public CreateStudentServices(
            IStudentRepository studentRepository
            )
        {
            _studentRepository = studentRepository;
        }

        public CreateStudentDto execute(CreateStudentDto student)
        {
            string hash = CryptService.EncryptToPassword(student.Password);
            bool exitsEmail = _studentRepository.ExistStudentWithEmail(student.Email);

            if (exitsEmail)
            {
                throw new BadRequestException("Email já registrado !");
            }

            StudentEntity result = _studentRepository.createStudent(new StudentEntity
            {
                FirstName = student.FirstName,
                SecondName = student.SecondName,
                Email = student.Email,
                Password = hash,
                Description = student.Description,
                BirthDate = student.BirthDate
            });
            student.Id = result.Id;
            return student;
        }
    }
}
