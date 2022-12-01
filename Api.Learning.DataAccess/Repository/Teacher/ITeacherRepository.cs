using Api.Learning.DataAccess.Entities.Teacher;
using Api.Learning.DataAccess.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Learning.DataAccess.Repository.Teacher
{
    public interface ITeacherRepository : IGenericRepository<TeacherEntity>
    {

        TeacherEntity createTeacher(TeacherEntity entity);

        void deleteTeacher(TeacherEntity entity);
    }
}
