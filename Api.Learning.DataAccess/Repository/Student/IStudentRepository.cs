using Api.Learning.DataAccess.Repository.Generic;
using Api.Learning.DataAccess.Entities.Student;
using System;
using System.Collections.Generic;
using System.Text;
using Api.Learning.Dtos.Dtos.Student;

namespace Api.Learning.DataAccess.Repository.Student
{
    public interface IStudentRepository : IGenericRepository<StudentEntity>
    {
        StudentEntity createStudent(StudentEntity data);

        void DeleteStudent (StudentEntity data);

        bool ExistStudentWithEmail(string email);

        StudentEntity updateStudent(StudentEntity data);

    }
}
