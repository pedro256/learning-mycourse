using Api.Learning.DataAccess.Repository.Student;
using Api.Learning.Services.Services.Students.ShowStudentService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.Services.Services.Students.DeleteStudentService
{
    public class DeleteStudentService : IDeleteStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public DeleteStudentService(
            IStudentRepository studentRepository
            )
        {
            _studentRepository = studentRepository;
        }

        public int execute(int Id)
        {
            var result = _studentRepository.GetById(Id);
            if (result==null)
            {
                return 0;
            }
            _studentRepository.DeleteById(result);
            return Id;
        }
    }
}
