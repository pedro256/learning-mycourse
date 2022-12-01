using Api.Learning.DataAccess.Context;
using Api.Learning.DataAccess.Entities.Student;
using Api.Learning.DataAccess.Entities.Teacher;
using Api.Learning.DataAccess.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.DataAccess.Repository.Teacher
{
    public class TeacherRepository : GenericRepository<TeacherEntity>, ITeacherRepository
    {
        public TeacherRepository(ApiLearningContext context) : base(context)
        {

        }

        public TeacherEntity createTeacher(TeacherEntity entity)
        {
            _context.TeacherEntity.Add(entity);
            _context.SaveChanges();
            return entity;

        }

        public void deleteTeacher(TeacherEntity entity)
        {
            _context.TeacherEntity.Attach(entity);
            _context.TeacherEntity.Remove(entity);
            _context.SaveChanges();
        }
    }
}
