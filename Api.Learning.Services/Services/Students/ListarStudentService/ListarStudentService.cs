using Api.Learning.DataAccess.Repository.Student;
using Api.Learning.Dtos.Dtos.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Learning.Services.Services.Students.ListarStudentService
{
    public class ListarStudentService : IListarStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public ListarStudentService(
            IStudentRepository studentRepository
            )
        {
            _studentRepository = studentRepository;
        }
        public List<StudentDto> execute()
        {
            var result = _studentRepository.GetAll();
            var students = result.Select(x => new StudentDto
            {
                Id = x.Id,
                Description = x.Description,
                Email = x.Email,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                BirthDate = x.BirthDate
            }).ToList();


            return students;

        }
    }
}
