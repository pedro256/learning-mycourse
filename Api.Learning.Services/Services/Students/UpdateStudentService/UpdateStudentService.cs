using Api.Learning.DataAccess.Entities.Student;
using Api.Learning.DataAccess.Repository.Student;
using Api.Learning.Dtos.Dtos.Student;
using Api.Learning.Utils.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Students.UpdateStudentService
{
    public class UpdateStudentService : IUpdateStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public UpdateStudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public StudentDto execute(UpdateStudentDto studentDto)
        {
            StudentEntity student = _studentRepository.GetById((int)studentDto.Id);
            if(student == null)
            {
                throw new BadRequestException("Estudante não encontrado.");
            }

            if(studentDto.FirstName != student.FirstName && studentDto.FirstName != null) { 
                student.FirstName = studentDto.FirstName; 
            }

            if (studentDto.SecondName != student.SecondName && studentDto.SecondName != null)
            {
                student.SecondName = studentDto.SecondName;
            }

            if (studentDto.Email != student.Email && studentDto.Email != null)
            {
                bool exitsEmail = _studentRepository.ExistStudentWithEmail(studentDto.Email);

                if (exitsEmail)
                {
                    throw new BadRequestException("Email já registrado !");
                }
                student.Email = studentDto.Email;
            }

            if (studentDto.Description != student.Description && studentDto.Description != null)
            {
                student.Description = studentDto.Description;
            }

            if (studentDto.BirthDate != student.BirthDate && studentDto.BirthDate != null)
            {
                student.BirthDate =(DateTime) studentDto.BirthDate;
            }

            _studentRepository.updateStudent(student);
            return new StudentDto
            {
                Id = student.Id
            };
        }
    }
}
