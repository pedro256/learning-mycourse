using Api.Learning.DataAccess.Repository.Generic;
using Api.Learning.DataAccess.Entities.Student;
using System;
using System.Collections.Generic;
using System.Text;
using Api.Learning.Dtos.Dtos.Student;
using Api.Learning.DataAccess.Context;
using System.Linq;

namespace Api.Learning.DataAccess.Repository.Student
{
    public class StudentRepository : GenericRepository<StudentEntity>, IStudentRepository
    {

        public StudentRepository(ApiLearningContext context):base(context)
        {

        }

        public StudentEntity createStudent(StudentEntity data)
        {
            _context.StudentEntity.Add(data);
            _context.SaveChanges();
            return data;
        }

        public void DeleteStudent(StudentEntity entity)
        {

            _context.StudentEntity.Attach(entity);
            _context.StudentEntity.Remove(entity);
            _context.SaveChanges();

        }

        public bool ExistStudentWithEmail(string email)
        {
           int counter =  _context.StudentEntity.Count(x => x.Email == email);
            if (counter > 0)
            {
                return true;
            }
            return false;
        }
    }
}
